using Swashbuckle.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace API.Framework
{
    public interface ISwaggerUi
    {
        void Apply(Assembly assembly, SwaggerUiConfig config);
    }
}
