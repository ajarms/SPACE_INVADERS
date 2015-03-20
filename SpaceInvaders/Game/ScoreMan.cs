using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class ScoreMan
    {
        private ScoreMan()
        {
            this.highScore = 0;

            this.currPlayer = null;

            this.extraLifeList = null;

        }

        private static ScoreMan getInstance()
        {
            Debug.Assert(instance != null);
            return instance;
        }

        public static void create()
        {
            Debug.Assert(instance == null);
            instance = new ScoreMan();
        }

        // for some reason when these messages are loaded in the constructor it causes azul to crash
        // probably because the manager's construction is called in the Initialize() step of the game
        // instead of the LoadContent() step.  Strange though... so this is a decent fix
        public static void loadMessages()
        {
            ScoreMan tmp = ScoreMan.getInstance();

            tmp.headerText = new Azul.SpriteFont("SCORE<1>     HI-SCORE     SCORE<2>", Azul.AZUL_FONTS.Consolas48pt,
                                                 64, Constants.SCREEN_HEIGHT - 42);
            tmp.p1ScoreText = new Azul.SpriteFont("", Azul.AZUL_FONTS.Consolas48pt,
                                                   96, Constants.SCREEN_HEIGHT - 96.0f);
            tmp.p2ScoreText = new Azul.SpriteFont("", Azul.AZUL_FONTS.Consolas48pt,
                                                   Constants.SCREEN_WIDTH / 2 - 36, Constants.SCREEN_HEIGHT - 96.0f);
            tmp.hiScoreText = new Azul.SpriteFont("", Azul.AZUL_FONTS.Consolas48pt,
                                                   Constants.SCREEN_WIDTH - 192.0f, Constants.SCREEN_HEIGHT - 96.0f);
            tmp.creditsText = new Azul.SpriteFont("", Azul.AZUL_FONTS.Consolas48pt, 600.0f, 36.0f);
            tmp.livesText = new Azul.SpriteFont("", Azul.AZUL_FONTS.Consolas48pt, 48.0f, 36.0f);
        }

        public static void addPoints(GameObj destroyed)
        {
            ScoreMan tmp = ScoreMan.getInstance();
            int points = 0;

            if (destroyed is Octopus)
            {
                points = 10;
            }
            else if (destroyed is Crab)
            {
                points = 20;
            }
            else if (destroyed is Squid)
            {
                points = 30;
            }
            else if (destroyed is UFO)
            {
                points = 50 * Randomizer.randInt(1, 4);
            }

            tmp.currPlayer.score.currScore += points;
            tmp.currPlayer.score.nextLife -= points;
            if (tmp.currPlayer.score.nextLife <= 0)
            {
                tmp.currPlayer.score.nextLife += 1000;
                tmp.currPlayer.score.lives++;
            }
        }

        public static void draw()
        {
            ScoreMan tmp = ScoreMan.getInstance();
            
            tmp.p1ScoreText.Update(tmp.currPlayer.score.currScore.ToString("D4"));
            tmp.p2ScoreText.Update("0000");
            tmp.hiScoreText.Update(tmp.highScore.ToString("D4"));
            tmp.creditsText.Update("CREDITS "+tmp.currPlayer.score.credits.ToString("D2"));
            tmp.livesText.Update(tmp.currPlayer.score.lives.ToString());

            tmp.p1ScoreText.Draw();
            tmp.headerText.Draw();
            tmp.p2ScoreText.Draw();
            tmp.hiScoreText.Draw();
            tmp.livesText.Draw();
            tmp.creditsText.Draw();

            // add images of spare ships
        }

        public static void death()
        {
            ScoreMan tmp = ScoreMan.getInstance();
            tmp.currPlayer.score.lives--;
        }

        public static void setPlayer(Player pPlayer)
        {
            ScoreMan tmp = ScoreMan.getInstance();

            tmp.currPlayer = pPlayer;
        }

        public static int getLives()
        {
            ScoreMan tmp = ScoreMan.getInstance();

            return tmp.currPlayer.score.lives;
        }

        public static void hiScoreUpdate()
        {
            ScoreMan tmp = ScoreMan.getInstance();

            if (tmp.currPlayer.score.currScore > tmp.highScore)
            {
                tmp.highScore = tmp.currPlayer.score.currScore;
            }
        }

        public static void reset()
        {
            ScoreMan tmp = ScoreMan.getInstance();

            tmp.currPlayer.score.currScore = 0;
            tmp.currPlayer.score.credits = 1;
            tmp.currPlayer.score.lives = 3;
            tmp.currPlayer.score.nextLife = 1000;
        }

        //------------------------------
        private static ScoreMan instance;
        protected FSprite extraLifeList;
        protected Player currPlayer;
        protected int highScore;

        protected Azul.SpriteFont headerText;
        protected Azul.SpriteFont p1ScoreText;
        protected Azul.SpriteFont p2ScoreText;
        protected Azul.SpriteFont hiScoreText;
        protected Azul.SpriteFont creditsText;
        protected Azul.SpriteFont livesText;

    }
}
