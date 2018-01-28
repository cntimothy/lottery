using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    class Individual
    {
        public string Name;

        public Individual(string name)
        {
            this.Name = name;
        }

        public override string ToString()
        {
            return Name;
        }

        public override bool Equals(object obj)
        {
            Individual individual = obj as Individual;
            if (individual.Name.Equals(this.Name))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode();
        }
    }
}
