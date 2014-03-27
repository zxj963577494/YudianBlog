using System;
using System.Text.RegularExpressions;

namespace YudianBlog.Infrastructure.Common
{
    /// <summary>
    /// 服务端表单验证
    /// </summary>
    public class ValidateHelper
    {
        public ValidateHelper()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        #region 正则表达式
        private static Regex RegNumber = new Regex("^[0-9]+$");
        private static Regex RegNumberSign = new Regex("^[+-]?[0-9]+$");
        private static Regex RegDecimal = new Regex("^[0-9]*[.]?[0-9]+$");
        private static Regex RegDecimalSign = new Regex("^[+-]?[0-9]+[.]?[0-9]+$"); //等价于^[+-]?\d+[.]?\d+$
        private static Regex RegEmail = new Regex("^[\\w-]+@[\\w-]+\\.(com|net|org|edu|mil|tv|biz|info)$");//w 英文字母或数字的字符串，和 [a-zA-Z0-9] 语法一样 
        private static Regex RegCHZN = new Regex("[\u4e00-\u9fa5]");
        private static Regex RegMobile = new Regex("^1[3,4,5,8]\\d{9}$");
        private static Regex RegUrl = new Regex(@"^(http|https)\://([a-zA-Z0-9\.\-]+(\:[a-zA-Z0-9\.&%\$\-]+)*@)*((25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9])\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[0-9])|localhost|([a-zA-Z0-9\-]+\.)*[a-zA-Z0-9\-]+\.(com|edu|gov|int|mil|net|org|biz|arpa|info|name|pro|aero|coop|museum|[a-zA-Z]{1,10}))(\:[0-9]+)*(/($|[a-zA-Z0-9\.\,\?\'\\\+&%\$#\=~_\-]+))*$");
        private static Regex RegHomePhone = new Regex("((\\(\\d{3}\\) ?)|(\\d{3}-))?\\d{3}-\\d{4}|((\\(\\d{3}\\) ?)|(\\d{4}-))?\\d{4}-\\d{4}");
        private static Regex RegIDCard = new Regex("^\\d{15}$|^\\d{18}$");
        private static Regex RegMoney = new Regex("^([0-9]|[0-9].[0-9]{0-2}|[1-9][0-9]*.[0-9]{0,2})$");
        private static Regex RegIP = new Regex(@"^(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9])\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[0-9])$");
        private static Regex RegEngOrNum = new Regex(@"^[a-zA-Z0-9]$");
        private static Regex RegCode = new Regex(@"^[1-9][0-9]{5}$");
        #endregion

        #region 字段串是否为Null或为""(空)
        /// <summary>
        /// 字段串是否为Null或为""(空)
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(string str)
        {
            if (str == null || str.Trim() == string.Empty)
                return true;

            return false;
        }
        #endregion

        #region 字段串中是否包含字母和(或)数字
        /// <summary>
        /// 字段串中是否包含字母和(或)数字
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsEngOrNum(string inputData)
        {
            Match m = RegEngOrNum.Match(inputData);
            return m.Success;
        }
        #endregion

        #region 日期检查
        /// <summary>
        /// Format 的摘要说明。
        /// </summary>
        public static bool IsDateTime(string inputData)
        {
            DateTime dateTime;
            return DateTime.TryParse(inputData, out dateTime);
        }
        #endregion

        #region Guid检查
        public static bool IsGuid(string inputData)
        {
            Guid dateTime;
            return Guid.TryParse(inputData, out dateTime);
        }
        #endregion

        #region 数字字符串检查

        /// <summary>
        /// 是否数字字符串
        /// </summary>
        /// <param name="inputData">输入字符串</param>
        /// <returns></returns>
        public static bool IsNumber(string inputData)
        {
            Match m = RegNumber.Match(inputData);
            return m.Success;
        }
        /// <summary>
        /// 是否数字字符串 可带正负号
        /// </summary>
        /// <param name="inputData">输入字符串</param>
        /// <returns></returns>
        public static bool IsNumberSign(string inputData)
        {
            Match m = RegNumberSign.Match(inputData);
            return m.Success;
        }
        /// <summary>
        /// 是否是浮点数
        /// </summary>
        /// <param name="inputData">输入字符串</param>
        /// <returns></returns>
        public static bool IsDecimal(string inputData)
        {
            Match m = RegDecimal.Match(inputData);
            return m.Success;
        }
        /// <summary>
        /// 是否是浮点数 可带正负号
        /// </summary>
        /// <param name="inputData">输入字符串</param>
        /// <returns></returns>
        public static bool IsDecimalSign(string inputData)
        {
            Match m = RegDecimalSign.Match(inputData);
            return m.Success;
        }

        #endregion

        #region 中文检测

        /// <summary>
        /// 检测是否有中文字符
        /// </summary>
        /// <param name="inputData"></param>
        /// <returns></returns>
        public static bool IsHasCHZN(string inputData)
        {
            Match m = RegCHZN.Match(inputData);
            return m.Success;
        }

        #endregion

        #region email检查
        /// <summary>
        /// 是否是email地址
        /// </summary>
        /// <param name="inputData">输入字符串</param>
        /// <returns></returns>
        public static bool IsEmail(string inputData)
        {
            Match m = RegEmail.Match(inputData);
            return m.Success;
        }
        #endregion

        #region 手机号码检查
        /// <summary>
        /// 验证是否为手机号码
        /// </summary>
        /// <param name="number">手机号</param>
        /// <returns>Boolean</returns>
        public static Boolean IsCellPhoneNumber(string number)
        {
            Match m = RegMobile.Match(number);
            return m.Success;
        }
        #endregion

        #region 网址检查
        /// <summary>
        /// 验证是否为网址
        /// </summary>
        /// <param name="number">网址</param>
        /// <returns>Boolean</returns>
        public static Boolean IsUrl(string url)
        {
            Match m = RegUrl.Match(url);
            return m.Success;
        }
        #endregion

        #region 固定电话检查
        /// <summary>
        /// 验证是否为固定电话(请依 (XXX)XXX-XXXX 格式或 (XXX)XXXX-XXXX 输入电话号码！)
        /// </summary>
        /// <param name="number">固定电话</param>
        /// <returns>Boolean</returns>
        public static Boolean IsHomePhone(string homePhone)
        {
            Match m = RegHomePhone.Match(homePhone);
            return m.Success;
        }
        #endregion

        #region 身份证号码检查
        /// <summary>
        /// 验证是否为身份证号码
        /// </summary>
        /// <param name="number">身份证号码</param>
        /// <returns>Boolean</returns>
        public static Boolean IsIDCard(string card)
        {
            Match m = RegIDCard.Match(card);
            return m.Success;
        }
        #endregion

        #region 金额检查
        /// <summary>
        /// 验证是否为金额
        /// </summary>
        /// <param name="number">金额</param>
        /// <returns>Boolean</returns>
        public static Boolean IsMoney(string money)
        {
            Match m = RegMoney.Match(money);
            return m.Success;
        }
        #endregion

        #region IP检查
        /// <summary>
        /// 验证是否为IP
        /// </summary>
        /// <param name="number">ip</param>
        /// <returns>Boolean</returns>
        public static Boolean IsIP(string ip)
        {
            Match m = RegIP.Match(ip);
            return m.Success;
        }
        #endregion

        #region 邮政编码检查
        /// <summary>
        /// 验证是否为邮政编码
        /// </summary>
        /// <param name="number">code</param>
        /// <returns>Boolean</returns>
        public static Boolean IsYZCode(string code)
        {
            Match m = RegCode.Match(code);
            return m.Success;
        }
        #endregion
    }
}