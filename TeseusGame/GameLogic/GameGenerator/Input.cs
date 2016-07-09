using OpenTK;

namespace GameLogic.GameGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using OpenTK.Input;
    using System.Drawing;

    /// <summary>
    /// Implements keybort 
    /// </summary>
   public class Input
    {
        private static List<Key> keyDown;
        private static List<Key> keyDownLast;

        private static List<MouseButton> buttonDown;
        private static List<MouseButton> buttonDownLast;

        public static void Initialize(GameWindow game)
        {
            keyDown = new List<Key>();
            keyDownLast = new List<Key>();

            buttonDown = new List<MouseButton>();
            buttonDownLast = new List<MouseButton>();


            game.KeyDown += Game_KeyDown;
            game.KeyUp += Game_KeyUp;
            game.MouseDown += Game_MouseDown;
            game.MouseUp += Game_MouseUp;
        }

        private static void Game_MouseUp(object sender, MouseButtonEventArgs e)
        {
            while (buttonDown.Contains(e.Button))
            {
                buttonDown.Remove(e.Button);
            }
        }

        private static void Game_MouseDown(object sender, MouseButtonEventArgs e)
        {
            buttonDown.Add(e.Button);

        }

        private static void Game_KeyUp(object sender, KeyboardKeyEventArgs e)
        {
            while (keyDown.Contains(e.Key))
            {
               keyDown.Remove(e.Key);
            }
        }

        private static void Game_KeyDown(object sender, KeyboardKeyEventArgs e)
        {
            keyDown.Add(e.Key);
        }


        public static void Update()
        {
            keyDownLast = new List<Key>(keyDown);
            buttonDownLast = new List<MouseButton>(buttonDown);

        }
        /// <summary>
        /// Checks if a key is presss
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool KeyPress(Key key)
        {
            return (keyDown.Contains(key) && !keyDownLast.Contains(key));
        }
        public static bool KeyReleas(Key key)
        {
            return (!keyDown.Contains(key) && keyDownLast.Contains(key));
        }
        public static bool KeyDown(Key key)
        {
            return (keyDown.Contains(key));
        }


        /// <summary>
        /// Mous Button
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool MousePress(MouseButton button)
        {
            return (buttonDown.Contains(button) && !buttonDownLast.Contains(button));
        }
        public static bool MouseReleas(MouseButton button)
        {
            return (!buttonDown.Contains(button) && buttonDownLast.Contains(button));
        }
        public static bool MouseDown(MouseButton button)
        {
            return (buttonDown.Contains(button));
        }

    }
}
