using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class TempObjNode : MLink
    {
        public TempObjNode()
            : base()
        {
            this.pGameObj = null;
        }

        ~TempObjNode()
        {
            this.pGameObj = null;
        }

        public void set(GameObj target)
        {
            this.pGameObj = target;
        }

        public override Enum getName()
        {
            Debug.Assert(pGameObj != null);

            return pGameObj.name;
        }

        public override Enum getIndex()
        {
            Debug.Assert(pGameObj != null);

            return pGameObj.index;
        }

        //--------------------
        public GameObj pGameObj;
    }
}
