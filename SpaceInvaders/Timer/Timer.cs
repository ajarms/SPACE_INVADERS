using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class Timer: PriorityNode
    {
        public enum Name
        {
            UFOTimer,
            BombTimer,
            BombAnimationTimer,
            AlienAnimationTimer,
            DeathAnimationTimer,
            RespawnTimer,
            WaveTimer,
            StopExplosionTimer,
            NOT_INITIALIZED
        }

        public Timer()
            : base()
        {
            this.deltaTime = 0.0f;
            this.triggerTime = 0.0f;
            this.pEvent = null;
        }

        ~Timer()
        {
            this.pEvent = null;
        }

        public void set(Timer.Name _name, Event _event, float deltaTime)
        {
            this.name = _name;
            this.deltaTime = deltaTime;
            this.pEvent = _event;
            this.triggerTime = TimerMan.getTime() + deltaTime;
        }

        // contract with priority node
        // needed for adding in time-sorted order
        public override bool compare(PriorityNode compareTo)
        {
            Timer other = compareTo as Timer;
            return this.triggerTime <= other.triggerTime;
        }

        public void execute()
        {
            Debug.Assert(this.pEvent != null);

            this.pEvent.execute(deltaTime);
        }

        override public Enum getName()
        {
            return this.name;
        }

        override public Enum getIndex()
        {
            return this.index;
        }

        //-------------------------
        public Name name;
        public Index index = Index._0;
        public Event pEvent;
        public float deltaTime;
        public float triggerTime;
    }
}
