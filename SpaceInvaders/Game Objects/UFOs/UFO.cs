using System;

namespace SpaceInvaders
{
    class UFO: _UFO
    {
        public UFO( Index index = Index._0, float _x = 0.0f, float _y = 700.0f)
            : base( GameObj.Name.UFO, index, BSprite.Name.UFO, new Azul.Color(250.0f, 0.0f, 0.0f))
        {
            this.x = _x;
            this.y = _y;
        }

        public override void update()
        {
            if ((direction > 0 && x > Constants.SCREEN_WIDTH) ||
                (direction < 0 && x < 0))
            {
                (EventMan.find(Event.Name.UFO_Sound) as SoundEvent).pause();
                TempObjMan.add(this);
                this.removeMe();
                return;
            }

            this.x += Constants.UFO_SPEED * direction;
            base.update();
        }

        public float direction = 1.0f;

        //-----------------------------------
        // visitor handlers
        //-----------------------------------

        public override void accept(GameObj that)
        {
            that.visitUFO(this);
        }
    }
}
