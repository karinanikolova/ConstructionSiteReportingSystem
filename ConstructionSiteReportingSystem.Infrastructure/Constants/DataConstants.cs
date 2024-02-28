using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
