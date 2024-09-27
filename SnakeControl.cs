 namespace RanSanMoi
{
 public class SnakeControl
    {
        public static Point food = new Point(8, 8);
        public static bool SNAKE_DIE = false;
        public static bool foodExist = false;
        public static int speed = 500;
        public static int row = 15;
        public static int col = 40;
        public static string direction = "Right";
        public static int score;
        public static string TITLE="RAN SAN MOI";
        public static Point[] body = new Point[2]
        {
            new Point(3,4),
            new Point(3,3)
        };
        public static Point _head = new Point(10, 10);
        public static string[,] board = new string[row, col];
        // ve cac doi tuong tren ban do (bien, ran, moi)
        public static void Drawboard()
        {
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (i == 0 || i == row - 1 || j == 0 || j == col - 1)
                    {
                        board[i, j] = "#";
                    }
                    else if (i == _head.X && j == _head.Y)
                    {
                        board[i, j] = "o";
                    }
                    else
                    {
                        bool isBodyPart = false;
                        for (int count = 0; count < body.Length; count++)
                        {
                            if (i == body[count].X && j == body[count].Y)
                            {
                                board[i, j] = "+";
                                isBodyPart = true;
                                break;
                            }
                        }
                        if (!isBodyPart)
                        {
                            if (i == food.X && j == food.Y)
                            {
                                board[i, j] = "@";
                            }
                            else
                            {
                                board[i, j] = " ";
                            }
                        }
                    }
                }
            }
        }
        // kiem tra va cham voi cac canh cua ban do
        public static void MoveSnakeHead()
        {
            switch (direction)
            {
                case "Right":
                    _head.Y += 1;
                    if (_head.Y == col - 1)
                    {
                        /* _head.Y = 1; */
                        SNAKE_DIE=true;
                    }
                    break;
                case "Left":
                    _head.Y -= 1;
                    if (_head.Y == 0)
                    {
                       /*  _head.Y = col - 1; */
                       SNAKE_DIE=true;
                    }
                    break;
                case "Up":
                    _head.X -= 1;
                    if (_head.X == 0)
                    {
                      /*   _head.X = row - 1; */
                      SNAKE_DIE=true;
                    }
                    break;
                case "Down":
                    _head.X += 1;
                    if (_head.X == row - 1)
                    {
                       /*  _head.X = 1; */
                       SNAKE_DIE=true;
                    }
                    break;
            }
        }
        // doc vao phim len,xuong,trai,phai
        public static void ListenKey()
        {
            while (true)
            {
                ConsoleKeyInfo keyinfo = Console.ReadKey();
                switch (keyinfo.Key)
                {
                    case ConsoleKey.RightArrow:
                        if (direction == "Up" || direction == "Down" || direction == "Left")
                        {
                            direction = "Right";
                        }
                        break;
                    case ConsoleKey.LeftArrow:
                        if (direction == "Up" || direction == "Down" || direction == "Right")
                        {
                            direction = "Left";
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        if (direction == "Left" || direction == "Right" || direction == "Down")
                        {
                            direction = "Up";
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (direction == "Left" || direction == "Right" || direction == "Up")
                        {
                            direction = "Down";
                        }
                        break;
                }
            }
        }
        // hien thi ra ban do
        public static void setUpBoard()
        {
             
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    Console.Write(board[i, j]);
                }
                Console.WriteLine();
            }
        }
        // hien thi thuc an
        public static void PopUpfood()
        {
            Random random = new Random();
            int x = random.Next(1, row - 1);
            int y = random.Next(1, col - 1);
            if (x != _head.X && y != _head.Y)
            {
                if (foodExist == false)
                {
                    food.X = x;
                    food.Y = y;
                    foodExist = true;
                }
            }
        }
        // tang size cua mang, khoi tao nut moi
        public static void EatFood()
        {
            if (_head.X == food.X && _head.Y == food.Y)
            {
                score += 1;
                Array.Resize(ref body, body.Length + 1);
                body[body.Length - 1] = new Point(-1, -1);
                speed -= 20;
                foodExist = false;
            }
        }
        // tang do dai than ran
        public static void SpawnBody()
        {
            for (int i = body.Length - 1; i > 0; i--)
            {
                body[i].X = body[i - 1].X;
                body[i].Y = body[i - 1].Y;
            }
            if (body.Length > 0)
            {
                body[0].X = _head.X;
                body[0].Y = _head.Y;
            }
        }
        // hien thi diem
        public static void ShowPoint()
        {
            Console.WriteLine($"Score: {score}");
        }
    }
}