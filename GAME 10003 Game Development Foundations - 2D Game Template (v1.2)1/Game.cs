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
    
    public class Game
    {
        // Variables:

        RedPaddle redpaddle = new RedPaddle();

        BluePaddle bluepaddle = new BluePaddle();

        // Assigning class array
        Color[] ballColor = new Color[10];
        int ballColorIndex = 0;

        Ball ball = null;

        // Paddle speed
        float paddlespeed = 5;

        // Flat values for ballspeed
        float ballspeedx = 0;
        float ballspeedy = 0;

        // Randomized which direction the ball goes at the start
        bool startdir = Random.CoinFlip();

        // Individual Radii
        float ballradius = 42;
        float rpradius = 42;
        float bpradius = 42;
        // Radii valued at 42 so that it could still read for collisions
        // closer to the end of the paddles


        // Flat values for radii values at the start
        float bpbRadii = 0;
        float rpbRadii = 0;

        // Randomizing bounce angle
        float randomY = Random.Float((float) -1, (float) 1);

        
        public void Setup()
        {
            Window.SetTitle("Pong Pt. 2: Electric Boogaloo");
            Window.SetSize(800, 600);


            
            // Assigning value
            bpbRadii = ballradius + bpradius;
            // bpb = blue paddle ball
            rpbRadii = ballradius + rpradius;
            //rpb = red paddle ball

            for (int i = 0; i < ballColor.Length; i++)
            {
                ballColor[i] = Random.Color();
            }
            ball = new Ball(ballColor[ballColorIndex]);
        }

        
        public void Update()
        {
            
            Window.ClearBackground(Color.Black);   

            // Paddle Renders
            bluepaddle.Render();
            redpaddle.Render();

            // Field Lines
            Draw.LineColor = Color.Gray;
            Draw.FillColor = Color.Black;
            Draw.Circle(400, 300, 200);

            Draw.LineColor = Color.Gray;
            Draw.Line(400, 600, 400, 0);  
            
            // Spawn Ball
            ball.Render();
            ball.Ballposition.X += ballspeedx;
            ball.Ballposition.Y += ballspeedy;

            // slightly randomizing the angle the ball bounces at
            randomY = Random.Float((float) -1, (float) 1);

            // Game Start
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

            // Blue Paddle Controls
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
            
            // Red Paddle controls
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
           
            // Paddle collisions and velocity adjustment
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
           
            // Roof/Floor collisions
            if (ball.Ballposition.Y <= 14)
            {
                ballspeedy = (ballspeedy * -1);
            }
            else if (ball.Ballposition.Y >= 586)
            {
                ballspeedy = (ballspeedy * -1);
            }
           
            // When ball hits wall behind either paddle, game resets
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
            
            // Arrayed and Randomized ball color changes
            if (Input.IsKeyboardKeyPressed(KeyboardInput.C))
            {
                Console.WriteLine(ballColorIndex);
                    if (ballColorIndex == (ballColor.Length - 1))
                {
                    ballColorIndex = 0;
                }
                    else
                {
                    ballColorIndex += 1;
                }

                ball.ChangeColor(ballColor[ballColorIndex]);
            }
            else if (Input.IsKeyboardKeyPressed(KeyboardInput.X))
            {
                Console.WriteLine(ballColorIndex);
                if (ballColorIndex == 0)
                {
                    ballColorIndex = (ballColor.Length - 1);
                }
                else
                {
                    ballColorIndex -= 1;
                }

                ball.ChangeColor(ballColor[ballColorIndex]);
            }
        }
    }
}
