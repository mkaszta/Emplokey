namespace Emplokey_WebAdmin
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Users
    {
        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        public string Username { get; set; }

        [StringLength(50)]
        public string Type { get; set; }
    }
}
