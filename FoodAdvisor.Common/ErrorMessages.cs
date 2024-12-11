using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodAdvisor.Common
{
    public static class ErrorMessages
    {
		public const string InvalidFileMessage = "Invalid file!";
        public const string InvalidGuidMessage = "Invalid Guid!";
       
        public const string GeneralErrorMessage = "An unexpected error occurred.Please try again later.";
        public const string UnexpectedErrorMessage = "An unexpected error occurred. Please try again later or contact support.";
		public const string EntityNotFoundMessage = "No entity found with the provided details. Please check your information and try again.";
        public const string MissingFileErrorMessage = "The File is empty or missing!";
      
        public const string InvalidModelStateErrorMessage = "The data provided is invalid. Please ensure all fields are filled out correctly and try again.";
        
        public const string DeletingWasSuccesfullMessage = "Deleting was successfull!";
		public const string AddingWasSuccesfullMessage = "Adding was successfull!";
		public const string EditingWasSuccesfullMessage = "Editing was successfull!";

		public const string CommentAddingSuccesfullMessage = "Comment added successfully!";

		public const string FavoritesErrorMessage = "Entity is alredy in your favorites!";
		public const string FavoritesSuccessMessage = "Entity is added to your favorites!";
		public const string FavoritesRemoveSuccessMessage = "Entity is removed from your favorites!";

		public const string NotManagerErrorMessage = "You do not have manager privileges to perform this operation.";

		public const string ErrorMessage = "ErrorMessage!";
        public const string WarningMessage = "WarningMessage!";
        public const string SuccessMessage = "SuccessMessage!";
        public const string InfoMessage = "InfoMessage!";

    }
}
