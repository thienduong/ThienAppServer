using API.Framework.Caching;
using API.Framework.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Framework.Services
{
    public abstract class BaseService<T> : IBaseService<T> where T : BaseEntity
    {
        private readonly IRepository<T> _tRepository;
        private readonly ICacheManager _cacheManager;
        public BaseService(IRepository<T> tRepository,
            ICacheManager cacheManager)
        {
            this._tRepository = tRepository;
            this._cacheManager = cacheManager;
        }

        protected abstract string PatternKey { get; }
        #region Synchronous
        public virtual void Insert(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("enity");
            _cacheManager.RemoveByPattern(PatternKey);

            _tRepository.Insert(entity);
        }

        public void Insert(List<T> entities)
        {
            foreach (var entity in entities)
            {
                if (entity == null)
                    throw new ArgumentNullException("enity");
            }

            _cacheManager.RemoveByPattern(PatternKey);

            _tRepository.Insert(entities);
        }

        public virtual void Update(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("enity");

            _cacheManager.RemoveByPattern(PatternKey);

            _tRepository.Update(entity);
        }

        public virtual void Update(List<T> entities)
        {
            foreach (var entity in entities)
            {
                if (entity == null)
                    throw new ArgumentNullException("enity");
            }

            _cacheManager.RemoveByPattern(PatternKey);

            _tRepository.Update(entities);
        }

        public virtual void Delete(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("enity");

            _cacheManager.RemoveByPattern(PatternKey);

            _tRepository.Delete(entity);
        }

        public virtual void Delete(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                if (entity == null)
                    throw new ArgumentNullException("enity");
            }

            _cacheManager.RemoveByPattern(PatternKey);

            _tRepository.Delete(entities);
        }

        public virtual T GetById(int id)
        {
            if (id == 0)
                return null;

            var key = string.Format(PatternKey + "byid-{0}", id);

            return _cacheManager.Get(key, () => _tRepository.GetById(id));
        }

        public virtual List<T> GetByIds(List<int> ids)
        {
            return _tRepository.Table.Where(t => ids.Contains(t.Id)).ToList();
        }

        public virtual IList<T> GetAll()
        {
            var key = string.Format(PatternKey + "all");

            return _cacheManager.Get(key, () =>
            {
                return _tRepository.Table.ToList();
            });
        }

        public virtual IPagedList<T> GetAll(int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var key = string.Format(PatternKey + "all");

            return _cacheManager.Get(key, () =>
            {
                var query = _tRepository.Table.OrderBy(x => x.Id);
                return new PagedList<T>(query, pageIndex, pageSize);
            });
        }

        public virtual bool CheckExist(Func<T, bool> fieldCheck, int? entityId = null)
        {
            var query = _tRepository.Table;
            if (entityId.HasValue)
            {
                query = query.Where(x => x.Id != entityId);
            }
            return query.Any(fieldCheck);
        }
        #endregion
        #region Asynchronous
        public virtual async Task InsertAsync(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("enity");
            _cacheManager.RemoveByPattern(PatternKey);

            await _tRepository.InsertAsync(entity);
        }

        public virtual async Task InsertAsync(List<T> entities)
        {
            foreach (var entity in entities)
            {
                if (entity == null)
                    throw new ArgumentNullException("enity");
            }

            _cacheManager.RemoveByPattern(PatternKey);

            await _tRepository.InsertAsync(entities);
        }

        public virtual async Task UpdateAsync(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("enity");

            _cacheManager.RemoveByPattern(PatternKey);

            await _tRepository.UpdateAsync(entity);
        }

        public virtual async Task UpdateAsync(List<T> entities)
        {
            foreach (var entity in entities)
            {
                if (entity == null)
                    throw new ArgumentNullException("enity");
            }

            _cacheManager.RemoveByPattern(PatternKey);

            await _tRepository.UpdateAsync(entities);
        }

        public virtual async Task DeleteAsync(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("enity");

            _cacheManager.RemoveByPattern(PatternKey);

            await _tRepository.DeleteAsync(entity);
        }

        public virtual async Task DeleteAsync(List<T> entities)
        {
            foreach (var entity in entities)
            {
                if (entity == null)
                    throw new ArgumentNullException("enity");
            }

            _cacheManager.RemoveByPattern(PatternKey);

            await _tRepository.DeleteAsync(entities);
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            if (id == 0)
                return null;

            var key = string.Format(PatternKey + "byidAsync-{0}", id);

            return await _cacheManager.Get(key, async () => {
                return await _tRepository.GetByIdAsync(id);
            });

        }

        public virtual Task<List<T>> GetByIdsAsync(List<int> ids)
        {
            return _tRepository.Table.Where(t => ids.Contains(t.Id)).ToListAsync();
        }

        public virtual async Task<IList<T>> GetAllAsync()
        {
            var key = string.Format(PatternKey + "allAsync");

            return await _cacheManager.Get(key, async () =>
            {
                return await _tRepository.Table.ToListAsync();
            });
        }

        public virtual async Task<IPagedList<T>> GetAllAsync(int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var key = string.Format(PatternKey + "all");

            return await _cacheManager.Get(key, async () =>
            {
                var query = await _tRepository.Table.ToListAsync();
                return await Task.FromResult(new PagedList<T>(query, pageIndex, pageSize) as IPagedList<T>);
            });
        }

        public virtual async Task<bool> CheckExistAsync(Func<T, bool> fieldCheck, int? entityId = null)
        {
            var query = _tRepository.Table;
            if (entityId.HasValue)
            {
                query = query.Where(x => x.Id != entityId);
            }
            return await Task.FromResult(query.Any(fieldCheck));
        }

        #endregion
    }
}
