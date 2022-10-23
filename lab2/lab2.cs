using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System.Drawing;



namespace OpenTK_LAB2
{
   public  class lab2
    {
        
        double unghi = 0.0;
        
        GameWindow window;

        public lab2(GameWindow window)
        {
            this.window = window;
            Start();
        }
        void Start()
        {
            window.Load += incarcat;
            window.Resize += resize;
            window.UpdateFrame += updateF;
            window.RenderFrame += renderF;
            window.KeyPress += key;
            window.MouseDown += mouse;
            window.Run(1.0 / 60.0);
        }
        
        
        void resize(object o, EventArgs e)
        {
            GL.Viewport(0, 0, window.Width, window.Height);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(-50.0, 50.0, -50.0, 50.0, -1.0, 1.0);
            GL.MatrixMode(MatrixMode.Modelview);
        }
        void updateF(object o, EventArgs e)
        {
            KeyboardState s = Keyboard.GetState();
            //Rotirea cubului la stanga
            if (s.IsKeyDown(Key.L))
            {
                unghi += 1.0;

            }
            //Rotirea cubului la drepta
            if (s.IsKeyDown(Key.R))
            {
                unghi += -1.0;

            }
            //Stoparea cubului
            if (s.IsKeyDown(Key.S))
            {
                unghi = 0.0;

            }

        }
        void renderF(object o, EventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.Rotate(unghi,0.0, 0.0, 1.0);
            GL.Begin(PrimitiveType.Quads);

            GL.Color3(1.0, 0.0, 0.0);

            GL.Vertex2(30.0, 30.0);

            GL.Color3(1.0, 1.0, 0.0);

            GL.Vertex2(-30.0, 30.0);

            GL.Color3(0.0, 0.0, 1.0);

            GL.Vertex2(-30.0, -30.0);

            GL.Color3(1.0, 1.0, 0.0);

            GL.Vertex2(30.0, -30.0);

            GL.End();
            window.SwapBuffers();
        }
        void key (object o,KeyPressEventArgs e)
        {
            Console.WriteLine("keypress : " + e.KeyChar);
        }
        void mouse(object o,MouseButtonEventArgs e)
        {
            MouseState mouse = OpenTK.Input.Mouse.GetState();
            if (mouse[MouseButton.Left])
                //umbrirea cubului
            {
                if (GL.IsEnabled(EnableCap.Lighting))
                    GL.Disable(EnableCap.Lighting);
                else
                    GL.Enable(EnableCap.Lighting);
                
                
            }
        }
        void keyUp(object o, KeyboardKeyEventArgs e)
        {
            Console.WriteLine("KeyUp : " + e.Key);
        }




        void incarcat (object o,EventArgs e)
        {
            GL.ClearColor(0.0f,0.0f,0.0f,0.0f);
        }
    }
}