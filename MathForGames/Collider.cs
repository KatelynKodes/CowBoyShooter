using System;
using System.Collections.Generic;
using System.Text;

namespace MathForGames
{
    enum ColliderType
    {
        CIRCLE,
        AABB
    }
    abstract class Collider
    {
        private Actor _owner;
        private ColliderType _colliderType;

        public Actor Owner
        {
            get { return _owner; }
            set { _owner = value; }
        }

        public ColliderType ColliderType
        {
            get { return _colliderType; }
        }

        public Collider(Actor owner, ColliderType colliderType)
        {
            _owner = owner;
            _colliderType = colliderType;
        }

        public virtual void Draw() { }

        public bool CheckCollider(Actor actor)
        {
            if (actor.Collider.ColliderType == ColliderType.CIRCLE)
                return actor.Collider.CheckCircleCollision((CircleCollider)actor.Collider);
            else if (actor.Collider.ColliderType == ColliderType.AABB)
                return actor.Collider.CheckCollisionAABB((AABBCollider)actor.Collider);

            return false;
        }

        public virtual bool CheckCircleCollision(CircleCollider circleCollider) { return false; }
        public virtual bool CheckCollisionAABB(AABBCollider boxCollider) { return false; }

    }
}
