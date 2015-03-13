using System;

namespace SpaceInvaders
{
    class BatchNode: SubLink
    {
        public BatchNode()
            : base()
        {
            this.sprite = null;
        }

        ~BatchNode()
        {
            this.sprite = null;
        }

        public override Enum getName()
        {
            return this.sprite.name;
        }

        // need to refactor to search for game objects
        public void set(BSprite _sprite)
        {
            this.sprite = _sprite;
        }

        // draw the referenced object
        public void draw()
        {
            this.sprite.update();
            this.sprite.draw();
        }

        public BSprite sprite;
    }
}
