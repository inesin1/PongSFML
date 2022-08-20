using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.System;
using SFML.Graphics;
using SFML.Window;

namespace PongSFML
{
    /// <summary>
    /// Ракетка
    /// </summary>
    internal class Bat
    {
        public Vector2f Position { get; set; } = new Vector2f();    // Позиция
        public Sprite Sprite { get; set; } = new Sprite();          // Спрайт

        private float _speed = 400.0f;      // Скорость движения
        private string _side = "none";      // С какой стороны ракетка (Лево, право)

        /// <summary>
        /// Стандартный конструктор
        /// </summary>
        /// <param name="side">Сторона ракетки: 'left' - слева, 'right' - справа</param>
        public Bat(string side) { 
            _side = side;
        }

        /// <summary>
        /// Инициализация 
        /// </summary>
        public void Init() {
            if (_side == "left")
            {
                Position = Variables.DEFAULT_BAT_L_POSITION;
                Sprite = new Sprite(new Texture(Variables.ASSETS_FOLDER + "s_Bat_L.png"));
                Sprite.Origin = new Vector2f(Sprite.GetLocalBounds().Width / 2, Sprite.GetLocalBounds().Height / 2);
            }
            else {
                Position = Variables.DEFAULT_BAT_R_POSITION;
                Sprite = new Sprite(new Texture(Variables.ASSETS_FOLDER + "s_Bat_R.png"));
                Sprite.Origin = new Vector2f(Sprite.GetLocalBounds().Width / 2, Sprite.GetLocalBounds().Height / 2);
            }
        }

        /// <summary>
        /// Обновление 
        /// </summary>
        public void Update(float deltaTime) {
            Move(deltaTime);

            Sprite.Position = Position;
        }

        /// <summary>
        /// Передвижение
        /// </summary>
        private void Move(float deltaTime) {
            if (_side == "left")
            {
                if (Keyboard.IsKeyPressed(Keyboard.Key.W))
                {
                    Position = new Vector2f(Position.X, Position.Y - _speed * deltaTime);
                }

                if (Keyboard.IsKeyPressed(Keyboard.Key.S))
                {
                    Position = new Vector2f(Position.X, Position.Y + _speed * deltaTime);
                }
            }
            else
            {
                if (Keyboard.IsKeyPressed(Keyboard.Key.Up))
                {
                    Position = new Vector2f(Position.X, Position.Y - _speed * deltaTime);
                }

                if (Keyboard.IsKeyPressed(Keyboard.Key.Down))
                {
                    Position = new Vector2f(Position.X, Position.Y + _speed * deltaTime);
                }
            }

            if (Position.Y < 0 + Sprite.GetLocalBounds().Height / 2)
                Position = new Vector2f(Position.X, Position.Y + _speed * deltaTime);

            if (Position.Y > Variables.SCREEN_HEIGHT - Sprite.GetLocalBounds().Height / 2)
                Position = new Vector2f(Position.X, Position.Y - _speed * deltaTime);
        }
    }
}
