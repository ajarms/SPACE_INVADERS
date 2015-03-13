using System;

namespace SpaceInvaders
{
    abstract class _Alien: GameObj
    {
        public enum AlienType
        {
            Crab,
            Octopus,
            Squid,
            Grid,
            Column
        }

        protected _Alien(GameObj.Name objectName, Index _index, BSprite.Name spriteName, Azul.Color color)
            : base(objectName, _index, spriteName, color, true)
        {
            this.type = GameObj.Type._Alien;
        }

    }
}
