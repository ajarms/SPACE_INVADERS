using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    
    class SpawnAlienEvent : Event
    {
        public SpawnAlienEvent()
            : base()
        { }

        ~SpawnAlienEvent()
        {
        }

        public override void execute(float deltaTime)
        {
            GameScene pScene = SceneMan.getCurrent() as GameScene;

            AlienFactory.spawnAliens(Constants.GRID_START_X,
                                     Constants.GRID_START_Y - pScene.nextWave() * Constants.GRID_SPACING,
                                     Constants.GRID_SPACING,
                                     Constants.GRID_SPACING);
        }

        override public Enum getName()
        {
            return this.name;
        }

        override public Enum getIndex()
        {
            return this.index;
        }

        //-----------------------
        public Name name = Event.Name.Alien_Spawn;
        public Index index = Index._0;
    }
}