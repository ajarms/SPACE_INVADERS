using System;

namespace SpaceInvaders
{
    class SceneState_Attract : State
    {
        public SceneState_Attract() : base() { }

        public override void handle(GameObj context)
        {
            InputManager.setState(new SceneState_Splash());

            SceneMan.setScene(Scene.Name.Splash_Screen);
        }
    }
}
