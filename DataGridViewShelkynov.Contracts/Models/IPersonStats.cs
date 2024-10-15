using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGridViewShelkynov.Contracts.Models
{
    public interface IPersonStats
    {
        int Count { get; }

        int FemaleCount { get; }

        int MaleCount { get; }

        int FullTimeCount { get; }

        int FiftyFifty {  get; }

        int BEER {  get; }

        int Value1 { get; }

        int Value2 { get; }

        int Value3 { get; }

        int Result {  get; }
    }
}
