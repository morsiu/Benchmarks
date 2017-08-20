using System;
using Impl = LibraryInterfacePerformance.StaticMethods.Library;

namespace LibraryInterfacePerformance.StaticMethods.Consumer
{
    public struct Range<T> : IRange<T, Range<T>>
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

        public bool OpenStart => (_state & State.OpenStart) != 0;
        public bool OpenEnd => (_state & State.OpenEnd) != 0;

        public bool IntersectsWith(Range<T> other) =>
            Impl.RangeOperations.IntersectsWith(
                Start, OpenStart, End, OpenEnd,
                other.Start, other.OpenStart, other.End, other.OpenEnd);

        public Range<T> Intersect(Range<T> other)
        {
            return Impl.RangeOperations.Intersect(
                    Start, OpenStart, End, OpenEnd,
                    other.Start, other.OpenStart, other.End, other.OpenEnd,
                    out var start, out var openStart, out var end, out var openEnd)
                ? new Range<T>(start, openStart, end, openEnd)
                : new Range<T>();
        }

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