using System;

namespace SpaceInvaders
{
    // flyweights for similar sprites
    class FSprite: BSprite
    {
        public FSprite(BSprite.Name _name, Index _index, BSprite _sprite, float x, float y)
            : base()
        {
            this.target = _sprite;
            this.name = _name;
            this.index = _index;
            this.x = x;
            this.y = y;
        }

        ~FSprite()
        {
            this.target = null;
        }

        public override void update()
        {
            target.x = this.x;
            target.y = this.y;
            target.update();
        }

        public override void draw()
        {
            target.draw();
        }

        public override float getWidth()
        {
            return target.getWidth();
        }

        public override float getHeight()
        {
            return target.getHeight();
        }

        //-----------------------
        
        public BSprite target;

    }
}
