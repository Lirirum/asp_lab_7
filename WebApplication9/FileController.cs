using Microsoft.AspNetCore.Mvc;


namespace WebApplication9
{
    public class FileController : Controller
    {
        public IActionResult DownloadFile()
        {
            return View("./Views/FileView.cshtml");
        }

        [HttpPost]
        public IActionResult Download(string firstName, string lastName, string fileName)
        {
            string fileContent = $"Ім'я: {firstName}, Прізвище: {lastName}";
            string filesDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Files");

            // Перевірка, що папка існує
            if (!Directory.Exists(filesDirectory))
            {
                Directory.CreateDirectory(filesDirectory);
            }

      
            string filePath = Path.Combine(filesDirectory, fileName + ".txt");
            string fileType = "text/plain";

            System.IO.File.WriteAllText(filePath, fileContent);

           
            return File(System.IO.File.ReadAllBytes(filePath), fileType, fileName + ".txt");
        }
    }
}
