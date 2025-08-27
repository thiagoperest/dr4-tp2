using Microsoft.AspNetCore.Mvc.RazorPages;

namespace dr4_tp2.Pages.CityManager
{
    public class CityListModel : PageModel
    {
        public List<string> Cities { get; set; } = new List<string>();

        public void OnGet()
        {
            Cities = new List<string> { "Rio", "Recife", "Bahia" };
        }
    }
}