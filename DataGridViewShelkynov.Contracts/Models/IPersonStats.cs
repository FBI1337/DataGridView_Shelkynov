using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGridViewShelkynov.Contracts.Models
{
    /// <summary>
    /// Интерфейс для вычесляемых данных в списках <see cref="Person"/>
    /// </summary>
    public interface IPersonStats
    {
        /// <summary>
        /// Общее количество абитуриентов
        /// </summary>
        int Count { get; }

        /// <summary>
        /// Общее количество абитуриентов женского пола
        /// </summary>
        int FemaleCount { get; }

        /// <summary>
        /// Общее количество абитуриентов мужского пола
        /// </summary>
        int MaleCount { get; }

        /// <summary>
        /// Общее количество абитуриентов на очное обучение
        /// </summary>
        int FullTimeCount { get; }

        /// <summary>
        /// Общее количество абитуриентов на очное-заочное обучение
        /// </summary>
        int FiftyFifty { get; }

        /// <summary>
        /// Общее количество абитуриентов на заочное обучение
        /// </summary>
        int BEER { get; }

        /// <summary>
        /// Количество баллов по математике
        /// </summary>
        int Value1 { get; }

        /// <summary>
        /// Количество баллов по русскому
        /// </summary>
        int Value2 { get; }

        /// <summary>
        /// Количество баллов по информатике
        /// </summary>
        int Value3 { get; }

        /// <summary>
        /// Общее количество баллов за все экзамены
        /// </summary>
        int Result { get; }
    }
}
