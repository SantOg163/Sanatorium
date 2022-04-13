namespace Sanatorium.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Appointment")]
    public partial class Appointment
    {
        public int Id { get; set; }

        public int ClientId { get; set; }

        public int EmployeeId { get; set; }

        public int CabinetId { get; set; }

        public int ServiceId { get; set; }

        [Column(TypeName = "date")]
        public DateTime VisitDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateRegistration { get; set; }

        public virtual Cabinet Cabinet { get; set; }

        public virtual Client Client { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual Service Service { get; set; }
    }
}
