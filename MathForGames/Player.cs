using System;
using System.Collections.Generic;
using System.Text;
using MathLibrary;

namespace MathForGames
{
    class Player : Actor
    {
        private Vector2 _velocity;
        private float _speed;

        public float GetSpeed
        {
            get { return _speed; }
            set { _speed = value; }
        }

        public Vector2 GetVelocity
        {
            get { return _velocity; }
            set { _velocity = value; }
        }

        public Player(char icon, float x, float y, float speed, string name = "Actor", ConsoleColor IconColor = ConsoleColor.White) :
            base(icon, x, y, name, IconColor)
        {
            _speed = speed;
        }

        public override void Update()
        {
            Vector2 Movedirection = new Vector2();
            ConsoleKey KeyPressed = Engine.GetConsoleKey();

            if (KeyPressed == ConsoleKey.A)
            {
                Movedirection = new Vector2 { X = -1};
            }
            if (KeyPressed == ConsoleKey.D)
            {
                Movedirection = new Vector2 { X = 1 };
            }
            if (KeyPressed == ConsoleKey.W)
            {
                Movedirection = new Vector2 { Y = -1 };
            }
            if (KeyPressed == ConsoleKey.S)
            {
                Movedirection = new Vector2 { Y = 1 };
            }

            GetVelocity = Movedirection * _speed;

            GetPosition += _velocity;
        }

        public override void OnCollision(Actor actor)
        {
            Engine.CloseApplication();
        }
    }
}
