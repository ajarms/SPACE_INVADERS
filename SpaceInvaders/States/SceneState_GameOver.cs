using System;

namespace SpaceInvaders
{
    class SceneState_GameOver : State
    {
        public SceneState_GameOver() : base() { }

        public override void handle(GameObj context)
        {
            InputManager.setState(new SceneState_Attract());
            ScoreMan.reset();
            SceneMan.setScene(Scene.Name.Attract_Screen);
        }
    }
}