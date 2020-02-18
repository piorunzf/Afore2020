using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Afore2020.Models
{
    public class AOdbiorcy
    {
        [Key]
        public int AOdbiorcyID { get; set; }

        [Required(ErrorMessage = "Proszę kod odbiorcy  ")]
        [Display(Name = "Kod odbiorcy")]
        [StringLength(70)]
        public String AOdbiorcyKod { get; set; }

        [Required(ErrorMessage = "Proszę nazwę odbiorcy ")]
        [Display(Name = "Nazwa odbiorcy")]
        [StringLength(200)]
        public String AOdbiorcyNazwa { get; set; }

        
        [Display(Name = "NIP odbiorcy")]
        [StringLength(20)]
        public String AOdbiorcyNIP { get; set; }

        [Display(Name = "Miejscowosc")]
        public int AMiastaID { get; set; }

        
        [StringLength(100)]
        [Display(Name = "Ulica nr domu")]
        public String AOdbiorcyUlicaNumerDomuLokalu { get; set; }

        
        [StringLength(60)]
        [Display(Name = "Poczta")]
        public String AOdbiorcyPoczta { get; set; }

        
        [StringLength(15)]
        [Display(Name = "Kod pocztowy")]
        public String AOdbiorcyKodPocztowy { get; set; }

        [Display(Name = "Wojewodztwo")]
        public int AWojewodztwoID { get; set; }

       
        [StringLength(100)]
        [Display(Name = "Telefon")]
        public String AOdbiorcyTelefon { get; set; }

        [Display(Name = "Email address")]
        
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string AOdbiorcaEmail { get; set; }

        [StringLength(250)]
        [Display(Name = "Uwagi")]
        public string AOdborcaUwagi { get; set; }

        public virtual AWojewodztwo AWojewodztwo { get; set; }

        public virtual AMiasta AMiejscowosc { get; set; }


    }
}