using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class InputManager
    {
        private InputManager()
        {
        }

        ~InputManager()
        {
        }

        public static void create()
        {
            Debug.Assert(instance == null);
            if (instance == null)
            {
                instance = new InputManager();
            }
        }

        private static InputManager getInstance()
        {
            Debug.Assert(instance != null);

            return instance;
        }

        public static void update(float totalTime)
        {
            InputManager tmp = InputManager.getInstance();

            // get player
            PlayerRoot pPlayer = GObjMan.find(GameObj.Type._Player, GameObj.Name.PlayerRoot) as PlayerRoot;
            Debug.Assert(pPlayer != null);

            //-----------------------------------------------------
            // Toggle Collision Boxes [ctrl + C]

            if ((Azul.Input.GetKeyState(Azul.AZUL_KEYS.KEY_LEFT_CONTROL) ||
                    Azul.Input.GetKeyState(Azul.AZUL_KEYS.KEY_RIGHT_CONTROL)) &&
                    Azul.Input.GetKeyState(Azul.AZUL_KEYS.KEY_C) && totalTime - tmp.lastPress > 0.25f)
            {
                SpriteBatch batch = SBatchMan.find(SpriteBatch.Name.Collision);
                if (batch.enabled)
                {
                    SBatchMan.drawOff(SpriteBatch.Name.Collision);
                }
                else
                {
                    SBatchMan.drawOn(SpriteBatch.Name.Collision);
                }
                tmp.lastPress = totalTime;
            }
            

            //-----------------------------------------------------
            // Fire missiles [Space]

            if (Azul.Input.GetKeyState(Azul.AZUL_KEYS.KEY_SPACE) && pPlayer.child != null)
            {
                    pPlayer.fireMissile();
            }


            //-----------------------------------------------------
            // Move Player [Right // Left]

            if (Azul.Input.GetKeyState(Azul.AZUL_KEYS.KEY_LEFT) && pPlayer.child != null)
            {
                pPlayer.moveLeft();
            }
            if (Azul.Input.GetKeyState(Azul.AZUL_KEYS.KEY_RIGHT) && pPlayer.child != null)
            {
                pPlayer.moveRight();
            }

            //-----------------------------------------------------
            // Step to the next screen [Enter]

            if (Azul.Input.GetKeyState(Azul.AZUL_KEYS.KEY_ENTER) &&
                totalTime - tmp.lastPress > 0.25f)
            {
                tmp.lastPress = totalTime;
                tmp.sceneState.handle(null);
            }
            

        }

        public static void setState(State inputState)
        {
            InputManager tmp = InputManager.getInstance();

            tmp.sceneState = inputState;
        }

        //-------------------
        private static InputManager instance;
        private State sceneState;
        private float lastPress = 0.0f;
    }
}

