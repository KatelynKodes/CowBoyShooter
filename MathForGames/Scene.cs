using System;
using System.Collections.Generic;
using System.Text;

namespace MathForGames
{
    class Scene
    {
        /// <summary>
        /// Array of actors in the scenes
        /// </summary>
        private Actor[] _actors;

        public Scene()
        {
            _actors = new Actor[0];
        }

        /// <summary>
        /// Calls start for all the actors in the _actors array
        /// </summary>
        public virtual void Start()
        {
            for (int i = 0; i < _actors.Length; i++)
            {
                _actors[i].Start();
            }
        }

        /// <summary>
        /// Calls update for every actor in the actor array
        /// Calls start for the actor if it wasn't already called
        /// </summary>
        public virtual void Update()
        {
            for (int i = 0; i < _actors.Length; i++)
            {
                if (!_actors[i].Started)
                {
                    _actors[i].Start();
                }
                _actors[i].Update();

                // Check for collision
                for (int j = 0; j < _actors.Length; j++)
                {
                    if (_actors[i].GetPosition == _actors[j].GetPosition)
                    {
                        _actors[i].OnCollision(_actors[j]);
                    }
                }
            }

        }

        /// <summary>
        /// Calls End for all the actors in the _actors array
        /// </summary>
        public virtual void End()
        {
            for (int i = 0; i < _actors.Length; i++)
            {
                _actors[i].End();
            }
        }

        /// <summary>
        /// Calls draw for all the actors in the _actors array
        /// </summary>
        public virtual void Draw()
        {
            for (int i = 0; i < _actors.Length; i++)
            {
                _actors[i].Draw();
            }
        }

        /// <summary>
        /// Adds a new actor to the _actors array
        /// </summary>
        /// <param name="actor"> The actor being added to the array</param>
        public void AddActor(Actor actor)
        {
            //Creates a new template array
            Actor[] NewActorArray = new Actor[_actors.Length + 1];

            //Places the previos values in their proper spot in the template array
            for (int i = 0; i < _actors.Length; i++)
            {
                NewActorArray[i] = _actors[i];
            }

            //Sets the last spot of the template array to actor
            NewActorArray[NewActorArray.Length-1] = actor;

            //makes _actors array match the template array
            _actors = NewActorArray;
        }

        /// <summary>
        /// Removes a specified actor from a given Array
        /// </summary>
        /// <param name="actor">The actor the player must get rid of </param>
        /// <returns></returns>
        public bool RemoveActor(Actor actor)
        {
            // A variable to show if remove was successful
            bool ActorRemoved = false;

            //A new array that is smaller than the original
            Actor[] TempArray = new Actor[_actors.Length - 1];

            //Copy all values except actior we do not want
            int j = 0;
            for (int i = 0; i < TempArray.Length; i++)
            {
                //If the actor in the array matches the one we're trying to find
                if (_actors[i] != actor)
                {
                    //Store actor in the index of J
                    TempArray[j] = _actors[i];

                    //Increase j
                    j++;
                }
                else
                {
                    //Set ActorRemoved to true
                    ActorRemoved = true;
                }
            }

            //Check if actor was removed
            if (ActorRemoved)
            {
                //Make the _actors array match the temparray
                _actors = TempArray;
            }

            //return ActorRemoved
            return ActorRemoved;
        }
    }
}
