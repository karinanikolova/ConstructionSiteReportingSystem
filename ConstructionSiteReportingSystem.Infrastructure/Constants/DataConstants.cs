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

        public static class ProjectSiteInfo
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

        public static class WorkInfo
        {
            public const int NameMinLength = 3;
            public const int NameMaxLength = 150;
        }
    }
}
