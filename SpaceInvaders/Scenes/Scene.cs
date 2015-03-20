using System;

namespace SpaceInvaders
{
    abstract class Scene: MLink
    {
        public enum Name
        {
            Attract_Screen,
            Splash_Screen,
            Player1_Game,
            Player2_Game,
        }

        protected Scene(Scene.Name _name)
            :base()
        {
            this.name = _name;
        }

        public abstract void update(float totalTime);

        public abstract void draw();

        public override Enum getName()
        {
            return this.name;
        }

        public override Enum getIndex()
        {
            return null;
        }

        public Name name;
    }
}
