using System;

namespace SpaceInvaders
{
    abstract class _Explosion : GameObj
    {
        protected _Explosion(GameObj.Name objectName, Index _index, BSprite.Name spriteName, Azul.Color color)
            : base(objectName, _index, spriteName, color, true)
        {
        }
    }
}
