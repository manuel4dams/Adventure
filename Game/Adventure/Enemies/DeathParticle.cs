using System.Drawing;
using Framework.Game;
using OpenTK;

namespace Adventure.Enemies
{
    public class DeathParticle : GameObject
    {
        public DeathParticle(Vector2 position)
        {
            transform.position = position;

            AddComponent(new ParticleRenderer(this, 100, 2f, 0.1f, Color.IndianRed));
        }
    }
}