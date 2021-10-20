using System;

namespace MathLibrary
{
    public struct Vector2
    {
        public float X;
        public float Y;

        public Vector2(float xValue, float yValue)
        {
            X = xValue;
            Y = yValue;
        }

        /// <summary>
        /// Gets the length of the vector 
        /// </summary>
        public float Magnitude
        {
            get
            {
                return (float)Math.Sqrt(X * X + Y * Y);
            }
        }

        public Vector2 Normalized
        {
            get
            {
                Vector2 value = this;
                return value.Normalize();
            }
        }

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

        /// <summary>
        /// Returns a vector2 containg an instance of a vector divided by the magnitude
        /// </summary>
        /// <returns> The result of the normalization. Returns an empty vector2 if the magnitude is zero</returns>
        public Vector2 Normalize()
        {
            if (Magnitude == 0)
            {
                return new Vector2();
            }
            return this / Magnitude;
        }


        /// <param name="lhs"> The left hand side</param>
        /// <param name="rhs"> The right hand side</param>
        /// <returns> The dot product of the first vector2 on to the second </returns>
        public static float DotProduct(Vector2 lhs, Vector2 rhs)
        {
            return (lhs.X * rhs.X) + (lhs.Y * rhs.Y);
        }

        /// <summary>
        /// Finds the distance from one vector to the second
        /// </summary>
        /// <param name="lhs"> The starting point</param>
        /// <param name="rhs"> The ending point</param>
        /// <returns> A scaler representing the distance</returns>
        public static float Distance(Vector2 lhs, Vector2 rhs)
        {
            return (rhs - lhs).Magnitude;
        }
    }
}
