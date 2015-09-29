using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinfinityClass;


namespace WinfinityClass
{
   public class Test:ITestRepo
    {
       public int Save(TestEntity testEntity)
        {
            TestRepo t = new TestRepo();
            return t.Save(testEntity);
        }
    }
}
