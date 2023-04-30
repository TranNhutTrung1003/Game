using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AiLaTrieuPhu
{
    internal class Question
    {
        string my_question;
        string[] answers = new String[4];
        string ans_index;
        int[] arr_ans_del;

        public string My_question { get => my_question; set => my_question = value; }
        public string[] Answers { get => answers; set => answers = value; }
        public string Ans_index { get => ans_index; set => ans_index = value; }
        public int[] Arr_ans_del { get => arr_ans_del; set => arr_ans_del = value; }

        public Question(string a, string[] b, string c, int[] d)
        {
            my_question = a;
            answers = b;
            ans_index = c;
            arr_ans_del = d;
        }
        

    }
}
