using System;
namespace RanSanMoi
{
    class Program
    {
        public static SnakeControl snakeControl=new SnakeControl();
        static void Main(string[] args)
        {


            Thread _game = new Thread(snakeControl.ListenKey);
            bool EndGame = false;
            int bestScore = SnakeControl.BestScore;

            _game.Start();

            do
            {
                try
                {
                    if (!SnakeControl.SNAKE_DIE)
                    {

                        Console.Clear();
                        snakeControl.Drawboard();
                        snakeControl.setUpBoard();
                        snakeControl.MoveSnakeHead();
                        snakeControl.EatFood();
                        snakeControl.SpawnBody();
                        snakeControl.PopUpfood();
                        snakeControl.ShowPoint();
                        Thread.Sleep(SnakeControl.speed);
                    }
                    else
                    {
                        if (SnakeControl.score > bestScore)
                        {
                            SnakeControl.saveNewHighScore(SnakeControl.score.ToString());
                            Console.WriteLine("GAME OVER!");
                            Console.WriteLine("New best score: " + SnakeControl.score);
                            EndGame = true;
                        }
                        else
                        {
                            Console.WriteLine("GAME OVER!!!");
                            EndGame = true;
                        }


                    }
                }
                catch (Exception e)
                {

                }



            } while (!EndGame);
        }
    }
}
