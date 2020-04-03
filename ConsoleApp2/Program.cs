using Newtonsoft.Json;
using System;
using System.Linq;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Test2();
            return;
        }

        static bool JudgeLastPackage(string packagNo, int expressCompanyId, int orderStatus, int stationId)
        { 
            try
            {
                // 非京东单号 
                if (!packagNo.ToUpper().StartsWith("JD") && !packagNo.ToUpper().StartsWith("ZY"))
                {
                    return true;
                }

                //最后一位自动补全 -
                packagNo = packagNo.Last() != '-' ? packagNo + "-" : packagNo;  

                //把 NS 转化为 - 类型
                if (packagNo[15] != '-')
                {
                    packagNo = $"{packagNo.Substring(0, 15)}-{packagNo.Substring(16)}"; 
                }  

                var middle = packagNo.Split('-')[1];

                foreach (var item in middle.ToList())
                {
                    if (!Char.IsNumber(item))
                    {
                        var end_index = middle.IndexOf(item);

                        packagNo = packagNo.Split('-')[0] + "-" + middle.Substring(0,end_index) + "-" + middle.Substring(end_index + 1);

                        break; 
                    } 
                }

                var expressNo = packagNo.Contains("-") ? packagNo.Split('-')[0] : packagNo;

                int packagCount = 3;

                int count = 0; 

                var end = packagNo.Split('-')[2]; 

                // 判断包裹数量
                if (end.ToList().Any(x => !char.IsNumber(x)))
                {
                    foreach (var item in end.ToList())
                    {
                        if (!Char.IsNumber(item))
                        {
                            count = Convert.ToInt32(end.Substring(0, end.IndexOf(item)));

                            break;
                        }
                    } 
                }
                else
                {
                    count = Convert.ToInt32(end);
                } 
               
                if (count == packagCount && packagCount > 0)
                {
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                return true;
            }  
        } 

        static void Test1()
        {  
            var c = new Random().Next(100000,999999) + new Random().Next(10,99);

            Console.WriteLine(c);
        
        }

        static void Test2()
        {
            try
            {
                var str = "{\"code\":1,\"data\":{\"isSendPhone\":true,\"isSendWeiChat\":false,\"sendPhoneResult\":0},\"message\":\"成功\",\"success\":true}";
                var result = JsonConvert.DeserializeObject<PushResponse>(str);

            }
            catch (Exception ex)
            {

                throw;
            } 
        
        } 
    }


    public class PushResponse
    {
        /// <summary>
        /// 状态(0-发送成功，-1 发送失败)
        /// </summary>
        public int code { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string message { get; set; }
        /// <summary>
        /// 0：微信  1：手机
        /// 2019-7-23改为
        /// 位置  0 微信  1 短信
        ///value 0：未发送  1：发送成功  2 发送失败
        /// </summary>
        public PushResponseData data { get; set; }

        public bool success { get; set; }

    }

    public class PushResponseData
    {
        public bool isSendPhone { get; set; }

        public bool isSendWeiChat { get; set; }

        /// <summary>
        /// 0 成功 -1 失败
        /// </summary>
        public int sendPhoneResult { get; set; }

        /// <summary>
        /// 0 成功 -1 失败
        /// </summary>
        public int sendWeiChatResult { get; set; }
    }

}
