using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class BombExplosionObserver : Observer
    {
        public BombExplosionObserver()
            : base()
        { }

        public override void notify()
        {
             Subject pSub = ColMan.getActivePair().sub;

            if (pSub.subA is _Bomb)
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
            else if (pSub.subB is _Bomb)
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
        }

        
    }
}