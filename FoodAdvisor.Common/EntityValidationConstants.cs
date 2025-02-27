﻿namespace FoodAdvisor.Common
{
    public class EntityValidationConstants
    {
        public static class Restaurant
		{
            public const int NameMinLenght = 2;
            public const int NameMaxLenght = 50;

			public const int DescriptionMinLenght = 100;
            public const int DescriptionMaxLenght = 700;

            public const int AddressMinLenght = 5;
            public const int AddressMaxLenght = 85;

		}

        public static class City
        {
            public const int CityNameMinLenght = 4;
            public const int CityNameMaxLenght = 56;
        }
		public static class Cuisine
		{
			public const int CuisineNameMinLenght = 4;
			public const int CuisineNameMaxLenght = 20;
		}

		public static class Category
        {
            public const int NameMinLenght = 3;
            public const int NameMaxLenght = 20;

        }
		public static class Comment
		{
			public const int MessageMinLenght = 1;
			public const int MessageMaxLenght = 300;
		}
        public static class Manager
        {
			public const int PhoneNumberMinLenght = 6;
			public const int PhoneNumberMaxLenght = 15;

			public const int AddressMinLenght = 5;
			public const int AddressMaxLenght = 40;
		}
        
        public static class Recepie
        {
			public const int NameMinLenght = 3;
			public const int NameMaxLenght = 30;

			public const int DescriptionMinLenght = 50;
			public const int DescriptionMaxLenght = 500;

			public const int CookingStepsMinLenght = 50;
			public const int CookingStepsMaxLenght = 3000;

			public const int ProductsMinLengt = 10;
			public const int ProductsMaxLenght = 300;

		}

        public static class User
        {
			public const int FirstNameMinLenght = 2;
			public const int FirstNameMaxLenght = 50;

			public const int LastNameMinLenght = 2;
			public const int LastNameMaxLenght = 50;

			public const int AboutMeMinLenght = 5;
			public const int AboutMeMaxLenght = 200;

			public const int UsernameMaxLenght = 20;

			public const int CountryMinLenght = 4;
			public const int CountryMaxLenght = 56;

		}
	}
}
