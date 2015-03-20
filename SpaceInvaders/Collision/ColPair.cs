using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class ColPair:MLink
    {
        public enum Name
        {
            // ADD ALL PAIRS HERE
            Alien_Missile,
            Alien_Wall,
            Alien_Shield,
            Alien_Player,
            Player_Bomb,
            Player_Wall,
            UFO_Missile,
            UFO_Wall,
            Shield_Missile,
            Shield_Bomb,
            Bomb_Wall,
            Missile_Wall,
            Missile_Bomb,
            NOT_INITIALIZED
        }

        public ColPair()
        {
            this.name = ColPair.Name.NOT_INITIALIZED;
            this.index = Index._0;

            this.sub = new Subject();
            this.treeA = null;
            this.treeB = null;
        }

        public void set(ColPair.Name _name, GameObj rootA, GameObj rootB)
        {
            this.name = _name;

            Debug.Assert(rootA != null);
            this.treeA = rootA;

            Debug.Assert(rootB != null);
            this.treeB = rootB;
        }

        public void setSubs(GameObj objA, GameObj objB)
        {
            sub.set(objA, objB);
        }

        public void attach(Observer obs)
        {
            sub.attach(obs);
        }

        public static bool collide(GameObj objA, GameObj objB)
        {
            Debug.Assert(objA != null && objB != null);
            // TODO MAKE THINGS BREAK
            // bash trees till the branches are empty
            // visitor pattern will handle progression through the collision trees
            // bash top level and watch the magic happen

            // do they collide?
            if (objA.collision.intersect(objB.collision))
            {
                // go pay them a visit
                objA.accept(objB);
                return true;
            }
            return false;
        }

        public override Enum getName()
        {
            return name;
        }

        public override Enum getIndex()
        {
            return index;
        }

        //------------------------------------------
        public Name name;
        public Index index = Index._0;

        public Subject sub;
        public GameObj treeA;
        public GameObj treeB;
    }
}
