using System;
using System.Collections.Generic;
using System.Text;
using MathLibrary;

namespace MathForGames
{
    struct Icon
    {
        public char Symbol;
        public ConsoleColor color;
    }

    class Actor
    {
        private Icon _icon;
        private string _name;
        private Vector2 _position;
        private bool _started;

        public bool Started
        {
            get { return _started;}
        }

        public Vector2 GetPosition
        {
            get { return _position; }
            set { _position = value; }
        }

        public Actor(char icon, float x, float y, string name = "Actor", ConsoleColor IconColor = ConsoleColor.White) : 
            this(icon, new Vector2 { X = x, Y = y}, name, IconColor ){}

        public Actor(char CharIcon, Vector2 Position, string name = "Actor", ConsoleColor IconColor = ConsoleColor.White)
        {
            _icon = new Icon { Symbol = CharIcon, color = IconColor};
            _position = Position;
            _name = name;
        }

        public virtual void Start()
        {
            _started = true;
        }

        public virtual void Update()
        {
        }

        public virtual void Draw()
        {
            Engine.Render(_icon, _position);
        }

        public void End()
        {
            
        }

        public virtual void OnCollision(Actor actor)
        {
            
        }
    }
}
