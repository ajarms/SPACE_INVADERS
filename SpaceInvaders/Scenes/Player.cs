using System;

namespace SpaceInvaders
{
    class Player
    {
        public enum Name
        {
            Player1,
            Player2
        }

        public Player(Player.Name _name)
        {
            this.name = _name;
            this.score.lives = 3;
            this.score.nextLife = 1000;
            this.score.currScore = 0;
            this.score.credits = 1;
        }

        public Name name;
        public Score score;
    }

    public struct Score
    {
        public int lives;
        public int currScore;
        public int credits;
        public int nextLife;
    }
}
