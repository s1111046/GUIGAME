using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private XaXbEngine xaxb; // XaXbEngine 類的實例，用於處理遊戲邏輯
        private int counter; // 記錄猜測次數的計數器
        private HashSet<string> previousGuesses; // 保存之前猜測過的數字

        public Form1()
        {
            InitializeComponent();
            xaxb = new XaXbEngine(); // 初始化 XaXbEngine
            counter = 0; // 初始化計數器
            previousGuesses = new HashSet<string>(); // 初始化保存之前猜測數字的集合
        }

        // 點擊猜一猜按鈕時的事件處理
        private void button2_Click(object sender, EventArgs e)
        {
            string userNum = textBox2.Text.Trim(); // 獲取用戶輸入的數字並去除首尾空格

            // 檢查用戶輸入是否合法（長度為3）
            if (!xaxb.IsLegal(userNum))
            {
                MessageBox.Show("請輸入的資料重複，或長度不對！！請重新輸入！！");
                textBox2.Clear(); // 清空輸入框
                return; // 不執行下面的代碼，直接返回
            }

            // 檢查是否之前已經輸入過這個數字
            if (previousGuesses.Contains(userNum))
            {
                MessageBox.Show("這個數字已經猜過了，請輸入另一個數字！");
                textBox2.Clear(); // 清空輸入框
                return; // 不執行下面的代碼，直接返回
            }

            // 將新猜的數字添加到集合中
            previousGuesses.Add(userNum);

            // 檢查是否猜中正確的數字
            if (xaxb.IsGameover(userNum))
            {
                MessageBox.Show("恭喜你猜對了！");
            }
            else
            {
                counter++; // 增加猜測次數
                string result = xaxb.GetResult(userNum); // 獲取猜測結果
                listBox1.Items.Add($"{userNum} : {result}, 猜測次數: {counter}"); // 在列表框中顯示結果
            }

            textBox2.Clear(); // 清空輸入框
        }
    }
}
