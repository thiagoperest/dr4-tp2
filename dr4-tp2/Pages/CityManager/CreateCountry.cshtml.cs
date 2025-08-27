using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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
            public string CountryName { get; set; } = string.Empty;
            public string CountryCode { get; set; } = string.Empty;
        }
    }

    public class Country
    {
        public string CountryName { get; set; } = string.Empty;
        public string CountryCode { get; set; } = string.Empty;
    }
}