using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using MathLibrary;
using Raylib_cs;
using System.Diagnostics;

namespace MathForGames
{
    class Engine
    {
        public static bool _applicationShouldClose = false;
        public static Scene CurrentScene;
        private static int _currentSceneIndex = 0;
        private static Scene[] _scenes = new Scene[0];
        private Stopwatch _stopwatch = new Stopwatch();

        private static int _enemiesDead;
        private static bool _playerAlive;

        /// <summary>
        /// Called to begin the application
        /// </summary>
        public void Run()
        {
            //Call start for the entire application
            Start();

            float currTime = 0;
            float lastTime = 0;
            float deltaTime = 0;

            //Loop until application is told to close
            while (!Raylib.WindowShouldClose() && !_applicationShouldClose)
            {
                //Get how much time has passed since the application started
                currTime = _stopwatch.ElapsedMilliseconds / 1000.0f;

                //Set deltatime to be the difference in time from the last time recorded to the current time recorded
                deltaTime = currTime - lastTime;

                Update(deltaTime);
                Draw();

                //Set the last time recorded to be the current time
                lastTime = currTime;
            }

            //Calll at the end of the entire application.
            End();
        }

        /// <summary>
        /// Called when the application starts
        /// </summary>
        private void Start()
        {
            _stopwatch.Start();

            //Create Window using raylib
            Raylib.InitWindow(800, 450, "MathForgames");
            Raylib.SetTargetFPS(0);

            //ChaseScene
            Scene TagScene = new Scene();
            Scene LoseScene = new Scene();
            Scene WinScene = new Scene();

            //Actors
            Player Player = new Player('@', 200, 200, 50, Color.BROWN, 20, "Player");
            Chaser Chaser = new Chaser('C', 0, 0, 30, Color.ORANGE, 20, "Chaser", 3, Player);
            Chaser Chaser2 = new Chaser('C', 100, 300, 30, Color.ORANGE, 20, "Chaser2", 3, Player);
            Chaser Chaser3 = new Chaser('C', 200, 400, 30, Color.ORANGE, 20, "Chaser3", 3, Player);


            //UI
            UIText WinningText = new UIText(10, 10, 0, "TestTextBox", Color.GREEN, 800, 800, 15, "The player won! Good Job Partner :)");
            UIText LosingText = new UIText(10, 10, 0, "TestTextBox", Color.RED, 800, 800, 15, "The player Lost! Sorry Partner :(");

            //Add actors to the scene
            TagScene.AddActor(Player);
            TagScene.AddActor(Chaser);
            TagScene.AddActor(Chaser2);
            TagScene.AddActor(Chaser3);
            _playerAlive = false;
            _enemiesDead = 0;


            LoseScene.AddUIElement(LosingText);
            WinScene.AddUIElement(WinningText);

            _scenes = new Scene[]{ TagScene, LoseScene, WinScene };
            //Starts the current scene
            _scenes[_currentSceneIndex].Start();
        }

        /// <summary>
        /// Called everytime the game loops
        /// </summary>
        private void Update(float deltaTime)
        {
            _scenes[_currentSceneIndex].Update(deltaTime);
            CurrentScene = _scenes[_currentSceneIndex];

            while (Console.KeyAvailable)
            {
                Console.ReadKey(true);
            }

            if (_enemiesDead == 3)
            {
                _currentSceneIndex = 2;
            }
            else if (_playerAlive)
            {
                _currentSceneIndex = 1;
            }
        }

        /// <summary>
        /// Called At the end of the application
        /// </summary>
        private void End()
        {
            _scenes[_currentSceneIndex].End();
            Raylib.CloseWindow();
            Console.Clear();
        }

        /// <summary>
        /// Called everytime the game loops to update visuals
        /// </summary>
        private void Draw()
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.BLACK);

            //Adds all actor icons to buffer
            _scenes[_currentSceneIndex].Draw();
            _scenes[_currentSceneIndex].DrawUI();

            Raylib.EndDrawing();
        }

        /// <summary>
        /// Adds a new scene to the engines scene array
        /// </summary>
        /// <param name="scene"></param>
        /// <returns></returns>
        public int AddScene(Scene scene)
        {
            //Create Temporary Array
            Scene[] TempArray = new Scene[_scenes.Length + 1];

            //Copy all values into temporary array
            for (int i = 0; i < _scenes.Length; i++)
            {
                TempArray[i] = _scenes[i];
            }

            //Set the last index to be the new scene
            TempArray[_scenes.Length] = scene;

            //set the old array to the new array
            _scenes = TempArray;

            //Return the last index
            return _scenes.Length - 1;
        }


        /// <summary>
        /// Gets the next key in the input stream
        /// </summary>
        /// <returns>The key that was pressed</returns>
        public static ConsoleKey GetConsoleKey()
        {
            //If there is No Key being pressed...
            if (!Console.KeyAvailable)
            {
                //...Return
                return 0;
            }

            //Return the current key being pressed
            return Console.ReadKey(true).Key;
        }

        //Closes the Application
        public static void CloseApplication()
        {
            _applicationShouldClose = true;
        }

        public static void ActorDeath(Actor actorToRemove)
        {
            if (actorToRemove is Chaser)
            {
                _enemiesDead++;

            }
            else if (actorToRemove is Player)
            {
                _playerAlive = true;
            }
        }
    }
}