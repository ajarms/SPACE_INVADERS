using System;

namespace SpaceInvaders
{
    class SoundEvent : Event
    {
        public enum Name
        {
            Alien_MoveA,
            Alien_MoveB,
            Alien_MoveC,
            Alien_MoveD,
            Player_Shoot,
            UFO_OnScreen,
            Explosion,
            NOT_INITIALIZED
        }

        public SoundEvent()
            : base()
        {
            this.name = Name.NOT_INITIALIZED;

            this.pSound = null;
        }

        ~SoundEvent()
        {
            this.pSound = null;
        }

        public void set(SoundEvent.Name _name)
        {
            this.name = _name;
            
            switch (_name)
            {
                case SoundEvent.Name.Alien_MoveA:
                    this.pSound = null; //new Azul.Sound();
                    break;
            }
        }

        public override void execute(float deltaTime)
        {
            // playback sound

            // add back onto timer
            TimerMan.add(Timer.Name.AlienAnimationTimer, this, deltaTime);
        }

        override public Enum getName()
        {
            return this.name;
        }

        public void pause(SoundEvent.Name _name)
        {
            SoundEvent tmp;
        }

        override public Enum getIndex()
        {
            return this.index;
        }

        //-------------------
        public SoundEvent.Name name;
        public Index index = Index._0;

        Azul.Sound pSound;
    }

}