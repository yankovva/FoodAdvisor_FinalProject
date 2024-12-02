using Microsoft.AspNetCore.Http;

namespace FoodAdvisor.Data.Services.Interfaces
{
	public interface IFileService
	{
		Task<string> UploadFileAsync(IFormFile file, string folderName, string uniqueFileName);
		void DeleteFile(string relativeFilePath);
		bool IsFileValid(IFormFile file, string[] allowedExtensions, long maxSize);
	}
}
