namespace Задача_10
{
    class ListEntry
    {
        public int Degree { get; set; }
        public int A { get; set; }
        public ListEntry Next { get; set; }
        public ListEntry()
        {
            Degree = 0;
            A = 0;
            Next = null;
        }
        public ListEntry(int degree, int a)
        {
            Degree = degree;
            A = a;
            Next = null;
        }
        public override string ToString()
        {
            return Degree + " " + A;
        }
    }
}
