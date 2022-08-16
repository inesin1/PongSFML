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

                _window.Clear();                    // Очищаем окно

                Update(time.AsSeconds()); 
                Draw();

                _window.Display();                  // Отображаем окно
            }
        }

        /// <summary>
        /// Инициализирует игру и игровые объекты
        /// </summary>
        private void Init() {
            _window.Closed += (object? sender, EventArgs e) => { _window.Close(); };

            _circleShape.FillColor = Color.Red;
            _bitmapSprite = new Sprite(_bitmapTexture);
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
        }
    }
}
