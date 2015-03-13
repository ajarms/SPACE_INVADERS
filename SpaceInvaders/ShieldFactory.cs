using System;

namespace SpaceInvaders
{
    class ShieldFactory: Factory
    {
        private ShieldFactory()
            :base()
        {}

        private static ShieldFactory getInstance()
        {
            if (instance == null)
            {
                instance = new ShieldFactory();
            }
            return instance;
        }

        public static PCSTree getTree()
        {
            ShieldFactory tmp = ShieldFactory.getInstance();

            return tmp.tree;
        }

        
        public static void makeShields()
        {
            makeShield(1.0f, 1.0f);
        }

        private static void makeShield(float xPos, float yPos)
        {
        }


        //---------------------------------------
        private static ShieldFactory instance;
    }
}
