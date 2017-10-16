using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.ViewModels
{
    public class ValoViewModel
    {
        public int IdValonTila { get; set; }
        public string HuoneNimi { get; set; }
        public string ValaisinNimi { get; set; }
        public DateTime? ValotOn33 { get; set; }
        public bool Valot33 { get; set; }
        public Nullable<System.DateTime> ValotOn66 { get; set; }
        public bool Valot66 { get; set; }
        public Nullable<System.DateTime> ValotOn100 { get; set; }
        public bool Valot100 { get; set; }
        public Nullable<System.DateTime> ValotOff { get; set; }
        public bool ValonTilaOff { get; set; }
    }
}