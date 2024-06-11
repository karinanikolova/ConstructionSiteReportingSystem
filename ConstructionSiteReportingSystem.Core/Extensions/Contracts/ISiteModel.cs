namespace ConstructionSiteReportingSystem.Core.Extensions.Contracts
{
    /// <summary>
    /// Interface which can be implemented by Model classes in order to have properties for modifying page URLs.
    /// </summary>
    public interface ISiteModel
    {
        /// <summary>
        /// Represents the name of the Model class.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Represents the finish date of the Model class.
        /// </summary>
        public string FinishDate { get; }
    }
}
