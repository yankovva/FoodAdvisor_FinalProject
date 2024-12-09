using FoodAdvisor.Data.Services.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace FoodAdvisor.Data.Services
{
	public class FileService : IFileService
	{
		private readonly IWebHostEnvironment _environment;

		public FileService(IWebHostEnvironment environment)
		{
			_environment = environment;
		}

		public async Task<string> UploadFileAsync(IFormFile file, string folderName, string uniqueFileName)
		{
			if (file == null || file.Length == 0)
				throw new ArgumentException("The File is empty or missing!");

			string uploadFolder = Path.Combine(_environment.WebRootPath, folderName);
			if (!Directory.Exists(uploadFolder))
				Directory.CreateDirectory(uploadFolder);

			string filePath = Path.Combine(uploadFolder, uniqueFileName);

			using (var stream = new FileStream(filePath, FileMode.Create))
			{
				await file.CopyToAsync(stream);
			}

			return Path.Combine(folderName, uniqueFileName);
		}

		public void DeleteFile(string relativeFilePath)
		{
			if (string.IsNullOrEmpty(relativeFilePath))
				return;

			string fullPath = Path.Combine(_environment.WebRootPath, relativeFilePath);
			if (File.Exists(fullPath))
				File.Delete(fullPath);
		}

		public bool IsFileValid(IFormFile file, string[] allowedExtensions, long maxSize)
		{
			if (file == null || file.Length == 0)
				return false;

			string fileExtension = Path.GetExtension(file.FileName).ToLower();
			if (!Array.Exists(allowedExtensions, ext => ext == fileExtension))
				return false;

			return file.Length <= maxSize;
		}
	}
}
