using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.ViewModels
{
    public class LampoViewModel
    {
        public int IdLampo { get; set; }
        public Nullable<System.DateTime> LampoKirjattu { get; set; }
        public string Huone { get; set; }
        public Nullable<int> TavoiteLampo { get; set; }
        public Nullable<int> NykyLampo { get; set; }
        public bool LampoOn { get; set; }
        public bool LampoOff { get; set; }
    }
}