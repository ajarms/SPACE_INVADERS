﻿using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class UFOExplosionObserver : Observer
    {
        public UFOExplosionObserver()
            : base()
        { }

        public override void notify()
        {
            Subject pSub = ColMan.getActivePair().sub;

            if (pSub.subA is _UFO)
            {
                GameObj pExplosion = ExplosionFactory.explode(pSub.subA);

                StopEvent stopExplosion = null;
                int i = 0;

                while (stopExplosion == null)
                {
                    stopExplosion = EventMan.find(Event.Name.Stop_Explosion, Index._0 + i) as StopEvent;
                    ++i;
                }
                Debug.Assert(stopExplosion != null);
                stopExplosion.set(pExplosion);
                EventMan.remove(stopExplosion.name, stopExplosion.index);

                TimerMan.add(Timer.Name.StopExplosionTimer, stopExplosion, 0.05f);
            }
            else if (pSub.subB is _UFO)
            {
                GameObj pExplosion = ExplosionFactory.explode(pSub.subB);

                StopEvent stopExplosion = null;
                int i = 0;

                while (stopExplosion == null)
                {
                    stopExplosion = EventMan.find(Event.Name.Stop_Explosion, Index._0 + i) as StopEvent;
                    ++i;
                }
                Debug.Assert(stopExplosion != null);
                stopExplosion.set(pExplosion);
                EventMan.remove(stopExplosion.name, stopExplosion.index);

                TimerMan.add(Timer.Name.StopExplosionTimer, stopExplosion, 0.05f);
            }

            EventMan.find(Event.Name.UFODeath_Sound).execute(0.0f);
        }
    }
}
