using System;

namespace SpaceInvaders
{
    abstract class _Player: GameObj
    {
        protected _Player(GameObj.Name objectName, Index _index, BSprite.Name spriteName, Azul.Color color)
            : base(objectName, _index, spriteName, color, true)
        {
            this.type = GameObj.Type._Player;
        }
    }
}
