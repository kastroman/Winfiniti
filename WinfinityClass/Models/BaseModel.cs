using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinfinityClass
{
   public class BaseModel
   {
       #region Variables
      
        protected int key;
        protected bool isChanged;
        protected DateTime createdDate=new DateTime(1970,1,1);
        protected DateTime updatedDate = new DateTime(1970, 1, 1);
        protected DateTime createdDateFrom = new DateTime(1970, 1, 1);
        protected DateTime updatedDateFrom = new DateTime(1970, 1, 1);
        protected DateTime createdDateTo = new DateTime(1970, 1, 1);
        protected DateTime updatedDateTo = new DateTime(1970, 1, 1);
       #endregion

        #region Properties
        /// <summary>
       /// Key Value of Entity
       /// </summary>
        public int Key
        {
            get
            {
                return key;
            }
            set
            {

                if (key != value)
                {
                    IsChanged = true;
                }
                    key = value;
                
            }
        }
       /// <summary>
       /// Is any property Value Changed within a Entity
       /// </summary>
        public bool IsChanged
        {

            get
            {
                return isChanged;
            }
            set
            {
                isChanged = value;

            }
        }

        public DateTime CreatedDate 
        {
            get
            {
                return createdDate;
            }
            set
            {
                if (createdDate != value)
                {
                    IsChanged = true;
                }
                createdDate = value;
            }
        }
        public DateTime CreatedDateFrom
        {
            get
            {
                return createdDateFrom;
            }
            set
            {
                
                createdDateFrom = value;
            }
        }
        public DateTime CreatedDateTo
        {
            get
            {
                return createdDateTo;
            }
            set
            {
                
                createdDateTo = value;
            }
        }

        public DateTime UpdatedDate
        {
            get
            {
                return updatedDate;
            }
            set
            {
                if (updatedDate != value)
                {
                    IsChanged = true;
                }
                updatedDate = value;
            }

        }
        public DateTime UpdatedDateFrom
        {
            get
            {
                return updatedDateFrom;
            }
            set
            {
                
                updatedDateFrom = value;
            }

        }
        public DateTime UpdatedDateTo
        {
            get
            {
                return updatedDateTo;
            }
            set
            {
                
                updatedDateTo = value;
            }

        }
        #endregion 
   }
}
