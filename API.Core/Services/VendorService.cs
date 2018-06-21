using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Core.Entities;
using API.Framework.Caching;
using API.Framework.Data;
using API.Framework.Services;

namespace API.Core.Services
{
    public class VendorService : BaseService<Vendor>, IVendorService
    {
        private readonly IRepository<Vendor> _tRepository;
        private readonly ICacheManager _cacheManager;
        public VendorService(IRepository<Vendor> tRepository, ICacheManager cacheManager) : base(tRepository , cacheManager)
        {
            this._tRepository = tRepository;
            this._cacheManager = cacheManager;

        }
        protected override string PatternKey
        {
            get
            {
                return "Vendor.";
            }
        }

    }
}
