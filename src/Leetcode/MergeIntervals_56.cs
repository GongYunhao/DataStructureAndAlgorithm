using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Leetcode
{
    public class MergeIntervals_56
    {
        public IList<Interval> Merge(IList<Interval> intervals)
        {
            if (intervals == null)
                throw new ArgumentNullException();
            if (intervals.Count <= 1)
                return intervals;

            List<Interval> newList = intervals.OrderBy(o => o.start).ToList();
            List<Interval> result = new List<Interval>(newList.Count);

            int start = newList[0].start;
            int end = newList[0].end;

            for (int i = 1; i < newList.Count; i++)
            {
                // no overlapping
                if (newList[i].start > end)
                {
                    result.Add(new Interval(start, end));
                    start = newList[i].start;
                    end = newList[i].end;
                }
                else
                {
                    end = Math.Max(end, newList[i].end);
                }
            }

            result.Add(new Interval(start, end));
            return result;
        }
    }

    public class Interval
    {
        public int start;
        public int end;
        public Interval() { start = 0; end = 0; }
        public Interval(int s, int e) { start = s; end = e; }
    }
}
