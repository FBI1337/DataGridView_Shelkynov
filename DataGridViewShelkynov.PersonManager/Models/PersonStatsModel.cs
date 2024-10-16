using DataGridViewShelkynov.Contracts.Models;

namespace DataGridViewShelkynov.PersonManager.Models
{
    /// <summary>
    /// Вычесляемые данные в списке <see cref="Person"/>
    /// </summary>
    public class PersonStatsModel : IPersonStats
    {
        /// <inheritdoc cref="IPersonStats.Count"/>
        public int Count { get; set; }
        /// <inheritdoc cref="IPersonStats.FemaleCount"/>
        public int FemaleCount { get; set; }
        /// <inheritdoc cref="IPersonStats.MaleCount"/>
        public int MaleCount { get; set; }
        /// <inheritdoc cref="IPersonStats.FullTimeCount"/>
        public int FullTimeCount { get; set; }
        /// <inheritdoc cref="IPersonStats.FiftyFifty"/>
        public int FiftyFifty { get; set; }
        /// <inheritdoc cref="IPersonStats.BEER"/>
        public int BEER { get; set; }
        /// <inheritdoc cref="IPersonStats.Value1"/>
        public int Value1 { get; set; }
        /// <inheritdoc cref="IPersonStats.Value2"/>
        public int Value2 { get; set; }
        /// <inheritdoc cref="IPersonStats.Value3"/>
        public int Value3 { get; set; }
        /// <inheritdoc cref="IPersonStats.Result"/>
        public int Result { get; set; }
    }
}
