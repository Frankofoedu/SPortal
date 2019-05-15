using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Sportal.Models;
using Sportal.Services;
using SPortal.Data;

namespace SPortal.Web.Pages.Admin.MStudents
{
    [Authorize(Roles = "PortalAdministrators")]
    public class IndexModel : DI_BasePageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public IList<Sportal.Models.Student> Students { get; private set; }

        public IndexModel(ApplicationDbContext context,
            IAuthorizationService authorizationService, IUnitOfWork unitOfWork,
            UserManager<AppUser> userManager)
            : base(context, authorizationService, userManager)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task OnGetAsync()
        {
            Students = await _unitOfWork.GetRepositoryInstance<Student>().FindAll().ToListAsync();
            
        }


    }
}