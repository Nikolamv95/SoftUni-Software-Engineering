using System.Collections.Generic;

namespace MilitaryElite.Contracts
{
    public interface ILieutenantGeneral : IPrivate
    {
        //We increased the level of abstraction becase we cannot add privates to the collection. If we cant access a prop or method always put the base class
        //as preffered type of data
        IReadOnlyCollection<ISoldier> Privates { get;}

        void AddPrivate(ISoldier newPrivate);
    }
}
