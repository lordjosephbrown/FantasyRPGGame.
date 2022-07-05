using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyRPGGame.Model
{
    public class Battle
    {
        private List<Creature> creatures = new List<Creature>();
        public List<string> Messages = new List<string>();
        public int winCondition = 0;

        public void AddCreature(Creature creature) 
        {
            creatures.Add(creature);
        }

        public Creature ReturnCreature(int index) 
        {
            return creatures[index];
        }

        public void RemoveCreature(int index)
        {
            creatures.RemoveAt(index);
        }

        public int Due1(int index1, int index2) 
        {
            //Messages = new List<string>();
            int winCondition = 2;
            while (creatures[index1].HitPoints > 0 && creatures[index2].HitPoints > 0) 
            {

                if (creatures[index1].HitPoints > 0 && creatures[index2].HitPoints > 0)
                {
                    Messages.Add($"{creatures[index1].Race} attacks {creatures[index2].Race}");
                    int attact1  = creatures[index1].Attack(creatures[index2]);
                    Messages.Add($"{creatures[index1].Race} deals {attact1} damage to the {creatures[index2].Race}");
                    Messages.Add($"{creatures[index2].Race}'s health: {creatures[index2].HitPoints}");
                    Messages.Add($"{creatures[index2].Race} attacks {creatures[index1].Race}");
                    int attact2 = creatures[index2].Attack(creatures[index1]);
                    Messages.Add($"{creatures[index2].Race} deals {attact2} damage to the {creatures[index1].Race}");
                    Messages.Add($"{creatures[index1].Race} health: {creatures[index1].HitPoints}");
                    
                }
                    
                
            }
            Messages.Add($"----------------------------------");
            Messages.Add($"{creatures[index1].Race} health: {creatures[index1].HitPoints}");
            Messages.Add($"{creatures[index2].Race} health: {creatures[index2].HitPoints}");
            if (creatures[index1].HitPoints <= 0 && creatures[index2].HitPoints <= 0)
            {
                Messages.Add("It's a tie");
                Messages.Add("The battle has ended");
                winCondition = -1;
            }
            else if (creatures[index1].HitPoints <= 0 && creatures[index2].HitPoints > 0)
            {
                Messages.Add($"{creatures[index2].Race} has defeated {creatures[index1].Race}");
                Messages.Add("The battle has ended");
                winCondition = index2;
            }
            else if (creatures[index1].HitPoints > 0 && creatures[index2].HitPoints <= 0)
            {
                Messages.Add($"{creatures[index1].Race} has defeated {creatures[index2].Race}");
                Messages.Add("The battle has ended");
                winCondition = index1;
            }
            Messages.Add($"----------------------------------");
            return winCondition;
        }
    }
}
