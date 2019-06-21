using System;

namespace Задача_9
{
    class CircularListEntry
    {
        public int Value { get; set; }
        public int Key { get; set; } // в коллекции является, по сути, индексатором
        public CircularListEntry Next{ get; set; }
        public CircularListEntry()
        {
            Key = 0;
            Value = 0;
            Next = null;
        }
        public CircularListEntry(int value)
        {
            Value = value;
            Next = null;
        }
        public override string ToString()
        {
            return Convert.ToString(Value);
        }
        public void Show()
        {
            Console.WriteLine(ToString());
        }
    }
}
