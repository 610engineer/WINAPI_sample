using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace API_sample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    //ブザー
                    BasicDll.BeepFunc();
                    break;

                case 1:
                    //ウィンドウタイトル変更
                    BasicDll.SetWindowTitle();
                    break;

                case 2:
                    //現在のディレクトリ名を取得
                    textBox1.Text = StringFunc.SetCurrentDirectory();
                    break;

                case 3:
                    //現在の日時取得(classで構造体を宣言)
                    textBox1.Text = StructFunc.GetTime();
                    break;

                case 4:
                    //設定した日時に変更(classで構造体を宣言)
                    textBox1.Text = StructFunc.SetTime();
                    break;

                case 5:
                    //現在の日時を取得(structで構造体を宣言)
                    textBox1.Text = StructFunc.GetT();
                    break;

                case 6:
                    //設定した日時に変更(structで構造体を宣言)
                    textBox1.Text = StructFunc.SetT();
                    break;

                
            }
        }
    }
}
