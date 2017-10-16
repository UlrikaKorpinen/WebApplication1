using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.ViewModels
{
    public class SaunaViewModel
    {
        public int IdSaunanTila { get; set; }
        public Nullable<System.DateTime> TilaKirjattu { get; set; }
        public string SaunanNimi { get; set; }
        public bool SaunanTila { get; set; }
        public DateTime? SaunaOn { get; set; }
        public DateTime? SaunaOff { get; set; }

        [Display(Name = "Tavoitelämpö")]
        public string SaunaTavoitelampo { get; set; }

        [Display(Name = "Nykylämpö")]
        public string SaunaNykylampo { get; set; }
    }
}