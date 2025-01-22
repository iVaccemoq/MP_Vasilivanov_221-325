namespace pingPong
{
    public partial class Form1 : Form
    {

        int ballXspeed = 4;
        int ballYspeed = 4;
        int speed = 2;
        Random rand = new Random();
        bool goDown, goUp;
        int computer_speed_change = 50;
        int playerScore = 0;
        int computerScore = 0;
        int playerSpeed = 8;
        int[] i = { 5, 6, 8, 9 };
        int[] j = { 10, 9, 8, 11, 12 };

        public Form1(int difficulty)
        {
            InitializeComponent();

            // ”станавливаем скорость м€ча в зависимости от сложности
            ballXspeed = difficulty * 4; // 4, 8, 12
            ballYspeed = difficulty * 4;
        }

        private void GameTimerEvent(object sender, EventArgs e)
        {
            ball.Top -= ballYspeed;
            ball.Left -= ballXspeed;
            this.Text = "Player Score: " + playerScore + " -- Computer Score: " + computerScore;
            if (ball.Top < 0 || ball.Bottom > this.ClientSize.Height)
            {
                ballYspeed = -ballYspeed;
            }
            if (ball.Left < -2)
            {
                ball.Left = 300;
                ballXspeed = -ballXspeed;
                computerScore++;
            }
            if (ball.Right > this.ClientSize.Width + 2)
            {
                ball.Left = 300;
                ballXspeed = -ballXspeed;
                playerScore++;
            }
            if (computer.Top <= 1)
            {
                computer.Top = 0;
            }
            else if (computer.Bottom >= this.ClientSize.Height)
            {
                computer.Top = this.ClientSize.Height - computer.Height;
            }
            if (ball.Top < computer.Top + (computer.Height / 2) && ball.Left > 300)
            {
                computer.Top -= speed;
            }
            if (ball.Top > computer.Top + (computer.Height / 2) && ball.Left > 300)
            {
                computer.Top += speed;
            }
            computer_speed_change -= 1;
            if (computer_speed_change < 0)
            {
                speed = i[rand.Next(i.Length)];
                computer_speed_change = 50;
            }
            if (goDown && player.Top + player.Height < this.ClientSize.Height)
            {
                player.Top += playerSpeed;
            }
            if (goUp && player.Top > 0)
            {
                player.Top -= playerSpeed;
            }
            CheckCollision(ball, player, player.Right + 5);
            CheckCollision(ball, computer, computer.Left - 35);
            if (computerScore > 5)
            {
                GameOver("Sorry you lost the game");
            }
            else if (playerScore > 5)
            {
                GameOver("You Won this game");
            }
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                goDown = true;
            }
            if (e.KeyCode == Keys.Up)
            {
                goUp = true;
            }
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                goDown = false;
            }
            if (e.KeyCode == Keys.Up)
            {
                goUp = false;
            }
        }

        private void CheckCollision(PictureBox PicOne, PictureBox PicTwo, int offset)
        {
            //if (PicOne.Bounds.IntersectsWith(PicTwo.Bounds))
            //{
            //    PicOne.Left = offset;
            //    int x = j[rand.Next(j.Length)];
            //    int y = j[rand.Next(j.Length)];
            //    if (ballXspeed < 0)
            //    {
            //        ballXspeed = x;
            //    }
            //    else
            //    {
            //        ballXspeed = -x;
            //    }
            //    if (ballYspeed < 0)
            //    {
            //        ballYspeed = -y;
            //    }
            //    else
            //    {
            //        ballYspeed = y;
            //    }
            //}
            if (PicOne.Bounds.IntersectsWith(PicTwo.Bounds))
            {
                // ћен€ем направление м€ча, но сохран€ем текущую скорость
                ballXspeed = -ballXspeed;

                // ѕеремещаем м€ч немного, чтобы избежать повторной коллизии
                PicOne.Left = offset;
            }
        }

        private void GameOver(string message)
        {
            GameTimer.Stop();
            MessageBox.Show(message, "results: ");
            computerScore = 0;
            playerScore = 0;
            ballXspeed = ballYspeed = 4;
            computer_speed_change = 50;
            GameTimer.Start();
        }

    }
}