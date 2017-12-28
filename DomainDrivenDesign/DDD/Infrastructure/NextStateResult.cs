﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DDD
{
	public class NextStateResult<TModel>
	{
		private readonly TModel model;
		private readonly IEnumerable<string> events;

		public NextStateResult(TModel model, IEnumerable<string> events)
		{
			this.model = model;
			this.events = events;
		}
		public TModel Model()
		{
			return model;
		}
		public IEnumerable<string> Events()
		{
			return events;
		}
	}
}
