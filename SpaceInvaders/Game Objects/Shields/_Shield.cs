using System;

namespace SpaceInvaders
{
    abstract class _Shield: GameObj
    {
        protected _Shield(GameObj.Name objectName, Index _index, BSprite.Name spriteName, Azul.Color color)
            : base(objectName, _index, spriteName, color, true)
        {
            this.type = GameObj.Type._Shield;
        }
    }
}
