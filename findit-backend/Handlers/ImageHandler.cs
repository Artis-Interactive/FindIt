using findit_backend.Handlers;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace findit_backend.Handlers
{
    public class ImageHandler : ControllerBase
    {
        private readonly string[] permittedExtensions = { ".jpg", ".jpeg", ".png"};
        
        public string isImageValid([FromForm] IFormFile image)
        {
          if (image == null || image.Length == 0)
            {
                return "No image was uploaded.";
            }

            if (!image.ContentType.StartsWith("image/"))
            {
                return "The file is not a valid image.";
            }

            var extension = Path.GetExtension(image.FileName).ToLowerInvariant();
            if (string.IsNullOrEmpty(extension) || !permittedExtensions.Contains(extension))
            {
                return "Invalid image format. Only .jpg, .jpeg, .png files are allowed.";
            }
            return null;
        }

        public async Task saveProductImage(string productId, IFormFile image)
        {
            var extension = Path.GetExtension(image.FileName);
            var savePath = Path.Combine(Directory.GetCurrentDirectory(), "Assets", "ProductImages", productId + extension);

            Directory.CreateDirectory(Path.GetDirectoryName(savePath));

            using (var stream = new FileStream(savePath, FileMode.Create))
            {
                await image.CopyToAsync(stream); // Await the asynchronous operation
            }
        }


        public IActionResult loadProductImage(string productId)
        {

            productId = productId.ToLowerInvariant();
            var imageDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Assets", "ProductImages");
            var imageFile = Directory.GetFiles(imageDirectory).FirstOrDefault(file => Path.GetFileNameWithoutExtension(file) == productId);
            if (imageFile == null)
            {
                return NotFound();
            }
            var extension = Path.GetExtension(imageFile).ToLowerInvariant();
            var extensionType = getExtensionType(extension);

            // Return the file
            byte[] fileBytes = System.IO.File.ReadAllBytes(imageFile);
            return File(fileBytes, extensionType);
        }


        public string getExtensionType(string extension)
        {
            return extension == ".png" ? "image/png" : "image/jpeg";
        }
    }
}