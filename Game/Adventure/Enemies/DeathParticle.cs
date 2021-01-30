using Framework.Game;
using Framework.Render;
using OpenTK;
using OpenTK.Graphics;
using Framework.Util;
using System;
using System.Collections.Generic;
using System.Text;
using Framework.Development.Components;
using System.Drawing;

namespace Adventure.Enemies
{
    public class DeathParticle : GameObject
    {
        public DeathParticle(Vector2 position)
        {
            transform.position = position;
            ParticleRenderer particleRenderer = new ParticleRenderer(this, 100, 2f, 0.1f, Color4.IndianRed);
            AddComponent(particleRenderer);
            particleRenderer.CreateParticles();
            if (Debug.enabled)
            {
                AddComponent(new DebugUnrotatedColliderEdgesComponent(this, new Framework.Shapes.RectangleBounds(.5f, .5f), Color.GreenYellow));
            }
        }

    }
}
