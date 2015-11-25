using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emplokey_WebAdmin.Models
{
    public class StatisticsModel
    {
        [Key]
        [Display(Name ="Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime date { get; set; }

        public TimeSpan timeSpent{ get; set; }

        [Display(Name = "Total time")]
        public string timeSpentString
        {
            get
            {
                return string.Format("{0:00}:{1:00}:{2:00}", timeSpent.Hours, timeSpent.Minutes, timeSpent.Seconds);
            }
            set { }                                
        }

        [Display(Name = "PC")]
        public string pcName { get; set; }
    }
}
