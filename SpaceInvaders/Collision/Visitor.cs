using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    abstract class Visitor: PCSNode
    {
        protected Visitor()
            : base()
        { }

        public abstract void accept(GameObj other);


        // TODO MAKE METHODS FOR EVERY CONCRETE GAME OBJECT
        // OVERRIDE WHERE RELEVANT, CALL WITH ACCEPT()
        public virtual void visitMissile(GameObj other)
        {
            Debug.Assert(false);
        }

        public virtual void visitMissileRoot(GameObj other)
        {
            Debug.Assert(false);
        }

        public virtual void visitAlienRoot(GameObj other)
        {
            Debug.Assert(false);
        }

        public virtual void visitAlienColumn(GameObj other)
        {
            Debug.Assert(false);
        }

        public virtual void visitAlien(GameObj other)
        {
            Debug.Assert(false);
        }

        public virtual void visitShieldRoot(GameObj other)
        {
            Debug.Assert(false);
        }

        public virtual void visitShield(GameObj other)
        {
            Debug.Assert(false);
        }

        public virtual void visitShieldColumn(GameObj other)
        {
            Debug.Assert(false);
        }

        public virtual void visitShieldBlock(GameObj other)
        {
            Debug.Assert(false);
        }

        public virtual void visitWallRoot(GameObj other)
        {
            Debug.Assert(false);
        }

        public virtual void visitWallSides(GameObj other)
        {
            Debug.Assert(false);
        }

        public virtual void visitWallBottom(GameObj other)
        {
            Debug.Assert(false);
        }

        public virtual void visitWallTop(GameObj other)
        {
            Debug.Assert(false);
        }

        public virtual void visitUFO(GameObj other)
        {
            Debug.Assert(false);
        }

        public virtual void visitUFORoot(GameObj other)
        {
            Debug.Assert(false);
        }

        public virtual void visitPlayer(GameObj other)
        {
            Debug.Assert(false);
        }

        public virtual void visitPlayerRoot(GameObj other)
        {
            Debug.Assert(false);
        }

        public virtual void visitBomb(GameObj other)
        {
            Debug.Assert(false);
        }

        public virtual void visitBombRoot(GameObj other)
        {
            Debug.Assert(false);
        }
    }
}
