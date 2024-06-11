using ConstructionSiteReportingSystem.Core.Extensions.Contracts;
using System.Text.RegularExpressions;

namespace ConstructionSiteReportingSystem.Core.Extensions
{
    public static class ModelExtensions
    {
        public static string GetInformation(this ISiteModel site)
        {
            string info = site.Name.Replace(" ", "-") + GetFinishDate(site.FinishDate);
            info = Regex.Replace(info, @"[^a-zA-Z0-9\-]", string.Empty);

            return info;
        }

        private static string GetFinishDate(string finishDate)
        {
            finishDate = string.Join("-", finishDate.Split(" ").Take(3));

            return finishDate;
        }
    }
}
