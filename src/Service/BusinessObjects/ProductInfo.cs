using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.BusinessObjects
{
    public class ProductInfo
    {
        public String ProductId { get; set; }
        public String Brand { get; set; }
        public String Model { get; set; }
        public Decimal Price { get; set; }
        public Int32 CountryMakerId { get; set; }
    }
}
