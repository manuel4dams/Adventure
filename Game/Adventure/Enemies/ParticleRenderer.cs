using System;
using System.Collections.Generic;
using System.Drawing;
using Framework.Camera;
using Framework.Game;
using Framework.Interfaces;
using Framework.Shapes;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Adventure.Enemies
{
    public class ParticleRenderer : IComponent, IUpdateable, IRender
    {
        int maxParticles;
        float lifetime;
        float particleBounds;
        Color color;

        public ParticleRenderer(GameObject gameObject, int maxParticles, float lifetime, float particleBounds,
            Color color)
        {
            this.gameObject = gameObject;
            this.maxParticles = maxParticles;
            this.lifetime = lifetime;
            this.particleBounds = particleBounds;
            this.color = color;

            CreateParticles();
        }

        public GameObject gameObject { get; }
        private readonly List<Particle> particles = new List<Particle>();


        public void Update(float deltaTime)
        {
            particles.ForEach(particle => particle.Update(deltaTime));

            particles.RemoveAll(particle => particle.lifetime <= 0);
        }

        public void Draw()
        {
            particles.ForEach(particle => particle.Draw());
        }

        private void CreateParticles()
        {
            for (var i = 0; i < maxParticles; i++)
            {
                particles.Add(new Particle(
                    lifetime,
                    particleBounds,
                    gameObject.transform.position,
                    new Vector2(new Random().Next(-30, 30) / 10f, new Random().Next(-40, 50) / 10f),
                    color));
            }
        }
    }

    public class Particle
    {
        public float lifetime;
        private float size;
        private int alpha = 255;
        private Vector2 position;
        private Vector2 direction;
        private Vector2 velocity;
        private Color color;

        public Particle(float lifetime, float size, Vector2 position, Vector2 direction, Color color)
        {
            this.lifetime = lifetime;
            this.size = size;
            this.position = position;
            this.direction = direction;
            velocity = this.direction;
            this.color = color;
        }

        public void Update(float deltaTime)
        {
            velocity = Vector2.Lerp(velocity, new Vector2(0, -1), deltaTime * 2f);
            position += velocity * deltaTime;
            lifetime -= deltaTime;
            color = Color.FromArgb(alpha, color);
            if (alpha > 5)
            {
                alpha -= 5;
            }
            Console.WriteLine($"{lifetime} {deltaTime} {position}");
        }

        public void Draw()
        {
            var quad = default(Quad);
            quad.vertex1 = position + new Vector2(-size, -size);
            quad.vertex2 = position + new Vector2(size, -size);
            quad.vertex3 = position + new Vector2(size, size);
            quad.vertex4 = position + new Vector2(-size, size);
            quad.Translate(-Camera.instance.transform.position);

            GL.Begin(PrimitiveType.Quads);
            GL.Color4(color);
            GL.Vertex2(quad.vertex1);
            GL.Vertex2(quad.vertex2);
            GL.Vertex2(quad.vertex3);
            GL.Vertex2(quad.vertex4);
            GL.End();
            GL.Color4(Color.White);
        }
    }
}