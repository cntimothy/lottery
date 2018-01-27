using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    class Individual
    {
        private string name;
        private bool isHitted;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public bool IsHitted
        {
            get { return isHitted; }
            set { isHitted = value; }
        }

        public Individual(string name)
        {
            this.Name = name;
            this.IsHitted = false;
        }
        
        public String dump()
        { 
            return Name + ":" + IsHitted;
        }
    }
}
