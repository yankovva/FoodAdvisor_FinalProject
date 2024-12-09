using FoodAdvisor.Data.Models;
using FoodAdvisor.Data.Repository.Interfaces;
using FoodAdvisor.Data.Services;
using FoodAdvisor.Data.Services.Interfaces;
using FoodAdvisor.ViewModels.CommentViewModel;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodAdvisor.Services.Tests
{
	[TestFixture]
	public class CommentServiceTests
	{
		private Mock<IRepository<Comment, Guid>>commentRepository;
		

		[SetUp]
		public void Setup()
		{
			this.commentRepository = new Mock<IRepository<Comment, Guid>>();
		}
		[Test]
		public async Task AddAsync_ValidMessage_AddsCommentAndReturnsTrueIfRecipeExistPositive()
		{
			var userId = Guid.NewGuid();
			var recepieId = Guid.NewGuid().ToString();
			var restaurantId = (string?)null;

			commentRepository
				.Setup(cr => cr.AddAsync(It.IsAny<Comment>()))
				.Returns(Task.CompletedTask);

			ICommentService commentService = new CommentService(commentRepository.Object);

			var model = new AddCommentViewModel
			{
				Message = "Great recipe!"
			};

			var result = await commentService.AddAsync(recepieId, restaurantId, userId, model);

			Assert.IsTrue(result);
			commentRepository.Verify(cr => cr.AddAsync(It.Is<Comment>(c => c.Message == model.Message && c.UserId == userId)), Times.Once);
		}

		[Test]
		public async Task AddAsync_NullMessage_ReturnsFalse()
		{
			var model = new AddCommentViewModel { Message = null };
			var userId = Guid.NewGuid();
			var recepieId = Guid.NewGuid().ToString();
			var restaurantId = (string?)null;

			commentRepository
				.Setup(cr => cr.AddAsync(It.IsAny<Comment>()))
				.Returns(Task.CompletedTask);

			ICommentService commentService = new CommentService(commentRepository.Object);
			
			var result = await commentService.AddAsync(recepieId, restaurantId, userId, model);

			Assert.IsFalse(result);
			commentRepository.Verify(cr => cr.AddAsync(It.IsAny<Comment>()), Times.Never);
		}
		[Test]
		public async Task AddAsync_NoRecepieOrRestaurantId_ReturnsFalse()
		{
			var model = new AddCommentViewModel { Message = "No ID test" };
			var userId = Guid.NewGuid();
			var recepieId = (string?)null;
			var restaurantId = (string?)null;

			commentRepository
				.Setup(cr => cr.AddAsync(It.IsAny<Comment>()))
				.Returns(Task.CompletedTask);

			ICommentService commentService = new CommentService(commentRepository.Object);

			var result = await commentService.AddAsync(recepieId, restaurantId, userId, model);

			Assert.IsFalse(result);
			commentRepository.Verify(cr => cr.AddAsync(It.IsAny<Comment>()), Times.Never);
		}

		[Test]
		public async Task AddAsync_ValidRestaurantId_AddsCommentAndReturnsTrue()
		{
			var model = new AddCommentViewModel { Message = "Great restaurant!" };
			var userId = Guid.NewGuid();
			var recepieId = (string?)null;
			var restaurantId = Guid.NewGuid().ToString();

			commentRepository
				.Setup(cr => cr.AddAsync(It.IsAny<Comment>()))
				.Returns(Task.CompletedTask);

			ICommentService commentService = new CommentService(commentRepository.Object);
			
			var result = await commentService.AddAsync(recepieId, restaurantId, userId, model);

			Assert.IsTrue(result);
			commentRepository.Verify(cr => cr.AddAsync(It.Is<Comment>(c => c.Message == model.Message && c.UserId == userId)), Times.Once);
		}
		[Test]
		public async Task DeleteAsync_CommentExistsAndNotDeleted_SetsIsDeletedAndSavesChanges()
		{
			var commentId = Guid.NewGuid().ToString();
			var comment = new Comment { 
				Id = Guid.Parse(commentId), 
				IsDeleted = false,
				Message = "Amazing, love it"!
			};

			this.commentRepository
				.Setup(cr => cr.GetByIdAsync(Guid.Parse(commentId)))
				.ReturnsAsync(comment);

			this.commentRepository
				.Setup(cr => cr.SaveChangesAsync())
				.Returns(Task.CompletedTask);

			ICommentService commentService = new CommentService(commentRepository.Object);
			var result = await commentService.DeleteAsync(commentId);

			Assert.IsTrue(result);
			Assert.IsTrue(comment.IsDeleted == true);
			this.commentRepository.Verify(cr => cr.GetByIdAsync(Guid.Parse(commentId)), Times.Once);
			this.commentRepository.Verify(cr => cr.SaveChangesAsync(), Times.Once);
		}
		[Test]
		public async Task DeleteAsync_CommentDoesNotExist_ReturnsFalse()
		{
			var commentId = Guid.NewGuid().ToString();
			var commentGuid = Guid.Parse(commentId);
			
			this.commentRepository
				.Setup(cr => cr.GetByIdAsync(commentGuid))
				.ReturnsAsync((Comment)null);

			ICommentService commentService = new CommentService(commentRepository.Object);
			
			var result = await commentService.DeleteAsync(commentId);

			Assert.IsFalse(result);
			this.commentRepository.Verify(cr => cr.GetByIdAsync(commentGuid), Times.Once);
			this.commentRepository.Verify(cr => cr.SaveChangesAsync(), Times.Never);
		}
		[Test]
		public async Task DeleteAsync_CommentAlreadyDeleted_ReturnsFalse()
		{
			var commentId = Guid.NewGuid().ToString();
			var commentGuid = Guid.Parse(commentId);
			var comment = new Comment
			{ 
				Id = commentGuid, 
				IsDeleted = true,
				Message = "I'm deleted comment"
			};

			this.commentRepository
				.Setup(cr => cr.GetByIdAsync(commentGuid))
				.ReturnsAsync(comment);

			ICommentService commentService = new CommentService(commentRepository.Object);

			var result = await commentService.DeleteAsync(commentId);

			Assert.IsFalse(result);
			this.commentRepository.Verify(cr => cr.GetByIdAsync(commentGuid), Times.Once);
			this.commentRepository.Verify(cr => cr.SaveChangesAsync(), Times.Never);
		}
	}
}
