using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Framework
{
    public interface IMapperRegistrar
    {
        void Register(IMapperConfigurationExpression config);

        int Order { get; }
    }
}
