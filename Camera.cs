using Microsoft.Xna.Framework;

namespace Leaf
{
    public class Camera
    {
        public Matrix Transform { get; private set; }

        public void Follow(Sprite target)
        {
            Matrix offset = Matrix.CreateTranslation(
                LeafGame.ScreenWidth  / 2, 
                LeafGame.ScreenHeight / 2, 
                0);
            
            Matrix position = Matrix.CreateTranslation(
                -target.position.X - (target.getFrameWidth()  / 2),
                -target.position.Y - (target.getFrameHeight() / 2),
                0);

            Transform = position * offset;
        }
    }
}