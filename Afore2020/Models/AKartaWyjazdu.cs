using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Afore2020.Models
{
    public class AKartaWyjazdu
    {
        [Key]
        public int AKartaWyjazduID { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Data dodawania zapisu")]
        // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime AKartaWyjazduDataWizyty { get; set; }

        [Required(ErrorMessage = "Numer wyjazdu")]
        [StringLength(20)]
        [Display(Name = "Numer wyjazdu.")]
        public string AKartaWyjazduNrWyjazdu { get; set; }


        [Required(ErrorMessage = "Wprowadz dane serwisanta")]
        [Display(Name = "Imie i nazwisko serwisanta")]
        public int ASerwisanciID { get; set; }

        [Required(ErrorMessage = "Wprowadz imię i nazwsko zgłoszającego")]
        [StringLength(100)]
        [Display(Name = "Imie Nazwisko")]
        public String AKartaWyjazduImieNazwisko { get; set; }


        [Display(Name = "Miejscowosc")]
        public int AMiastaID { get; set; }

        [Required(ErrorMessage = "Ulica numer domu lokalu")]
        [StringLength(100)]
        [Display(Name = "Ulica nr domu")]
        public String AKartaWyjazduUlicaNumerDomuLokalu { get; set; }

        [Required(ErrorMessage = "Podaj pocztę")]
        [StringLength(60)]
        [Display(Name = "Poczta")]
        public String AKartaWyjazduPoczta { get; set; }

        [Required(ErrorMessage = "Wprowadz Kod pocztowy")]
        [StringLength(15)]
        [Display(Name = "Kod pocztowy")]
        public String AKartaWyjazduKodPocztowy { get; set; }

        [Display(Name = "Wojewodztwo")]
        public int AWojewodztwoID { get; set; }

        [Required(ErrorMessage = "Wprowadz numer telefonu ")]
        [StringLength(100)]
        [Display(Name = "Telefon")]
        public String AKartaWyjazduTelefon { get; set; }

        [StringLength(100)]
        [Display(Name = "Telefon pomocniczy")]
        public String AKartaWyjazduTelefon2 { get; set; }

        [Required(ErrorMessage = "Wprowadz model inwertera")]
        [Display(Name = "Model inwertera")]
        public int AInwerteryID { get; set; }

        [Required(ErrorMessage = "Wprowadz numer inwentora")]
        [StringLength(16)]
        [Display(Name = "Numer inwertera")]
        public string AKartaWyjazduNumerInwertera { get; set; }

        [Required(ErrorMessage = "Wprowadz numer wifi ")]
        [StringLength(11)]
        [Display(Name = "Numer Wifi")]
        public string AKartaWyjazduNumerWifi { get; set; }

        [Required]
        [Display(Name = "OnLine", ShortName = "OnLine")]
        public bool AKartaWyjazduOnLine { get; set; } = false;

        //liczba stringów
        //1
        [Display(Name = "PV1")]
        public int AKartaWyjazduPV1 { get; set; }
        [Display(Name = "PV1 liczba paneli")]
        public int AKartaWyjazduPV1LiczbaPaneli { get; set; }
        [StringLength(250)]
        [Display(Name = "PV1 kierunek")]
        public string AKartaWyjazduPV1Kierunek { get; set; }
        //2
        [Display(Name = "PV2")]
        public int AKartaWyjazduPV2 { get; set; }
        [Display(Name = "PV2 liczba paneli")]
        public int AKartaWyjazduPV2LiczbaPaneli { get; set; }
        [StringLength(250)]
        [Display(Name = "PV2 kierunek")]
        public string AKartaWyjazduPV2Kierunek { get; set; }
        //3
        [Display(Name = "PV3")]
        public int AKartaWyjazduPV3 { get; set; }
        [Display(Name = "PV3 liczba paneli")]
        public int AKartaWyjazduPV3LiczbaPaneli { get; set; }
        [StringLength(250)]
        [Display(Name = "PV3 kierunek")]
        public string AKartaWyjazduPV3Kierunek { get; set; }




        //inne dane z inwertera
        [StringLength(250)]
        [Display(Name = "Kody błędów")]
        public string AKartaWyjazduKodyBledow { get; set; }

        [StringLength(250)]
        [Display(Name = "Softy")]
        public string AKartaWyjazduSofty { get; set; }

        [StringLength(250)]
        [Display(Name = "Norma")]
        public string AKartaWyjazduNoramPanstwo { get; set; }

        //zabezpieczenia
        [Required]
        [Display(Name = "Ogranicznik przepieć AC", ShortName = "Ogranicznik przepieć AC")]
        public bool AKartaWyjazduOgranicznikPrzepiecAC { get; set; } = false;

        [Required]
        [Display(Name = "Ogranicznik przepieć DC", ShortName = "Ogranicznik przepieć DC")]
        public bool AKartaWyjazduOgranicznikPrzepiecDC { get; set; } = false;

        [Required]
        [Display(Name = "Bezpiecznik AC", ShortName = "Bezpiecznik AC")]
        public bool AKartaWyjazduBezpiecznikAC { get; set; } = false;

        [Required]
        [Display(Name = "Bezpiecznik DC", ShortName = "Bezpiecznik DC")]
        public bool AKartaWyjazduBezpiecznikDC { get; set; } = false;

        [Required]
        [Display(Name = "Uziemienie inwertera", ShortName = "Uziemienie inwertera")]
        public bool AKartaWyjazduUziemienieInwertera { get; set; } = false;



        //dane logownia
        [StringLength(250)]
        [Display(Name = "Login Email klienta")]
        public string AKartaWyjazduLoginKlienta { get; set; }

        [StringLength(250)]
        [Display(Name = "Haslo")]
        public string AKartaWyjazduHasloKlienta { get; set; }


        //uwagi koncowe
        [StringLength(250)]
        [Display(Name = "Spostrzeżenia")]
        public string AKartaWyjazduSpostrzezenia { get; set; }

        [StringLength(250)]
        [Display(Name = "Dzialania")]
        public string AKartaWyjazduDzialania { get; set; }


        //dane dotyczace zapisu
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Data dodawania zapisu")]
        // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime AKartaWyjazduDataTworzenia { get; set; }

        [StringLength(70)]
        [Display(Name = "Operor dodajacy zapis")]
        public String AKartaWyjazduOperatorTw { get; set; }


        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Data modyfikacji zapisu")]
        //  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime AKartaWyjazduDatamodyfikacji { get; set; }

        [StringLength(70)]
        [Display(Name = "Operor modyfikujacy zapis")]
        public String AKartaWyjazduOperatorMd { get; set; }


        public virtual AWojewodztwo AWojewodztwo { get; set; }

        public virtual AMiasta AMiejscowosc { get; set; }

        public virtual ASerwisanci ASerwisanci { get; set; }

        public virtual AInwertery AInwertera { get; set; }


    }
}