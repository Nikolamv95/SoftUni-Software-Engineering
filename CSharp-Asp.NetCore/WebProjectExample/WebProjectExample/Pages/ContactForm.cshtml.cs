using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebProjectExample.Pages
{
    public class ContactFormModel : PageModel
    {
        [Required]
        [BindProperty]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [BindProperty]
        [MinLength(3)]
        public string Name { get; set; }

        [Required]
        [BindProperty]
        public string Title { get; set; }

        [Required]
        [BindProperty]
        [MinLength(10)]
        public string Description { get; set; }

        public string InfoMessage { get; set; }

        public void OnGet()
        {

        }

        public void OnPost()
        {
            if (this.ModelState.IsValid)
            {

                this.InfoMessage = "Thank you for submitting the contact form!";
                //TODO: Send email
                //TODO: Save to Db 
            }
        }
    }
}
