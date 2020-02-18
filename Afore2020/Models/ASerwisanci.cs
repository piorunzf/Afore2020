using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Afore2020.Models
{
    public class ASerwisanci
    {
          [Key]
            public int ASerwisanciID { get; set; }

            [Required(ErrorMessage = "Proszę imię serwisanta  ")]
            [Display(Name = "imię")]
            [StringLength(70)]
            public String ASerwisanciImię { get; set; }

            [Required(ErrorMessage = "Proszę nazwisko serwisanta  ")]
            [Display(Name = "Nazwisko")]
            [StringLength(70)]
            public String ASerwisanciNazwisko { get; set; }


            [Required(ErrorMessage = "Proszę nazwisko numer telefonu  ")]
            [Display(Name = "Telefon")]
            [StringLength(70)]
            public String ASerwisanciTelefon { get; set; }

            [StringLength(250)]
            [Display(Name = "Opis")]
            public string ASerwisanciOpis { get; set; }


            [Required]
            [Display(Name = "Serwisant aktywny", ShortName = "Aktywny")]
            public bool ASerwisanciAktywny { get; set; } = true;


            [DataType(DataType.Date)]
            [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
            [Display(Name = "Data dodawania zapisu")]
            // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public DateTime ASerwisanciDataTworzenia { get; set; }

            [StringLength(70)]
            [Display(Name = "Operor dodajacy zapis")]
            public String ASerwisanciOperatorTw { get; set; }


            [DataType(DataType.Date)]
            [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
            [Display(Name = "Data modyfikacji zapisu")]
            //  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public DateTime ASerwisanciDatamodyfikacji { get; set; }

            [StringLength(70)]
            [Display(Name = "Operor modyfikujacy zapis")]
            public String ASerwisanciOperatorMd { get; set; }
        public virtual ICollection<AKartaWyjazdu> AKartaWyjazdus { get; set; }



    }
    }
