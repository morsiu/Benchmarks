using System;
using LibraryInterfacePerformance.InterfacedStructureInByRef.Library;

namespace LibraryInterfacePerformance.InterfacedStructureInByRef.Consumer
{
    public struct Range<T> : IRange<T>, IRange<T, Range<T>>
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
            RangeOperations.IntersectsWith<T, Range<T>>(ref this, ref other);

        public Range<T> Intersect(Range<T> other) =>
            RangeOperations.Intersect<T, Range<T>, Ranges<T>>(ref this, ref other, new Ranges<T>());

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