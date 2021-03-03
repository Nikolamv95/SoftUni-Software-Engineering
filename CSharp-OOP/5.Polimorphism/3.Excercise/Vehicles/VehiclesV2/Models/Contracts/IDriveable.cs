using System;
using System.Collections.Generic;
using System.Text;

namespace VehiclesV2.Models.Contracts
{
    public interface IDriveable
    {
        string Drive(double amount);
    }
}
