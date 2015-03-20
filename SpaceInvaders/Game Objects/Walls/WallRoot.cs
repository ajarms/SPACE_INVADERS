using System;

namespace SpaceInvaders
{
    class WallRoot: _Wall
    {
        public WallRoot()
            : base(GameObj.Name.WallRoot, Index._0, BSprite.Name.NullSprite, new Azul.Color(0.0f, 0.0f, 250.0f))
        {
            this.x = 0.0f;
            this.y = 0.0f;
        }

        public override void update()
        {
            base.unionUpdate();
        }

        //-----------------------------------
        // visitor handlers
        //-----------------------------------

        public override void accept(GameObj that)
        {
            that.visitWallRoot(this);
        }

        public override void visitAlienRoot(GameObj other)
        {
            // step through children
            // collide with side walls
            _Wall curr = this.child as _Wall;

            while (curr != null)
            {
                if ((curr is WallRight) || (curr is WallLeft))
                {
                    if (ColPair.collide(curr, other))
                    {
                        return;
                    }
                }
                curr = curr.sibling as _Wall;
            }
        }

        public override void visitMissileRoot(GameObj other)
        {
            // step through children
            // collide with top wall
            _Wall curr = this.child as _Wall;

            while (curr != null)
            {
                if (curr is WallTop)
                {
                    ColPair.collide(curr, other);
                    return;
                }
                curr = curr.sibling as _Wall;
            }
        }

        public override void visitBombRoot(GameObj other)
        {
            // step through children
            // collide with bottom wall
            _Wall curr = this.child as _Wall;

            while (curr != null)
            {
                if (curr is WallBottom)
                {
                    ColPair.collide(curr, other);
                    return;
                }
                curr = curr.sibling as _Wall;
            }
        }

        public override void visitPlayerRoot(GameObj other)
        {
            // step through children
            // collide with side walls
            _Wall curr = this.child as _Wall;

            while (curr != null)
            {
                if ((curr is WallRight) || (curr is WallLeft))
                {
                    ColPair.collide(curr, other);
                }
                curr = curr.sibling as _Wall;
            }
        }

        public override void visitUFORoot(GameObj other)
        {
            // step through children
            // collide with side walls
            _Wall curr = this.child as _Wall;

            while (curr != null)
            {
                if ((curr is WallRight) || (curr is WallLeft))
                {
                    ColPair.collide(curr, other);
                }
                curr = curr.sibling as _Wall;
            }
        }
    }
}
