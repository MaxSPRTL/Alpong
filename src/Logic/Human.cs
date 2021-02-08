using Godot;
using Scripts.Blocks;

namespace Logic
{
    public class Human : Player
    {
        public Human(Constants.Side side, Wall wall, Label livesLabel) : base(side, wall, livesLabel) { }
    }
}