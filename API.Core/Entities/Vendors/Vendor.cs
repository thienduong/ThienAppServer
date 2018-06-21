using API.Framework.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Core.Entities.Vendors
{
    public class Vendor : BaseEntity
    {     
        public string vendorName { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
