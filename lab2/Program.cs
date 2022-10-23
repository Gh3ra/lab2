using System;
using OpenTK;
using OpenTK.Graphics;

namespace OpenTK_LAB2
{
    class program
    {
        public static void Main(string[] args)
        {
            GameWindow window = new GameWindow(500,500);
            lab2 lab = new lab2(window);
        }
    }
}