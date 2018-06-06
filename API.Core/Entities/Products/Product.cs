using API.Framework.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Core.Entities
{
    /// <summary>
    /// Product entity
    /// </summary>
    public class Product : BaseEntity
    {
        /// <summary>
        /// Product Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Price
        /// </summary>
        public double Price { get; set; }
        /// <summary>
        /// Category Id
        /// </summary>
        public int CategoryId { get; set; }
        /// <summary>
        /// Category
        /// </summary>
        public virtual Category Category { get; set; }

    }

    /// <summary>
    /// Product mapping
    /// </summary>
    public class ProductMap : EntityTypeConfiguration<Product>
    {
        public ProductMap()
        {
            this.ToTable("Product");
            this.HasKey(c => c.Id);

            this.HasRequired(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId);
        }
    }
}
