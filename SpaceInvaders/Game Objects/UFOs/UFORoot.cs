using System;

namespace SpaceInvaders
{
    class UFORoot: _UFO
    {
        public UFORoot( Index index = Index._0, float _x = 0.0f, float _y = 0.0f)
            : base(GameObj.Name.UFORoot, index, BSprite.Name.NullSprite, new Azul.Color(0.0f, 0.0f, 250.0f))
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
            that.visitUFORoot(this);
        }

        public override void visitMissileRoot(GameObj other)
        {
            if (this.child != null)
            {
                ColPair.collide(this.child as _UFO, other);
            }
        }

        public override void visitWallSides(GameObj other)
        {
            if (this.child != null)
            {
                ColPair.collide(this.child as _UFO, other);
            };
        }
    }
}
