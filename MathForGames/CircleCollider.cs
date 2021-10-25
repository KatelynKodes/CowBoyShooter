using System;
using System.Collections.Generic;
using System.Text;
using MathLibrary;
using Raylib_cs;

namespace MathForGames
{
    class CircleCollider: Collider
    {
        //Collision radius
        private float _collisionRadius;

        public float CollisionRadius
        {
            get { return _collisionRadius; }
            set { _collisionRadius = value; }
        }

        //Constructor
        public CircleCollider(float collisionRadius, Actor owner) : base(owner, ColliderType.CIRCLE)
        {
            _collisionRadius = collisionRadius;
        }

        /// <summary>
        /// Draws the circle collider onto the screen using raylib 
        /// </summary>
        public override void Draw()
        {
            Raylib.DrawCircleLines((int)Owner.GetPosition.X, (int)Owner.GetPosition.Y, CollisionRadius, Color.RED);
        }

        public override bool CheckCircleCollision(CircleCollider circleCollider)
        {
            if (circleCollider.Owner == Owner)
                return false;

            float distance = Vector2.Distance();
            float CombinedRadii = circleCollider.CollisionRadius + CollisionRadius;
            return;
        }

        public override bool CheckCollisionAABB(AABBCollider boxCollider)
        {

        }
    }
}
