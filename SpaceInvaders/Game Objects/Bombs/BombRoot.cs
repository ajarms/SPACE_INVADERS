using System;

namespace SpaceInvaders
{
    class BombRoot: _Bomb
    {
        public BombRoot(Index index = Index._0, float _x = 0.0f, float _y = 0.0f)
            : base(GameObj.Name.BombRoot, index, BSprite.Name.NullSprite, new Azul.Color(0.0f, 0.0f, 250.0f))
        {
            this.x = _x;
            this.y = _y;
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
            that.visitBombRoot(this);
        }

        public override void visitWallBottom(GameObj other)
        {
            // step through children
            // when a collision is found
            GameObj curr = this.child as GameObj;

            while (curr != null)
            {
                if (ColPair.collide(curr, other))
                {
                    return;
                }
                curr = curr.sibling as GameObj;
            }
        }

        public override void visitPlayerRoot(GameObj other)
        {
            // step through children
            // when a collision is found
            GameObj curr = this.child as GameObj;

            while (curr != null)
            {
                if (ColPair.collide(curr, other))
                {
                    return;
                }
                curr = curr.sibling as GameObj;
            }
        }

        public override void visitShieldRoot(GameObj other)
        {
            // step through children
            // when a collision is found
            GameObj curr = this.child as GameObj;

            while (curr != null)
            {
                if (ColPair.collide(curr, other))
                {
                    return;
                }
                curr = curr.sibling as GameObj;
            }
        }

        public override void visitShield(GameObj other)
        {
            // step through children
            // when a collision is found
            GameObj curr = this.child as GameObj;

            while (curr != null)
            {
                if (ColPair.collide(curr, other))
                {
                    return;
                }
                curr = curr.sibling as GameObj;
            }
        }

        public override void visitMissileRoot(GameObj other)
        {
            // step through children
            // when a collision is found
            GameObj curr = this.child as GameObj;

            while (curr != null)
            {
                if (ColPair.collide(curr, other))
                {
                    return;
                }
                curr = curr.sibling as GameObj;
            }
        }

        public override void visitMissile(GameObj other)
        {
            Subject tmp = ColMan.getActivePair().sub;

            tmp.set(this, other);
            tmp.notify();
        }
    }
}
