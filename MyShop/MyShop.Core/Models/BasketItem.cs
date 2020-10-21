using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Core.Models
{
    public class BasketItem: BaseEntity
    {
        public string BasketId { get; set; }
        public string ProductId { get; set; }
        public int Quantity { get; set; }
        public static class Cultures
        {
            public static readonly CultureInfo UnitedKingdom =
                CultureInfo.GetCultureInfo("en-GB");
        }
    }

}
