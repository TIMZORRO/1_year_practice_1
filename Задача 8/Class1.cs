using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задача_8
{
    class VertexEntry : IComparable<VertexEntry>
    {
        public int Degree { get; set; }
        public List<VertexEntry> Near { get; set; }
        public VertexEntry()
        {
            Degree = 0;
            Near = null;
        }
        public VertexEntry(ICollection<VertexEntry> c)
        {
            Degree = c.Count;
            Near = new List<VertexEntry>(c);
        }
        public VertexEntry(int degree)
        {
            Degree = degree;
            Near = new List<VertexEntry>(degree);
        }
        public int CompareTo(VertexEntry ve)
        {
            if (this.Degree == ve.Degree) return 0;
            else if (this.Degree > ve.Degree) return 1;
            else return -1;
        }
        public static bool Compare(VertexEntry ve1, VertexEntry ve2, int depth, int max_depth)
        {
            if (max_depth == depth) return true;
            else
            {
                bool ans = false;
                if (ve1.Degree == ve2.Degree)
                {
                    foreach (VertexEntry venear1 in ve1.Near)
                    {
                        bool help = false;
                        foreach (VertexEntry venear2 in ve2.Near)
                            help = Compare(venear1, venear2, depth + 1, max_depth) || help;
                        ans = ans && help;
                    }
                }
                return ans;
            }
        }
    }
}
