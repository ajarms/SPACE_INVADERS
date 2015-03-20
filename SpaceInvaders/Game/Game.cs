using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class Game : Azul.Engine
    {
        //-----------------------------------------------------------------------------
        // Game::Initialize()
        //		Allows the engine to perform any initialization it needs to before 
        //      starting to run.  This is where it can query for any required services 
        //      and load any non-graphic related content. 
        //-----------------------------------------------------------------------------
        public override void Initialize()
        {
            Azul.Camera.setWindowSize(Constants.SCREEN_WIDTH, Constants.SCREEN_HEIGHT);
            setClearBufferColor(new Azul.Color(0.0f, 0.0f, 0.0f));

            GameManager.start();
        }

        //-----------------------------------------------------------------------------
        // Game::LoadContent()
        //		Allows you to load all content needed for your engine,
        //	    such as objects, graphics, etc.
        //-----------------------------------------------------------------------------
        public override void LoadContent()
        {
            GameManager.load();
        }
       
        //-----------------------------------------------------------------------------
        // Game::Update()
        //      Called once per frame, update data, tranformations, etc
        //      Use this function to control process order
        //      Input, AI, Physics, Animation, and Graphics
        //-----------------------------------------------------------------------------
        public override void Update(float totalTime)
        {
            SceneMan.update(totalTime);
        }

        //-----------------------------------------------------------------------------
        // Game::Draw()
        //		This function is called once per frame
        //	    Use this for draw graphics to the screen.
        //      Only do rendering here
        //-----------------------------------------------------------------------------
        public override void Draw()
        {
            SceneMan.draw();
        }

        //-----------------------------------------------------------------------------
        // Game::UnLoadContent()
        //       unload content (resources loaded above)
        //       unload all content that was loaded before the Engine Loop started
        //-----------------------------------------------------------------------------
        public override void UnLoadContent()
        {
            GameManager.close();
        }

        // snagged from keenan
        public override bool EscapeTriggerFunc()
        {
            bool exitConditions;

            exitConditions = Azul.Input.GetKeyState(Azul.AZUL_KEYS.KEY_ESCAPE) || Azul.Input.GetKeyState(Azul.AZUL_KEYS.KEY_Q);

            return exitConditions;
        }

    }
}
