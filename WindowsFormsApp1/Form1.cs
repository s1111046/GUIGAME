using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private XaXbEngine xaxb;
        private int counter;

        public Form1()
        {
            InitializeComponent();
            xaxb = new XaXbEngine();
            counter = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string userNum = textBox2.Text.Trim(); // 获取用户输入的数字

            if (!xaxb.IsLegal(userNum)) // 如果用户输入不合法
            {
                MessageBox.Show("請輸入的資料重複，或長度不對！！請重新輸入！！");
                return; // 不执行下面的代码，直接返回
            }

            if (xaxb.IsGameover(userNum))
            {
                MessageBox.Show("恭喜你猜對了！");
            }
            else
            {
                counter++;
                string result = xaxb.GetResult(userNumber: userNum);
                listBox1.Items.Add($"{userNum} : {result},猜測次數: {counter}");
            }
        }
    }
}
