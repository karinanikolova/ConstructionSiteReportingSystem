namespace ConstructionSiteReportingSystem.Infrastructure.Data.Utilities.Contracts
{
    /// <summary>
    /// Interface which can be implemented by Entity classes in order to be marked as soft-deleted.
    /// </summary>
    public interface ISoftDelete
    {
        /// <summary>
        /// Represents the current deleted state of the Entity.
        /// </summary>
        public bool IsDeleted { get; }

        /// <summary>
        /// Represents the deletion point in time of the Entity.
        /// </summary>
        public DateTimeOffset? DeletedAt { get; }

        /// <summary>
        /// Reverts the soft delete. Should be implemented by switching the IsDeleted state to false and setting the DeletedAt point in time to null. 
        /// </summary>
        void UndoDelete();
    }
}
