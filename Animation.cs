using Microsoft.Xna.Framework.Graphics;

namespace Leaf
{
    public class Animation
    {
        public Texture2D Texture { get; private set; }
        public int CurrentFrame { get; set; }
        public int FrameCount { get; private set; }
        public int RowCount { get; private set; }
        public int CurrentRow { get; set; }
        public int FrameHeight { get { return Texture.Height / RowCount; } }
        public int FrameWidth {get { return Texture.Width / FrameCount; } }
        public float FrameSpeed  { get; set; }
        public bool IsLooping { get; set; }

        public Animation(Texture2D texture, int frameCount, int rowCount, int currentRow)
        {
            Texture = texture;
            FrameCount = frameCount;
            RowCount = rowCount;
            CurrentRow = currentRow;
            IsLooping = true;
            FrameSpeed = 0.2f;
        }
    }
}