using Swashbuckle.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Framework
{
    public interface IPathItem
    {
        /// <summary>
        /// Return a PathItem
        /// </summary>
        /// <returns></returns>
        PathItem GetPathItem();
        /// <summary>
        /// Return an api key
        /// </summary>
        /// <returns></returns>
        string GetApiKey();
    }
}
