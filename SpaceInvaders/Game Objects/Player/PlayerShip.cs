using System;

namespace SpaceInvaders
{
    class PlayerShip: _Player
    {
        public PlayerShip( Index index, float _x, float _y, BSprite.Name _spriteName)
            : base( GameObj.Name.Player, index, _spriteName, new Azul.Color(250.0f, 0.0f, 0.0f))
        {
            this.x = _x;
            this.y = _y;
        }

        public override void accept(GameObj that)
        {
            that.visitPlayer(this);
        }
    }
}
