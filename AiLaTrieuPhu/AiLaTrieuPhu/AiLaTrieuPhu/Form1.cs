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
        int timeLeft = 30;
        Timer timer = new Timer();
        int index = 0;
        int core = 0;
        int[] arr_core=new int[15];
        //string[] lb = { "lb_1", "lb_2", "lb_3", "lb_4", "lb_5", "lb_6", "lb_7", "lb_8", "lb_9", "lb_10", "lb_11", "lb_12", "lb_13", "lb_14", "lb_15" };
        void ReadFile()
        {
            try
            {
                FileStream f = new FileStream("question.txt",FileMode.Open,FileAccess.Read);
                StreamReader rd = new StreamReader(f);
                //Console.OutputEncoding = Encoding.UTF8;
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
            lb_1.ForeColor = Color.Red;
            lb_2.ForeColor = Color.Red;
            lb_3.ForeColor = Color.Red;
            lb_4.ForeColor = Color.Red;
            lb_5.ForeColor = Color.Red;
            lb_6.ForeColor = Color.Red;
            lb_7.ForeColor = Color.Red;
            lb_8.ForeColor = Color.Red;
            lb_9.ForeColor = Color.Red;
            lb_10.ForeColor = Color.Red;
            lb_11.ForeColor = Color.Red;
            lb_12.ForeColor = Color.Red;
            lb_13.ForeColor = Color.Red;
            lb_14.ForeColor = Color.Red;
            lb_15.ForeColor = Color.Red;
        }

        void AutoChangeColor(int count)
        {
            RemoveColor();
            if (count == 1)
                lb_2.ForeColor = Color.BlueViolet;
            if (count == 2)
                lb_3.ForeColor = Color.BlueViolet;
            if (count == 3)
                lb_4.ForeColor = Color.BlueViolet;
            if (count == 4)
                lb_5.ForeColor = Color.BlueViolet;
            if (count == 5)
                lb_6.ForeColor = Color.BlueViolet;
            if (count == 6)
                lb_7.ForeColor = Color.BlueViolet;
            if (count == 7)
                lb_8.ForeColor = Color.BlueViolet;
            if (count == 8)
                lb_9.ForeColor = Color.BlueViolet;
            if (count == 9)
                lb_10.ForeColor = Color.BlueViolet;
            if (count == 10)
                lb_11.ForeColor = Color.BlueViolet;
            if (count == 11)
                lb_12.ForeColor = Color.BlueViolet;
            if (count == 12)
                lb_13.ForeColor = Color.BlueViolet;
            if (count == 13)
                lb_14.ForeColor = Color.BlueViolet;
            if (count == 14)
                lb_15.ForeColor = Color.BlueViolet;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timeLeft--;
            if (timeLeft < 0)
            {
                timer.Stop();
                MessageBox.Show("het thoi gian");
                if (lb_clock.Text == "0" && radio_optionA.Checked == false && radio_optionB.Checked == false && radio_optionC.Checked == false && radio_optionD.Checked == false)
                {
                    radio_optionA.Enabled = false;
                    radio_optionB.Enabled = false;
                    radio_optionC.Enabled = false;
                    radio_optionD.Enabled = false;

                    if (index % 5 == 0) MessageBox.Show($"Game Over---Core:{arr_core[index]} ");
                    else MessageBox.Show($"Game Over---Core:{arr_core[index - ((index + 1) % 5)]} ");
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
            tb_answerA.BackColor = Color.Blue;
            tb_answerB.BackColor = Color.Blue;
            tb_answerC.BackColor = Color.Blue;
            tb_answerD.BackColor = Color.Blue;
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
            timeLeft = 30;
            timer.Interval = 1000;
            timer.Tick += timer1_Tick;
            timer.Start();
            tb_answerA.BackColor = Color.Blue;
            tb_answerB.BackColor = Color.Blue;
            tb_answerC.BackColor = Color.Blue;
            tb_answerD.BackColor = Color.Blue;
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

        private void btn_dapan_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Xin chao");

            if (radio_optionA.Checked)
            {

                if (tb_answerA.Text == lsQuestions[index].Ans_index)
                {
                    tb_answerA.BackColor = Color.Green;
                    core = core + 100 * (index + 1);
                    lb_core.Text=core.ToString();
                    arr_core[index] = core;
                    index++;
                    AutoChangeColor(index);
                    if (MessageBox.Show("Ban co muon tiep tuc khong?", "Thong bao", MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        MessageBox.Show($"So tien cua ban la: {core}");
                    }
                    else
                    {
                        btn_next.Enabled = true;
                    }
                }
                else
                {
                    tb_answerA.BackColor = Color.Red;
                    if (tb_answerB.Text == lsQuestions[index].Ans_index) tb_answerB.BackColor = Color.Green;
                    if (tb_answerC.Text == lsQuestions[index].Ans_index) tb_answerC.BackColor = Color.Green;
                    if (tb_answerD.Text == lsQuestions[index].Ans_index) tb_answerD.BackColor = Color.Green;

                    if (index % 5 == 0) MessageBox.Show($"Game Over---Core:{arr_core[index]} ");
                    else MessageBox.Show($"Game Over---Core:{arr_core[index + 1 - ((index + 1) % 5)]} ");
                    Close();
                }
            }
            if (radio_optionB.Checked)
            {
                if (tb_answerB.Text == lsQuestions[index].Ans_index)
                {
                    tb_answerB.BackColor = Color.Green;
                    core = core + 100 * (index+1);
                    lb_core.Text = core.ToString();
                    arr_core[index] = core;
                    index++;
                    AutoChangeColor(index);
                    if (MessageBox.Show("Ban co muon tiep tuc khong?", "Thong bao", MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        MessageBox.Show($"So tien cua ban la: {core}");
                    }
                    else
                    {
                        btn_next.Enabled = true;
                    }
                }
                else
                {
                    tb_answerB.BackColor = Color.Red;
                    if (tb_answerA.Text == lsQuestions[index].Ans_index) tb_answerA.BackColor = Color.Green;
                    if (tb_answerC.Text == lsQuestions[index].Ans_index) tb_answerC.BackColor = Color.Green;
                    if (tb_answerD.Text == lsQuestions[index].Ans_index) tb_answerD.BackColor = Color.Green;

                    if (index % 5 == 0) MessageBox.Show($"Game Over---Core:{arr_core[index]} ");
                    else MessageBox.Show($"Game Over---Core:{arr_core[index + 1 - ((index + 1) % 5)]} ");
                    Close();
                }
            }
            if (radio_optionC.Checked)
            {
                if (tb_answerC.Text == lsQuestions[index].Ans_index)
                {
                    tb_answerC.BackColor = Color.Green;
                    core = core + 100 * (index + 1);
                    lb_core.Text = core.ToString();
                    arr_core[index] = core;
                    index++;
                    AutoChangeColor(index);
                    if (MessageBox.Show("Ban co muon tiep tuc khong?", "Thong bao", MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        MessageBox.Show($"So tien cua ban la: {core}");
                    }
                    else
                    {
                        btn_next.Enabled = true;
                    }
                }
                else
                {
                    tb_answerC.BackColor = Color.Red;
                    if (tb_answerB.Text == lsQuestions[index].Ans_index) tb_answerB.BackColor = Color.Green;
                    if (tb_answerA.Text == lsQuestions[index].Ans_index) tb_answerA.BackColor = Color.Green;
                    if (tb_answerD.Text == lsQuestions[index].Ans_index) tb_answerD.BackColor = Color.Green;

                    if (index % 5 == 0) MessageBox.Show($"Game Over---Core:{arr_core[index]} ");
                    else MessageBox.Show($"Game Over---Core:{arr_core[index + 1 - ((index + 1) % 5)]} ");
                    Close();
                }
            }
            if (radio_optionD.Checked)
            {
                if (tb_answerD.Text == lsQuestions[index].Ans_index)
                {
                    tb_answerD.BackColor = Color.Green;
                    core = core + 100 * (index + 1);
                    lb_core.Text = core.ToString();
                    arr_core[index] = core;
                    index++;
                    AutoChangeColor(index);
                    if (MessageBox.Show("Ban co muon tiep tuc khong?", "Thong bao", MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        MessageBox.Show($"So tien cua ban la: {core}");
                    }
                    else
                    {
                        btn_next.Enabled = true;
                    }
                }
                else
                {
                    tb_answerD.BackColor = Color.Red;
                    if (tb_answerB.Text == lsQuestions[index].Ans_index) tb_answerB.BackColor = Color.Green;
                    if (tb_answerC.Text == lsQuestions[index].Ans_index) tb_answerC.BackColor = Color.Green;
                    if (tb_answerA.Text == lsQuestions[index].Ans_index) tb_answerA.BackColor = Color.Green;

                    if (index % 5 == 0) MessageBox.Show($"Game Over---Core:{arr_core[index]} ");
                    else MessageBox.Show($"Game Over---Core:{arr_core[index + 1 - ((index + 1) % 5)]} ");
                    Close();
                }
            }
        }

        private void pb_50_50_Click(object sender, EventArgs e)
        {
            if (lsQuestions[index].Arr_ans_del[0] == 0 || lsQuestions[index].Arr_ans_del[1] == 0) tb_answerA.Visible = false;
            if (lsQuestions[index].Arr_ans_del[0] == 1 || lsQuestions[index].Arr_ans_del[1] == 1) tb_answerB.Visible = false;
            if (lsQuestions[index].Arr_ans_del[0] == 2 || lsQuestions[index].Arr_ans_del[1] == 2) tb_answerC.Visible = false;
            if (lsQuestions[index].Arr_ans_del[0] == 3 || lsQuestions[index].Arr_ans_del[1] == 3) tb_answerD.Visible = false;
            pb_50_50.Enabled = false;
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

        private void radio_optionA_CheckedChanged(object sender, EventArgs e)
        {
            if (radio_optionA.Checked)
            {
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
                tb_answerD.BackColor = Color.Yellow;
                radio_optionB.Enabled = false;
                radio_optionC.Enabled = false;
                radio_optionA.Enabled = false;
                btn_next.Enabled = false;
            }
            
        }
    }
}
