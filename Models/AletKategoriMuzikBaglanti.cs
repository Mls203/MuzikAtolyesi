using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProje.Models
{
    public class AletKategoriMuzikBaglanti
    {
        public int kategoriId { get; set; }
        public int aletId { get; set; }
        public List<SelectListItem> KategoriList { get; set; }
        public List<SelectListItem> AletList { get; set; }

    }
}