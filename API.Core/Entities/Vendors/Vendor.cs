using API.Framework.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Core.Entities
{
    public class Vendor : BaseEntity
    {     
        public string Name { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
