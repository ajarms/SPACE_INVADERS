using System;

namespace SpaceInvaders
{
    class WallTop: _Wall
    {
        public WallTop(Index index = Index._0, float _x = -20.0f, float _y = Constants.SCREEN_HEIGHT - 128.0f)
            : base( GameObj.Name.WallTop, index, BSprite.Name.NullSprite, new Azul.Color(250.0f, 250.0f, 0.0f))
        {
            this.x = _x;
            this.y = _y;
            this.collision.set(_x, _y, Constants.SCREEN_WIDTH + 40.0f, 128.0f);
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
            that.visitWallTop(this);
        }

        
    }
}
