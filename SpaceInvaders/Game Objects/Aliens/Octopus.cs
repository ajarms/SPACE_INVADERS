using System;

namespace SpaceInvaders
{
    class Octopus: _Alien
    {
        public Octopus(Index index, float _x, float _y)
            : base(GameObj.Name.Octopus, index, BSprite.Name.Octopus, new Azul.Color(250.0f, 0.0f, 0.0f))
        {
            this.x = _x;
            this.y = _y;
        }

        //-----------------------------------
        // visitor handlers
        //-----------------------------------

        public override void accept(GameObj that)
        {
            that.visitAlien(this);
        }

        public override void visitShieldBlock(GameObj other)
        {
            Subject tmp = ColMan.getActivePair().sub;

            tmp.set(this, other);
            tmp.notify();
        }

        public override void visitPlayer(GameObj other)
        {
            Subject tmp = ColMan.getActivePair().sub;

            tmp.set(this, other);
            tmp.notify();
        }
    }
}
