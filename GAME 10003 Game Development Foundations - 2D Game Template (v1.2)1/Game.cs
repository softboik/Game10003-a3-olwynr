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

        RedPaddle redpaddle = new RedPaddle();

        BluePaddle bluepaddle = new BluePaddle();

        Ball ball = new Ball();

        float paddlespeed = 5;

        float ballspeedx = 0;
        float ballspeedy = 0;

        bool startdir = Random.CoinFlip();

        float ballradius = 42;
        float rpradius = 42;
        float bpradius = 42;

        float bpbRadii = 0;
        float rpbRadii = 0;

        float randomY = Random.Float((float) -0.7, (float) 0.7);

        public void Setup()
        {
            Window.SetSize(800, 600);
            
            bpbRadii = ballradius + bpradius;
            rpbRadii = ballradius + rpradius;
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

            randomY = Random.Float((float)-0.7, (float)0.7);

            if (Input.IsKeyboardKeyDown(KeyboardInput.Space))
            {
                float y = ball.Ballposition.Y;
                float x = ball.Ballposition.X;

                if (ballspeedx == 0 && startdir == true)
                {
                    ballspeedx = 3;
                    ballspeedy = 0;
                }
                else if (ballspeedx == 0 && startdir == false)
                {
                    ballspeedx = -3;
                    ballspeedy = 0;
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
            
            bool doBallandRedOverlap = Vector2.Distance(ball.Ballposition, redpaddle.RPposition) <= rpbRadii;
            bool doBallandBlueOverlap = Vector2.Distance(ball.Ballposition, bluepaddle.BPposition) <= bpbRadii;
            if (doBallandRedOverlap == true && ball.Ballposition.X >= 750)
            {
                ballspeedx = (ballspeedx * -1) - 1;
                ballspeedy = (ballspeedy + randomY);
            }
            else if (doBallandBlueOverlap == true && ball.Ballposition.X <= 50)
            {
                ballspeedx = (ballspeedx * -1) + 1;
                ballspeedy = (ballspeedy + randomY);
            }
            if (ball.Ballposition.Y <= 14)
            {
                ballspeedy = (ballspeedy * -1);
            }
            else if (ball.Ballposition.Y >= 586)
            {
                ballspeedy = (ballspeedy * -1);
            }
            if (ball.Ballposition.X <= 0)
            {
                ball.Ballposition.X = 400;
                ball.Ballposition.Y = 300;
                
                ballspeedx = 0;
                ballspeedy = 0;

                redpaddle.RPposition.Y = 300;

                bluepaddle.BPposition.Y = 300;
            }
            else if (ball.Ballposition.X >= 800)
            {
                ball.Ballposition.X = 400;
                ball.Ballposition.Y = 300;

                ballspeedx = 0;
                ballspeedy = 0;

                redpaddle.RPposition.Y = 300;

                bluepaddle.BPposition.Y = 300;
            }
        }
    }
}
