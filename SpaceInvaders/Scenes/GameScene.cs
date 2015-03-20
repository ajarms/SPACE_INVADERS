using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class GameScene: Scene
    {
        public GameScene(Scene.Name _name)
            : base(_name)
        {
            if (_name.Equals(Scene.Name.Player1_Game))
            {
                this.player = new Player(Player.Name.Player1);
            }
            else if (_name.Equals(Scene.Name.Player2_Game))
            {
                this.player = new Player(Player.Name.Player2);
            }
            Debug.Assert(this.player != null);

            this.floor = new Azul.Line(5.0f, new Azul.Color(0.0f, 250.0f, 0.0f), 0.0f, 64.0f, Constants.SCREEN_WIDTH, 64.0f);
            this.wave = 0;
            this.gameOver = new Azul.SpriteFont("GAME OVER", Azul.AZUL_FONTS.Consolas48pt,
                                                Constants.SCREEN_WIDTH / 2 - 96.0f, Constants.SCREEN_HEIGHT - 196.0f);
        }

        public override void update(float totalTime)
        {
            InputManager.update(totalTime);
            // check if our of lives are out
            if (player.score.lives <= 0)
            {
                // if so, gameover message
                // swap inputMan state
                ScoreMan.hiScoreUpdate();
                InputManager.setState(new SceneState_Attract());
                return;
                // hangs forever; wait for enter key to swap states.
            }
            TimerMan.update(totalTime);
            ColMan.update();
            GObjMan.update();
        }

        public override void draw()
        {
            
            SBatchMan.draw();
            ScoreMan.draw();
            floor.Draw();
            if (player.score.lives <= 0)
            {
                // if so, gameover message
                gameOver.Draw(new Azul.Color(250.0f, 0.0f, 0.0f));
                // hangs forever; wait for enter key to swap states.
            }
        }

        public Player getPlayer()
        {
            return this.player;
        }

        public int nextWave()
        {
            this.wave++;
            return this.wave;
        }

        protected Player player = null;
        protected Azul.Line floor;
        protected Azul.SpriteFont gameOver;
        protected int wave;
    }
}
