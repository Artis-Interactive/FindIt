using findit_backend.Handlers;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace findit_backend.Handlers
{
    public class ImageHandler
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

        public void saveProductImage(string productId, [FromForm] IFormFile image)
        {
            string uniqueProductImageName = productId + image.FileName;
            var savePath = Path.Combine(Directory.GetCurrentDirectory(), "Assets", "ProductImages", uniqueProductImageName);

            Directory.CreateDirectory(Path.GetDirectoryName(savePath));

            using (var stream = new FileStream(savePath, FileMode.Create))
            {
                image.CopyToAsync(stream);
            }
        }
  }
}