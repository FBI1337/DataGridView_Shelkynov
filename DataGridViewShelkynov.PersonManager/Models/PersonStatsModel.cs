using DataGridViewShelkynov.Contracts;
using DataGridViewShelkynov.Contracts.Models;

namespace DataGridViewShelkynov.PersonManager.Models
{
    public class PersonStatsModel : IPersonStats
    {
        public int Count { get; set; }

        public int FemaleCount { get; set; }

        public int MaleCount { get; set; }

        public int FullTimeCount { get; set; }

        public int FiftyFifty { get; set; }

        public int BEER { get; set; }

        public int Value1 { get; set; }

        public int Value2 { get; set; }

        public int Value3 { get; set; }

        public int Result { get; set; }
    }
}
