using System;
using System.Collections.Generic;
using System.Text;
using Raylib_cs;

namespace MathForGames
{
    class UIText : Actor
    {
        public string Text;
        public int Width;
        public int Height;
        public Font Font;
        public int FontSize; 

        public UIText(float x, float y, float collisionRadius, string name, Color color, int width, int height, int fontsize, string text) : base( '\0', x, y, color, collisionRadius, name)
        {
            Text = text;
            Width = width;
            Height = height;
            Font = Raylib.LoadFont("resources/fonts/alagard.png");
            FontSize = fontsize;
        }

        public override void Draw()
        {
            Rectangle textbox = new Rectangle(GetPosition.X, GetPosition.Y, Width, Height);
            Raylib.DrawTextRec(Font, Text, textbox, FontSize, 1, true, GetIcon.color);
        }
    }
}
