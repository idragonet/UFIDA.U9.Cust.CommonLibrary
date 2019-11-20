using System;
using System.Data;
using UFSoft.UBF.PL;
using UFSoft.UBF.Sys.Database;
using UFSoft.UBF.Util.DataAccess;

namespace UFIDA.U9.Cust.CommonLibrary.Find
{
    /// <summary>
    /// 常用资源查找类（料品、存储地点、供应商、业务员...）
    /// </summary>
    public class Find
    {
        /// <summary>
        /// 获取料品资料
        /// </summary>
        /// <param name="code">料号</param>
        /// <returns></returns>
        public static UFIDA.U9.CBO.SCM.Item.ItemMaster GetItemMaster(string code)
        {
            // var item = new UFIDAU9CBOSCMItemItemInfoData();

            var oqlPar1 = new[]
            {
                new OqlParam("Code",code),
                new OqlParam("Org", UFIDA.U9.Base.Context.LoginOrg.ID)
            };

            return UFIDA.U9.CBO.SCM.Item.ItemMaster.Finder.Find("Code=@Code and Org=@Org", oqlPar1);
        }

        /// <summary>获取客户资料.</summary>
        /// <param name="code">料号</param>
        /// <returns></returns>
        public static UFIDA.U9.CBO.SCM.Customer.Customer GetCustomer(string code)
        {
            // var item = new UFIDAU9CBOSCMItemItemInfoData(); UFIDA::U9::CBO::SCM::Customer::Customer

            var oqlPar1 = new[]
            {
                new OqlParam("Code",code),
                new OqlParam("Org", UFIDA.U9.Base.Context.LoginOrg.ID)
            };

            return UFIDA.U9.CBO.SCM.Customer.Customer.Finder.Find("Code=@Code and Org=@Org", oqlPar1);
        }

        /// <summary>获取存储地点信息.</summary>
        /// <param name="code">The code.</param>
        /// <param name="orgId">默认当前组织</param>
        /// <returns></returns>
        public static UFIDA.U9.CBO.SCM.Warehouse.Warehouse GetWH(string code, long orgId = 0)
        {
            if (orgId == 0)
            {
                orgId = UFIDA.U9.Base.Context.LoginOrg.ID;
            }

            var oqlPar1 = new[]
            {
                new OqlParam("Code", code),
                new OqlParam("Org", orgId)
            };

            return UFIDA.U9.CBO.SCM.Warehouse.Warehouse.Finder.Find("Code=@Code and Org=@Org", oqlPar1);
        }

        /// <summary>获取当前记账期间.</summary>
        /// <returns></returns>
        public static long GetSOBAccountingPeriod()
        {
            string sql = @"SELECT A1.ID FROM dbo.Base_SOBAccountingPeriod A1
JOIN Base_SetofBooks A2 ON A1.SetofBooks=A2.ID
WHERE
A2.Org=@Org AND
A1.Year=@Year AND A1.Code=@Code";

            var parasUpdate = new DataParamList
            {
                DataParamFactory.CreateInput("Org", UFIDA.U9.Base.Context.LoginOrg.ID, System.Data.DbType.Int64),
                DataParamFactory.CreateInput("Year", DateTime.Now.Year, System.Data.DbType.Int16),
                DataParamFactory.CreateInput("Code", DateTime.Now.ToString("MM"), System.Data.DbType.String)
            };
            DataAccessor.RunSQL(DatabaseManager.GetCurrentConnection(), sql, parasUpdate, out DataSet ds);
            if (ds != null && ds.Tables.Count != 0 && ds.Tables[0].Rows.Count != 0)
            {
                return Convert.ToInt64(ds.Tables[0].Rows[0][0]);
            }

            return -1;
        }

        /// <summary>查询组织.</summary>
        /// <param name="code">组织编码.</param>
        /// <returns></returns>
        public static UFIDA.U9.Base.Organization.Organization GetOrg(string code)
        {
            var oqlPar1 = new[]
            {
                new OqlParam("Code", code)
            };

            return UFIDA.U9.Base.Organization.Organization.Finder.Find("Code=@Code", oqlPar1);
        }

        /// <summary>获取业务员.</summary>
        /// <param name="code">业务员编码.</param>
        /// <returns></returns>
        public static UFIDA.U9.CBO.HR.Operator.Operators GetOperators(string code)
        {
            var oqlPar1 = new[]
            {
                new OqlParam("Code",code),
                new OqlParam("Org", UFIDA.U9.Base.Context.LoginOrg.ID)
            };

            return UFIDA.U9.CBO.HR.Operator.Operators.Finder.Find("Code=@Code and Org=@Org", oqlPar1);
        }

        /// <summary>获取供应商.</summary>
        /// <param name="code">供应商编码</param>
        /// <returns></returns>
        public static UFIDA.U9.CBO.SCM.Supplier.Supplier GetSupplier(string code)
        {
            var oqlPar1 = new[]
            {
                new OqlParam("Code",code),
                new OqlParam("Org", UFIDA.U9.Base.Context.LoginOrg.ID)
            };

            return UFIDA.U9.CBO.SCM.Supplier.Supplier.Finder.Find("Code=@Code and Org=@Org", oqlPar1);
        }
    }
}