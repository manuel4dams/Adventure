using System;
using System.Collections.Generic;
using System.Drawing;
using Framework.Game;
using Framework.Interfaces;
using Framework.Shapes;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace Framework.Render
{
    public class ParticleRenderer : IComponent, IUpdateable, IRender
    {
        private struct Particle
        {
            public float lifetime;
            private float size;
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
                // Vector2.Lerp(Velocity, new Vector2(0, -1), deltaTime);
                position += velocity * deltaTime;
                lifetime -= deltaTime;
                Console.WriteLine($"{lifetime} {deltaTime} {position}");
            }

            public void Draw()
            {
                var quad = default(Quad);
                quad.vertex1 = position + new Vector2(-size, -size);
                quad.vertex2 = position + new Vector2(size, -size);
                quad.vertex3 = position + new Vector2(size, size);
                quad.vertex4 = position + new Vector2(-size, size);
                quad.Translate(-Camera.Camera.instance.transform.position);
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

        int maxParticles;
        float Lifetime;
        float Size;
        Color Color;

        public ParticleRenderer(GameObject gameObject, int maxParticles, float lifetime, float size, Color color)
        {
            this.gameObject = gameObject;
            this.maxParticles = maxParticles;
            Lifetime = lifetime;
            Size = size;
            Color = color;
        }

        public GameObject gameObject { get; }
        private readonly List<Particle> particles = new List<Particle>();


        public void CreateParticles()
        {
            var random = new Random();

            for (int i = 0; i < maxParticles; i++)
            {
                particles.Add(new Particle(
                    Lifetime,
                    Size,
                    new Vector2(gameObject.transform.position.X,
                        gameObject.transform.position.Y),
                    new Vector2(2f, 1f),
                    Color));
            }
        }

        public void Update(float deltaTime)
        {
            // particles.ForEach(particle => particle.Update(deltaTime));
            for (var i = 0; i < particles.Count; i++)
            {
                particles[i].Update(deltaTime);
            }

            particles.RemoveAll(particle => particle.lifetime <= 0);
        }

        public void Draw()
        {
            particles.ForEach(particle => particle.Draw());
        }
    }
}