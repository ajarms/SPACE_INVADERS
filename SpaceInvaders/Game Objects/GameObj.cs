using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    abstract class GameObj: Visitor
    {
        public enum Name
        {
            Squid,
            Crab,
            Octopus,
            AlienRoot,
            AlienColumn,
            MissileRoot,
            Missile,
            BombRoot,
            BombA,
            BombB,
            BombC,
            UFORoot,
            UFO,
            WallRoot,
            WallRight,
            WallLeft,
            WallTop,
            WallBottom,
            PlayerRoot,
            Player,
            ShieldRoot,
            Shield,
            ShieldColumn,
            ShieldBlock,
            EnemyExplosion,
            PlayerExplosion,
            MissileExplosion,
            BombExplosion,
            NOT_INITIALIZED
        }

        public enum Type
        {
            _Alien,
            _Player,
            _Shield,
            _Missile,
            _UFO,
            _Bomb,
            _Wall,
            NOT_INITIALIZED
        }

        ~GameObj()
        {
            this.drawSprite = null;
        }

        protected GameObj(GameObj.Name _name, Index _index, BSprite.Name spriteName, Azul.Color color, bool flyweight)
            :base()
        {
            this.name = _name;
            this.index = _index;
            if (flyweight)
            {
                this.drawSprite = new FSprite(spriteName, Index._0, SpriteMan.find(spriteName), this.x, this.y);
            }
            else
            {
                this.drawSprite = SpriteMan.find(spriteName);
            }
            this.collision = new ColObject(this, color);
        }

        // recursively update object and all of its children
        virtual public void update()
        {
            // depth-first through tree
            if (this.child != null)
            {
                (this.child as GameObj).update();
            }
            if (this.sibling != null)
            {
                (this.sibling as GameObj).update();
            }

            // work here
            drawSprite.x = x;
            drawSprite.y = y;
            collision.update();
        }

        // recursively update collision box to the union of all children
        protected void unionUpdate()
        {
            // get child
            GameObj curr = this.child as GameObj;

            // depth-first through tree
            if (curr != null)
            {
                curr.update();
            }
            if (this.sibling != null)
            {
                (this.sibling as GameObj).update();
            }

            // exception for empty trees, esp the missile and ufo trees
            // don't remove the object entirely, this would disrupt the visitors' collision tree navigation
            // instead make it uncollidable
            if (curr == null)
            {
                this.collision.x = -30.0f;
                this.collision.y = -30.0f;
                this.collision.h = 0.0f;
                this.collision.w = 0.0f;
                return;
            }

            // set to child's collision box
            this.collision.union(curr.collision, curr.collision);

            // merge all siblings
            while (curr.sibling != null)
            {
                curr = curr.sibling as GameObj;
                this.collision.union(this.collision, curr.collision);
            }
        }

        // recursively move object and all of its children
        public virtual void move(float deltaX, float deltaY)
        {
            // depth-first through tree
            if (this.child != null)
            {
                (this.child as GameObj).move(deltaX, deltaY);
            }
            if (this.sibling != null)
            {
                (this.sibling as GameObj).move(deltaX, deltaY);
            }

            // work here
            this.x += deltaX;
            this.y += deltaY;
        }

        public virtual void removeMe()
        {
            this.drawSprite.batchRemove();
            this.collision.drawSprite.batchRemove();

            GObjMan.remove(this);
        }

        override public Enum getName()
        {
            return this.name;
        }

        override public Enum getIndex()
        {
            return this.index;
        }

        public float getHeight()
        {
            return drawSprite.getHeight();
        }

        public float getWidth()
        {
            return drawSprite.getWidth();
        }

        //----------------------
        public GameObj.Name name;
        public Index index;
        public GameObj.Type type;

        public ColObject collision;
        public BSprite drawSprite;
        public float x;
        public float y;
    }
}
