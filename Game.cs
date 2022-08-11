using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.Window;

namespace PongSFML
{
    internal class Game
    {
        // Игровое окно
        private RenderWindow _window = new RenderWindow(new VideoMode(Variables.SCREEN_WIDTH, Variables.SCREEN_HEIGHT), Variables.GAME_TITLE);

        public Game() {
            Init();
        }

        /// <summary>
        /// Запускает игру
        /// </summary>
        public void Start()
        {
            while (_window.IsOpen) {
                _window.DispatchEvents();

                //Update();
                Draw();

                _window.Display();
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
            
        }
    }
}
