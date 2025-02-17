using ConstructionSiteReportingSystem.Infrastructure.Data.Utilities.Contracts;

namespace ConstructionSiteReportingSystem.Infrastructure.Data.Utilities
{
	/// <summary>
	/// Abstract class which implements the ISoftDelete interface.It provides a common definition of a base class that multiple derived Entity classes can share in order to be marked as soft-deleted.
	/// </summary>
	public abstract class SoftDelete : ISoftDelete
    {
        /// <summary>
        /// Implementation of the ISoftDelete IsDeleted property.
        /// </summary>
        public bool IsDeleted { get; private set; } = false;

        /// <summary>
        /// Implementation of the ISoftDelete DeletedAt property.
        /// </summary>
        public DateTimeOffset? DeletedAt { get; private set; } = null;

        /// <summary>
        /// Implementation of the ISoftDelete UndoDelete method by switching the IsDeleted state to false and setting the DeletedAt point in time to null. 
        /// </summary>
        public void UndoDelete()
        {
            IsDeleted = false;
            DeletedAt = null;
        }
    }
}