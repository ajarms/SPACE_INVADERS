using System;

namespace SpaceInvaders
{
    class ColObject
    {
        public ColObject(GameObj inObj, Azul.Color inColor)
        {
            this.pObj = inObj;

            // BUILD FROM inObj DATA
            this.h = pObj.getHeight();
            this.w = pObj.getWidth();
            this.x = pObj.drawSprite.x - w/2.0f;
            this.y = pObj.drawSprite.y - h/2.0f;

            this.drawSprite = new CSprite(this, inColor);
        }

        public void set(float _x, float _y, float _w, float _h)
        {
            this.x = _x;
            this.y = _y;
            this.h = _h;
            this.w = _w;
        }

        public bool intersect(ColObject c)
        {
            // top1 vs bottom2
            // y + h > c.y

            // bottom 1 vs top 2
            // y < c.y + c.h

            // right 1 vs left 2
            // x < c.x + c.w

            // left 1 vs right2
            // x + w > c.x

            if ((y < c.y + c.h &&
                 y + h > c.y) &&
                (x < c.x + c.w &&
                 x + w > c.x))
            {
                return true;
            }

            return false;
        }

        // returns the union of multiple collision objects, as a new collision object
        public void union(ColObject objA, ColObject objB)
        {
            // target top =
            // min (top a, top b)

            // target bottom =
            // max (bottom a, bottom b)

            // target right =
            // max (right a, right b)

            // target left =
            // min (left a, left b)

            float tx;
            float ty;
            float tw;
            float th;

            // check top
            if (objA.y < objB.y)
            {
                ty = objA.y;
            }
            else
            {
                ty = objB.y;
            }

            // check bottom
            if (objA.y + objA.h > objB.y + objB.h)
            {
                th = objA.y + objA.h - ty;
            }
            else
            {
                th = objB.y + objB.h - ty;
            }
                
            // check left
            if (objA.x < objB.x)
            {
                tx = objA.x;
            }
            else
            {
                tx = objB.x;
            }

            // check right
            if (objA.x + objA.w > objB.x + objB.w)
            {
                tw = objA.x + objA.w - tx;
            }
            else
            {
                tw = objB.x + objB.w - tx;
            }

            // set values
            this.x = tx;
            this.y = ty;
            this.h = th;
            this.w = tw;
        }

        // updates collision information after changes to the game object
        public void update()
        {
            // special case for union objects without draw sprites
            if (pObj.drawSprite.name.Equals(BSprite.Name.NullSprite))
            {
                return;
            }
            // otherwise get latest sprite location
            this.x = pObj.x - w / 2.0f;
            this.y = pObj.y - h / 2.0f;
        }

        //-----------------------------
        private GameObj pObj;
        public BSprite drawSprite;
        public float x;
        public float y;
        public float w;
        public float h;
    }
}
