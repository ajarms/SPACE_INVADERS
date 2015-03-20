using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    
    class Image: MLink
    {
        public enum Name
        {
            Player_Ship,
            Ship_Base,
            Ship_Blaster,
            Alien_Explosion,
            Ship_Explosion_0,
            Ship_Explosion_1,
            Projectile_vs_Wall,
            Bomb_vs_Missile,
            UFO,
            Shield,
            Shield_Block,
            Shield_Corner,
            Shield_SmallBlock,
            Red_Bird,
            Squid_0,
            Squid_1,
            Crab_0,
            Crab_1,
            Octopus_0,
            Octopus_1,
            Missile,
            BombA_0,
            BombA_1,
            BombA_2,
            BombA_3,
            BombB_0,
            BombB_1,
            BombB_2,
            BombC_0,
            BombC_1,
            BombC_2,
            NOT_INITIALIZED
        }


        public Image()
            : base()
        {
            this.name = Name.NOT_INITIALIZED;
            this.text = null;
            this.rect = null;
        }

        virtual public void set(Image.Name inName, Texture.Name inText, int x, int y, int width, int height)
        {
            this.name = inName;
            this.rect = new Azul.Rect(x,y,width,height);

            // grab texture, if it exists
            Texture tmp = TextMan.find(inText);
            Debug.Assert(tmp != null);
            this.text = tmp;
        }

        public override Enum getName()
        {
            return this.name;
        }

        override public Enum getIndex()
        {
            return this.index;
        }

        //----------------------
        public Name name;
        public Index index = Index._0;
        public Texture text;
        public Azul.Rect rect;

    }
}
