using System;
using System.Collections.Generic;
using System.Text;

namespace FakeAxeAndDummy.Tests.Fakes
{
    public class IWeaponFake : IWeapon
    {
        public int AttackPoints => 100;

        public int DurabilityPoints => 50;

        public void Attack(ITarget target)
        {
            
        }
    }
}
