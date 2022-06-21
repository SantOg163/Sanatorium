namespace Sanatorium.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Statistic")]
    public partial class Statistic
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int expenses { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string Title { get; set; }

        [Key]
        [Column(Order = 3)]
        public DateTime Month { get; set; }
    }
}
