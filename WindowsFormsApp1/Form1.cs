using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        

        public char[] terms = new char[10] {'A','B','C','D','E','F','G','H','I','J'};
        public string[] termsValue = new string[10];
        public int termsSize;
        public string str,strOut, outText;  
        public char[] s_alphabet = new char[50];
        public char[] s_beginState = new char[50];
        public int stInd = 0, alpInd = 0;
        public int strLength;
        public int s_statesListLength = 0;
        public int s_alphabetLength = 0;
        public int s_endStateLength = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void setTable_Click(object sender, EventArgs e)
        {
                richTextBox1.Text = "";
                for (int i = 0; i < 10; i++) termsValue[i] = "";
                s_alphabetLength = alphabet.TextLength;
                
                //переводим строку в массив символов
               
                for (int i = 0; i < alphabet.TextLength; i++)
                {
                    s_alphabet[i] = alphabet.Text[i];
                }
                for (int i = 0; i < beginState.TextLength; i++)
                {
                    s_beginState[i] = beginState.Text[i];
                }


                /////////////////////////
                ///
                //Узнаем количество нетерминальных элементов
                if(Convert.ToInt32(numericUpDown3.Value) > beginState.Text.Length)
            {

                termsSize = Convert.ToInt32(numericUpDown3.Value) - beginState.Text.Length + 2;
                if (termsSize < 3) termsSize = 3;
            }
                //правило для А
                for(int i = 1; i < termsSize-1; i++)
            {
                termsValue[0] += terms[i].ToString();
            }

            if(Convert.ToInt32(numericUpDown2.Value) / Convert.ToInt32(numericUpDown3.Value) - 1 >1)
                for(int i = 0; i < Convert.ToInt32(numericUpDown2.Value)/Convert.ToInt32(numericUpDown3.Value)-1; i++)
            {
                termsValue[0] += terms[termsSize - 1];
            }else termsValue[0] += terms[termsSize - 1];

            termsValue[0] += beginState.Text;
            //Правило для всех остальных кроме последнего
            for(int i = 1; i < termsSize - 1; i++)
            {
                for (int j = 0; j < alphabet.Text.Length; j++)
                {
                    termsValue[i] += alphabet.Text[j];
                }
            }
            //правило для последнего нетерминала
            for (int i = 0; i < termsSize; i++)
            {
                termsValue[termsSize - 1] += terms[termsSize - 2];
            }
            termsValue[termsSize - 1] += "|lam";

            for (int i = 0; i < termsSize; i++)
            {
                richTextBox1.Text += termsValue[i] + '\n';
            }
           
            
            /*

                richTextBox1.Text = "";
                //задаем заблицу переходов
                for (int i = 0; i < s_alphabetLength; i++)
                {
                    dataGridView1.Columns.Add("", s_alphabet[i].ToString());
                }
                for (int i = 0; i < s_statesListLength; i++)
                {
                    dataGridView1.Rows.Add();
                }
                for (int i = 0; (i < (dataGridView1.Rows.Count - 1)); i++)
                {
                   // dataGridView1.Rows[i].HeaderCell.Value = s_statesList[i].ToString();
                }

                for (int i = 0; i < s_alphabetLength; i++)
                {
                      for (int j = 0; j < s_statesListLength; j++)
                       {
                            dataGridView1.Rows[j].Cells[i].Value="0";
                       }     
                }

                chekList.Enabled=true;
            */

        }
        private void chekList_Click(object sender, EventArgs e)
        {
            string current = termsValue[0];
            while (isterms(current) != 0)
            {

            }


        }


        public int isterms(string current)
        {
            for(int i = 0; i < terms.Length; i++)
            {
                for(int j = 0; j < current.Length; j++)
                {
                    if (current[j] == terms[i])
                    {
                        return i;
                    }
                }
            }


            return 0;
        }


        public bool stateInAlphabet(char[] a,int aL, char[] b, int bL)
        {
            for (int i = 0; i < aL; i++)
            {
                for (int j = 0; j < bL; j++)
                {
                    if (a[i] == b[j]) return false;
                }
            }
            return true;
        }
        public bool charInString(char c, char[] b, int bL)
        {
            for (int i = 0; i < bL; i++)
            {
                if (b[i] == c) return true;
            }
            return false;
        }
        public bool stateInEndState(char[] a, int aL, char[] b, int bL)
        {
            bool flag = false;
            for (int i = 0; i < aL; i++)
            {
                flag = false;
                for (int j = 0; j < bL; j++)
                {
                    if (a[i] == b[j]) flag=true;
                }
                if (flag == false) return false;
            }

            return true;
        }
        public bool tableCheck(char[,] a,int a1L,int a2L, char[] b, int bL)
        {
            bool flag;
                for (int i = 0; i < a1L; i++)
                {
                    for (int j = 0; j < a2L; j++)
                    {
                    flag = false;   
                    for (int k = 0; k < bL; k++)
                    {
                        
                        if (a[i,j].ToString() == b[k].ToString())
                        {
                            flag = true;
                        }
                        
                    }
                    if (flag == false) return false;
                }
                }
            return true;
        }
        public bool strCheck(string s, char[] a, int aL)
        {
            for (int i = 0; i < s.Length; i++)
            {
                bool flag = false;  
                for (int j = 0; j < aL; j++)
                {
                    if (str[i]==a[j])
                    {
                        return true;
                    }
                }
                if (flag == false) return false;
            }
            return true;
        }
    }
}
