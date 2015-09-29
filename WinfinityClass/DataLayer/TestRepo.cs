using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinfinityClass
{
   public class TestRepo:BaseSQL,ITestRepo
    {

        /// <summary>
        /// Insert Of Update record in DB   
        /// </summary>
        /// <param name="testEntity"></param>
        /// <returns></returns>
        public int Save(TestEntity testEntity)
        {
            try
            {
                return (int)db.ExecuteScalar("Save_Demotbl", testEntity.Key, testEntity.Name, testEntity.ID);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}
