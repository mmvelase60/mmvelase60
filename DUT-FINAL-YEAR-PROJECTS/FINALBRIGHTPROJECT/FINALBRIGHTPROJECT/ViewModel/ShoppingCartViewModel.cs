using FINALBRIGHTPROJECT.ViewModel;
using FINALBRIGHTPROJECT.ViewModel.BrightModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FINALBRIGHTPROJECT.ViewModel
{
    public class ShoppingCartViewModel
    {
        public string Id { get; set; }
        public List<Cart> CartItems { get; set; }
        public decimal CartTotal { get; set; }
    }
}