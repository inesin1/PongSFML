using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.System;

namespace PongSFML
{
    static internal class Variables
    {
        public const int SCREEN_WIDTH = 800;       //Ширина экрана
        public const int SCREEN_HEIGHT = 600;      //Высота экрана

        public const int SCREEN_HALF_WIDTH = SCREEN_WIDTH / 2;        //Половина ширины экрана
        public const int SCREEN_HALF_HEIGHT = SCREEN_HEIGHT / 2;      //Половина высоты экрана

        public const string GAME_TITLE = "Pong";                      //Заголовок игры
        public const string ASSETS_FOLDER = "Assets\\";

        // Стандартнаые позиции объектов
        public static Vector2f DEFAULT_BAT_L_POSITION = new Vector2f(50, SCREEN_HALF_HEIGHT);                   
        public static Vector2f DEFAULT_BAT_R_POSITION = new Vector2f(SCREEN_WIDTH - 50, SCREEN_HALF_HEIGHT);
        public static Vector2f DEFAULT_BALL_POSITION = new Vector2f(SCREEN_HALF_WIDTH, SCREEN_HALF_HEIGHT);
    }
}
