using System.Drawing;
using ForestAdventure.Bow;
using ForestAdventure.Enemies;
using ForestAdventure.GameCamera;
using ForestAdventure.GameEnding;
using ForestAdventure.Level;
using Framework.Collision.Collider;
using Framework.Development.Components;
using Framework.Game;
using Framework.Interfaces;
using Framework.Render;
using Framework.Shapes;
using OpenTK;

namespace ForestAdventure.PlayerComponents
{
    public class Player : GameObject, ICollision
    {
        public Player()
        {
            transform.position = new Vector2(3f, 8f);

            var bodyBounds = new RectangleBounds(2f, 3f);
            var colliderBounds = new RectangleBounds(0f,-0.2f,0.5f, 2.5f);
            
            AddComponent(new RectangleTextureRenderer(
                this,
                bodyBounds,
                Resources.Resources.Player,
                RenderScaleType.Crop,
                size: new Vector4(0f, 0.5f, 0.25f, 1f)));
            AddComponent(new RectangleColliderComponent(this, colliderBounds));
            AddComponent(new PlayerMovementComponent(this));
            AddComponent(new CameraFollowObjectComponent(this));
            AddComponent(new RectangleTextureRenderer(
                this,
                bodyBounds,
                Resources.Resources.Player_bow,
                RenderScaleType.Crop,
                size: new Vector4(0f, 0.5f, 0.25f, 1f)));
            AddComponent(new BowComponent(this));
#if DEBUG
            AddComponent(new DebugUnrotatedColliderEdgesComponent(this,bodyBounds, Color.GreenYellow));
            AddComponent(new DebugUnrotatedColliderEdgesComponent(this, colliderBounds));
#endif
        }

        public void OnCollision(ICollider other, Vector2 touchOffset)
        {
            switch (other.gameObject)
            {
                case Enemy _:
                    Game.instance.AddGameObject(new GameEndingOverlay(this, transform.position, false));
                    break;
                case Exit _:
                    Game.instance.AddGameObject(new GameEndingOverlay(this, transform.position, true));
                    break;
            }
        }
    }
}