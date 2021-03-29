using System;
using System.Collections.Generic;
using System.Text;

namespace SUS.MvcFramework
{
    public interface IServiceCollection
    {
        //.Add<IUsersService(Put the mather interface), UsersService(put the service which inherits the mather interface)>
        void Add<TSource, TDestination>();

        object CreateInstance(Type type);
    }
}
