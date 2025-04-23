using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_PintPoint.Entities
{
    public class UserAddress
    {
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string PostCode { get; set; }
        public int IdCity { get; set; }
        public int AddressId { get; set; }
    }
}
