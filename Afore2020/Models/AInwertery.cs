using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Afore2020.Models
{
    public class AInwertery
    {
        [Key]
        public int AInwerteryID { get; set; }

        [Required(ErrorMessage = "Proszę podać model inwentera  ")]
        [Display(Name = "Model inwentera")]
        [StringLength(70)]
        public String AInwerteryModelInwentera { get; set; }


        [StringLength(250)]
        [Display(Name = "Opis")]
        public string AInwerteryOpis { get; set; }


        [Required]
        [Display(Name = "Inwenter aktywny", ShortName = "Aktywny")]
        public bool AInwerteryAktywny { get; set; } = true;


        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Data dodawania zapisu")]
        // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime AInwerteryDataTworzenia { get; set; }

        [StringLength(70)]
        [Display(Name = "Operor dodajacy zapis")]
        public String AInwerteryiOperatorTw { get; set; }


        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Data modyfikacji zapisu")]
        //  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime AInwerteryDatamodyfikacji { get; set; }

        [StringLength(70)]
        [Display(Name = "Operor modyfikujacy zapis")]
        public String AInwerteryOperatorMd { get; set; }

        public virtual ICollection<AKartaWyjazdu> AKartaWyjazdus { get; set; }
    }
}