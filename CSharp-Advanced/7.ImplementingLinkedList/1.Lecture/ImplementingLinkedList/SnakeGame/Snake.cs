using SnakeGame.Interfaces;
using System;

namespace SnakeGame
{
    public class Snake : IDrawable
    {
        public Snake(Position headPosition)
        {
            SnakeBody = new LinkedList();
            SnakeBody.AddHead(new Node(headPosition));

            for (int i = 1; i < 10; i++)
            {
                SnakeBody.AddLast(new Node(new Position (headPosition.X + i, headPosition.Y)));
            }
        }

        public LinkedList SnakeBody { get; set; }

        public void Draw()
        {
            SnakeBody.ForEach(n =>
            {
                Console.SetCursorPosition(n.Value.X, n.Value.Y);
                Console.Write("*");
            });
        }

        public void Move(Position position)
        {
            SnakeBody.Head.Value.ChangePosition(position);
        }
    }
}
