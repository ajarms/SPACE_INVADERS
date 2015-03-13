using System;

namespace SpaceInvaders
{
    abstract class Alien: GameObj
    {
        public enum Type
        {
            Crab,
            Octopus,
            Squid,
            Grid,
            Column
        }

        protected Alien(GameObj.Name objectName, Index _index, BSprite.Name spriteName, Alien.Type _type, Azul.Color color)
            : base(objectName, _index, spriteName, color, true)
        {
        }

    }
}
