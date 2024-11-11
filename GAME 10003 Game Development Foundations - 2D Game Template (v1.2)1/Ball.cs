using Game10003;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GAME_10003_Game_Development_Foundations___2D_Game_Template__v1._2_1
{
    public class Ball
    {
            public Color BallColor;
            public Color BallLColor;
            public Vector2 Ballposition;

            public Ball()
            {
                BallColor = new Color(255, 255, 255);
                BallLColor = new Color(120, 120, 120);
                Ballposition = new Vector2(400, 300);
            }
            public void Render()
            {
                Draw.FillColor = BallColor;
                Draw.LineColor = BallLColor;
                Draw.LineSize = 2;
                Draw.Circle(400, 300, 15);
            }
        
    }
}
