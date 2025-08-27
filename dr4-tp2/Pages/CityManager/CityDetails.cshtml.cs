using Microsoft.AspNetCore.Mvc.RazorPages;

namespace dr4_tp2.Pages.CityManager
{
    public class CityDetailsModel : PageModel
    {
        public string CityName { get; set; } = string.Empty;

        public void OnGet(string cityName)
        {
            CityName = cityName ?? string.Empty;
        }
    }
}