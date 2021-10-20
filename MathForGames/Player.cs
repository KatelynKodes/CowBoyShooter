using System;
using System.Collections.Generic;
using System.Text;
using MathLibrary;
using Raylib_cs;

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

        public Player(char icon, float x, float y, float speed, Color IconColor, float collisionRadius, string name = "Actor") :
            base(icon, x, y, IconColor, collisionRadius, name)
        {
            _speed = speed;
        }

        /// <summary>
        /// Checks which button is pressed by the player, then moves the player object to that position
        /// Updates every frame
        /// </summary>
        public override void Update(float deltaTime)
        {
            int xDirection = -Convert.ToInt32(Raylib.IsKeyDown(KeyboardKey.KEY_A)) +
                Convert.ToInt32(Raylib.IsKeyDown(KeyboardKey.KEY_D));
            int yDirection = -Convert.ToInt32(Raylib.IsKeyDown(KeyboardKey.KEY_W)) +
                Convert.ToInt32(Raylib.IsKeyDown(KeyboardKey.KEY_S)); ;

            Vector2 Movedirection = new Vector2(xDirection, yDirection);

            GetVelocity = Movedirection.Normalized * _speed * deltaTime;

            GetPosition += _velocity;
        }


        /// <summary>
        /// Preforms an action if the position of the player is equal to the position of another actor
        /// or the child of an actor
        /// </summary>
        /// <param name="collider"> The actor the player collided with </param>
        public override void OnCollision(Actor collider)
        {
            if (collider is Chaser)
            {
                Engine.CloseApplication();
            }
        }
    }
}