using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class PlayerDeathObserver : Observer
    {
        public PlayerDeathObserver()
            : base()
        { }

        public override void notify()
        {
            Subject pSub = ColMan.getActivePair().sub;
            GameObj pExplosion = null;
            GameObj curr = null;
            StopEvent stopExplosion = null;
            int i = 0;

            if (pSub.subA is _Player)
            {
                pExplosion = ExplosionFactory.explode(pSub.subA.parent as GameObj);
                curr = pSub.subA.parent.child as GameObj;
            }
            else if (pSub.subB is _Player)
            {
                pExplosion = ExplosionFactory.explode(pSub.subB.parent as GameObj);
                curr = pSub.subB.parent.child as GameObj;
            }

            TimerMan.wait(2.5f);
            TimerMan.add(Timer.Name.RespawnTimer, EventMan.find(Event.Name.Player_Spawn), 2.5f);
            TimerMan.add(Timer.Name.DeathAnimationTimer, EventMan.find(Event.Name.Death_Animation), 0.05f);

            while (stopExplosion == null)
            {
                stopExplosion = EventMan.find(Event.Name.Stop_Explosion, Index._0 + i) as StopEvent;
                ++i;
            }
            Debug.Assert(stopExplosion != null);
            stopExplosion.set(pExplosion);
            EventMan.remove(stopExplosion.name, stopExplosion.index);
            TimerMan.add(Timer.Name.StopExplosionTimer, stopExplosion, 0.2f);

            (curr.sibling as GameObj).removeMe();
            curr.removeMe();

            EventMan.find(Event.Name.Death_Sound).execute(0.0f);
            ScoreMan.death();
        }
    }
}
