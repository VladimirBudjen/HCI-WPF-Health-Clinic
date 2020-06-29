// File:    TimeInterval.cs
// Author:  Luka Doric
// Created: Friday, May 15, 2020 23:46:22
// Purpose: Definition of Class TimeInterval

using Newtonsoft.Json;
using System;

namespace Model.Util
{
    public class TimeInterval
    {
        private DateTime start;
        private DateTime end;

        public DateTime Start { get => start; set => start = value; }
        public DateTime End { get => end; set => end = value; }

        public String Time
        {
            get
            {
                String start = this.start.ToString("HH:mm");
                String end = this.end.ToString("HH:mm");
                return start + " - " + end;
            }
        }

        [JsonConstructor]
        public TimeInterval(DateTime start, DateTime end)
        {
            this.start = start;
            this.end = end;
        }
        public TimeInterval(string start, string end)
        {
            try
            {
                this.start = Convert.ToDateTime(start);
                this.end = Convert.ToDateTime(end);
            }
            catch
            {

            }

        }

        public override string ToString()
        {
            return Start.ToString("HH:mm") + " - " + End.ToString("HH:mm");
        }

        public override bool Equals(object obj)
        {
            TimeInterval other = obj as TimeInterval;
            if(other == null)
            {
                return false;
            }
            return this.start.Equals(other.start) && this.end.Equals(other.end);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        internal string ToStringHours()
        {
            return "start: " + start.ToString("HH:mm") + "\nend: " + end.ToString("HH:mm");
        }
        public bool IsOverLapping(TimeInterval other)
        {
            bool condition1 = other.Start.CompareTo(this.End) < 0 && other.End.CompareTo(this.Start) > 0;
            bool condition2 = this.Start.CompareTo(other.End) < 0 && this.End.CompareTo(other.Start) > 0;
            return condition1 || condition2;
        }
        public bool IsTimeOfDayContained(TimeInterval other)
        {
            int thisStart = this.Start.Hour * 60 + this.Start.Minute;
            int thisEnd = this.End.Hour * 60 + this.End.Minute;
            if(thisEnd < thisStart)
            {
                thisEnd += 24 * 60;
            }
            int otherStart = other.Start.Hour * 60 + other.Start.Minute;
            int otherEnd = other.End.Hour * 60 + other.End.Minute;
            if(otherEnd < otherStart)
            {
                otherEnd += 24 * 60;
            }
            return thisStart <= otherStart && thisEnd >= otherEnd;
        }
        public bool TimeOfDayEquals(TimeInterval other)
        {
            return this.Start.TimeOfDay.Equals(other.Start.TimeOfDay) && this.End.TimeOfDay.Equals(other.End.TimeOfDay);
        }
    }
}