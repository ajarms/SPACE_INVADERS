using System;

namespace SpaceInvaders
{
    class AttractScene: Scene
    {
        public AttractScene()
            : base(Scene.Name.Attract_Screen)
        {
            this.playMsg = new Azul.SpriteFont("PLAY", Azul.AZUL_FONTS.Consolas48pt, 360, 572);
            this.spaceInvadersMsg = new Azul.SpriteFont("SPACE INVADERS", Azul.AZUL_FONTS.Consolas48pt, 256, 464);
            this.scoreMsg = new Azul.SpriteFont("*SCORE ADVANCE TABLE*", Azul.AZUL_FONTS.Consolas48pt, 192, 256);
            this.octoPoints = new Azul.SpriteFont("PLAY", Azul.AZUL_FONTS.Consolas48pt, 360, 256);
            this.crabPoints = new Azul.SpriteFont("PLAY", Azul.AZUL_FONTS.Consolas48pt, 360, 572);
            this.squidPoints = new Azul.SpriteFont("PLAY", Azul.AZUL_FONTS.Consolas48pt, 360, 572);
            this.UFOPoints = new Azul.SpriteFont("PLAY", Azul.AZUL_FONTS.Consolas48pt, 360, 572);
        }

        public override void update(float totalTime)
        {
            InputManager.update(totalTime);
        }

        public override void draw()
        {
            this.playMsg.Draw();
            this.spaceInvadersMsg.Draw();
            this.scoreMsg.Draw();
            ScoreMan.draw();
        }



        protected Azul.SpriteFont playMsg;
        protected Azul.SpriteFont spaceInvadersMsg;
        protected Azul.SpriteFont scoreMsg;
        protected Azul.SpriteFont octoPoints;
        protected Azul.SpriteFont crabPoints;
        protected Azul.SpriteFont squidPoints;
        protected Azul.SpriteFont UFOPoints;
    }
}
