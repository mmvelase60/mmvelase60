using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;

namespace FINALBRIGHTPROJECT.ViewModel
{
    public class DeliveryViewModel
    {
        [Key]
        [Display(Name = " ID ")]

        public int delID { get; set; }
        [Display(Name = " C_Lastname ")]

        public string delcustLnameV { get; set; }
        [Display(Name = " C_Surname ")]

        public string DelSurnameV { get; set; }
        [Display(Name = " Phone No: ")]

        public string delTelv { get; set; }
        [Display(Name = " USerName ")]

        public string UserName { get; set; }
        [Display(Name = " Size ")]

        public string deltentSizV { get; set; }
        [Display(Name = " Type ")]

        public string DeltentTyp { get; set; }
        [Display(Name = " QTY ")]

        public int DelQtyv { get; set; }
       // [Display(Name = " Drv_LName ")]

        public string drvLnameV { get; set; }
        [Display(Name = " Date ")]

        public DateTime deliverdateV { get; set; }
        [Display(Name = " Time ")]

        public DateTime delivertTimeV { get; set; }
        [Display(Name = " C_Date ")]

        public DateTime deldateCollectedV { get; set; }
        [Display(Name = " Address ")]
        public string DelAddressV { get; set; }
        [Display(Name = " City ")]

        public string DelCityV { get; set; }
        [Display(Name = " Code ")]

        public string PostalCodeV { get; set; }
        [Display(Name = " Status ")]

        public string DelstatusV { get; set; }


    }

}