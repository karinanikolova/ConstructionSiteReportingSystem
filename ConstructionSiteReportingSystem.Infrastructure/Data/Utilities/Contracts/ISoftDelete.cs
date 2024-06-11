namespace ConstructionSiteReportingSystem.Infrastructure.Data.Utilities.Contracts
{
    /// <summary>
    /// Interface which can be implemented by Entity classes in order to be marked as soft-deleted.
    /// </summary>
    public interface ISoftDelete
    {
        /// <summary>
        /// Represents the current delete state of the Entity.
        /// </summary>
        public bool IsDeleted { get; }

        /// <summary>
        /// Represents the deletion point in time of the Entity.
        /// </summary>
        public DateTimeOffset? DeletedAt { get; }

        /// <summary>
        /// Reverts the soft delete.
        /// </summary>
        void UndoDelete();
    }
}
