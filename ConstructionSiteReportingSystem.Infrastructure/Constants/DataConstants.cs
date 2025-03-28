﻿namespace ConstructionSiteReportingSystem.Infrastructure.Constants
{
    public static class DataConstants
    {
        public static class Task
        {
            public const int TitleMinLength = 3;
            public const int TitleMaxLength = 100;

            public const int DescriptionMinLength = 10;
            public const int DescriptionMaxLength = 1000;
        }

        public static class Site
        {
            public const int NameMinLength = 3;
            public const int NameMaxLength = 100;
			public const string NameMatchRegex = @"^(?=[A-Za-z\d\-\s\']{3,})(\'*\d*[A-Za-z]+\d*[A-Za-z]*\d*\'*\s*?|\-*?\'*?){1,}[A-Za-z]*$";
		}

        public static class Stage
        {
            public const int NameMinLength = 3;
            public const int NameMaxLength = 100;
			public const string NameMatchRegex = @"^(?=[A-Za-z\d\-\s]{3,})(\d*[A-Za-z]+\d*[A-Za-z]*\d*\s*?|\-*?){1,}[A-Za-z]*$";
		}

        public static class Unit
        {
            public const int TypeMinLength = 1;
            public const int TypeMaxLength = 30;
			public const string TypeMatchRegex = @"^(?=[A-Za-z\d\.\^\\/\'s]{1,})[A-Za-z]+\.*\^*\d*\'*\/*\s??[A-Za-z]*\.*\^*\d*\'*\/*$";
		}

        public static class Work
        {
            public const int DescriptionMinLength = 0;
            public const int DescriptionMaxLength = 500;

            public const double QuantityMinValue = 0.01;
            public const double QuantityMaxValue = double.MaxValue;

			public const decimal CostPerUnitMinValue = 0.01M;
			public const decimal CostPerUnitMaxValue = decimal.MaxValue;
		}

        public static class WorkType
        {
            public const int NameMinLength = 3;
            public const int NameMaxLength = 150;
            public const string NameMatchRegex = @"^(?=[A-Za-z\d\,\.\-\(\)\s]{3,})(\(*\d*[A-Za-z]+\d*[A-Za-z]*\d*\)*\,*\s??){1,}[A-Za-z]*\.*$";
        }

        public static class Contractor
        {
            public const int NameMinLength = 3;
            public const int NameMaxLength = 100;
            public const string NameMatchRegex = @"^(?=[A-Za-z\d\-\s]{3,})(\d*[A-Za-z]+\d*[A-Za-z]*\d*\s*?|\-*?){1,}[A-Za-z]*$";

		}

        public static class ApplicationUser
        {
            public const int FirstNameMinLength = 1;
            public const int FirstNameMaxLength = 50;

			public const int MiddleNameMinLength = 1;
			public const int MiddleNameMaxLength = 50;

			public const int LastNameMinLength = 1;
			public const int LastNameMaxLength = 50;
		}
    }
}