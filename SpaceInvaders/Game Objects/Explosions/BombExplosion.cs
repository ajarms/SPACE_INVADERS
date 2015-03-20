using System;

namespace SpaceInvaders
{
    class BombExplosion : _Explosion
    {
        public BombExplosion(Index index, float _x, float _y)
            : base(GameObj.Name.BombExplosion, index, BSprite.Name.BombExplosion, new Azul.Color(250.0f, 0.0f, 0.0f))
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