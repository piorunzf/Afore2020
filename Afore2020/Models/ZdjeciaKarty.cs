using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Afore2020.Models
{
    public class ZdjeciaKarty
    {
        [Key]
        public int ZdjeciaKartyID { get; set; }

        [Display(Name = "Nazwa")]
        [StringLength(70)]
        public String ZdjeciaKartyNazwa { get; set; }


        [Display(Name = "Opis")]
        [StringLength(70)]
        public String ZdjeciaKartyOpis { get; set; }

        [Display(Name = "Zdjecie")]
        public Byte[] ZdjeciaKartyZdjecie { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Data dodawania zapisu")]
        // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime ZdjeciaKartyDataTworzenia { get; set; }

        [StringLength(70)]
        [Display(Name = "Operor dodajacy zapis")]
        public String ZdjeciaKartyOperatorTw { get; set; }


        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Data modyfikacji zapisu")]
        //  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime ZdjeciaKartyDatamodyfikacji { get; set; }

        [StringLength(70)]
        [Display(Name = "Operor modyfikujacy zapis")]
        public String ZdjeciaKartyOperatorMd { get; set; }

    }
}