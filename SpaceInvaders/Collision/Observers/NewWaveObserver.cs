using System;

namespace SpaceInvaders
{
    class NewWaveObserver: Observer
    {
        public NewWaveObserver()
            : base()
        {

        }

        public override void notify()
        {
            float count = GObjMan.alienCount();
            if (count <= 0.0f)
            {
                TimerMan.wait(2.5f);
                TimerMan.add(Timer.Name.WaveTimer, EventMan.find(Event.Name.Alien_Spawn), 2.5f);
            }
        }
    }
}
