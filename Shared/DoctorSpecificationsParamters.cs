using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class DoctorSpecificationsParamters
    {
        public int? Specializationn {  get; set; }
        public string? name { get; set; }
        public string? sort {  get; set; }
        private int pageIndex=1;
        private int pageSize=5;

        public int _pageSize
        {
            get { return pageSize; }
            set { pageSize = value; }
        }


        public int _pageIndex
        {
            get { return pageIndex; }
            set { pageIndex = value; }
        }

    }
}
