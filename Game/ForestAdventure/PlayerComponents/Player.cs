using ForestAdventure.Bow;
using ForestAdventure.Enemies;
using ForestAdventure.GameCamera;
using ForestAdventure.GameEnding;
using ForestAdventure.Level;
using Framework.Collision.Collider;
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

            var colliderBounds = new RectangleBounds(1.5f, 3f);
            var textureBounds = new RectangleBounds(3f, 3f);
            AddComponent(new RectangleTextureRenderer(
                this,
                textureBounds,
                Resources.Resources.Player,
                RenderScaleType.Crop,
                size: new Vector4(0f, 0.5f, 0.25f, 1f)));
            AddComponent(new RectangleColliderComponent(this, colliderBounds));
            AddComponent(new PlayerMovementComponent(this));
            AddComponent(new CameraFollowObjectComponent(this));
            AddComponent(new RectangleTextureRenderer(
                this,
                textureBounds,
                Resources.Resources.Player_bow,
                RenderScaleType.Crop,
                size: new Vector4(0f, 0.5f, 0.25f, 1f)));
            AddComponent(new BowComponent(this));
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