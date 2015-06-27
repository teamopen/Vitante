using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Vitante {
    class Sprite {
        private Texture2D texture;
        public float X { get; set; }
        public float Y { get; set; }

        public Sprite(Texture2D texture) {
            this.texture = texture;
            this.X = 0.0f;
            this.Y = 0.0f;
        }

        public Sprite(Texture2D texture, Vector2 position) {
            this.texture = texture;
            this.X = position.X;
            this.Y = position.Y;
        }

        public void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(texture, new Vector2(X, Y));
        }
    }
}
