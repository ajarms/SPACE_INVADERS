using System;

namespace SpaceInvaders
{
    abstract class _Missile: GameObj
    {
        protected _Missile(GameObj.Name objectName, Index _index, BSprite.Name spriteName, Azul.Color color)
            : base(objectName, _index, spriteName, color, false)
        {
            this.type = GameObj.Type._Missile;
        }
    }
}
