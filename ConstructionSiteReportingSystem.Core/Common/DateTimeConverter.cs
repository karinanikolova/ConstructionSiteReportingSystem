using System.Globalization;
using static ConstructionSiteReportingSystem.Core.Constants.ValidationConstants;

namespace ConstructionSiteReportingSystem.Core.Common
{
	public static class DateTimeConverter
	{
		public static string ConvertDateToString(DateTime date)
		{
			return date.ToString(DateTimePreferredFormat, CultureInfo.InvariantCulture);
		}
	}
}
