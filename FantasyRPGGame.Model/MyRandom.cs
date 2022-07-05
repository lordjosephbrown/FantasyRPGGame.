using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyRPGGame.Model
{
    public class MyRandom : IRandom
    {
        public int Next(int num1)
        {
            Random rnd = new Random();
            return rnd.Next(num1);
        }
        public int Next(int num1,int num2)
        {
            Random rnd = new Random();
            return rnd.Next(num1,num2);
        }
    }
}
