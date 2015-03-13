using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class CSprite:BSprite
    {
        public CSprite(ColObject collision, Azul.Color inColor)
            : base()
        {
            this.pCol = collision;
            this.line = new Azul.Line(1.0f, inColor, 0.0f, 0.0f, 0.0f, 0.0f);
        }

        public override void draw()
        {
            Debug.Assert(pCol != null);

            // top line
            line.Draw(pCol.x, pCol.y, pCol.x + pCol.w, pCol.y);

            // right line
            line.Draw(pCol.x + pCol.w, pCol.y, pCol.x + pCol.w, pCol.y + pCol.h);

            // bottom line
            line.Draw(pCol.x + pCol.w, pCol.y + pCol.h, pCol.x, pCol.y + pCol.h);

            // left line
            line.Draw(pCol.x, pCol.y + pCol.h, pCol.x, pCol.y);
        }

        public override void update()
        {
            // do nothing
        }

        public override float getHeight()
        {
            return pCol.h;
        }

        public override float getWidth()
        {
            return pCol.w;
        }

        //----------------
        private Azul.Line line;
        private ColObject pCol;

    }
}
