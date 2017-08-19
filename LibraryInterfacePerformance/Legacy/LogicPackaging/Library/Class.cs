namespace LibraryInterfacePerformance.Legacy.LogicPackaging.Library
{
    public sealed class Class<T>
    {
        public T Start { get; }
        public bool HasOpenStart { get; }
        public T End { get; }
        public bool HasOpenEnd { get; }

        public Class(T start, bool hasOpenStart, T end, bool hasOpenEnd)
        {
            Start = start;
            HasOpenStart = hasOpenStart;
            End = end;
            HasOpenEnd = hasOpenEnd;
        }
    }
}