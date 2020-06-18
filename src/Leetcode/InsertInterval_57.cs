using System;
using System.Collections.Generic;
using System.Linq;

namespace Leetcode
{
    public class InsertInterval_57
    {
        // the given intervals are not overlapped
        // so we just need to handle with intervals that is overlapped with the new one
        // others can be added to result without edit
        public IList<Interval> Insert(IList<Interval> intervals, Interval newInterval)
        {
            if (intervals == null || newInterval == null)
                throw new ArgumentNullException();
            if (intervals.Count == 0)
                return new List<Interval> { newInterval };

            List<Interval> result = new List<Interval>(intervals.Count);
            int start = newInterval.start, end = newInterval.end;
            foreach (var target in intervals)
            {
                if (target.end < start || target.start > end)
                    result.Add(target);// 'target' is not overlapped with newInterval
                else
                {
                    // intervals overlapped, should merge
                    start = Math.Min(start, target.start);
                    end = Math.Max(end, target.end);
                }
            }

            result.Add(new Interval(start, end));
            result = result.OrderBy(o => o.start).ToList();// merged intervals added to the tail, so sort the list to make it look like insert
            return result;
        }
    }
}
