﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Afore2020.Models
{
    public class AWojewodztwo
    {

        [Key]
        public int AWojewodztwoID { get; set; }

        [StringLength(70)]
        [Display(Name = "Nazwa województwa")]

        public string AWojewodztwoNazwa { get; set; }

        public virtual ICollection<AWojewodztwo> AWojewodztwos { get; set; }
        public virtual ICollection<AKartaWyjazdu> AKartaWyjazdus { get; set; }
        public virtual ICollection<AOdbiorcy> AOdbiorcies { get; set; }


    }
}