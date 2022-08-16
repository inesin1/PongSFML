using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.System;
using SFML.Graphics;

namespace PongSFML
{
    /// <summary>
    /// Ракетка
    /// </summary>
    internal class Bat
    {
        public Vector2f Position { get; set; } = new Vector2f();
        public Sprite Sprite { get; set; } = new Sprite();

        private float _speed = 100.0f;
        private string _side = "none";

        /// <summary>
        /// Стандартный конструктор
        /// </summary>
        /// <param name="side">Сторона ракетки: 'left' - слева, 'right' - справа</param>
        public Bat(string side) { 
            _side = side;
        }

        public void Init() { 
            
        }

        public void Move() { 
            
        }
    }
}
