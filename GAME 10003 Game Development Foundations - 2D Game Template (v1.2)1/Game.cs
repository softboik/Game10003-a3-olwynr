// Include code libraries you need below (use the namespace).
using System;
using System.Data;
using System.Numerics;
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

            Draw.Capsule(30, 220, 30, 380, 10);
            Draw.LineColor = Color.White;
            Draw.LineSize = 2;
            Draw.FillColor = BlueTeam;

            Draw.Capsule(770, 220, 770, 380, 10);
            Draw.LineColor = Color.White;
            Draw.LineSize = 2;
            Draw.FillColor = RedTeam;

            Draw.Circle(400, 300, 20);
            Draw.FillColor = Color.White;
        }
    }
}
