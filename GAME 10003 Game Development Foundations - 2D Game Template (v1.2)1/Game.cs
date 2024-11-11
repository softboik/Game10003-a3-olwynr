// Include code libraries you need below (use the namespace).
using System;
using System.Data;
using System.Numerics;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;

// The namespace your code is in.
namespace Game10003
{
    /// <summary>
    ///     Your game code goes inside this class!
    /// </summary>
    public class Game
    {
        // Variables:
        Color RedTeam = new Color(200, 5, 5);
        
        Color BlueTeam = new Color(0, 160, 220);

       // Draw Rpaddle = new Draw.Capsule(30, 220, 30, 380, 10);

        public void Setup()
        {
            Window.SetSize(800, 600);
        }

        /// <summary>
        ///     Update runs every frame.
        /// </summary>
        public void Update()
        {
            Window.ClearBackground(Color.Black);

            Draw.Line(400, 600, 400, 0);
            Draw.LineColor = Color.Gray;

            Draw.Circle(400, 300, 200);
            Draw.LineColor = Color.Gray;
            Draw.FillColor = Color.Black;

            Draw.Capsule(30, 220, 30, 380, 10);
            Draw.FillColor = BlueTeam;
            Draw.LineColor = Color.White;
            Draw.LineSize = 2;
            

            Draw.Capsule(770, 220, 770, 380, 10);
            Draw.FillColor = RedTeam;
            Draw.LineColor = Color.White;
            Draw.LineSize = 2;
            

            Draw.Circle(400, 300, 20);
            Draw.FillColor = Color.White;

            if (Input.IsKeyboardKeyDown(KeyboardInput.W))
            {

            }
            else if (Input.IsKeyboardKeyDown(KeyboardInput.S))
            {

            }

        }
    }
}
