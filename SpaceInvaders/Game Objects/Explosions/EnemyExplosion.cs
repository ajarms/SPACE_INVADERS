using System;

namespace SpaceInvaders
{
    class EnemyExplosion : _Explosion
    {
        public EnemyExplosion(Index index, float _x, float _y)
            : base(GameObj.Name.EnemyExplosion, index, BSprite.Name.EnemyExplosion, new Azul.Color(250.0f, 0.0f, 0.0f))
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
