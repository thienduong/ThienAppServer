using API.Core.Entities;
using API.Framework.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Core.Services
{
    public interface ICategoryService : IBaseService<Category>
    {
        List<Category> Search(string textSearch);
    }
}
