using System;
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
        [HttpGet]
        public object Get()
        {
            using (BusinessContext context = new BusinessContext())
            {
                var files = context.Files
                    .Select(f => new
                    {
                        Id = f.Id,
                        Name = f.Name,
                        FolderId = f.FolderId
                    })
                    .ToList();

                return files;
            }
        }
    }
}