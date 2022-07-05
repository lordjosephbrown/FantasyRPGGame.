using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FantasyRPGGame.Model;

namespace FantasyRPGGame.UnitTesting
{
    public class DummyCreature : Creature
    {
        public DummyCreature(IRandom random) : base(random)
        {
        }
        public override string Race => "DummyCreature";
    }

}
