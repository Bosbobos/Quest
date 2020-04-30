namespace Quests
{
    public class Bot
    {
        public int X { get; set; }
        public int Y { get; set; }
        public decimal Hp { get; set; } = 100m;

        public Bot(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }

        public void Hit (Bot bot, Character character)
        {
            if (Geometry.AreNear(bot.X, character.X, bot.Y, character.Y))
                    character.Hp -= 30;
        }
    }
}
