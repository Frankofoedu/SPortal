using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sportal.Models;
using Sportal.Services;

namespace SPortal.Web.Pages.Admin.MStudents
{
    public class NewStudentModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public NewStudentModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult OnGet()
        {
            return Page();
        }


        [BindProperty]
        public Student Student { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _unitOfWork.GetRepositoryInstance<Student>().Add(Student);
            await _unitOfWork.SaveAsync();

            return RedirectToPage("./Index");
        }
    }
}