using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class SceneMan
    {
        private SceneMan()
        {
            this.pHead = null;
            this.currScene = this.pHead as Scene;
        }

        private static SceneMan getInstance()
        {
            Debug.Assert(instance != null);
            return instance;
        }

        public static void create()
        {
            Debug.Assert(instance == null);
            instance = new SceneMan();
        }

        public static Scene add(Scene _scene)
        {
            SceneMan tmp = SceneMan.getInstance();

            if (tmp.pHead == null)
            {
                tmp.pHead = _scene;
                _scene.next = null;
                _scene.prev = null;
            }
            else
            {
                _scene.next = tmp.pHead;
                _scene.prev = null;
                tmp.pHead.prev = _scene;
                tmp.pHead = _scene;
            }

            return _scene;

        }

        public static Scene find(Scene.Name _name)
        {
            SceneMan tmp = SceneMan.getInstance();

            Scene curr = tmp.pHead as Scene;
            while (curr != null)
            {
                if (curr.name.Equals(_name))
                {
                    break;
                }

                curr = curr.next as Scene;
            }

            return curr;
        }

        public static void remove(Scene.Name _name)
        {
            SceneMan tmp = SceneMan.getInstance();

            Scene scene = SceneMan.find(_name);

            if (scene != null)
            {
                if (scene.prev != null)
                {
                    scene.prev.next = scene.next;
                }
                else
                {
                    tmp.pHead = scene.next;
                }
                if (scene.next != null)
                {
                    scene.next.prev = scene.prev;
                }
                scene = null;
            }
        }

        public static void setScene(Scene.Name _name)
        {
            SceneMan tmp = SceneMan.getInstance();

            tmp.currScene = SceneMan.find(_name);
        }

        public static Scene getCurrent()
        {
            SceneMan tmp = SceneMan.getInstance();

            return tmp.currScene;
        }

        public static void update(float totalTime)
        {
            SceneMan tmp = SceneMan.getInstance();

            tmp.currScene.update(totalTime);
        }

        public static void draw()
        {
            SceneMan tmp = SceneMan.getInstance();

            tmp.currScene.draw();
        }

        //-----------------
        private static SceneMan instance;
        private MLink pHead;
        private Scene currScene;
    }
}
