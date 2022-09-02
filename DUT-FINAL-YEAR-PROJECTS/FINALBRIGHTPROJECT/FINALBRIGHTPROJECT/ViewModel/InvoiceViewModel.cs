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
public class InvoiceViewModel
{
[Key]
public int inViewID { get; set; }
        [DisplayName("UserName")]

        public string InvoUserNameV { get; set; }
      //  [DisplayName("C_FirstName")]

        public string InvcustFnameV { get; set; }
       // [DisplayName("C_LName")]

        public string InvcustLnameV { get; set; }
       // [DisplayName("Surname")]

        public string InvocustSurnameV { get; set; }
        [DisplayName("RSA_ID")]

        public string invoIdentity { get; set; }

        public string cellNumber { get; set; }
        // [DisplayName("Customer FirstName")]
        [DisplayName("Call NO:")]

        public string invoTelV { get; set; }
        [DisplayName("Size")]

        public string invotentSizV { get; set; }
        [DisplayName("Type")]

        public string invotentTypV { get; set; }
        [DisplayName("QTY")]

        public int invQtyV { get; set; }
        [DisplayName("Price")]

        public decimal invotentPriceV { get; set; }
        [DisplayName("TotalPrice")]

        public decimal invTotalV { get; set; }
       [DisplayName("D_Lname")]

        public string invodrvLnameView { get; set; }
       [DisplayName("D_Surname")]

        public string InvodrvSurnameV { get; set; }
        [DisplayName("Date")]

        public DateTime InvoDateV { get; set; }
        [DisplayName("Time")]

        public DateTime InvoTimeV { get; set; }
        [DisplayName("ownerNo:")]

        public string ownerCell { get; set; }
     }
}