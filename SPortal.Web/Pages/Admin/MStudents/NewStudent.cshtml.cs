using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sportal.Models;
using Sportal.Services;

namespace SPortal.Web.Pages.Admin.MStudents
{
    public class NewStudentModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHostingEnvironment _hostingEnvironment;
        public NewStudentModel(IUnitOfWork unitOfWork, IHostingEnvironment hostingEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostingEnvironment = hostingEnvironment;
        }


        [BindProperty]
        public IFormFile Image { set; get; }

        [BindProperty]
        public List<SelectListItem> DClassess { get; set; }

     
        public List<SelectListItem> Sections { get; set; }

        [BindProperty]
        public Student Student { get; set; }

        //[BindProperty]
        //public Parent Parent { get; set; }

        public IActionResult OnGet()
        {
            DClassess = _unitOfWork.GetRepositoryInstance<dClass>().FindAll()
                .Select(a => 
                            new SelectListItem
                            {
                                Value = a.dClassID.ToString(),
                                Text = a.ClassName
                            })
                .ToList();



            // .ToList();

            return Page();
        }

       
        public async Task<IActionResult> OnPostAsync()
        {

            var imgPath = GetImageFileName();

            if (!ModelState.IsValid || imgPath == null)
            {
                DClassess = _unitOfWork.GetRepositoryInstance<dClass>().FindAll()
                .Select(a => 
                            new SelectListItem
                            {
                                Value = a.dClassID.ToString(),
                                Text = a.ClassName
                            })
                .ToList();

                return Page();
            }

           // Student.OtherNames = MiddleName + Surname;

            Student.Image = imgPath;
           

            _unitOfWork.GetRepositoryInstance<Student>().Add(Student);
            await _unitOfWork.SaveAsync();

            return RedirectToPage("./Index");
        }


        string GetImageFileName()
        {
            if (Image != null)
            {
                var fileName = Image.FileName;
                var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
                var filePath = Path.Combine(uploads, fileName);
                Image.CopyTo(new FileStream(filePath, FileMode.Create));


                return fileName;
            }

            return null;
        }
       
    }

}