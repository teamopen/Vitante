using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Vitante {
    class Character : Sprite{

        private float speed = 0.0f;
        public Character(Texture2D texture) : base(texture) {
        }

        public Character(Texture2D texture, Vector2 position) : base(texture, position) {
        }

        public void Update() {
            X += speed;
        }

        public void MoveLeft() {
            speed -= 1.0f;
        }

        public void MoveRight() {
            speed += 1.0f;
        }

    }
}
