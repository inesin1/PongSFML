using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongSFML
{
    /// <summary>
    /// Мяч
    /// </summary>
    internal class Ball
    {
        public Vector2f Position { get; set; } = new Vector2f();    // Позиция
        public Vector2f Size { get; set; } = new Vector2f();        // Размеры
        public Sprite Sprite { get; set; } = new Sprite();          // Спрайт

        private float _speed = 400.0f;      // Скорость движения
        private float _direction = 45.0f;   // Направление

        /// <summary>
        /// Инициализация. Запускается при создании объекта
        /// </summary>
        public void Init() {
            Position = Variables.DEFAULT_BALL_POSITION;
            Sprite = new Sprite(new Texture(Variables.ASSETS_FOLDER + "s_Ball.png"));
            Sprite.Origin = new Vector2f(Sprite.GetLocalBounds().Width / 2, Sprite.GetLocalBounds().Height / 2);
        }

        /// <summary>
        /// Обновление. Запускается каждый кадр
        /// </summary>
        public void Update(float deltaTime) {
            Sprite.Position = Position;

            float newX = Position.X + (float)Math.Cos(DegToRad(_direction)) * _speed * deltaTime;
            float newY = Position.Y - (float)Math.Sin(DegToRad(_direction)) * _speed * deltaTime;
            Position = new Vector2f(newX, newY);
        }

        /// <summary>
        /// Конвертирует градусы в радианы
        /// </summary>
        private float DegToRad(float deg) {
            return deg * (float)Math.PI / 180;
        }
    }
}
