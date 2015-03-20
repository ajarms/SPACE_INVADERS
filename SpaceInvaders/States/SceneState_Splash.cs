using System;

namespace SpaceInvaders
{
    class SceneState_Splash : State
    {
        public SceneState_Splash() : base() { }

        public override void handle(GameObj context)
        {
            InputManager.setState(new SceneState_Game());

            SceneMan.setScene(Scene.Name.Player1_Game);
        }
    }
}