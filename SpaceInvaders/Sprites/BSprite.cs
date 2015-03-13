using System;

namespace SpaceInvaders
{
    
    // base class for all sprites
    abstract class BSprite: MLink
    {
        public enum Name
        {
            Player_Ship,
            Ship_Base,
            Ship_Blaster,
            UFO,
            Missile,
            BombA,
            BombB,
            BombC,
            Shield,
            Shield_Block,
            Shield_UpperRight,
            Shield_UpperLeft,
            Shield_SmallBlock,
            Red_Bird,
            Octopus,
            Squid,
            Crab,
            NullSprite,
            NOT_INITIALIZED
        }

        protected BSprite()
            : base()
        {
            this.name = BSprite.Name.NOT_INITIALIZED;
            this.y = 0.0f;
            this.x = 0.0f;
        }

        public void batchRemove()
        {
            if (this.batch != null)
            {
                batch.remove(this);
            }
        }

        public override Enum getName()
        {
            return this.name;
        }

        override public Enum getIndex()
        {
            return this.index;
        }

        abstract public void draw();

        abstract public void update();

        abstract public float getHeight();

        abstract public float getWidth();

        //------------------------------
        public Name name;
        public Index index;
        public SpriteBatch batch = null;
        public float x;
        public float y;
    }
}
