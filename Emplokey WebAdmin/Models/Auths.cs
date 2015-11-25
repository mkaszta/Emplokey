namespace Emplokey_WebAdmin
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Auths
    {
        public int ID { get; set; }

        public int ID_user { get; set; }

        public int ID_pc { get; set; }

        [Required]
        [StringLength(100)]
        public string Auth_key { get; set; }

        [Required]
        [StringLength(100)]
        public string Device { get; set; }
    }
}
