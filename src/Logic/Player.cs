using Scripts.Entities;
using Scripts.Blocks;

namespace Logic
{
    public abstract class Player
    {
        public Paddle Paddle;
        public Wall Wall;
        public Constants.Side Side;
        public int NbLives;

        public Player(Paddle paddle, Wall wall, Constants.Side side, int nbLives)
        {
            Paddle = paddle;
            Wall = wall;
            Side = side;
            NbLives = nbLives;
        }

        public void Hit()
        {
            this.NbLives -= 1;
        }
    }
}