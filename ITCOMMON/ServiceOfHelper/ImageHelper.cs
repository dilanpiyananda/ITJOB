using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace ITCOMMON.ServiceOfHelper
{
    public static class ImageHelper
    {
        public static byte[] Resize(byte[] imageContent, Size size, out string error, int jpgQuality = 75)
        {
            try
            {
                // load the image
                NetVips.Image image = NetVips.Image.NewFromBuffer(imageContent).ThumbnailImage(size.Width, size.Height);
                error = null;

                return image.JpegsaveBuffer(q: jpgQuality);

            }
            catch (Exception e)
            {
                error = e.Message;
                return null;
            }
        }
    }
}