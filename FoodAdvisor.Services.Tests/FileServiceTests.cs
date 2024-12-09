using FoodAdvisor.Data.Services;
using FoodAdvisor.Data.Services.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Moq;

using static FoodAdvisor.Common.ErrorMessages;
namespace FoodAdvisor.Services.Tests
{
	[TestFixture]
	public class FileServiceTests
	{
		private Mock<IWebHostEnvironment> environment;
		[SetUp]
		public void Setup()
		{
			this.environment = new Mock<IWebHostEnvironment>();
		}
		[Test]
		public void UploadFileAsync_ShouldThrowArgumentException_WhenFileIsNullOrEmpty()
		{
			IFormFile file = null;
			string folderName = "uploads";
			string uniqueFileName = "testfile.txt";

			IFileService fileService = new FileService(environment.Object);
			var ex = Assert.ThrowsAsync<ArgumentException>(async () =>
				await fileService.UploadFileAsync(file, folderName, uniqueFileName));
			Assert.That(ex.Message, Is.EqualTo(MissingFileErrorMessage));
		}
		[Test]
		public void UploadFileAsync_ShouldThrowArgumentException_WhenFileIsNull()
		{
			IFormFile file = null;
			string folderName = "uploads";
			string uniqueFileName = "testfile.txt";

			IFileService fileService = new FileService(environment.Object);

			Assert.ThrowsAsync<ArgumentException>(async () => await fileService.UploadFileAsync(file, folderName, uniqueFileName));
		}
		[Test]
		public void DeleteFile_ShouldDeleteFile_WhenFileExists()
		{
			string relativeFilePath = "uploads/testfile.txt";
			var fullPath = Path.Combine("C:/wwwroot", relativeFilePath);

			environment.Setup(e => e.WebRootPath).Returns("C:/wwwroot");

			Directory.CreateDirectory(Path.GetDirectoryName(fullPath));
			File.WriteAllText(fullPath, "Test content");

			IFileService fileService = new FileService(environment.Object);

			fileService.DeleteFile(relativeFilePath);

			Assert.IsFalse(File.Exists(fullPath));
		}
		[Test]
		public void IsFileValid_ShouldReturnTrue_WhenFileIsValid()
		{
			var file = new Mock<IFormFile>();
			var allowedExtensions = new[] { ".jpg", ".png" };
			int maxSize = 5 * 1024 * 1024;

			file.Setup(f => f.FileName).Returns("image.jpg");
			file.Setup(f => f.Length).Returns(1024 * 1024); // 1 MB

			IFileService fileService = new FileService(environment.Object);
			var result = fileService.IsFileValid(file.Object, allowedExtensions, maxSize);

			Assert.IsTrue(result);
		}
		[Test]
		public void IsFileValid_ShouldReturnFalse_WhenFileIsTooLarge()
		{
			var file = new Mock<IFormFile>();
			var allowedExtensions = new[] { ".jpg", ".png" };
			int maxSize = 5 * 1024 * 1024; 

			file.Setup(f => f.FileName).Returns("image.jpg");
			file.Setup(f => f.Length).Returns(10 * 1024 * 1024); // 10 MB

			IFileService fileService = new FileService(environment.Object);
			var result = fileService.IsFileValid(file.Object, allowedExtensions, maxSize);

			Assert.IsFalse(result);
		}
		[Test]
		public void IsFileValid_ShouldReturnFalse_WhenFileExtensionIsNotAllowed()
		{
			var file = new Mock<IFormFile>();
			var allowedExtensions = new[] { ".jpg", ".png" };
			int maxSize = 5 * 1024 * 1024;

			file.Setup(f => f.FileName).Returns("document.pdf");
			file.Setup(f => f.Length).Returns(1024 * 1024); // 1 MB

			IFileService fileService = new FileService(environment.Object);
			var result = fileService.IsFileValid(file.Object, allowedExtensions, maxSize);

			Assert.IsFalse(result);
		}
	}
}