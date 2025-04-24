namespace _2D_Framework_Game.Objects.Creatures
{
    public class Creature
    {
        public string Name { get; set; }
        public int HitPoints { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public Creature(string name, int hitPoints, int x, int y)
        {
            Name = name;
            HitPoints = hitPoints;
            X = x;
            Y = y;
        }

        public void ReceiveHit(int damage)
        {
            HitPoints -= damage;
            if (HitPoints <= 0)
            {
                HitPoints = 0;
                // Handle creature death logic here
            }
        }

        public int Hit()
        {
            // Example damage calculation; modify this logic as needed
            return 10;  // Default damage for now
        }
    }
}
