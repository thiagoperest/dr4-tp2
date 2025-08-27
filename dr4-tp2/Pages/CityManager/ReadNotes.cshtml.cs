using Microsoft.AspNetCore.Mvc.RazorPages;

namespace dr4_tp2.Pages.CityManager
{
    public class ReadNotesModel : PageModel
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public List<string> FileNames { get; set; } = new List<string>();
        public string? SelectedFileName { get; set; }
        public string? FileContent { get; set; }

        public ReadNotesModel(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public void OnGet(string? fileName = null)
        {
            var filesDirectory = Path.Combine(_webHostEnvironment.WebRootPath, "files");
            
            if (Directory.Exists(filesDirectory))
            {
                FileNames = Directory.GetFiles(filesDirectory, "*.txt")
                    .Select(Path.GetFileName)
                    .Where(name => !string.IsNullOrEmpty(name))
                    .Cast<string>()
                    .OrderByDescending(name => name)
                    .ToList();
            }

            if (!string.IsNullOrEmpty(fileName) && FileNames.Contains(fileName))
            {
                SelectedFileName = fileName;
                var filePath = Path.Combine(filesDirectory, fileName);
                FileContent = System.IO.File.ReadAllText(filePath);
            }
        }
    }
}