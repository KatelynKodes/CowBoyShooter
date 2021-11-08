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

            float distance = Vector2.Distance(circleCollider.Owner.GetPosition, Owner.GetPosition);
            float CombinedRadii = circleCollider.CollisionRadius + CollisionRadius;
            return distance <= CombinedRadii;
        }

        public override bool CheckCollisionAABB(AABBCollider boxCollider)
        {
            if (boxCollider.Owner == Owner)
            {
                return false;
            }

            Vector2 direction = Owner.GetPosition - boxCollider.Owner.GetPosition;

            direction.X = Math.Clamp(direction.X, -boxCollider.Width/2, boxCollider.Width/2);
            direction.Y = Math.Clamp(direction.Y, -boxCollider.Height / 2, boxCollider.Height / 2);

            Vector2 closestPoint = boxCollider.Owner.GetPosition + direction;

            float distFromClosestPoint = Vector2.Distance(Owner.GetPosition, closestPoint);

            return distFromClosestPoint <= CollisionRadius;
        }
    }
}
