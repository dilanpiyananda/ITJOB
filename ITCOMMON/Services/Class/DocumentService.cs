using ITCOMMON.ServiceOfHelper;
using ITCOMMON.Services.Interface;
using ITDB.Domain.Document;
using ITDB.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;

namespace ITCOMMON.Services.Class
{
    public class DocumentService: IDocumentService
    {
        private IDocumentDbService _docDbService = new DocumentDbService();
        private IGlobleNoteService _globleService = new GlobleNoteService();
        /// <summary>
        /// Upload Images
        /// </summary>
        /// <returns></returns>
        public string UploadImage(HttpPostedFileBase file, Section section,string userId,long parentId)
        {
            
            string rootpath = ServiceHelper.ServerPath(section, userId, out string SubPath, out string virtualpathname);

            string error = null;
            error = makePath(rootpath);
            if (error != null)
            {
                return error;
            }

            error = makePath(SubPath);
            if (error != null)
            {
                return error;
            }

            //-------------------virtual path-----------------------------
            string originalVirtualPath = virtualpathname + ServiceHelper.FileName(section, FileType._Original) + System.IO.Path.GetExtension(file.FileName);
            string medeumVirtualPath = virtualpathname + ServiceHelper.FileName(section, FileType._Medium) + System.IO.Path.GetExtension(file.FileName);
            string lowVirtualPath = virtualpathname + ServiceHelper.FileName(section, FileType._Low) + System.IO.Path.GetExtension(file.FileName);
            //-------------------virtual path-----------------------------

            List<DocumentImageList> imagelist = new List<DocumentImageList>();


            //original image save
            string originalpath = imageSave(file, SubPath, ServiceHelper.FileName(section, FileType._Original));
            DocumentImageList or_imageList = new DocumentImageList()
            {
                fileType = FileType._Original,
                path = originalVirtualPath,
            };
            imagelist.Add(or_imageList);


            //mediumImageSave
            string mediumpath = imageSave(file, SubPath, ServiceHelper.FileName(section, FileType._Medium));
            SaveByte(mediumpath, FileType._Medium);
            DocumentImageList me_imageList = new DocumentImageList()
            {
                fileType = FileType._Medium,
                path = medeumVirtualPath,
            };
            imagelist.Add(me_imageList);


            //lowResolutionImage
            string lowpath = imageSave(file, SubPath, ServiceHelper.FileName(section, FileType._Low));
            SaveByte(lowpath, FileType._Low);
            DocumentImageList lo_imageList = new DocumentImageList()
            {
                fileType = FileType._Low,
                path = lowVirtualPath,
            };
            imagelist.Add(lo_imageList);

            //save document
            var docarray = _docDbService.SaveDocument(imagelist, userId, out string errordoc);
            if (errordoc != null)
                return errordoc;

            string errorGloble = _globleService.SaveGlobleNote(section,docarray, userId, parentId);
            return errorGloble;
        }

        private string makePath(string root)
        {
            try
            {
                // If directory does not exist, create it. 
                if (!Directory.Exists(root))
                {
                    Directory.CreateDirectory(root);
                }
                return null;
            }
            catch(Exception ex)
            {
                return ex.Message.ToString();
            }  
        }

        private string imageSave(HttpPostedFileBase ImgStr,string folderPath,string imageName)
        {
            string extention=System.IO.Path.GetExtension(ImgStr.FileName);
            imageName = imageName + extention;

            var filename = Path.GetFileName(imageName);
            var path = Path.Combine(folderPath, filename);
            ImgStr.SaveAs(path);
            return path;
        }
        
        private void SaveByte(string imagePath,FileType fileType)
        {
            if (imagePath != null )
            {
                Size sizes = new Size();
                int jpgQuality = 75;

                //string path = HttpContext.Current.Server.MapPath(imagePath);
                byte[] photo = File.ReadAllBytes(imagePath);
                if(fileType == FileType._Medium)
                {
                    sizes.Width = 150;
                    sizes.Height = 150;
                    jpgQuality = 20;

                }
                else if(fileType == FileType._Low)
                {
                    sizes.Width = 50;
                    sizes.Height = 50;
                    jpgQuality = 10;
                }
                byte[] convertedByte = ImageHelper.Resize(photo, sizes, out string error, jpgQuality);
                using (Stream file = File.OpenWrite(imagePath))
                {
                    file.Write(convertedByte, 0, convertedByte.Length);
                }
            }
        }
        
    }
}