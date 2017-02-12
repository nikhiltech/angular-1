﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Entity.Context;
using Entity.Model;

namespace WebApi.Controllers
{
    public class FilesController : ApiController
    {
        [HttpPost]
        public object Get(GetParams @params)
        {
            using (BusinessContext context = new BusinessContext())
            {
                var files = context.Files
                    .OrderBy(f=>f.Id)
                    .Skip(@params.Skip)
                    .Take(@params.Top)
                    .Select(f => new
                    {
                        Id = f.Id,
                        Name = f.Name,
                        FolderId = f.FolderId,
                        Extension = f.Extension
                    })
                    .ToList();

                var total = context.Files.Count();

                return new
                {
                    Values = files,
                    Total = total
                };
            }
        }
    }

    public class GetParams
    {
        public int Skip { get; set; }
        public int Top { get; set; }
    }
}