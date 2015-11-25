using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emplokey_WebAdmin.Models
{
    public class LogsViewModel
    {
        [Key]
        public string Username { get; set; }

        public string PcName { get; set; }

        public DateTime Time_login { get; set; }

        public DateTime? Time_logout { get; set; }
    }
}
