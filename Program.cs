using System;
namespace RanSanMoi
{
    class Program
    {

        static void Main(string[] args)
        {


            Thread _game = new Thread(SnakeControl.ListenKey);
bool EndGame= false;
            _game.Start();

            do
            {
                if(!SnakeControl.SNAKE_DIE){
                Console.Clear();
                SnakeControl.Drawboard();
                SnakeControl.setUpBoard();
                SnakeControl.MoveSnakeHead();
                SnakeControl.EatFood();
                SnakeControl.SpawnBody();
                SnakeControl.PopUpfood();
                SnakeControl.ShowPoint();
                Thread.Sleep(SnakeControl.speed);
                }else{
                    Console.WriteLine("GAME OVER!!!");
                    EndGame=true;
                }


            } while (!EndGame);
        }
    }
}
