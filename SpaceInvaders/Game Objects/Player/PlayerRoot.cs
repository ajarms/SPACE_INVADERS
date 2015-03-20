using System;

namespace SpaceInvaders
{
    class PlayerRoot: _Player
    {
        public PlayerRoot( Index index = Index._0, float _x = 0.0f, float _y = 0.0f)
            : base(GameObj.Name.PlayerRoot, index, BSprite.Name.NullSprite, new Azul.Color(0.0f, 0.0f, 250.0f))
        {
            this.x = _x;
            this.y = _y;
            this.LeftState = new PlayerState_MoveL();
            this.FireState = new PlayerState_CanFire();
            this.RightState = new PlayerState_MoveR();
        }

        public override void update()
        {
            base.unionUpdate();
        }

        public void fireMissile()
        {
            fireState.handle(this);
        }

        public void moveRight()
        {
            rightState.handle(this);
        }

        public void moveLeft()
        {
            leftState.handle(this);
        }

        public State LeftState
        {
            get { return leftState; }
            set { leftState = value; }
        }
        public State RightState
        {
            get { return rightState; }
            set { rightState = value; }
        }
        public State FireState
        {
            get { return fireState; }
            set { fireState = value; }
        }
        private State fireState;
        private State leftState;
        private State rightState;

        //-----------------------------------
        // visitor handlers
        //-----------------------------------

        public override void accept(GameObj that)
        {
            that.visitPlayerRoot(this);
        }

        public override void visitWallSides(GameObj other)
        {
            _Player curr = this.child as _Player;

            while (curr != null)
            {
                ColPair.collide(curr, other);

                curr = curr.sibling as _Player;
            }
        }

        public override void visitBomb(GameObj other)
        {
            _Player curr = this.child as _Player;

            while (curr != null)
            {
                ColPair.collide(curr, other);

                curr = curr.sibling as _Player;
            }
        }

        public override void visitAlienRoot(GameObj other)
        {
            other.visitPlayerRoot(this);
        }

        public override void visitAlienColumn(GameObj other)
        {
            other.visitPlayerRoot(this);
        }

        public override void visitAlien(GameObj other)
        {
            _Player curr = this.child as _Player;

            while (curr != null)
            {
                ColPair.collide(curr, other);

                curr = curr.sibling as _Player;
            }
        }
    }
}
