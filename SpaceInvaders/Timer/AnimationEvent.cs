using System;

namespace SpaceInvaders
{
    class AnimationEvent:Event
    {
        public enum Name
        {
            Crab_Animation,
            Octopus_Animation,
            Squid_Animation,
            Grid_Movement,
            BombA_Animation,
            BombB_Animation,
            BombC_Animation,
            Death_Animation,
            NOT_INITIALIZED
        }

        public AnimationEvent()
            : base()
        {
            this.name = Name.NOT_INITIALIZED;
            this.animationTarget = null;

            this.current = null;
            this.listHead = null;
            this.moveTarget = null;
            this.deltaOverride = false;
            this.deltaX = 0.0f;
            this.deltaY = 0.0f;
            this.repeat = false;
        }

        ~AnimationEvent()
        {
            this.animationTarget = null;
            this.current = null;
            this.listHead = null;
            this.moveTarget = null;
        }

        public void set(AnimationEvent.Name _name, bool repeat, bool deltaOverride, GameObj moveTarget, float deltaX, float deltaY)
        {
            this.name = _name;
            this.deltaOverride = deltaOverride;
            this.moveTarget = moveTarget;
            this.deltaX = deltaX;
            this.deltaY = deltaY;

            switch (_name)
            {
                case AnimationEvent.Name.Grid_Movement:
                    break;
                case AnimationEvent.Name.Crab_Animation:
                    this.animationTarget = SpriteMan.find(GSprite.Name.Crab);
                    break;
                case AnimationEvent.Name.Octopus_Animation:
                    this.animationTarget = SpriteMan.find(GSprite.Name.Octopus);
                    break;
                case AnimationEvent.Name.Squid_Animation:
                    this.animationTarget = SpriteMan.find(GSprite.Name.Squid);
                    break;
                case AnimationEvent.Name.BombA_Animation:
                    this.animationTarget = SpriteMan.find(GSprite.Name.BombA);
                    break;
                case AnimationEvent.Name.BombB_Animation:
                    this.animationTarget = SpriteMan.find(GSprite.Name.BombB);
                    break;
                case AnimationEvent.Name.BombC_Animation:
                    this.animationTarget = SpriteMan.find(GSprite.Name.BombC);
                    break;
                case AnimationEvent.Name.Death_Animation:
                    this.animationTarget = SpriteMan.find(GSprite.Name.Player_Ship);
                    break;
            }
        }

        public void attach(Image.Name imgName)
        {
            Image img = ImgMan.find(imgName);
            ImgNode node = new ImgNode(img);

            // put image on head of img list
            if (listHead == null)
            {
                listHead = node;
            }
            else
            {
                node.next = listHead;
                listHead = node;
            }

            // make current
            current = node;
        }

        public override void execute(float deltaTime)
        {
            // account for timer override
            if (deltaOverride)
            {
                deltaTime = Constants.ALIEN_SPEED();
            }

            // account for movement component
            if (moveTarget != null)
            {
                moveTarget.move(deltaX, deltaY);
            }

            // account for image swap
            if (animationTarget != null)
            {
                // get next image
                ImgNode node = current.next as ImgNode;

                // if null, get start of list
                if (node == null)
                {
                    node = listHead as ImgNode;
                }

                // change target sprite's image
                animationTarget.img = node.image;

                // reset current image
                current = node;
            }

            // add back onto timer
            TimerMan.add(Timer.Name.AlienAnimationTimer, this, deltaTime);
        }

        override public Enum getName()
        {
            return this.name;
        }

        override public Enum getIndex()
        {
            return this.index;
        }

        //-------------------
        public AnimationEvent.Name name;
        public Index index = Index._0;
        //image swap component
        protected GSprite animationTarget;
        private ImgNode current;
        private ImgLink listHead;
        //movement component
        private GameObj moveTarget;
        private float deltaX;
        private float deltaY;
        //control for repetition
        private bool repeat;
        private bool deltaOverride;

    }


    class ImgLink
    {
        protected ImgLink()
        {
            this.next = null;
        }

        public ImgLink next;
    }

    class ImgNode : ImgLink
    {
        public ImgNode(Image img)
            : base()
        {
            this.image = img;
        }

        ~ImgNode()
        {
            this.image = null;
        }

        public Image image;
    }

}
