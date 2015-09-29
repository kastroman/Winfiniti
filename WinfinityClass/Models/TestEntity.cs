using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinfinityClass
{
   public class TestEntity:BaseModel
    {

        string name;
        string id;
       public string Name
       {
            get
            {
                return name;
            }
            set
            {
                if (name != value)
                {
                    IsChanged = true;
                }
                name = value;
            }

       }
       public string ID
       {
           get
           {
               return id;
           }
           set
           {
               if (id != value)
               {
                   IsChanged = true;
               }
               id = value;
           }
       }
        public int Save(TestEntity testEntity)
        {
            throw new NotImplementedException();
        }
    }
}
