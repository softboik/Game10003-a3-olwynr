using Game10003;
using System.Numerics;

namespace GAME_10003_Game_Development_Foundations___2D_Game_Template__v1._2_1
{
    public class RedPaddle
    {
        public Color RPColor;
        public Color RLColor;
        public Vector2 RPposition;

        public RedPaddle()
        {
           RPColor = new Color(200, 5, 5);
           RLColor = new Color(200,80,80);
           RPposition = new Vector2(770, 300);
        }
        public void Render()
        {          
           Draw.FillColor = RPColor;
           Draw.LineColor = RLColor;
           Draw.LineSize = 2;
           Draw.Capsule(770, 220, 770, 380, 10);
        }
    }
}
