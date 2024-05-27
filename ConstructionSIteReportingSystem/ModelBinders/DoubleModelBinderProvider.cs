using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ConstructionSiteReportingSystem.ModelBinders
{
	public class DoubleModelBinderProvider : IModelBinderProvider
	{
		public IModelBinder? GetBinder(ModelBinderProviderContext context)
		{
			if (context == null)
			{
				throw new ArgumentNullException(nameof(context));
			}

			if (context.Metadata.ModelType == typeof(double)
				|| context.Metadata.ModelType == typeof(double?))
			{
				return new DoubleModelBinder();
			}

			return null;
		}
	}
}
