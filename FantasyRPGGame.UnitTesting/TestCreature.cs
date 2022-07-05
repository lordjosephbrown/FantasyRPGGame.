using FantasyRPGGame.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyRPGGame.UnitTesting
{
    public class TestCreature : Creature
    {
        public int Damage { get; set; }
        public TestCreature(IRandom random = null) : base(random)
        {
        }

        public override string Race => "TestCreature";

        public override int Attack(Creature creature)
        {
            return creature.TakeDamage(Damage);
        }
    }
}
