using System;

namespace SpaceInvaders
{
    class ShieldRoot: _Shield
    {
        // union of all shields, collision only
        public ShieldRoot( Index index = 0.0f, float _x = 0.0f, float _y = 0.0f)
            : base(GameObj.Name.ShieldRoot, index, BSprite.Name.NullSprite, new Azul.Color(0.0f, 0.0f, 250.0f))
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
            that.visitShieldRoot(this);
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

        //public override void visitBombRoot(GameObj other)
        //{
        //    // drop one level
        //    GameObj curr = this.child as GameObj;

        //    // collide against everything at this level
        //    while (curr != null)
        //    {
        //        if (ColPair.collide(curr, other))
        //        {
        //            curr = curr.sibling as GameObj;
        //        }
        //    }
        //}

        public override void visitBomb(GameObj other)
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

        public override void visitAlienRoot(GameObj other)
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
    }
}
