using API.Framework.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Framework.Services
{
    public interface IBaseService<T> where T : BaseEntity
    {
        #region Synchronous
        T GetById(int id);
        List<T> GetByIds(List<int> ids);
        void Insert(T enity);
        void Insert(List<T> entities);
        void Update(T entity);
        void Update(List<T> entities);
        void Delete(T entity);
        void Delete(IEnumerable<T> entities);
        IList<T> GetAll();
        IPagedList<T> GetAll(int pageIndex = 0, int pageSize = int.MaxValue);
        bool CheckExist(Func<T, bool> fieldCheck, int? entityId = null);
        #endregion

        #region Asynchronous
        Task<T> GetByIdAsync(int id);
        Task<List<T>> GetByIdsAsync(List<int> ids);
        Task InsertAsync(T enity);
        Task InsertAsync(List<T> entities);
        Task UpdateAsync(T entity);
        Task UpdateAsync(List<T> entities);
        Task DeleteAsync(T entity);
        Task DeleteAsync(List<T> entities);
        Task<IList<T>> GetAllAsync();
        Task<IPagedList<T>> GetAllAsync(int pageIndex = 0, int pageSize = int.MaxValue);
        Task<bool> CheckExistAsync(Func<T, bool> fieldCheck, int? entityId = null);
        #endregion
    }
}
