namespace ForrestAdventure.Model
{
    internal class Object : IRectangle
    {
        public Object(float minX, float minY, float sizeX, float sizeY)
        {
            this.MinX = minX;
            this.MinY = minY;
            this.SizeX = sizeX;
            this.SizeY = sizeY;
        }

        public float MinX { get; protected set; }

        public float MinY { get; protected set; }

        public float MaxX => this.MinX + this.SizeX;

        public float MaxY => this.MinY + this.SizeY;

        public float SizeX { get; }

        public float SizeY { get; }

        public bool IntersectCheck(IRectangle obj)
        {
            bool noXintersect = (this.MaxX <= obj.MinX) || (this.MinX >= obj.MaxX);
            bool noYintersect = (this.MaxY <= obj.MinY) || (this.MinY >= obj.MaxY);
            return !(noXintersect || noYintersect);
        }
    }
}