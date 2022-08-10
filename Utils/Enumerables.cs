using System.Collections.Generic;

namespace JustEnoughScythes.Utils
{
    public class CycleList<T> : List<T>
    {
        private int _Counter { get; set; } = 0;
        protected int CycleIndex
        {
            get => _Counter;
            set
            {
                if (value >= Count)
                    _Counter = 0;
                _Counter = value;
            }
        }
        public CycleList() : base() { }
        public CycleList(int Capacity) : base(Capacity) { }
        public CycleList(IEnumerable<T> Collection) : base(Collection) { }
        public T Cycle()
        {
            T Item = this[CycleIndex];
            CycleIndex++;
            return Item;
        }
    }
}
