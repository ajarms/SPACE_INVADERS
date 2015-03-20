﻿using System;

namespace SpaceInvaders
{
    class SoundEvent : Event
    {
        public SoundEvent(Event.Name _name)
            : base()
        {
            this.name = _name;

            //switch (_name)
            //{
            //    case Event.Name.Alien_SoundA:
            //        this.pSound = Azul.Audio.playSound("A.wav", false, true, true);
            //        break;
            //    case Event.Name.Alien_SoundB:
            //        this.pSound = Azul.Audio.playSound("B.wav", false, true, true);
            //        break;
            //    case Event.Name.Alien_SoundC:
            //        this.pSound = Azul.Audio.playSound("C.wav", false, true, true);
            //        break;
            //    case Event.Name.Alien_SoundD:
            //        this.pSound = Azul.Audio.playSound("D.wav", false, true, true);
            //        break;
            //    case Event.Name.Shoot_Sound:
            //        this.pSound = Azul.Audio.playSound("shoot.wav", false, true, true);
            //        break;
            //    case Event.Name.UFO_Sound:
            //        this.pSound = Azul.Audio.playSound("ufo_highitch.wav", true, true, true);
            //        break;
            //    case Event.Name.Death_Sound:
            //        this.pSound = Azul.Audio.playSound("explosion.wav", true, true, true);
            //        break;
            //    case Event.Name.Explosion_Sound:
            //        this.pSound = Azul.Audio.playSound("invaderkilled.wav", true, true, true);
            //        break;
            //}
        }

        ~SoundEvent()
        {
            this.pSound = null;
        }

        public override void execute(float deltaTime)
        {

            switch (name)
            {
                case Event.Name.Alien_SoundA:
                    this.pSound = Azul.Audio.playSound("A.wav", false, true, true);
                    this.play();
                    TimerMan.add(Timer.Name.AlienAnimationTimer, this, Constants.ALIEN_SPEED() * 4);
                    break;
                case Event.Name.Alien_SoundB:
                    this.pSound = Azul.Audio.playSound("B.wav", false, true, true);
                    this.play();
                    TimerMan.add(Timer.Name.AlienAnimationTimer, this, Constants.ALIEN_SPEED() * 4);
                    break;
                case Event.Name.Alien_SoundC:
                    this.pSound = Azul.Audio.playSound("C.wav", false, true, true);
                    this.play();
                    TimerMan.add(Timer.Name.AlienAnimationTimer, this, Constants.ALIEN_SPEED() * 4);
                    break;
                case Event.Name.Alien_SoundD:
                    this.pSound = Azul.Audio.playSound("D.wav", false, true, true);
                    this.play();
                    TimerMan.add(Timer.Name.AlienAnimationTimer, this, Constants.ALIEN_SPEED()*4);
                    break;
                case Event.Name.Shoot_Sound:
                    this.pSound = Azul.Audio.playSound("shoot.wav", false, true, true);
                    this.play();
                    break;
                case Event.Name.UFO_Sound:
                    this.pSound = Azul.Audio.playSound("ufo_highpitch.wav", true, true, true);
                    this.play();
                    break;
                case Event.Name.Death_Sound:
                    this.pSound = Azul.Audio.playSound("explosion.wav", false, true, true);
                    this.play();
                    break;
                case Event.Name.Explosion_Sound:
                    this.pSound = Azul.Audio.playSound("invaderkilled.wav", false, true, true);
                    this.play();
                    break;
            }
        }

        override public Enum getName()
        {
            return this.name;
        }

        public void pause()
        {
            this.pSound.Pause(true);
        }

        public void play()
        {
            this.pSound.Pause(false);
        }

        override public Enum getIndex()
        {
            return this.index;
        }

        //-------------------
        public Event.Name name;
        public Index index = Index._0;

        Azul.Sound pSound;
    }

}