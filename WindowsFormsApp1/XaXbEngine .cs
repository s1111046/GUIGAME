using System;

namespace WindowsFormsApp1
{
    internal class XaXbEngine
    {
        // 幸运数字
        private string luckyNumber;

        // 构造函数，初始化幸运数字
        public XaXbEngine()
        {
            // 生成随机数对象
            Random random = new Random();
            int[] tem = new int[3];
            tem[0] = random.Next(0, 9);
            tem[1] = random.Next(0, 9);
            tem[2] = random.Next(0, 9);

            // 确保生成的幸运数字没有重复的数字
            while (tem[0] == tem[1] || tem[1] == tem[2] || tem[0] == tem[2])
            {
                tem[1] = random.Next(0, 9);
                tem[2] = random.Next(0, 9);
            }

            // 将生成的数字组合成字符串作为幸运数字
            luckyNumber = $"{tem[0]}{tem[1]}{tem[2]}";
        }

        // 判断用户输入的数字是否合法（三个数字不相同）
        public bool IsLegal(string theNumber)
        {
            char[] tem = theNumber.ToCharArray();
            if (tem.Length == 3)
            {
                if (tem[0] != tem[1] && tem[1] != tem[2] && tem[0] != tem[2])
                {
                    return true;
                }
            }
            return false;
        }

        // 根据用户输入的数字计算结果
        public string GetResult(string userNumber)
        {
            char[] user = userNumber.ToCharArray();
            char[] ans = this.luckyNumber.ToCharArray();
            int a = 0;
            int b = 0;
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
            return $"{a}A{b}B";
        }

        // 判断是否猜中幸运数字
        public bool IsGameover(string userNumber)
        {
            return GetResult(userNumber) == "3A0B";
        }
    }
}
