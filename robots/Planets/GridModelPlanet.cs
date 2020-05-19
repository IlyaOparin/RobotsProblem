namespace robots.Planets
{
    public abstract class GridModelPlanet : IPlanet
    {
        public int GridWidth { get; protected set; }
        public int GridHeight { get; protected set; }
    }
}
