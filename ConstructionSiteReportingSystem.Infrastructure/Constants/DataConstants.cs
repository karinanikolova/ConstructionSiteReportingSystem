namespace ConstructionSiteReportingSystem.Infrastructure.Constants
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
        }

        public static class Stage
        {
            public const int NameMinLength = 3;
            public const int NameMaxLength = 100;
        }

        public static class Unit
        {
            public const int TypeMinLength = 1;
            public const int TypeMaxLength = 30;
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
        }

        public static class Contractor
        {
            public const int NameMinLength = 3;
            public const int NameMaxLength = 100;
        }
    }
}
