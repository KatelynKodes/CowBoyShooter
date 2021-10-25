using System;
using System.Collections.Generic;
using System.Text;
using Raylib_cs;

namespace MathForGames
{
    class AABBCollider : Collider
    {
        //Width and height
        private float _width;
        private float _height;

        public float Width
        {
            get { return _width; }
            set { _width = value; }
        }

        public float Height
        {
            get { return _height; }
            set { _width = value; }
        }
        

        //Top, Bottom, left, right
        public float Top
        {
            get { return Owner.GetPosition.Y - (_height / 2); }
        }

        public float Bottom
        {
            get { return Owner.GetPosition.Y + (_height / 2); }
        }

        public float Left
        {
            get { return Owner.GetPosition.X - (_width / 2); }
        }

        public float Right
        {
            get { return Owner.GetPosition.X + (_width / 2); }
        }

        //Constructor
        public AABBCollider(float width, float height, Actor owner) : base(owner, ColliderType.CIRCLE)
        {
            _width = width;
            _height = height;
        }

        /// <summary>
        /// Draws Boxcollider onto the raylib window
        /// </summary>
        public override void Draw()
        {
            Raylib.DrawRectangleLines((int)Left, (int)Top, (int)_width, (int)_height, Color.GREEN);
        }

        /// <summary>
        /// Calls check AABB collision method from the circle collider
        /// </summary>
        /// <param name="circleCollider"> Circlecollider calling the method </param>
        /// <returns></returns>
        public override bool CheckCircleCollision(CircleCollider circleCollider)
        {
            return circleCollider.CheckCollisionAABB(this);
        }

        /// <summary>
        /// Checks collision with another box collider
        /// </summary>
        /// <param name="boxCollider"> the box collider being checked against for collision</param>
        /// <returns> True if the two box colliders collide with one another</returns>
        public override bool CheckCollisionAABB(AABBCollider boxCollider)
        {
            //Checks if the collider is not it's own
            if (boxCollider.Owner == Owner)
            {
                return false;
            }

            return (boxCollider.Left <= Right &&
                    boxCollider.Top <= Bottom &&
                    Left <= boxCollider.Right &&
                    Top <= boxCollider.Bottom);
        }
    }
}
