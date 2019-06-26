using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задача_8
{
    class PointEntry 
    {
        public int Degree
        {
            get
            {
                return Near.Count;
            }
        }
        public List<PointEntry> Near { get; set; }
        public int Number { get; set; }
        public PointEntry()
        {
            Near = null;
            Number = 0;
        }
        public PointEntry(ICollection<PointEntry> c)
        {
            Near = new List<PointEntry>(c);
            Number = 0;
        }
        public PointEntry(int degree)
        {
            Near = new List<PointEntry>(degree);
            Number = 0;
        }
        public int CompareTo(PointEntry ve)
        {
            if (this.Degree == ve.Degree) return 0;
            else if (this.Degree > ve.Degree) return 1;
            else return -1;
        }
        public static bool Compare(PointEntry ve1, PointEntry ve2, int depth, int max_depth)
        {
            if (max_depth == depth) return true;
            else
            {
                bool ans = false;
                if (ve1.Degree == ve2.Degree)
                {
                    foreach (PointEntry venear1 in ve1.Near)
                    {
                        bool help = false;
                        foreach (PointEntry venear2 in ve2.Near)
                            help = Compare(venear1, venear2, depth + 1, max_depth) || help;
                        ans = ans && help;
                    }
                }
                return ans;
            }
        }
    }
}
