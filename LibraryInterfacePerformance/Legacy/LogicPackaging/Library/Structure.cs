namespace LibraryInterfacePerformance.Legacy.LogicPackaging.Library
{
    public struct Structure<T>
    {
        public T Start { get; }
        public bool HasOpenStart { get; }
        public T End { get; }
        public bool HasOpenEnd { get; }

        public Structure(T start, bool hasOpenStart, T end, bool hasOpenEnd)
        {
            Start = start;
            HasOpenStart = hasOpenStart;
            End = end;
            HasOpenEnd = hasOpenEnd;
        }
    }
}