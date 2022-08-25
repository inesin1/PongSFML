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
        public Game Context { get; }                                // Контекст
        public Vector2f Position { get; set; } = new Vector2f();    // Позиция
        public Vector2f Size { get; set; } = new Vector2f();        // Размеры
        public Sprite Sprite { get; set; } = new Sprite();          // Спрайт

        private float _speed = 400.0f;      // Скорость движения
        private float _direction = 45.0f;   // Направление

        public Ball(Game context) { 
            Context = context;
        }

        /// <summary>
        /// Инициализация. Запускается при создании объекта
        /// </summary>
        public void Init() {
            Position = Variables.DEFAULT_BALL_POSITION;
            Sprite = new Sprite(new Texture(Variables.ASSETS_FOLDER + "s_Ball.png"));
            Sprite.Origin = new Vector2f(Sprite.GetLocalBounds().Width / 2, Sprite.GetLocalBounds().Height / 2);
            Size = new Vector2f(Sprite.GetLocalBounds().Width, Sprite.GetLocalBounds().Height);
        }

        /// <summary>
        /// Обновление. Запускается каждый кадр
        /// </summary>
        public void Update(float deltaTime) {
            Move(deltaTime);
            CheckCollision();

            Sprite.Position = Position;
        }

        /// <summary>
        /// Передвижение мяча
        /// </summary>
        private void Move(float deltaTime) {
            float newX = Position.X + (float)Math.Cos(DegToRad(_direction)) * _speed * deltaTime;
            float newY = Position.Y - (float)Math.Sin(DegToRad(_direction)) * _speed * deltaTime;
            Position = new Vector2f(newX, newY);
        }

        /// <summary>
        /// Проверяет столкновения мяча 
        /// </summary>
        private void CheckCollision() {
            // С вертикальными границами поля
            if (
                Position.Y <= 0 + Size.Y / 2 || 
                Position.Y >= Variables.SCREEN_HEIGHT - Size.Y / 2
                )
                _direction = 360 - _direction;

            // С горизонтальными границами поля
            if (Position.X >= Variables.SCREEN_WIDTH - Size.X / 2)
            {
                Context.Scores[0]++;
                Context.Restart();
            }

            if (Position.X <= 0 + Size.X / 2) {
                Context.Scores[1]++;
                Context.Restart();
            }

            // С ракетками
            if (IsCollide(Context.BatL) || IsCollide(Context.BatR))
                _direction = 180 - _direction;
        }

        /// <summary>
        /// Проверка столкновения с ракеткой
        /// </summary>
        /// <param name="bat">Ракетка</param>
        /// <returns>Есть ли столкновение</returns>
        private bool IsCollide(Bat bat) {
            return
                Position.X + Size.X >= bat.Position.X &&
                Position.X <= bat.Position.X + bat.Sprite.GetLocalBounds().Width &&
                Position.Y + Size.Y >= bat.Position.Y &&
                Position.Y <= bat.Position.Y + bat.Sprite.GetLocalBounds().Height;
        }

        /// <summary>
        /// Конвертирует градусы в радианы
        /// </summary>
        private float DegToRad(float deg) {
            return deg * (float)Math.PI / 180;
        }
    }
}
