using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using UFSoft.UBF.UI;
using UFSoft.UBF.UI.IView;

namespace UFIDA.U9.Cust.CommonLibrary
{

    /// <summary>
    /// 数据类型转换、数据判断、UI关闭
    /// </summary>
    public static class UIHelp
    {
        // Token: 0x06004251 RID: 16977 RVA: 0x001854CC File Offset: 0x001836CC
        public static string ToString(object obj)
        {
            string empty = string.Empty;
            string result;
            if (obj == null)
            {
                result = string.Empty;
            }
            else
            {
                result = obj.ToString();
            }
            return result;
        }

        // Token: 0x06004252 RID: 16978 RVA: 0x00185500 File Offset: 0x00183700
        public static bool ToBool(object obj)
        {
            bool flag = false;
            bool result;
            if (obj == null)
            {
                result = false;
            }
            else
            {
                bool.TryParse(obj.ToString(), out flag);
                result = flag;
            }
            return result;
        }

        // Token: 0x06004253 RID: 16979 RVA: 0x00185534 File Offset: 0x00183734
        public static decimal ToDecimal(object obj)
        {
            decimal num = 0m;
            decimal result;
            if (obj == null)
            {
                result = 0m;
            }
            else
            {
                decimal.TryParse(obj.ToString(), out num);
                result = num;
            }
            return result;
        }

        // Token: 0x06004254 RID: 16980 RVA: 0x00185570 File Offset: 0x00183770
        public static long ToLong(object obj)
        {
            long result;
            if (obj == null)
            {
                result = 0;
            }
            else
            {
                long num;
                long.TryParse(obj.ToString(), out num);
                result = num;
            }
            return result;
        }

        // Token: 0x06004255 RID: 16981 RVA: 0x001855A4 File Offset: 0x001837A4
        public static int ToInt(object obj)
        {
            int result;
            if (obj == null)
            {
                result = 0;
            }
            else
            {
                int num;
                int.TryParse(obj.ToString(), out num);
                result = num;
            }
            return result;
        }

        // Token: 0x06004256 RID: 16982 RVA: 0x001855D8 File Offset: 0x001837D8
        public static DateTime ToDateTime(object obj)
        {
            DateTime minValue = DateTime.MinValue;
            DateTime result;
            if (obj == null)
            {
                result = DateTime.MinValue;
            }
            else
            {
                DateTime.TryParse(obj.ToString(), out minValue);
                result = minValue;
            }
            return result;
        }



        /// <summary>
        /// 关闭窗口
        /// </summary>
        /// <param name="part"></param>
        public static void CloseForm(IPart part)
        {
            string text = "window.close();";
            AtlasHelper.RegisterAtlasStartupScript((Control)part.TopLevelContainer, part.GetType(), Guid.NewGuid().ToString(), text, true);
        }

        /// <summary>
        /// 判断对象是否为null或者DBNull
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool IsNullOrDBNull(object obj)
        {
            return obj == null || Convert.IsDBNull(obj);
        }

        /// <summary>
        /// 对象转为long
        /// </summary>
        /// <param name="dbValue"></param>
        /// <returns></returns>
        public static long GetIDFromDBValue(object dbValue)
        {
            long result;
            if (IsNullOrDBNull(dbValue) && long.TryParse(dbValue.ToString(), out var num))
            {
                result = num;
            }
            else
            {
                result = 0;
            }
            return result;
        }
    }
}
