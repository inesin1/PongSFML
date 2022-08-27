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

        private long _startSleep = 0;       // Время старта сна
        private int _sleepTime = 0;         // Время сна
        private bool _isSleep = false;      // Спит ли

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

            if (TimeSpan.FromTicks(DateTime.Now.Ticks - _startSleep).TotalMilliseconds >= _sleepTime)
                _isSleep = false;

            if (_isSleep)
            {
                _speed = 0;
            }
            else
            {
                _speed = 400.0f;
            }

            Sprite.Position = Position;
        }

        /// <summary>
        /// Останавливает объект на установленное время
        /// </summary>
        /// <param name="sleepTime">Время сна</param>
        public void Sleep(int sleepTime)
        {
            _startSleep = DateTime.Now.Ticks;
            _sleepTime = sleepTime;
            _isSleep = true;
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
                Sleep(1000);
            }

            if (Position.X <= 0 + Size.X / 2) {
                Context.Scores[1]++;
                Context.Restart();
                Sleep(1000);
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
