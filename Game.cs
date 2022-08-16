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
        //Часы
        private Clock _clock = new Clock();
        // Коробка со спрайтами для отрисовки
        private Dictionary<string, Drawable> _spriteBatch = new Dictionary<string, Drawable>();

        public Game() {
            Init();
        }

        /// <summary>
        /// Запускает игру
        /// </summary>
        public void Start()
        {
            // Игровой цикл
            while (_window.IsOpen) {
                Time time = _clock.Restart();       // Обнуляем таймер и сохраняем время, прошедшее с предыдущего кадра

                _window.DispatchEvents();           // Обрабатываем события окна

                Update(time.AsSeconds()); 
                Draw();
            }
        }

        /// <summary>
        /// Инициализирует игру и игровые объекты
        /// </summary>
        private void Init() {
            _window.Closed += (object? sender, EventArgs e) => { _window.Close(); };


        }

        /// <summary>
        /// Обновляет игровые объекты
        /// </summary>
        /// <param name="deltaTime">Разница во времени между кадрами</param>
        private void Update(float deltaTime) { 
            
        }

        /// <summary>
        /// Отрисовывает игровые объекты
        /// </summary>
        private void Draw() {
            _window.Clear();                    // Очищаем окно

            _window.Draw(_spriteBatch["batL"]);
            _window.Draw(_spriteBatch["batR"]);
            _window.Draw(_spriteBatch["ball"]);

            _window.Display();                  // Отображаем окно
        }
    }
}
