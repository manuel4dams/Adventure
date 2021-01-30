using System.Drawing;
using Framework.Development.Components;
using Framework.Game;
using Framework.Render;
using Framework.Shapes;
using Framework.Util;
using OpenTK;

namespace Adventure.Enemies
{
    public class DeathParticle : GameObject
    {
        public DeathParticle(Vector2 position)
        {
            transform.position = position;
            var particleRenderer = new ParticleRenderer(this, 100, 2f, 0.1f, Color.IndianRed);
            AddComponent(particleRenderer);
            if (Debug.enabled)
            {
                AddComponent(new DebugUnrotatedColliderEdgesComponent(
                    this,
                    new RectangleBounds(0.5f, 0.5f),
                    Color.GreenYellow));
            }
        }
    }
}