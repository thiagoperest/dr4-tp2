using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace dr4_tp2.Pages.CityManager
{
    public class CreateCountryModel : PageModel
    {
        [BindProperty]
        public InputModel Input { get; set; } = new InputModel();
        
        public Country? Country { get; set; }
        public bool IsSubmitted { get; private set; }

        public void OnGet()
        {
            IsSubmitted = false;
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                var firstLetterName = char.ToUpper(Input.CountryName[0]);
                var firstLetterCode = char.ToUpper(Input.CountryCode[0]);

                if (firstLetterName != firstLetterCode)
                {
                    ModelState.AddModelError("Input.CountryCode", 
                        "O código do país deve começar com a mesma letra do nome do país.");
                    return Page();
                }
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            Country = new Country
            {
                CountryName = Input.CountryName,
                CountryCode = Input.CountryCode
            };
            
            IsSubmitted = true;
            return Page();
        }

        public class InputModel
        {
            [Required(ErrorMessage = "O nome do país é obrigatório.")]
            public string CountryName { get; set; } = string.Empty;
            
            [Required(ErrorMessage = "O código do país é obrigatório.")]
            [StringLength(2, MinimumLength = 2, ErrorMessage = "O código do país deve ter exatamente 2 caracteres.")]
            public string CountryCode { get; set; } = string.Empty;
        }
    }

    public class Country
    {
        public string CountryName { get; set; } = string.Empty;
        public string CountryCode { get; set; } = string.Empty;
    }
}