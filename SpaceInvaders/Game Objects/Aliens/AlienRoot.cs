using System;

namespace SpaceInvaders
{
    class AlienRoot: _Alien
    {
        public AlienRoot(float _x, float _y)
            : base(GameObj.Name.AlienRoot, Index._0, BSprite.Name.NullSprite, new Azul.Color(0.0f, 0.0f, 250.0f))
        {
            this.x = _x;
            this.y = _y;
            this.total = _x;
        }

        public override void move(float deltaX, float deltaY)
        {
            float width = 640.0f;
            GameObj pChild = this.child as GameObj;

            if (this.total + width > Constants.SCREEN_WIDTH - ImgMan.find(Image.Name.Octopus_0).rect.w / 4 || this.total < ImgMan.find(Image.Name.Octopus_0).rect.w / 4)
            {
                this.direction *= -1.0f;
                pChild.move(2.0f * this.direction, deltaY);
                this.x += 2.0f * this.direction;
                this.y += deltaY;
            }
            else
            {
                pChild.move(deltaX * this.direction, 0.0f);
                this.x += deltaX * this.direction;
            }

            this.total += deltaX * this.direction;
        }

        public override void update()
        {
            // add union updating
            base.unionUpdate();
        }

        //-----------------------------------
        // visitor handlers
        //-----------------------------------

        public override void accept(GameObj that)
        {
            that.visitAlienRoot(this);
        }

        public override void visitMissileRoot(GameObj other)
        {
            // drop one level
            GameObj curr = this.child as GameObj;

            // collide against everything at this level
            while (curr != null)
            {
                if (ColPair.collide(curr, other))
                {
                    return;
                }

                curr = curr.sibling as GameObj;
            }
        }

        public override void visitWallRoot(GameObj other)
        {
            other.visitAlienRoot(this);
        }

        public override void visitWallSides(GameObj other)
        {
            Subject tmp = ColMan.getActivePair().sub;

            tmp.set(this, other);
            tmp.notify();
        }

        public override void visitShield(GameObj other)
        {
            // drop one level
            GameObj curr = this.child as GameObj;

            // collide against everything at this level
            while (curr != null)
            {
                ColPair.collide(curr, other);

                curr = curr.sibling as GameObj;
            }
        }

        public override void visitPlayerRoot(GameObj other)
        {
            // drop one level
            GameObj curr = this.child as GameObj;

            // collide against everything at this level
            while (curr != null)
            {
                ColPair.collide(curr, other);

                curr = curr.sibling as GameObj;
            }
        }

        private float direction = 1.0f;
        private float total;
    }
}
