using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class Game : Azul.Engine
    {
        // Used to throttle user input speed
        float inputTime = 0.0f;

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

            SBatchMan.drawOff(SpriteBatch.Name.Collision);
        }
       
        //-----------------------------------------------------------------------------
        // Game::Update()
        //      Called once per frame, update data, tranformations, etc
        //      Use this function to control process order
        //      Input, AI, Physics, Animation, and Graphics
        //-----------------------------------------------------------------------------
        public override void Update(float totalTime)
        {
            checkInput(totalTime);
            GameManager.update(totalTime);
        }

        //-----------------------------------------------------------------------------
        // Game::Draw()
        //		This function is called once per frame
        //	    Use this for draw graphics to the screen.
        //      Only do rendering here
        //-----------------------------------------------------------------------------
        public override void Draw()
        {
            SBatchMan.draw();
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


        private void checkInput(float totalTime)
        {
            // get player
            GameObj pPlayer = GObjMan.find(GameObj.Type._Player, GameObj.Name.PlayerRoot);
            Debug.Assert(pPlayer != null);

            //-----------------------------------------------------
            // Toggle Collision Boxes

            // check input timer
            if (totalTime - inputTime > 0.25f)
            {
                inputTime = totalTime;

                // ctrl+c toggles collision box drawing
                if ((Azul.Input.GetKeyState(Azul.AZUL_KEYS.KEY_LEFT_CONTROL) ||
                     Azul.Input.GetKeyState(Azul.AZUL_KEYS.KEY_RIGHT_CONTROL)) &&
                     Azul.Input.GetKeyState(Azul.AZUL_KEYS.KEY_C))
                {
                    SpriteBatch tmp = SBatchMan.find(SpriteBatch.Name.Collision);
                    if (tmp.enabled)
                    {
                        SBatchMan.drawOff(SpriteBatch.Name.Collision);
                    }
                    else
                    {
                        SBatchMan.drawOn(SpriteBatch.Name.Collision);
                    }
                }
            }

            //-----------------------------------------------------
            // Fire missiles

            if (Azul.Input.GetKeyState(Azul.AZUL_KEYS.KEY_SPACE) && pPlayer.child != null)
            {
                // check for a currently spawned player
                if (pPlayer.child != null)
                {
                    float x = pPlayer.collision.x + pPlayer.collision.w / 2;
                    float y = pPlayer.collision.y + pPlayer.collision.h + 8.0f;

                    MissileFactory.spawnMissile(x, y);
                }
            }

            //-----------------------------------------------------
            // Move Player

            if (Azul.Input.GetKeyState(Azul.AZUL_KEYS.KEY_LEFT) && pPlayer.child != null)
            {
                pPlayer.move(Constants.PLAYER_SPEED * -1.0f, 0.0f);            
            }
            if (Azul.Input.GetKeyState(Azul.AZUL_KEYS.KEY_RIGHT) && pPlayer.child != null)
            {
                pPlayer.move(Constants.PLAYER_SPEED, 0.0f);            
            }


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
