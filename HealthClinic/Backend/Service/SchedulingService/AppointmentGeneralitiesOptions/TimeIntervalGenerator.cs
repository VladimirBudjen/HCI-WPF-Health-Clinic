using Model.Schedule;
using Model.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backend.Service.SchedulingService.AppointmentGeneralitiesOptions
{
    class TimeIntervalGenerator
    {
        private const int MINUTES_BETWEEN_APPOINTMENTS = 15;
        private const int ALLOWED_DAYS_OF_SCHEDULING_IN_ADVANCE = 10;
        private ProcedureType procedure;
        private int restrictedSchedulingHours;
        public TimeIntervalGenerator(ProcedureType procedure, int restrictedSchedulingHours)
        {
            this.procedure = procedure;
            this.restrictedSchedulingHours = restrictedSchedulingHours;
        }

        public List<TimeInterval> generateAllTimeIntervals()
        {
            List<TimeInterval> timeIntervals = new List<TimeInterval>();
            DateTime currentDay = DateTime.Today.AddHours(restrictedSchedulingHours);
            while (IsSchedulingAllowedPeriod(currentDay))
            {
                timeIntervals.AddRange(generateTimeIntervalsForDay(currentDay));
                currentDay = currentDay.AddDays(1);
            }
            return timeIntervals;
        }

        public List<TimeInterval> generateTimeIntervalsForDay(DateTime day)
        {
            List<TimeInterval> timeIntervals = new List<TimeInterval>();
            DateTime currentStart = day.Date;
            while (!IsTheNextDay(currentStart, day))
            {
                timeIntervals.Add(generateOneTimeInterval(currentStart));
                currentStart = currentStart.AddMinutes(MINUTES_BETWEEN_APPOINTMENTS);
            }
            return timeIntervals;
        }
        private TimeInterval generateOneTimeInterval(DateTime start)
        {
            DateTime end = start.AddMinutes(procedure.EstimatedTimeInMinutes);
            return new TimeInterval(start, end);
        }
        private bool IsSchedulingAllowedPeriod(DateTime day)
        {
            DateTime lastDayAllowed = DateTime.Today.AddDays(ALLOWED_DAYS_OF_SCHEDULING_IN_ADVANCE);
            return day.CompareTo(lastDayAllowed) < 0;
        }
        private bool IsTheNextDay(DateTime date, DateTime today)
        {
            DateTime tomorrow = today.AddDays(1);
            return tomorrow.Equals(date.Date);
        }
    }
}
