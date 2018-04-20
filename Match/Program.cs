using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace Match
{
    class Program
    {
        // 初始化
        public static List<student> studentsList = new List<student>();// 學生清單
        static string data;// 資料位置

        static void Main(string[] args)
        {
            // 得到JSON檔並轉成List
            StreamReader rw = new StreamReader("D:\\VSProject\\Match\\Match\\Data.txt", Encoding.Default);
            data = rw.ReadToEnd();

            while (true)
            {
                Console.WriteLine("     ~歡迎來到月老配對系統~     \r\n         不保證每人有福\r\n         只保證句句精確\r\n");
                studentsList = JsonConvert.DeserializeObject<List<student>>(data);

                Console.WriteLine("請輸入學號(範例:A1060820**):");
                string stuNum = Console.ReadLine();

                //性向測驗
                Console.WriteLine("請輸入其性向(男or女  輸入男即喜歡男):");
                string Sexual = Console.ReadLine();
                Console.WriteLine("\r\n");

                // 尋找學號對應的資料
                student AA = studentsList.Find(s => s.studentNumber.Contains(stuNum));

                // 防止你的程式爆炸
                if(AA.height == 0)
                {
                    AA.height = 1;
                }

                // 依據性向做出篩選
                if (Sexual == "男")
                {
                    // 先把不喜歡的踢掉
                    studentsList.RemoveAll(s => s.gender != "男");

                    // 血型不合
                    switch (AA.bloodtype)
                    {
                        // 移除對應血型
                        case "O":
                            studentsList.RemoveAll(s => s.bloodtype != "AB");
                            break;
                        case "A":
                            studentsList.RemoveAll(s => s.bloodtype != "B");
                            break;
                        case "B":
                            studentsList.RemoveAll(s => s.bloodtype != "O");
                            break;
                        case "AB":
                            studentsList.RemoveAll(s => s.bloodtype != "A");
                            break;
                        default:
                            break;

                    }

                    // 星座不合
                    switch (AA.zodiacSign)
                    {
                        // 移除對應星座
                        case "白羊":
                        case "雙子":
                            studentsList.RemoveAll(s => s.zodiacSign == "白羊" || s.zodiacSign == "雙子");
                            break;
                        case "摩羯":
                        case "金牛":
                            studentsList.RemoveAll(s => s.zodiacSign == "摩羯" || s.zodiacSign == "金牛");
                            break;
                        case "巨蟹":
                        case "水瓶":
                            studentsList.RemoveAll(s => s.zodiacSign == "巨蟹" || s.zodiacSign == "水瓶");
                            break;
                        case "獅子":
                        case "天蠍":
                            studentsList.RemoveAll(s => s.zodiacSign == "獅子" || s.zodiacSign == "天蠍");
                            break;
                        case "處女":
                        case "射手":
                            studentsList.RemoveAll(s => s.zodiacSign == "處女" || s.zodiacSign == "射手");
                            break;
                        case "雙魚":
                        case "天枰":
                            studentsList.RemoveAll(s => s.zodiacSign == "雙魚" || s.zodiacSign == "天枰");
                            break;
                    }

                    // 顯示名單 邊緣人特別安慰一下
                    Console.WriteLine("相合名單:");
                    foreach (student s in studentsList)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write(s.name);
                        double heightP = (double)((s.height * 100 * 1.09) / AA.height);
                        if (heightP > 100)
                        {
                            heightP = 100 - (heightP - 100);
                        }
                        Console.Write("   額外契合度:" + heightP.ToString("#0.00") + "%\r\n");
                    }
                    if (studentsList.Count == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("可憐邊緣人");
                    }
                }
                // 同上
                else if (Sexual == "女")
                {
                    studentsList.RemoveAll(s => s.gender != "女");
                    switch (AA.bloodtype)
                    {
                        case "O":
                            studentsList.RemoveAll(s => s.bloodtype != "AB");
                            break;
                        case "A":
                            studentsList.RemoveAll(s => s.bloodtype != "B");
                            break;
                        case "B":
                            studentsList.RemoveAll(s => s.bloodtype != "O");
                            break;
                        case "AB":
                            studentsList.RemoveAll(s => s.bloodtype != "A");
                            break;
                        default:
                            break;

                    }
                    switch (AA.zodiacSign)
                    {
                        case "白羊":
                        case "雙子":
                            studentsList.RemoveAll(s => s.zodiacSign == "白羊" || s.zodiacSign == "雙子");
                            break;
                        case "摩羯":
                        case "金牛":
                            studentsList.RemoveAll(s => s.zodiacSign == "摩羯" || s.zodiacSign == "金牛");
                            break;
                        case "巨蟹":
                        case "水瓶":
                            studentsList.RemoveAll(s => s.zodiacSign == "巨蟹" || s.zodiacSign == "水瓶");
                            break;
                        case "獅子":
                        case "天蠍":
                            studentsList.RemoveAll(s => s.zodiacSign == "獅子" || s.zodiacSign == "天蠍");
                            break;
                        case "處女":
                        case "射手":
                            studentsList.RemoveAll(s => s.zodiacSign == "處女" || s.zodiacSign == "射手");
                            break;
                        case "雙魚":
                        case "天枰":
                            studentsList.RemoveAll(s => s.zodiacSign == "雙魚" || s.zodiacSign == "天枰");
                            break;
                    }
                    Console.WriteLine("相合名單:");
                    foreach (student s in studentsList)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(s.name);
                        double heightP = (double)((s.height * 100 * 1.09) / AA.height);
                        if (heightP > 100)
                        {
                            heightP = 100 - (heightP - 100);
                        }
                        Console.Write("   額外契合度:"+heightP.ToString("#0.00") + "%\r\n");
                    }
                    if(studentsList.Count == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("可憐邊緣人");
                    }
                }
                // 第三性向尚未開發
                else
                {
                    Console.WriteLine("What?");
                }

                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
    
    // 學生資料格式
    public class student
    {
        public string name { get; set; }
        public string studentNumber { get; set; }
        public string gender { get; set; }
        public int height { get; set; }
        public string bloodtype { get; set; }
        public string zodiacSign { get; set; }
    }
}
