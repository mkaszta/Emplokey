namespace Emplokey_WebAdmin
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Computers
    {
        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        public string PC_name { get; set; }

        public int Lock_status { get; set; }
    }
}
