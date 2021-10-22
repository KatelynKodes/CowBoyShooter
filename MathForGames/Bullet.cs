using System;
using System.Collections.Generic;
using System.Text;
using MathLibrary;
using Raylib_cs;

namespace MathForGames
{
    class Bullet:Actor
    {
        public Bullet(float x, float y, float collisionRadius) : base('-', x, y, Color.WHITE, collisionRadius, "Bullet")
        {
        }

        public override void Update(float deltaTime)
        {
            Vector2 newPos = new Vector2(1, 0);
            GetPosition += newPos;
        }

        public override void OnCollision(Actor actor)
        {
            if (actor is Chaser)
            {
                Engine.ActorDeath(actor);
            }
        }
    }
}
