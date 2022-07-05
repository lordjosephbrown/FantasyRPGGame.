namespace FantasyRPGGame.Model
{
    public abstract class Creature
    {
        public virtual int Strength { get; set; }
        public virtual int HitPoints { get; set; }
        public abstract string Race { get; }

        //private Random _random;
        protected IRandom _random;

        public Creature(IRandom random)
        {
            _random = random;
            Strength = 50;
            HitPoints = 100;
        }

        public virtual int TakeDamage(int damage)
        {
            // All creatures have a 1% chance of dodging the damage
            if (_random.Next(100) < 1)
            {
                damage = 0;
            }
            HitPoints -= damage;
            return damage;
        }

        public virtual int CalculateDamage()
        {
            int damage = 0;

            // All creatures inflict damage that is a random number up to their strength
            // with a minimum damage of 1
            damage = _random.Next(Strength) + 1;
            return damage;
        }

        public virtual int Attack(Creature creature)
        {
            return creature.TakeDamage(CalculateDamage());
        }
    }

}
   