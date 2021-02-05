using Scripts.Entities;
using Scripts.Blocks;

namespace Logic
{
    public class Human : Player
    {
        public Human(Paddle paddle, Wall wall, Constants.Side side, int nbLives) : base(paddle, wall, side, nbLives) { }
    }
}