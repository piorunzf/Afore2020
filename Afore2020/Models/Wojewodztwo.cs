using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Afore2020.Models
{
    public class Wojewodztwo
    {
        [Key]
        public int WojewodztwoID { get; set; }

        [StringLength(70)]
        [Display(Name = "Nazwa województwa")]

        public string WojewodztwoNazwa { get; set; }
    }
}