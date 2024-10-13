using System;
using System.ComponentModel.DataAnnotations;


namespace DataGridView_Shelkynov.Models
{
    public class Person : ICloneable
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        public DateTime Birhday { get; set; }

        [Range(0, 3)]
        public Gender Gender { get; set; }

        public object Clone()
        {
            return MemberwiseClone();
        }

    }
}
