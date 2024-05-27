using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Globalization;

namespace ConstructionSiteReportingSystem.ModelBinders
{
	public class DoubleModelBinder : IModelBinder
	{
		public Task BindModelAsync(ModelBindingContext bindingContext)
		{
			ValueProviderResult valueResult = bindingContext.ValueProvider
			   .GetValue(bindingContext.ModelName);

			if (valueResult != ValueProviderResult.None && !string.IsNullOrEmpty(valueResult.FirstValue))
			{
				double result = default;
				bool isSuccessful = false;

				try
				{
					string stringValue = valueResult.FirstValue.Trim();
					stringValue = stringValue.Replace(".", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
					stringValue = stringValue.Replace(",", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);

					result = Convert.ToDouble(stringValue, CultureInfo.CurrentCulture);
					isSuccessful = true;
				}
				catch (FormatException fe)
				{
					bindingContext.ModelState.AddModelError(bindingContext.ModelName, fe, bindingContext.ModelMetadata);
				}

				if (isSuccessful)
				{
					bindingContext.Result = ModelBindingResult.Success(result);
				}
			}

			return Task.CompletedTask;
		}
	}
}
