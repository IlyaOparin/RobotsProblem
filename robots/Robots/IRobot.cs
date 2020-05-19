namespace robots.Robots
{
    public interface IRobot
    {
        void Move();
        
        void Initialize(int xStart, int yStart, char orientationStart, string instructions);
    }
}
