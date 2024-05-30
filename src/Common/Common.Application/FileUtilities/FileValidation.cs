using Microsoft.AspNetCore.Http;


namespace Common.Application.FileUtilities
{
    public static class FileValidation
    {
        public static bool IsValidFile(this IFormFile file)
        {
            if (file == null) return false;

            var extension = Path.GetExtension(file.FileName);

            extension = extension.ToLower();

            if (extension == ".mp4" || extension == ".mp3" || extension == ".zip" ||
                extension == ".rar" || extension == ".wav" || extension == ".docx" ||
                extension == ".mmf" || extension == ".m4a" || extension == ".ogg" ||
                extension == ".doc" || extension == ".pdf" || extension == ".txt" ||
                extension == ".xls" || extension == ".xla" || extension == ".xlsx" ||
                extension == ".ppt" || extension == ".pptx" || extension == ".gif" ||
                extension == ".jpg" || extension == ".png" || extension == ".tif" || extension == ".wmv" ||
                extension == ".bmp" || extension == ".wmf" || extension == ".gif" || extension == ".log")
            {
                return true;
            }

            return false;
        }
        public static bool IsValidCompressFile(this IFormFile file)
        {
            if (file == null) return false;

            var extension = Path.GetExtension(file.FileName);

            extension = extension.ToLower();

            if (extension == ".zip" || extension == ".rar")
            {
                return true;
            }

            return false;
        }

        public static bool IsValidMp4File(this IFormFile file)
        {
            if (file == null) return false;

            var extension = Path.GetExtension(file.FileName);

            extension = extension.ToLower();

            if (extension == ".mp4")
            {
                return true;
            }

            return false;
        }

        public static bool IsValidImageFile(string fileName)
        {
            if (string.IsNullOrEmpty(fileName)) return false;

            var extension = Path.GetExtension(fileName);

            extension = extension.ToLower();

            if (extension == ".jpg" || extension == ".png" || extension == ".bmp" || extension == ".svg" || extension == ".jpeg" || extension == ".webp")
            {
                return true;
            }

            return false;
        }
    }
}
