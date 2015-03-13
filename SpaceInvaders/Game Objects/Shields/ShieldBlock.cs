using System;

namespace SpaceInvaders
{
    class ShieldBlock: _Shield
    {
        // single destructible piece of a shield, draw & collision
        // TODO REFACTOR & CREATE BLOCK SPRITES
        public ShieldBlock( Index index, float _x, float _y, BSprite.Name _name)
            : base( GameObj.Name.ShieldBlock, index, _name, new Azul.Color(250.0f, 0.0f, 0.0f))
        {
            this.x = _x;
            this.y = _y;
        }

        //-----------------------------------
        // visitor handlers
        //-----------------------------------

        public override void accept(GameObj that)
        {
            that.visitShieldBlock(this);
        }
    }
}
