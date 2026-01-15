using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Domain.Exceptions;

namespace CarRental.Domain.ValueObjects
{
    public record DateRange
    {
		private DateTime _start;
		private DateTime _end;

		public DateTime End
		{
			get { return this._end; }
		}

		public DateTime Start
		{
			get { return this._start; }
		}

		private DateRange(DateTime start, DateTime end)
		{
			this._start = start;
			this._end = end;
		}

		public static DateRange Create(DateTime start, DateTime end)
		{
			if (start >= end) throw new ValidationException("End date must be greater than start date.");

			return new DateRange(start, end);
		}

		public bool Overlaps(DateRange other)
		{

			return this.Start < other.End && other.Start < this.End;
		}

		public int Days()
		{
			return (End - Start).Days == 0 ? 1 : (int)Math.Ceiling((End - Start).TotalDays);
		}

	}
}
