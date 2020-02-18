using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Afore2020.Models
{
    public class AMiasta
    {
        [Key]
        public int AMiastaID { get; set; }


        public int AWojewodztwoID { get; set; }


        [StringLength(70)]
        [Display(Name = "Nazwa miejscowosci")]

        public string AMiastaNazwa { get; set; }

        public virtual AWojewodztwo AWojewodztwo { get; set; }
        public virtual ICollection<AKartaWyjazdu> AKartaWyjazdus { get; set; }
        public virtual ICollection<AOdbiorcy> AOdbiorcies { get; set; }

    }


}