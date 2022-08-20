using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.Window;
using SFML.System;

namespace PongSFML
{
    internal class Game
    {
        // Игровое окно
        private RenderWindow _window = new RenderWindow(new VideoMode(Variables.SCREEN_WIDTH, Variables.SCREEN_HEIGHT), Variables.GAME_TITLE);
        // Часы
        private Clock _clock = new Clock();
        // Коробка со спрайтами для отрисовки
        private Dictionary<string, Drawable> _spriteBatch = new Dictionary<string, Drawable>();

        // Игровые объекты
        private Bat _batL = new Bat("left");
        private Bat _batR = new Bat("right");
        private Ball _ball = new Ball();

        public Game() {
            Init();
        }

        /// <summary>
        /// Запускает игру
        /// </summary>
        public void Start()
        {
            LoadContent();

            // Игровой цикл
            while (_window.IsOpen) {
                Time time = _clock.Restart();       // Обнуляем таймер и сохраняем время, прошедшее с предыдущего кадра

                _window.DispatchEvents();           // Обрабатываем события окна

                Update(time.AsSeconds()); 
                Draw();
            }
        }

        /// <summary>
        /// Загрузка контента в игру
        /// </summary>
        private void LoadContent() {
            _spriteBatch.Add("batL", _batL.Sprite);
            _spriteBatch.Add("batR", _batR.Sprite);
            _spriteBatch.Add("ball", _ball.Sprite);
        }

        /// <summary>
        /// Инициализирует игру и игровые объекты
        /// </summary>
        private void Init() {
            _window.Closed += (object? sender, EventArgs e) => { _window.Close(); };

            _batL.Init();
            _batR.Init();
            _ball.Init();
        }

        /// <summary>
        /// Обновляет игровые объекты
        /// </summary>
        /// <param name="deltaTime">Разница во времени между кадрами</param>
        private void Update(float deltaTime) { 
            _batL.Update(deltaTime);
            _batR.Update(deltaTime);
            _ball.Update(deltaTime);
        }

        /// <summary>
        /// Отрисовывает игровые объекты
        /// </summary>
        private void Draw() {
            _window.Clear();                    // Очищаем окно

            // Отрисовываем спрайты
            _window.Draw(_spriteBatch["batL"]);
            _window.Draw(_spriteBatch["batR"]);
            _window.Draw(_spriteBatch["ball"]);

            _window.Display();                  // Отображаем окно
        }
    }
}
