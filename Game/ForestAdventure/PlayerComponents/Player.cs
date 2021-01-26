using System.Drawing;
using ForestAdventure.Bow;
using ForestAdventure.Checkpoints;
using ForestAdventure.Enemies;
using ForestAdventure.GameCamera;
using ForestAdventure.GameEnding;
using ForestAdventure.Level;
using ForestAdventure.Traps;
using Framework.Collision.Collider;
using Framework.Development.Components;
using Framework.Game;
using Framework.Interfaces;
using Framework.Render;
using Framework.Shapes;
using Framework.Util;
using OpenTK;

namespace ForestAdventure.PlayerComponents
{
    public class Player : GameObject, ICollision
    {
        private Vector2 checkpointPosition;
        private CheckpointAnimation currentCheckpoint;

        public Player(Vector2 position)
        {
            transform.position = position;

            var bodyBounds = new RectangleBounds(4f, 4f);
            var colliderBounds = new RectangleBounds(0f, -0.25f, 0.9f, 3.4f);

            AddComponent(new RectangleTextureRenderer(
                this,
                bodyBounds,
                Resources.Resources.Player,
                RenderScaleType.Crop,
                size: new Vector4(0f, 0.5f, 0.25f, 1f)));
            AddComponent(new RectangleTextureRenderer(
                this,
                bodyBounds,
                Resources.Resources.Player_bow,
                RenderScaleType.Crop,
                size: new Vector4(0f, 0.5f, 0.25f, 1f)));
            AddComponent(new RectangleColliderComponent(this, colliderBounds));
            AddComponent(new PlayerMovementComponent(this));
            AddComponent(new BowComponent(this));
            AddComponent(new CameraFollowObjectComponent(this));
            if (Debug.enabled)
            {
                AddComponent(new DebugUnrotatedColliderEdgesComponent(this, bodyBounds, Color.GreenYellow));
                AddComponent(new DebugUnrotatedColliderEdgesComponent(this, colliderBounds));
            }
        }

        public void OnCollision(ICollider other, Vector2 touchOffset)
        {
            switch (other.gameObject)
            {
                case Enemy _:
                    transform.position = checkpointPosition;
                    break;
                case HorizontalMovingTrap _:
                    transform.position = checkpointPosition;
                    break;
                case VerticalMovingTrap _:
                    transform.position = checkpointPosition;
                    break;
                case Exit _:
                    Game.instance.AddGameObject(new GameEndingOverlay(this, transform.position,
                        Resources.Resources.Victory, new RectangleBounds(15f, 5f)));
                    Game.instance.AddGameObject(new GameEndingOverlay(this, transform.position - new Vector2(0f, 5f),
                        Resources.Resources.Endscreen, new RectangleBounds(30f, 2.5f)));
                    break;
                case Checkpoint _:
                    currentCheckpoint?.setActive(false);
                    currentCheckpoint = other.gameObject.GetComponent<CheckpointAnimation>(0) as CheckpointAnimation;
                    checkpointPosition = other.gameObject.transform.position + new Vector2(0f, 1f);
                    currentCheckpoint.setActive(true);
                    break;
                case BottomLevelBorder _:
                    transform.position = checkpointPosition;
                    break;
            }
        }
    }
}