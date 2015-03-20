using System;

namespace SpaceInvaders
{
    class MissileExplosion : _Explosion
    {
        public MissileExplosion(Index index, float _x, float _y)
            : base(GameObj.Name.MissileExplosion, index, BSprite.Name.MissileExplosion, new Azul.Color(250.0f, 0.0f, 0.0f))
        {
            this.x = _x;
            this.y = _y;
        }

        public override void accept(GameObj other)
        {
            // do nothing
        }
    }
}