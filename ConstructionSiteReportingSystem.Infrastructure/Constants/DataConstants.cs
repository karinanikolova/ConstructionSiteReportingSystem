namespace ConstructionSiteReportingSystem.Infrastructure.Constants
{
    public static class DataConstants
    {
        public static class Task
        {
            public const int TitleMinLength = 3;
            public const int TitleMaxLength = 50;

            public const int DescriptionMinLength = 10;
            public const int DescriptionMaxLength = 1000;
        }

        public static class ProjectSiteName
        {
            public const int NameMinLength = 3;
            public const int NameMaxLength = 50;
        }

        public static class Stage
        {
            public const int NameMinLength = 3;
            public const int NameMaxLength = 50;
        }

        public static class Unit
        {
            public const int TypeMinLength = 1;
            public const int TypeMaxLength = 30;
        }

        public static class Work
        {
            public const int DescriptionMaxLength = 500;
        }

        public static class WorkType
        {
            public const int NameMinLength = 3;
            public const int NameMaxLength = 150;
        }

        public static class Contractor
        {
            public const int NameMinLength = 3;
            public const int NameMaxLength = 50;
        }
    }
}
