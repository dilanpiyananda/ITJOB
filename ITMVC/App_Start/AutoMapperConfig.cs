
using AutoMapper;
using ITDB.Domain;
using ITDB.Domain.Job;
using ITMVC.Models.EmailVM;
using ITMVC.Models.JOBVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITMVC.App_Start
{
    public class AutoMapperConfig
    {
        /// <summary>
        /// Configures AutoMapper - https://github.com/AutoMapper/AutoMapper/wiki/Static-and-Instance-API
        /// </summary>
        public static void Register()
        {
            Mapper.Initialize(config =>
            {
                config.CreateMap<AcceptEmail, EmailMM>();
                config.CreateMap<JobMain, JobMM>();
            });
        }
    }
}