using API.Core.Entities;
using API.Framework.Caching;
using API.Framework.Data;
using API.Framework.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Core.Services
{
    /// <summary>
    /// Product service
    /// </summary>
    public class ProductService : BaseService<Product>, IProductService
    {
        private readonly IRepository<Product> _tRepository;
        private readonly ICacheManager _cacheManager;
        public ProductService(IRepository<Product> tRepository,
            ICacheManager cacheManager) : base(tRepository, cacheManager)
        {
            this._tRepository = tRepository;
            this._cacheManager = cacheManager;
        }

        protected override string PatternKey
        {
            get
            {
                return "Product.";
            }
        }
    }
}
