using System;

namespace SpaceInvaders
{
    class WallRight : _Wall
    {
        public WallRight( Index index = Index._0, float _x = Constants.SCREEN_WIDTH - 20.0f, float _y = -20.0f)
            : base( GameObj.Name.WallRight, index, BSprite.Name.NullSprite, new Azul.Color(250.0f, 250.0f, 0.0f))
        {
            this.x = _x;
            this.y = _y;
            this.collision.set(_x, _y, 30.0f, Constants.SCREEN_HEIGHT + 40.0f);
        }

        public override void update()
        {
            // do nothing, walls will never change
        }

        //-----------------------------------
        // visitor handlers
        //-----------------------------------

        public override void accept(GameObj that)
        {
            that.visitWallSides(this);
        }

        public override void visitUFO(GameObj other)
        {
            Subject tmp = ColMan.getActivePair().sub;

            tmp.set(this, other);
            tmp.notify();
        }

        public override void visitPlayer(GameObj other)
        {
            Subject tmp = ColMan.getActivePair().sub;

            tmp.set(this, other);
            tmp.notify();
        }
    }
}
