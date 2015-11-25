namespace Emplokey_ActivityUpdater
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Requests
    {
        public int Id { get; set; }

        public int LogId { get; set; }

        public int Confirmed { get; set; }
    }
}
