using UFSoft.UBF.Util.Context;

namespace UFIDA.U9.Cust.CommonLibrary.Base
{
    /// <summary>当前登录信息</summary>
    public static class Context
    {
        /// <summary>获取企业ID.</summary>
        /// <value>The enterprise identifier.</value>
        public static string EnterpriseID
        {
            get
            {
                if (PlatformContext.Current == null || string.IsNullOrEmpty(PlatformContext.Current.EnterpriseID))
                    return "";
                return PlatformContext.Current.EnterpriseID;
            }
        }

        /// <summary>获取企业名称.</summary>
        /// <value>The name of the enterprise.</value>
        public static string EnterpriseName
        {
            get
            {
                if (PlatformContext.Current == null || string.IsNullOrEmpty(PlatformContext.Current.EnterpriseName))
                    return "";
                return PlatformContext.Current.EnterpriseName;
            }
        }
    }
}