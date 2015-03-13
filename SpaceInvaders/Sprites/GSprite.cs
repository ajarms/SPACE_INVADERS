using System;

namespace SpaceInvaders
{
    // class for game sprites
    class GSprite: BSprite
    {
        
        public GSprite()
            : base()
        {
            this.img = null;
            this.sprite = null;
            this.index = Index._0;
            this.sx = 1.0f;
            this.sy = 1.0f;
            this.angle = 0.0f;
        }

        protected GSprite(BSprite.Name _name, Index _index)
            : base()
        {

        }

        ~GSprite()
        {
            this.img = null;
            this.sprite = null;
        }

        public void set(BSprite.Name inName, Image inImg, float x, float y, float inSx = 1.0f, float inSy = 1.0f, float inAngle = 0.0f)
        {
            this.name = inName;
            this.img = inImg;
            this.x = x;
            this.y = y;
            this.sx = inSx;
            this.sy = inSy;
            this.angle = inAngle;
            this.sprite = new Azul.Sprite2D(inImg.text.text,
                                            inImg.rect,
                                            new Azul.Rect(x, y, inImg.rect.w, inImg.rect.h));
        }

        override public void update()
        {
            this.sprite.x = this.x;
            this.sprite.y = this.y;
            this.sprite.angle = this.angle;
            this.sprite.sx = this.sx;
            this.sprite.sy = this.sy;
            this.sprite.swapImage(this.img.rect);
        }

        override public void draw()
        {
            sprite.Draw();
        }

        public override float getWidth()
        {
            return this.img.rect.w * this.sx;
        }

        public override float getHeight()
        {
            return this.img.rect.h * this.sy;
        }

        //-----------------------------
        public Image img;
        public Azul.Sprite2D sprite;
        protected float sx;
        protected float sy;
        protected float angle;
    }
}
