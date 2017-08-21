using System;

namespace LibraryInterfacePerformance.AggregatedStructure.Library
{
    public struct Range<T>
        where T : IComparable<T>
    {
        public Range(T start, bool openStart, T end, bool openEnd)
        {
            Start = start;
            End = end;
            _state =
                (openStart ? State.OpenStart : State.None) |
                (openEnd ? State.OpenEnd : State.None) |
                State.NonEmpty;
        }

        public T Start { get; }
        public T End { get; }
        public bool Empty => (_state & State.NonEmpty) == 0;
        public bool OpenStart => (_state & State.OpenStart) != 0;
        public bool OpenEnd => (_state & State.OpenEnd) != 0;

        public Range<T> Intersect(Range<T> other)
        {
            if (!IntersectsWith(other))
            {
                return new Range<T>();
            }
            var startToOtherStart = Start.CompareTo(other.Start);
            var endToOtherEnd = End.CompareTo(other.End);
            return
                new Range<T>(
                    startToOtherStart  > 0 ? Start : other.Start,
                    startToOtherStart  == 0
                        ? OpenStart || other.OpenStart
                        : startToOtherStart  > 0
                            ? OpenStart
                            : other.OpenStart,
                    endToOtherEnd < 0 ? End : other.End,
                    endToOtherEnd == 0
                        ? OpenEnd || other.OpenEnd
                        : endToOtherEnd < 0
                            ? OpenEnd
                            : other.OpenEnd);
        }

        public bool IntersectsWith(Range<T> other)
        {
            if (Empty || other.Empty) return false;
            var startToOtherEnd = Start.CompareTo(other.End);
            if (startToOtherEnd > 0) return false;
            var endToOtherStart = End.CompareTo(other.Start);
            if (endToOtherStart < 0) return false;
            if (startToOtherEnd == 0) return !OpenStart && !other.OpenEnd;
            if (endToOtherStart == 0) return !OpenEnd && !other.OpenStart;
            return true;
        }
        
        private readonly State _state;

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