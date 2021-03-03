using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Contracts
{
    interface ISpy : ISoldier
    {
        int CodeNumber { get; }
    }
}
