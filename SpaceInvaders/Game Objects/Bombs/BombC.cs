using System;

namespace SpaceInvaders
{
    // lightning bomb
    class BombC: _Bomb
    {
        public BombC( Index index, float _x, float _y)
            : base( GameObj.Name.BombC, index, BSprite.Name.BombC, new Azul.Color(250.0f, 0.0f, 0.0f))
        {
            this.x = _x;
            this.y = _y;
        }

        public override void update()
        {
            this.y -= Constants.BOMB_SPEED;
            base.update();
        }

        //-----------------------------------
        // visitor handlers
        //-----------------------------------

        public override void accept(GameObj that)
        {
            that.visitBomb(this);
        }

        public override void visitPlayer(GameObj other)
        {
            Subject tmp = ColMan.getActivePair().sub;

            tmp.set(this, other);
            tmp.notify();
        }

        public override void visitShieldColumn(GameObj other)
        {
            other.visitBomb(this);
        }

        public override void visitShieldBlock(GameObj other)
        {
            Subject tmp = ColMan.getActivePair().sub;

            tmp.set(this, other);
            tmp.notify();
        }
    }
}
