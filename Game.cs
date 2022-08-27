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
        public Bat BatL = new Bat("left");
        public Bat BatR = new Bat("right");
        public Ball Ball;

        // Очки | [0] - left, [1] - right 
        public int[] Scores = { 0, 0 };

        // Шрифт
        private Font _font = new Font(@"Assets\AtariClassicSmooth.ttf");
        private Text _scorePanel;
        private Text _resultText = new Text();

        // Идет ли игра
        private bool _isPlay = true;

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
        /// Перезапускает игру
        /// </summary>
        public void Restart() {
            Ball.Position = Variables.DEFAULT_BALL_POSITION;
        }

        /// <summary>
        /// Загрузка контента в игру
        /// </summary>
        private void LoadContent() {
            _spriteBatch.Add("batL", BatL.Sprite);
            _spriteBatch.Add("batR", BatR.Sprite);
            _spriteBatch.Add("ball", Ball.Sprite);
        }

        /// <summary>
        /// Инициализирует игру и игровые объекты
        /// </summary>
        private void Init() {
            Ball = new Ball(this);

            _window.Closed += (object? sender, EventArgs e) => { _window.Close(); };

            BatL.Init();
            BatR.Init();
            Ball.Init();
        }

        /// <summary>
        /// Обновляет игровые объекты
        /// </summary>
        /// <param name="deltaTime">Разница во времени между кадрами</param>
        private void Update(float deltaTime) {
            if (_isPlay)
            {
                BatL.Update(deltaTime);
                BatR.Update(deltaTime);
                Ball.Update(deltaTime);

                CheckEndGame();
            }
            else {
                if (Keyboard.IsKeyPressed(Keyboard.Key.R)) {
                    Scores = new int[2] { 0, 0 };
                    _isPlay = true;
                    Restart();
                }
            }

            _scorePanel = new Text($"{Scores[0]}\t{Scores[1]}", _font);
            _scorePanel.Position = new Vector2f(Variables.SCREEN_HALF_WIDTH - _scorePanel.GetLocalBounds().Width / 2, 16);
            _resultText.Position = new Vector2f(Variables.SCREEN_HALF_WIDTH - _resultText.GetLocalBounds().Width / 2, Variables.SCREEN_HALF_HEIGHT - 100);
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
            _window.Draw(_scorePanel);
            if (!_isPlay) 
                _window.Draw(_resultText);

            _window.Display();                  // Отображаем окно
        }

        /// <summary>
        /// Проверяет закончена ли игра
        /// </summary>
        private void CheckEndGame() {
            if (Scores[0] == 2 || Scores[1] == 2) {
                _isPlay = false;

                if (Scores[0] > Scores[1])
                {
                    _resultText = new Text("Player 1 win!\nPress R to restart", _font);
                }
                else {
                    _resultText = new Text("Player 2 win!\nPress R to restart", _font);
                }
            }
        }
    }
}
