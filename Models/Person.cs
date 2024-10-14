using System;
using System.ComponentModel.DataAnnotations;


namespace DataGridView_Shelkynov.Models
{
    public class Person
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        public DateTime Birhday { get; set; }

        [Range(0, 3)]
        public Gender Gender { get; set; }

        public Enducation Education { get; set; }

        [Range(0, 100)]
        public decimal Value1 { get; set; }

        [Range(0, 100)]
        public decimal Value2 { get; set; }

        [Range(0, 100)]
        public decimal Value3 { get; set; }

        [Range(0, 300)]
        public decimal Result { get; set; }
    }
}
