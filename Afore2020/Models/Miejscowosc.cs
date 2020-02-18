using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Afore2020.Models
{
    public class Miejscowosc
    {
        [Key]
        public int MiejscowoscID { get; set; }


        public int WojewodztwoID { get; set; }


        [StringLength(70)]
        [Display(Name = "Nazwa miejscowosci")]

        public string MiejscowoscNazwa { get; set; }
    }
}