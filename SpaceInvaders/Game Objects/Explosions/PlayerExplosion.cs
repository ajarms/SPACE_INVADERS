using System;

namespace SpaceInvaders
{
    class PlayerExplosion : _Explosion
    {
        public PlayerExplosion(Index index, float _x, float _y)
            : base(GameObj.Name.PlayerExplosion, index, BSprite.Name.PlayerExplosion, new Azul.Color(0.0f, 250.0f, 0.0f))
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
