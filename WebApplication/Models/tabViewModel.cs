using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class tabViewModel
    {
        private string _TabText1;
        public string TabText1
        {
            get { return _TabText1; }
            set
            {
                _TabText1 = value;
            }
        }

        private string _TabText2;
        public string TabText2
        {
            get { return _TabText2; }
            set
            {
                _TabText2 = value;
            }
        }

        private string _TabText3;
        public string TabText3
        {
            get { return _TabText3; }
            set
            {
                _TabText3 = value;
            }
        }
    }
}