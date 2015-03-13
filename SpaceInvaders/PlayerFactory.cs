using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class PlayerFactory: Factory
    {
        private PlayerFactory()
            : base()
        { }

        private static PlayerFactory getInstance()
        {
            if (instance == null)
            {
                instance = new PlayerFactory();
            }
            return instance;
        }

        public static PCSTree getTree()
        {
            PlayerFactory tmp = PlayerFactory.getInstance();

            return tmp.tree;
        }

        public static void makePlayerRoot()
        {
            // make a test missle
            PlayerFactory tmp = PlayerFactory.getInstance();

            // set batches
            tmp.setBatch(SpriteBatch.Name.Projectiles);
            tmp.setColBatch(SpriteBatch.Name.Collision);

            // set PCSTree
            tmp.setPCSTree();

            // make missile root
            _Player shipUnion = new PlayerRoot();
            GObjMan.add(shipUnion);
            tmp.colBatch.add(shipUnion.collision.drawSprite);
            tmp.tree.insert(shipUnion, tmp.parent);
        }

        public static void spawnPlayer()
        {
            GameObj pRoot = GObjMan.find(GameObj.Type._Player, GameObj.Name.PlayerRoot);

            // cannot spawn a Player if one is active
            if (pRoot.child != null)
            {
                return;
            }

            PlayerFactory tmp = PlayerFactory.getInstance();

            tmp.setParent(pRoot);
            tmp.setBatch(SpriteBatch.Name.Midground);
            tmp.setColBatch(SpriteBatch.Name.Collision);

            float startX = Constants.SCREEN_WIDTH / 2 - 26.0f;
            float startY = 64.0f;

            // Base of Ship
            _Player ship = new PlayerShip(Index._0, startX, startY, BSprite.Name.Player_Ship);

            tmp.currBatch.add(ship.drawSprite);
            tmp.colBatch.add(ship.collision.drawSprite);
            tmp.tree.insert(ship, tmp.parent);

            // Blaster of Ship
            startX += 1.0f;
            ship = new PlayerShip(Index._0, startX, startY, BSprite.Name.Player_Ship);

            tmp.currBatch.add(ship.drawSprite);
            tmp.colBatch.add(ship.collision.drawSprite);
            tmp.tree.insert(ship, tmp.parent);

        }


        //----------------------------------//
        private static PlayerFactory instance;
    }
}
