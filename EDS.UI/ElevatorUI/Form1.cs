using System.Timers;
using Timer = System.Timers.Timer;

namespace ElevatorUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static Timer time = new Timer(1000);

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

          



        private async void button9_Click(object sender, EventArgs e)
        {

            // Thread mainThread = Thread.CurrentThread;
            //mainThread.Name = "Main Thread";
            //Console.WriteLine(mainThread.Name);

            for (int i = 1; i <= 4; i++)
            {
                upwardDirection(i);

                var t1 = Task.Delay(2000);
                await t1;

            }
            for (int i = 4; i >= 1; i--)
            {
                downwardDirection(i);

                var t1 = Task.Delay(2000);
                await t1;

            }





        }

        public void upwardDirection(int i)
        {
            if (i == 1)
            {
                textBox4.Text = "";
                textBox1.Text = "1";
                groupBox1.Location = new Point(515, 300);
                button5.Enabled = false;
            }
            else if (i == 2)
            {
                textBox1.Text = "";
                textBox2.Text = "2";
                groupBox1.Location = new Point(515, 180);
                button5.Enabled = true;
                button6.Enabled = false;
            }


            else if (i == 3)
            {
                textBox2.Text = "";
                textBox3.Text = "3";
                groupBox1.Location = new Point(515, 93);
                button6.Enabled = true;
                button7.Enabled = false;
            }

            else if (i == 4)
            {
                textBox3.Text = "";
                textBox4.Text = "4";
                groupBox1.Location = new Point(515, 12);
                button7.Enabled = true;
                button8.Enabled = false;
            }
        }
        public void downwardDirection(int i)
        {
            if (i == 1)
            {
                textBox2.Text = "";
                textBox1.Text = "1";
                groupBox1.Location = new Point(515, 300);
                button6.Enabled = true;
                button5.Enabled= false;
            }
            else if (i == 2)
            {
                textBox3.Text = "";
                textBox2.Text = "2";
                groupBox1.Location = new Point(515, 180);
                button7.Enabled = true;
                button6.Enabled= false;
            }


            else if (i == 3)
            {
                textBox4.Text = "";
                textBox3.Text = "3";
                groupBox1.Location = new Point(515, 93);
                button8.Enabled = true;
                button7.Enabled = false;
            }

            else if (i == 4)
            {
                textBox3.Text = "";
                textBox4.Text = "4";
                groupBox1.Location = new Point(515, 12);
                
            }
        }

    }
}