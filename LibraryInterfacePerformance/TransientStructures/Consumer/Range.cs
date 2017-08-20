using System;
using Impl = LibraryInterfacePerformance.TransientStructures.Library;

namespace LibraryInterfacePerformance.TransientStructures.Consumer
{
    public struct Range<T>
        where T : IComparable<T>
    {
        public T Start { get; }
        public T End { get; }
        private readonly State _state;

        public Range(T start, bool openStart, T end, bool openEnd)
        {
            Start = start;
            End = end;
            _state =
                State.NonEmpty |
                (openStart ? State.OpenStart : State.None) |
                (openEnd ? State.OpenEnd : State.None);
        }

        public bool Empty => (_state & State.NonEmpty) == 0;
        public bool OpenStart => (_state & State.OpenStart) != 0;
        public bool OpenEnd => (_state & State.OpenEnd) != 0;

        public bool IntersectsWith(Range<T> other) =>
            Implementation().IntersectsWith(other.Implementation());

        public Range<T> Intersect(Range<T> other) =>
            Interface(Implementation().Intersect(other.Implementation()));

        private Impl.Range<T> Implementation() =>
            !Empty
                ? new Impl.Range<T>(Start, OpenStart, End, OpenEnd)
                : new Impl.Range<T>();
        
        private static Range<T> Interface(Impl.Range<T> other) =>
            !other.Empty
                ? new Range<T>(other.Start, other.OpenStart, other.End, other.OpenEnd)
                : new Range<T>();
        
        [Flags]
        private enum State : byte
        {
            None = 0,
            OpenStart = 1,
            OpenEnd = 2,
            NonEmpty = 4
        }
    }
}