using System;

namespace SpaceInvaders
{
    class SplashScene: Scene
    {
        public SplashScene()
            : base(Scene.Name.Splash_Screen)
        {
        }

        public override void update(float totalTime)
        {
            InputManager.update(totalTime);
        }

        public override void draw()
        {

            ScoreMan.draw();
        }
    }
}
