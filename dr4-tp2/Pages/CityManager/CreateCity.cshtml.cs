using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace dr4_tp2.Pages.CityManager
{
    public class CreateCityModel : PageModel
    {
        [BindProperty] public string CityName { get; set; } = string.Empty;

        public bool IsSubmitted { get; private set; }

        public void OnGet()
        {
            IsSubmitted = false;
        }

        public IActionResult OnPost()
        {
            IsSubmitted = true;

            return Page();
        }
    }
}