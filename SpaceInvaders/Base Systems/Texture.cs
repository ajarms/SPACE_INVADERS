using System;

namespace SpaceInvaders
{
   
    class Texture : MLink
    {
        public enum Name
        {
            Angry_Birds,
            InvadersFromSpace,
            ArcadeQuality,
            Explosions,
            NOT_INITIALIZED
        }

        public Texture()
            :base()
        {
            this.name = Texture.Name.NOT_INITIALIZED;
            this.text = null;
        }
        
        public void set(Texture.Name inName, string fn)
        {
            this.name = inName;
            this.text = new Azul.Texture(fn);
        }

        public override Enum getName()
        {
            return this.name;
        }

        override public Enum getIndex()
        {
            return this.index;
        }

        //-----------------
        public Name name;
        public Index index = Index._0;
        public Azul.Texture text;

    }
}
