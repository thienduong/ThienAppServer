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
    public class CategoryService: BaseService<Category>, ICategoryService
    {
        private readonly IRepository<Category> _tRepository;
        private readonly ICacheManager _cacheManager;
        public CategoryService(IRepository<Category> tRepository,
            ICacheManager cacheManager) : base(tRepository, cacheManager)
        {
            this._tRepository = tRepository;
            this._cacheManager = cacheManager;
        }
        protected override string PatternKey
        {
            get
            {
                return "Category.";
            }
        }

        public List<Category> Search(string textSearch)
        {
            var qurery = this._tRepository.Table.AsQueryable();
            if (!string.IsNullOrEmpty(textSearch))
                qurery = qurery.Where(x => x.Name.Contains(textSearch));
            return qurery.ToList();
        }
    }
}
