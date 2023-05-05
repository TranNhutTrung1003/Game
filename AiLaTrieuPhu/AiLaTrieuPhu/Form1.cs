using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace AiLaTrieuPhu
{
    public partial class Form1 : Form
    {
        List<Question> lsQuestions;
        int timeLeft = 90;
        Timer timer = new Timer();
        int index = 0;
        int[] arr_core = {200, 400, 600, 1000, 2000, 3000, 6000, 10000, 14000, 22000, 30000, 40000, 60000, 85000, 150000 };
        System.Media.SoundPlayer player_count = new System.Media.SoundPlayer("Am-thanh-dem-nguoc-het-gio-www_tiengdong_com.wav");
        System.Media.SoundPlayer player_true = new System.Media.SoundPlayer("Am-thanh-tra-loi-dung-ai-la-trieu-phu-www_tiengdong_com.wav");
        System.Media.SoundPlayer player_false = new System.Media.SoundPlayer("Am-thanh-tra-loi-sai-ai-la-trieu-phu-www_tiengdong_com.wav");
        void ReadFile()
        {
            try
            {
                FileStream f = new FileStream("question.txt",FileMode.Open,FileAccess.Read);
                StreamReader rd = new StreamReader(f);
                string line;
                lsQuestions = new List<Question>();
                
                while ((line = rd.ReadLine()) != null)
                {
                    string question;
                    string[] option = new string[4];
                    string result; 
                    int[] option_del= new int[2];
                    string[] b = line.Split(';');
                    question= b[0];
                    option[0] = b[1];
                    option[1] = b[2];
                    option[2] = b[3];
                    option[3] = b[4];
                    result = b[5];
                    option_del[0] = int.Parse(b[6]);
                    option_del[1] = int.Parse(b[7]);
                    Question a = new Question(question,option,result,option_del);
                    lsQuestions.Add(a);
                }               
            }
            catch (Exception e)
            {
               // MessageBox.Show(e.Message);
            }
        }
        int DisplayAnswer(int index)
        {
            if (tb_answerA.Text == lsQuestions[index].Ans_index)
            {
                percenta.Visible = true;
                percenta.Text = "80%";
                percenta.ForeColor = Color.Red;
                return 1;
            }
            if (tb_answerB.Text == lsQuestions[index].Ans_index)
            {
                percentb.Visible = true;
                percentb.Text = "80%";
                percentb.ForeColor = Color.Red;
                return 2;
            }
            if (tb_answerC.Text == lsQuestions[index].Ans_index)
            {
                percentc.Visible = true;
                percentc.Text = "80%";
                percentc.ForeColor = Color.Red;
                return 3;
            }
            if (tb_answerD.Text == lsQuestions[index].Ans_index)
            {
                percentd.Visible = true;
                percentd.Text = "80%";
                percentd.ForeColor = Color.Red;
            }
            return 4;
        }

        void RemoveColor()
        {
            lb_1.ForeColor = Color.Blue;
            lb_2.ForeColor = Color.Red;
            lb_3.ForeColor = Color.Red;
            lb_4.ForeColor = Color.Red;
            lb_5.ForeColor = Color.Blue;
            lb_6.ForeColor = Color.Red;
            lb_7.ForeColor = Color.Red;
            lb_8.ForeColor = Color.Red;
            lb_9.ForeColor = Color.Red;
            lb_10.ForeColor = Color.Blue;
            lb_11.ForeColor = Color.Red;
            lb_12.ForeColor = Color.Red;
            lb_13.ForeColor = Color.Red;
            lb_14.ForeColor = Color.Red;
            lb_15.ForeColor = Color.Blue;
        }

        void AutoChangeColor(int index)
        {
            RemoveColor();
            if (index == 1)
                lb_2.ForeColor = Color.BlueViolet;
            if (index == 2)
                lb_3.ForeColor = Color.BlueViolet;
            if (index == 3)
                lb_4.ForeColor = Color.BlueViolet;
            if (index == 4)
                lb_5.ForeColor = Color.BlueViolet;
            if (index == 5)
                lb_6.ForeColor = Color.BlueViolet;
            if (index == 6)
                lb_7.ForeColor = Color.BlueViolet;
            if (index == 7)
                lb_8.ForeColor = Color.BlueViolet;
            if (index == 8)
                lb_9.ForeColor = Color.BlueViolet;
            if (index == 9)
                lb_10.ForeColor = Color.BlueViolet;
            if (index == 10)
                lb_11.ForeColor = Color.BlueViolet;
            if (index == 11)
                lb_12.ForeColor = Color.BlueViolet;
            if (index == 12)
                lb_13.ForeColor = Color.BlueViolet;
            if (index == 13)
                lb_14.ForeColor = Color.BlueViolet;
            if (index == 14)
                lb_15.ForeColor = Color.BlueViolet;
        }
        void DisplayCore(int index)
        {
            if (index == 0) MessageBox.Show($"Game Over---Core: 0 ");
            else if (index == 4) MessageBox.Show($"Game Over---Core:{arr_core[0]} ");
            else if (index == 9) MessageBox.Show($"Game Over---Core:{arr_core[4]} ");
            else if (index == 14) MessageBox.Show($"Game Over---Core:{arr_core[9]} ");
            else if (index < 4) MessageBox.Show($"Game Over---Core: 200 ");
            else MessageBox.Show($"Game Over---Core:{arr_core[index - ((index + 1) % 5)]} ");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timeLeft--;
            if(timeLeft <= 10)
            {
               
                player_count.Play();
            }
            if (timeLeft < 0)
            {
                timer.Stop();
                player_count.Stop();
                MessageBox.Show("het thoi gian");
                if (lb_clock.Text == "0" && radio_optionA.Checked == false && radio_optionB.Checked == false && radio_optionC.Checked == false && radio_optionD.Checked == false)
                {
                    radio_optionA.Enabled = false;
                    radio_optionB.Enabled = false;
                    radio_optionC.Enabled = false;
                    radio_optionD.Enabled = false;
                    DisplayCore(index);
                    Close();
                }
                
            }
            else
            {
                lb_clock.Text = timeLeft.ToString();
                
            }
        }
        void ShowQuestion(int index)
        {
            tb_question.Text = lsQuestions[index].My_question;
            tb_answerA.Text = lsQuestions[index].Answers[0];
            tb_answerB.Text = lsQuestions[index].Answers[1];
            tb_answerC.Text = lsQuestions[index].Answers[2];
            tb_answerD.Text = lsQuestions[index].Answers[3];
        }

        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
            ReadFile();
            ShowQuestion(0);
            lb_1.ForeColor = Color.BlueViolet;
            timer.Interval = 1000;
            timer.Tick += timer1_Tick;
            timer.Start();
            tb_answerA.BackColor = Color.White;
            tb_answerB.BackColor = Color.White;
            tb_answerC.BackColor = Color.White;
            tb_answerD.BackColor = Color.White;
            percenta.Visible = false;
            percentb.Visible = false;
            percentc.Visible = false;
            percentd.Visible = false;
            radio_optionA.Enabled = true;
            radio_optionB.Enabled = true;
            radio_optionC.Enabled = true;
            radio_optionD.Enabled = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }


        private void btn_next_Click(object sender, EventArgs e)
        {
            timeLeft = 90;
            timer.Start();
            tb_answerA.BackColor = Color.White;
            tb_answerB.BackColor = Color.White;
            tb_answerC.BackColor = Color.White;
            tb_answerD.BackColor = Color.White;
            tb_answerA.Visible = true;
            tb_answerB.Visible = true;
            tb_answerC.Visible = true;
            tb_answerD.Visible = true;
            percenta.Visible = false;
            percentb.Visible = false;
            percentc.Visible = false;
            percentd.Visible = false;
            radio_optionA.Enabled = true;
            radio_optionB.Enabled = true;
            radio_optionC.Enabled = true;
            radio_optionD.Enabled = true;
            radio_optionA.Checked = false;
            radio_optionB.Checked = false;
            radio_optionC.Checked = false;
            radio_optionD.Checked = false;
            AutoChangeColor(index);

            if (index == 15)
            {
                MessageBox.Show("Ban da chien thang");
                return;
            }
            else
            {
                ShowQuestion(index);
            }

        }
        void RadioOptionCheck(TextBox textBox, TextBox textBox1, TextBox textBox2, TextBox textBox3)
        {
            if (textBox.Text == lsQuestions[index].Ans_index && index == 14)
            {
                player_true.Play();
                textBox.BackColor = Color.Green;

                lb_core.Text = arr_core[index].ToString();

                if (MessageBox.Show("Bạn đã chiến thắng", "Thông báo", MessageBoxButtons.OK) == DialogResult.OK)
                {
                    Close();
                }
            }
            else if (textBox.Text == lsQuestions[index].Ans_index)
            {
                player_true.Play();
                textBox.BackColor = Color.Green;

                lb_core.Text = arr_core[index].ToString();

                if (MessageBox.Show("Bạn có muốn tiếp tục không?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    MessageBox.Show($"Số tiền của bạn là: {arr_core[index]}");
                }
                else
                {
                    btn_next.Enabled = true;
                }
                index++;
            }
            else
            {
                player_false.Play();
                textBox.BackColor = Color.Red;
                if (textBox1.Text == lsQuestions[index].Ans_index) textBox1.BackColor = Color.Green;
                if (textBox2.Text == lsQuestions[index].Ans_index) textBox2.BackColor = Color.Green;
                if (textBox3.Text == lsQuestions[index].Ans_index) textBox3.BackColor = Color.Green;
                DisplayCore(index);
                Close();
            }
        }

        private void btn_dapan_Click(object sender, EventArgs e)
        {
            if (radio_optionA.Checked) RadioOptionCheck(tb_answerA, tb_answerB, tb_answerC, tb_answerD);
            else if (radio_optionB.Checked) RadioOptionCheck(tb_answerB, tb_answerA, tb_answerC, tb_answerD);
            else if (radio_optionC.Checked) RadioOptionCheck(tb_answerC, tb_answerA, tb_answerB, tb_answerD);
            else if(radio_optionD.Checked) RadioOptionCheck(tb_answerD, tb_answerA, tb_answerC, tb_answerB);
        }

        private void pb_50_50_Click(object sender, EventArgs e)
        {
            if (lsQuestions[index].Arr_ans_del[0] == 0 || lsQuestions[index].Arr_ans_del[1] == 0) tb_answerA.Visible = false;
            if (lsQuestions[index].Arr_ans_del[0] == 1 || lsQuestions[index].Arr_ans_del[1] == 1) tb_answerB.Visible = false;
            if (lsQuestions[index].Arr_ans_del[0] == 2 || lsQuestions[index].Arr_ans_del[1] == 2) tb_answerC.Visible = false;
            if (lsQuestions[index].Arr_ans_del[0] == 3 || lsQuestions[index].Arr_ans_del[1] == 3) tb_answerD.Visible = false;
            pb_50_50.Enabled = false;
        }

        private void pb_call_Click(object sender, EventArgs e)
        {
            int count = 0;
            int answer_index = DisplayAnswer(index);
            if (tb_answerD.Text != lsQuestions[index].Ans_index && answer_index != 4)
            {
                if (count == 0)
                {
                    percentd.Visible = true;
                    percentd.Text = "20%";
                    percentd.ForeColor = Color.Red;
                }
                else
                {
                    percentd.Visible = true;
                    percentd.Text = "0%";
                    percentd.ForeColor = Color.Red;
                }
                count++;
            }
            if (tb_answerC.Text != lsQuestions[index].Ans_index && answer_index != 3)
            {
                if (count == 0)
                {
                    percentc.Visible = true;
                    percentc.Text = "20%";
                    percentc.ForeColor = Color.Red;
                }
                else
                {
                    percentc.Visible = true;
                    percentc.Text = "0%";
                    percentc.ForeColor = Color.Red;
                }
                count++;
            }
            if (tb_answerB.Text != lsQuestions[index].Ans_index && answer_index != 2)
            {
                if (count == 0)
                {
                    percentb.Visible = true;
                    percentb.Text = "20%";
                    percentb.ForeColor = Color.Red;
                }
                else
                {
                    percentb.Visible = true;
                    percentb.Text = "0%";
                    percentb.ForeColor = Color.Red;
                }
                count++;
            }
            if (tb_answerA.Text != lsQuestions[index].Ans_index && answer_index != 1)
            {
                if (count == 0)
                {
                    percenta.Visible = true;
                    percenta.Text = "20%";
                    percenta.ForeColor = Color.Red;
                }
                else
                {
                    percenta.Visible = true;
                    percenta.Text = "0%";
                    percenta.ForeColor = Color.Red;
                }
                count++;
            }
            pb_call.Enabled = false;
        }

        private void pb_sp_Click(object sender, EventArgs e)
        {
            int count = 0;
            int answer_index = DisplayAnswer(index);
            if (tb_answerA.Text != lsQuestions[index].Ans_index && answer_index != 1)
            {
                if (count == 0)
                {
                    percenta.Visible = true;
                    percenta.Text = "20%";
                    percenta.ForeColor = Color.Red;
                }
                else
                {
                    percenta.Visible = true;
                    percenta.Text = "0%";
                    percenta.ForeColor = Color.Red;
                }
                count++;
            }
            if (tb_answerB.Text != lsQuestions[index].Ans_index && answer_index != 2)
            {
                if (count == 0)
                {
                    percentb.Visible = true;
                    percentb.Text = "20%";
                    percentb.ForeColor = Color.Red;
                }
                else
                {
                    percentb.Visible = true;
                    percentb.Text = "0%";
                    percentb.ForeColor = Color.Red;
                }
                count++;
            }
            if (tb_answerC.Text != lsQuestions[index].Ans_index && answer_index != 3)
            {
                if (count == 0)
                {
                    percentc.Visible = true;
                    percentc.Text = "20%";
                    percentc.ForeColor = Color.Red;
                }
                else
                {
                    percentc.Visible = true;
                    percentc.Text = "0%";
                    percentc.ForeColor = Color.Red;
                }
                count++;
            }
            if (tb_answerD.Text != lsQuestions[index].Ans_index && answer_index != 4)
            {
                if (count == 0)
                {
                    percentd.Visible = true;
                    percentd.Text = "20%";
                    percentd.ForeColor = Color.Red;
                }
                else
                {
                    percentd.Visible = true;
                    percentd.Text = "0%";
                    percentd.ForeColor = Color.Red;
                }
                count++;
            }
            pb_sp.Enabled = false;
        }
        private void radio_optionA_CheckedChanged(object sender, EventArgs e)
        {
            if (radio_optionA.Checked)
            {
                timer.Stop();
                tb_answerA.BackColor = Color.Yellow;
                radio_optionB.Enabled = false;
                radio_optionC.Enabled = false;
                radio_optionD.Enabled = false;
                btn_next.Enabled = false;
            }
           
        }

        private void radio_optionB_CheckedChanged(object sender, EventArgs e)
        {
            if (radio_optionB.Checked)
            {
                timer.Stop();
                tb_answerB.BackColor = Color.Yellow;
                radio_optionA.Enabled = false;
                radio_optionC.Enabled = false;
                radio_optionD.Enabled = false;
                btn_next.Enabled = false;
            }
            
        }

        private void radio_optionC_CheckedChanged(object sender, EventArgs e)
        {
            if (radio_optionC.Checked)
            {
                timer.Stop();
                tb_answerC.BackColor = Color.Yellow;
                radio_optionB.Enabled = false;
                radio_optionA.Enabled = false;
                radio_optionD.Enabled = false;
                btn_next.Enabled = false;
            }
           
        }

        private void radio_optionD_CheckedChanged(object sender, EventArgs e)
        {
            if(radio_optionD.Checked)
            {
                timer.Stop();
                tb_answerD.BackColor = Color.Yellow;
                radio_optionB.Enabled = false;
                radio_optionC.Enabled = false;
                radio_optionA.Enabled = false;
                btn_next.Enabled = false;
            }
            
        }
        
    }
}
