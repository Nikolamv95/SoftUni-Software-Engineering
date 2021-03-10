using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace MappingObjectsNew
{
    public interface IHaveCustomMapping
    {
        void CreateMapping(IProfileExpression configuration);
    }
}
