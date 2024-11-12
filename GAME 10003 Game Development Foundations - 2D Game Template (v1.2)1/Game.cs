// Include code libraries you need below (use the namespace).
using GAME_10003_Game_Development_Foundations___2D_Game_Template__v1._2_1;
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

        RedPaddle redpaddle = new RedPaddle();

        BluePaddle bluepaddle = new BluePaddle();

        Ball ball = new Ball();

        float paddlespeed = 5;

        float ballspeedx = 0;
        float ballspeedy = 0;

        bool startdir = Random.CoinFlip();

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

            bluepaddle.Render();

            redpaddle.Render();

            Draw.LineColor = Color.Gray;
            Draw.FillColor = Color.Black;
            Draw.Circle(400, 300, 200);

            Draw.LineColor = Color.Gray;
            Draw.Line(400, 600, 400, 0);  
            
            ball.Render();
            ball.Ballposition.X += ballspeedx;
            ball.Ballposition.Y += ballspeedy;

            if (Input.IsKeyboardKeyDown(KeyboardInput.Space))
            {
                float y = ball.Ballposition.Y;
                float x = ball.Ballposition.X;

                if (ballspeedx == 0 && startdir == true)
                {
                    ballspeedx = 3;
                }
                else if (ballspeedx == 0 && startdir == false)
                {
                    ballspeedx = -3;
                }
            }

            if (Input.IsKeyboardKeyDown(KeyboardInput.W))
            {
                float y = bluepaddle.BPposition.Y;
                float x = bluepaddle.BPposition.X;

                if (y - (paddlespeed) >= 100)
                {
                    bluepaddle.BPposition = new Vector2(x, y - (paddlespeed));
                }
            }
            else if (Input.IsKeyboardKeyDown(KeyboardInput.S))
            {
                float y = bluepaddle.BPposition.Y;
                float x = bluepaddle.BPposition.X;

                if (y + (paddlespeed) <= 500)
                {
                    bluepaddle.BPposition = new Vector2(x, y + (paddlespeed));
                }
                
            }
            if (Input.IsKeyboardKeyDown(KeyboardInput.Up))
            {
                float y = redpaddle.RPposition.Y;
                float x = redpaddle.RPposition.X;

                if (y - (paddlespeed) >= 100)
                {
                    redpaddle.RPposition = new Vector2(x, y - (paddlespeed));
                }
            }
            else if (Input.IsKeyboardKeyDown(KeyboardInput.Down))
            {
                float y = redpaddle.RPposition.Y;
                float x = redpaddle.RPposition.X;

                if (y + (paddlespeed) <= 500)
                {
                    redpaddle.RPposition = new Vector2(x, y + (paddlespeed));
                }
            }

        }
    }
}
