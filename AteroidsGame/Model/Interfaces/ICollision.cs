using System.Drawing;

namespace AteroidsGame.Model.Interfaces
{
    public interface ICollision
    {
        bool Collision(ICollision obj);

        Rectangle Rect { get; }
    }
}
