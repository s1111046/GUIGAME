using System;

namespace WindowsFormsApp1
{
    internal class XaXbEngine
    {
        private string luckyNumber; // 儲存隨機生成的幸運數字

        public XaXbEngine()
        {
            Random random = new Random(); // 生成隨機數對象
            int[] tem = new int[3];
            tem[0] = random.Next(0, 10); // 生成第一個數字
            do
            {
                tem[1] = random.Next(0, 10); // 生成第二個數字，確保不重複
            } while (tem[1] == tem[0]);
            do
            {
                tem[2] = random.Next(0, 10); // 生成第三個數字，確保不重複
            } while (tem[2] == tem[0] || tem[2] == tem[1]);

            // 組合生成的數字成字符串作為幸運數字
            luckyNumber = $"{tem[0]}{tem[1]}{tem[2]}";
        }

        // 判斷用戶輸入的數字是否合法（三個數字不同）
        public bool IsLegal(string theNumber)
        {
            return theNumber.Length == 3;
        }

        // 根據用戶輸入的數字計算結果
        public string GetResult(string userNumber)
        {
            char[] user = userNumber.ToCharArray();
            char[] ans = luckyNumber.ToCharArray();
            int a = 0; // 計算位置和數字都正確的數量
            int b = 0; // 計算數字正確但位置不正確的數量
            for (int i = 0; i < user.Length; i++)
            {
                for (int j = 0; j < ans.Length; j++)
                {
                    if (user[i] == ans[j])
                    {
                        if (i == j)
                        {
                            a++;
                        }
                        else
                        {
                            b++;
                        }
                    }
                }
            }
            return $"{a}A{b}B"; // 返回結果
        }

        // 判斷是否猜中幸運數字
        public bool IsGameover(string userNumber)
        {
            return GetResult(userNumber) == "3A0B";
        }
    }
}
