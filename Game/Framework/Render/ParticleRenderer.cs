using Framework.Game;
using Framework.Interfaces;
using Framework.Shapes;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.Render
{
    public class ParticleRenderer : IComponent, IUpdateable, IRender
    {
        struct Particle
        {
            public float Lifetime;
            private float Size;
            private Vector2 Position;
            private Vector2 Direction;
            private Vector2 Velocity;
            private Color4 Color;

            public Particle(float lifetime, float size, Vector2 position, Vector2 direction, Color4 color)
            {
                Lifetime = lifetime;
                Size = size;
                Position = position;
                Direction = direction;
                Velocity = Direction;
                Color = color;
            }

            public void Update(float deltaTime)
            {
                //Vector2.Lerp(Velocity, new Vector2(0, -1), deltaTime);
                Position = Position + Velocity * deltaTime;
                Lifetime = Lifetime - deltaTime;
                Console.WriteLine($"{Lifetime} {deltaTime} {Position}");
            }

            public void Draw()
            {
                Quad quad = new Quad();
                quad.vertex1 = Position + new Vector2(-Size, -Size);
                quad.vertex2 = Position + new Vector2(Size, -Size);
                quad.vertex3 = Position + new Vector2(Size, Size);
                quad.vertex4 = Position + new Vector2(-Size, Size);
                quad.Translate(-Camera.Camera.instance.transform.position);
                GL.Begin(PrimitiveType.Quads);
                GL.Color4(Color);
                GL.Vertex2(quad.vertex1);
                GL.Vertex2(quad.vertex2);
                GL.Vertex2(quad.vertex3);
                GL.Vertex2(quad.vertex4);
                GL.End();
            }
        }

        int maxParticles;
        float Lifetime;
        float Size;
        Color4 Color;

        public ParticleRenderer(GameObject gameObject, int maxParticles, float lifetime, float size, Color4 color)
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
            Random random = new Random();

            for (int i = 0; i < maxParticles; i++)
            {
                particles.Add(new Particle(Lifetime, Size, new Vector2(gameObject.transform.position.X, gameObject.transform.position.Y), new Vector2(2f, 1f), Color));
            }
        }

        public void Update(float deltaTime)
        {
            //particles.ForEach(particle => particle.Update(deltaTime));
            for (int i = 0; i < particles.Count; i++)
            {
                particles[i].Update(deltaTime);
            }
            particles.RemoveAll(particle => particle.Lifetime <= 0);
        }

        public void Draw()
        {
            particles.ForEach(particle => particle.Draw());
        }
    }
}
