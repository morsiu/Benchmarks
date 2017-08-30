using System;

namespace LibraryInterfacePerformance.AggregatedStructureInClassAllByRef.Library
{
    public struct Range<T>
    {
        public T Start { get; }
        public T End { get; }
        private readonly State _state;
        public bool OpenStart => (_state & State.OpenStart) != 0;
        public bool OpenEnd => (_state & State.OpenEnd) != 0;
        
        public Range(T start, bool openStart, T end, bool openEnd)
        {
            Start = start;
            End = end;
            _state =
                State.NonEmpty |
                (openStart ? State.OpenStart : State.None) |
                (openEnd ? State.OpenEnd : State.None);
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