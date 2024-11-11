using Game10003;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GAME_10003_Game_Development_Foundations___2D_Game_Template__v1._2_1
{
    public class BluePaddle
    {
        public Color BPColor;
        public Color BLColor;
        public Vector2 BPposition;

        public BluePaddle()
        {
            BPColor = new Color(0, 160, 220);
            BLColor = new Color(50, 210, 270);
            BPposition = new Vector2(30, 300);
        }
        public void Render()
        {
            Draw.FillColor = BPColor;
            Draw.LineColor = BLColor;
            Draw.LineSize = 2;
            Draw.Capsule(BPposition.X, BPposition.Y - 80, BPposition.X, BPposition.Y + 80, 10);
        }
    }
}
