using System;

namespace SpaceInvaders
{
    class MissileRoot: _Missile
    {
        public MissileRoot()
            : base(GameObj.Name.MissileRoot, Index._0, BSprite.Name.NullSprite, new Azul.Color(0.0f, 0.0f, 250.0f))
        {
            this.x = 0.0f;
            this.y = 0.0f;
        }

        public override void update()
        {
            base.unionUpdate();
        }

        public override void move(float x, float y)
        {
            base.move(x, y);
        }

        //-----------------------------------
        // visitor handlers
        //-----------------------------------

        public override void accept(GameObj that)
        {
            that.visitMissileRoot(this);
        }

        public override void visitAlienRoot(GameObj other)
        {
            other.visitMissileRoot(this);
        }

        public override void visitAlienColumn(GameObj other)
        {
            other.visitMissileRoot(this);
        }

        public override void visitUFORoot(GameObj other)
        {
            other.visitMissileRoot(this);
        }

        public override void visitBombRoot(GameObj other)
        {
            other.visitMissileRoot(this);
        }

        public override void visitWallRoot(GameObj other)
        {
            other.visitMissileRoot(this);
        }

        public override void visitShieldRoot(GameObj other)
        {
            other.visitMissileRoot(this);
        }

        public override void visitShield(GameObj other)
        {
            other.visitMissileRoot(this);
        }

        public override void visitShieldColumn(GameObj other)
        {
            other.visitMissileRoot(this);
        }

        public override void visitAlien(GameObj other)
        {
            ColPair.collide(other, this.child as GameObj);
        }

        public override void visitWallTop(GameObj other)
        {
            ColPair.collide(other, this.child as GameObj);
        }

        public override void visitUFO(GameObj other)
        {
            ColPair.collide(other, this.child as GameObj);
        }

        public override void visitBomb(GameObj other)
        {
            ColPair.collide(other, this.child as GameObj);
        }

        public override void visitShieldBlock(GameObj other)
        {
            ColPair.collide(other, this.child as GameObj);
        }
    }
}
