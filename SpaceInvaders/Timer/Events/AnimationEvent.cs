using System;

namespace SpaceInvaders
{
    class AnimationEvent:Event
    {
        public AnimationEvent(Event.Name _name, bool deltaOverride = false)
            :base()
        {
            this.name = _name;
            this.deltaOverride = deltaOverride;

            switch (_name)
            {
                case Event.Name.Crab_Animation:
                    this.animationTarget = SpriteMan.find(GSprite.Name.Crab);
                    break;
                case Event.Name.Octopus_Animation:
                    this.animationTarget = SpriteMan.find(GSprite.Name.Octopus);
                    break;
                case Event.Name.Squid_Animation:
                    this.animationTarget = SpriteMan.find(GSprite.Name.Squid);
                    break;
                case Event.Name.BombA_Animation:
                    this.animationTarget = SpriteMan.find(GSprite.Name.BombA);
                    break;
                case Event.Name.BombB_Animation:
                    this.animationTarget = SpriteMan.find(GSprite.Name.BombB);
                    break;
                case Event.Name.BombC_Animation:
                    this.animationTarget = SpriteMan.find(GSprite.Name.BombC);
                    break;
                case Event.Name.Death_Animation:
                    this.animationTarget = SpriteMan.find(GSprite.Name.PlayerExplosion);
                    break;
            }
        }

        ~AnimationEvent()
        {
            this.animationTarget = null;
            this.current = null;
            this.listHead = null;
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

            // add back onto timer
            
            Timer.Name n;
            if (this.name.Equals(Event.Name.BombA_Animation) ||
                this.name.Equals(Event.Name.BombB_Animation) ||
                this.name.Equals(Event.Name.BombC_Animation))
            { n = Timer.Name.BombAnimationTimer; }

            else if (this.name.Equals(Event.Name.Death_Animation))
            { n = Timer.Name.DeathAnimationTimer; }

            else
            { n = Timer.Name.AlienAnimationTimer; }

            TimerMan.add(n, this, deltaTime);
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
        public Event.Name name;
        public Index index = Index._0;

        protected GSprite animationTarget;
        private ImgNode current;
        private ImgLink listHead;
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
