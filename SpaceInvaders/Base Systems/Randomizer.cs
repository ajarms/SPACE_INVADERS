using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class Randomizer
    {
        private Randomizer()
        {
            this.rand = new Random();
        }

        ~Randomizer()
        {
            this.rand = null;
        }

        public static void create()
        {
            Debug.Assert(instance == null);
            if (instance == null)
            {
                instance = new Randomizer();
            }
        }

        private static Randomizer getInstance()
        {
            Debug.Assert(instance != null);
            
            return instance;
        }

        public static bool randBool()
        {
            Randomizer tmp = Randomizer.getInstance();

            return Convert.ToBoolean(tmp.rand.Next(0, 2));
        }

        public static float randFloat()
        {
            Randomizer tmp = Randomizer.getInstance();

            return (float)tmp.rand.NextDouble();
        }

        public static int randInt(int min, int max)
        {
            Randomizer tmp = Randomizer.getInstance();

            return tmp.rand.Next(min, max);
        }

        //-------------------
        private static Randomizer instance;
        private Random rand;
    }
}
