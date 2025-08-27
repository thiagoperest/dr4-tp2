using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace dr4_tp2.Pages.CityManager
{
    public class CreateMultipleCountriesModel : PageModel
    {
        [BindProperty] public List<InputModel> Countries { get; set; } = new List<InputModel>();

        public List<CountryMultiple> SubmittedCountries { get; set; } = new List<CountryMultiple>();
        public bool IsSubmitted { get; private set; }

        public void OnGet()
        {
            IsSubmitted = false;

            Countries = new List<InputModel>();
            for (int i = 0; i < 5; i++)
            {
                Countries.Add(new InputModel());
            }
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            SubmittedCountries = Countries
                .Where(c => !string.IsNullOrEmpty(c.CountryName) && !string.IsNullOrEmpty(c.CountryCode))
                .Select(c => new CountryMultiple
                {
                    CountryName = c.CountryName,
                    CountryCode = c.CountryCode
                })
                .ToList();

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

    public class CountryMultiple
    {
        public string CountryName { get; set; } = string.Empty;
        public string CountryCode { get; set; } = string.Empty;
    }
}