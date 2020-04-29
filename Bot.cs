namespace Quests
{
    public class Bot
    {
        public int X { get; set; }
        public int Y { get; set; }
        public decimal Hp { get; set; } = 100m;
        int HitRange = 1;

        public Bot(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }

        public void Hit (Bot bot, Character character)
        {
            if (bot.X - character.X <= HitRange && bot.Y - character.Y <= HitRange
                || character.X - bot.X <= HitRange && character.Y - bot.Y <= HitRange)
                    character.Hp -= 30;
        }
    }
}
