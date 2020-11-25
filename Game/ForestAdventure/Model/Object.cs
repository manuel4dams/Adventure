using System;
using ForestAdventure.Helper;

namespace ForestAdventure.Model
{
    [Obsolete]
    public class Object : IRectangle
    {
        public Object(float minX, float minY, float sizeX, float sizeY)
        {
            MinX = minX;
            MinY = minY;
            SizeX = sizeX;
            SizeY = sizeY;
        }

        public float SizeX { get; }

        public float SizeY { get; }

        public float MinX { get; protected set; }

        public float MinY { get; protected set; }

        public float MaxX => MinX + SizeX;

        public float MaxY => MinY + SizeY;

        public bool IntersectCheck(IRectangle obj)
        {
            var noXintersect = MaxX <= obj.MinX || MinX >= obj.MaxX;
            var noYintersect = MaxY <= obj.MinY || MinY >= obj.MaxY;
            return !(noXintersect || noYintersect);
        }

        public bool JumpIntersectCheck(IRectangle targetObject, float sizeY = 0.01f)
        {
            // add box on player feet to check collision with platform
            IRectangle player = new Object(MinX, MinY, SizeX, sizeY);

            var noXintersect = player.MaxX <= targetObject.MinX || player.MinX >= targetObject.MaxX;
            var noYintersect = player.MaxY <= targetObject.MinY || player.MinY >= targetObject.MaxY;

            return !(noXintersect || noYintersect);
        }
    }
}