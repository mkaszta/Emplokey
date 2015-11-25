namespace Emplokey_ActivityUpdater
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Logs
    {
        public int ID { get; set; }

        public int ID_user { get; set; }

        public int ID_pc { get; set; }

        public DateTime Time_login { get; set; }

        public DateTime? Time_logout { get; set; }
    }
}
