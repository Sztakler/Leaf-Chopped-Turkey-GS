using System;

namespace Leaf
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new LeafGame())
                game.Run();
        }
    }
}
