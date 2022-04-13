namespace Sanatorium.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("History")]
    public partial class History
    {
        public int Id { get; set; }

        public int ClientId { get; set; }

        public int EmployeeId { get; set; }

        [Required]
        [StringLength(50)]
        public string Symptoms { get; set; }

        [Required]
        [StringLength(50)]
        public string Diagnosis { get; set; }

        [Required]
        [StringLength(50)]
        public string Medicine { get; set; }

        [Column(TypeName = "date")]
        public DateTime VisitDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime DischargeDate { get; set; }

        public virtual Client Client { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
