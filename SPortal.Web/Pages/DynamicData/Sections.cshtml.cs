using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sportal.Models;
using Sportal.Services;

namespace SPortal.Web.Pages.DynamicData
{
    
    public class SectionsModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public SectionsModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public JsonResult OnGet(string id)
        {
            var gid = new Guid(id);
           return new JsonResult(_unitOfWork.GetRepositoryInstance<Section>().FindByCondition(x => x.dClassID == gid).Select(x => new { value = x.SectionID, name = x.SectionName }));
        }
    }
}