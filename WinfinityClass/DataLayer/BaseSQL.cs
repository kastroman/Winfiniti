using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Reflection;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

namespace WinfinityClass
{
   public class BaseSQL
    {
        #region variables
        public  SqlConnection conn;
        public  SqlCommand cmd;
        protected Database db;//=GetConn();
        #endregion

        #region Methods
        /// <summary>
        /// Default Constructor to initiaize connection
        /// </summary>
        public BaseSQL()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["winfinityConn"].ToString());
            
        }

        public static Database GetConn()
        {
            Database db=null;
            try
            {
                db = DatabaseFactory.CreateDatabase(ConfigurationManager.ConnectionStrings["winfinityConn"].ConnectionString);
            }
            catch(Exception ex)
            { 
            
            }
            return db;
        }
        /// <summary>
        /// To Execure Inset,Update,Delete Stored Procedure
        /// </summary>
        /// <param name="spName">Name of procedure</param>
        /// <param name="parameter">Class Name</param>
        /// <returns>Number of Updated Record</returns>
        public  int Execute(string spName,object paramater)
        {
             cmd= new SqlCommand(spName,conn);
             cmd.CommandType = CommandType.StoredProcedure;
             MakeParameters(ref cmd, paramater);    
             return Connection();
        }
        public DataSet Execute(string spName, object paramater,params object[] parameter)
        {
            cmd = new SqlCommand(spName, conn);
            MakeParameters(ref cmd, paramater);
            DataSet ds = new DataSet();
            return ds;
        }


        /// <summary>
        /// to make parameter to pass in stored procedure
        /// </summary>
        /// <param name="cmd">Sql Commamnd</param>
        /// <param name="param">Class Name</param>
        public void MakeParameters(ref SqlCommand cmd, object param)
        {
            Type type = param.GetType();
            foreach (PropertyInfo item in type.GetProperties())
            {
                Type t = item.GetType();

                if (item.MemberType == MemberTypes.Property && !item.Name.EndsWith("From") && !item.Name.EndsWith("To") && !item.Name.Contains("IsChanged") && !item.Name.Contains("CreatedDate") && !item.Name.Contains("UpdatedDate"))
                {
                    if (item.GetValue(param) != null)
                    {
                        cmd.Parameters.AddWithValue("@" + item.Name,item.GetValue(param));
                    }
                }
            }
            
        }
        public void MakeParametersSearch(ref SqlCommand cmd, object param,object[] obj)
        {
            Type type = param.GetType();
            int count = 0;
            List<string> removeParam = new List<string>();
            foreach (PropertyInfo item in type.GetProperties())
            {
                if (item.MemberType == MemberTypes.Property)
                {
                    if (item.GetValue(param) != null)
                    {
                        if (!item.Name.Contains("Date") || !item.Name.Contains("To"))
                        {
                            cmd.Parameters.AddWithValue("@" + item.Name + "Passed", obj[count]);
                        }
                        else
                        {
                            removeParam.Add(item.Name);
                        }
                        
                        cmd.Parameters.AddWithValue("@" + item.Name, item.GetValue(param));
                        count++;
                    }
                }
            }
            

        }
        /// <summary>
        /// To Open and Close Connection and get the number of updated Recoeds
        /// </summary>
        /// <returns>Numeber of Updated Records</returns>
        public int  Connection()
        {
            int count = 0;
            try
            {
                
                conn.Open();
                count = cmd.ExecuteNonQuery();
                conn.Close();
                return count;
            }
            catch (Exception ex)
            {
                return 0;
               
            }
            
        }
        #endregion 
        
    }
}
