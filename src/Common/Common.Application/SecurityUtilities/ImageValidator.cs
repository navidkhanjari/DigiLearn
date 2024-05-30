using Common.Application.FileUtilities;
using Microsoft.AspNetCore.Http;

namespace Common.Application.SecurityUtilities
{
    public static class ImageValidator
    {
        public static bool IsImage(this IFormFile file)
        {
            if (file == null)
            {
                return false;
            }

            return FileValidation.IsValidImageFile(file.Name);
        }
    }
}
