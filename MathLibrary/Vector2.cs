using System;

namespace MathLibrary
{
    public struct Vector2
    {
        public float X;
        public float Y;


        /// <summary>
        /// Returns a Vector2 that contains x and y values that are sums of two Vector2 x and Y values
        /// </summary>
        /// <param name="lhs"> Vector2 on the left hand side </param>
        /// <param name="rhs"> Vector2 on the right hand side </param>
        /// <returns></returns>
        public static Vector2 operator +(Vector2 lhs, Vector2 rhs)
        {
            //Adds the x and y values of the left and right hand sides.
            //Returning new a new vector 2 with those values as the x and y coordinates
            return new Vector2 { X = lhs.X + rhs.X, Y = lhs.Y + rhs.Y };
        }

        /// <summary>
        /// Returns a Vector2 that contains x and y values that are differences of two Vector2 x and Y values
        /// </summary>
        /// <param name="lhs"> Vector2 on the left hand side </param>
        /// <param name="rhs"> Vector2 on the right hand side </param>
        /// <returns></returns>
        public static Vector2 operator -(Vector2 lhs, Vector2 rhs)
        {
            //Subtracts the x and y values of the left and right hand sides.
            //Returning new a new vector 2 with those values as the x and y coordinates
            return new Vector2 { X = lhs.X - rhs.X, Y = lhs.Y - rhs.Y };
        }

        //Multiplication with a scaler
        public static Vector2 operator *(Vector2 vector, float scaler)
        {
            // Multiplies the x and y values of a given vector by a scaler
            //Returns new a new vector 2 with those values as the x and y coordinates
            return new Vector2 { X = vector.X * scaler, Y = vector.Y * scaler };
        }

        //Division with a scaler
        public static Vector2 operator /(Vector2 vector, float scaler)
        {
            //Divides the x and y values of a given vector by a scaler
            //Returns new a new vector 2 with those values as the x and y coordinates
            return new Vector2 { X = vector.X / scaler, Y = vector.Y / scaler };
        }

        //Equals
        public static bool operator ==(Vector2 checkingVector, Vector2 vectorChecked)
        {
            // Checks if the x and y variables of one vector2 are exactly the same as another vector2's x and y variables
            if (checkingVector.X == vectorChecked.X && checkingVector.Y == vectorChecked.Y)
            {
                //...returns true
                return true;
            }

            //..otherwise, returns false
            return false;
        }

        //Not Equals
        public static bool operator !=(Vector2 checkingVector, Vector2 vectorChecked)
        {
            // Checks if the x or y variables of one vector are not equal to another vector2's x or y variables
            if (checkingVector.X != vectorChecked.X || checkingVector.Y != vectorChecked.Y)
            {
                //...returns true
                return true;
            }

            //...returns false
            return false;
        }
    }
}
