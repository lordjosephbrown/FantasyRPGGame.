using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyRPGGame.Model
{
    public class Demons : Creature
    {

        public Demons(IRandom random) : base(random)
        {
        }

        public override string Race => "Demon";

        public override int CalculateDamage()
        {
            int damage = 0;

            // All creatures inflict damage that is a random number up to their strength
            // with a minimum damage of 1
            damage = base.CalculateDamage();
            if (_random.Next(50) < 25)
            {
                damage += 10;
            }
            return damage;
        }
    }
}
