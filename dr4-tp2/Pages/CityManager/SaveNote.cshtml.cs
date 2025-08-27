using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace dr4_tp2.Pages.CityManager
{
    public class SaveNoteModel : PageModel
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        [BindProperty]
        public InputModel Input { get; set; } = new InputModel();

        public string? FileName { get; set; }
        public string? DownloadUrl { get; set; }
        public bool IsSubmitted { get; private set; }

        public SaveNoteModel(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public void OnGet()
        {
            IsSubmitted = false;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var filesDirectory = Path.Combine(_webHostEnvironment.WebRootPath, "files");
            if (!Directory.Exists(filesDirectory))
            {
                Directory.CreateDirectory(filesDirectory);
            }

            var timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            FileName = $"note-{timestamp}.txt";
            var filePath = Path.Combine(filesDirectory, FileName);

            await System.IO.File.WriteAllTextAsync(filePath, Input.Content);

            DownloadUrl = $"/files/{FileName}";
            IsSubmitted = true;

            return Page();
        }

        public class InputModel
        {
            [Required(ErrorMessage = "O conteúdo do documento é obrigatório.")]
            [Display(Name = "Conteúdo")]
            public string Content { get; set; } = string.Empty;
        }
    }
}