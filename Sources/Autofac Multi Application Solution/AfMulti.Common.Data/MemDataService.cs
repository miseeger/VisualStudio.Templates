using System;
using System.Linq;
using System.Collections.Generic;
using $ext_safeprojectname$.Common.Interfaces.Services;
using $ext_safeprojectname$.Common.Data.Model;
using AutofacModularity;

namespace $safeprojectname$
{

	[RegisterService]
	public class MemDataService : IMemDataService
	{

		public string Option { get; set; }
		public ILoggingService LoggingService { get; private set; }
		public List<StringValue> Data { get; set; }


		public MemDataService(ILoggingService loggingService, string option)
		{
			Option = option;
			LoggingService = loggingService;

			Data = new List<StringValue>
			{
				new StringValue{Id=0, Value="Value1"},
				new StringValue{Id=1, Value="Value2"},
				new StringValue{Id=2, Value="Value3"}
			};
		}


		public void Hello()
		{
			Console.WriteLine("MemDataService.Option: {0}", Option);
		}


		public IEnumerable<StringValue> GetStringValues()
		{
			return Data;
		}

		public StringValue GetStringValue(int Id)
		{
			return Data.FirstOrDefault(d => d.Id == Id);
		}
		
		public int CreateStringValue(StringValue NewStringValue)
		{
			if ((Data != null) && (NewStringValue != null))
			{
				NewStringValue.Id = Data.Count();
				Data.Add(NewStringValue);
				return NewStringValue.Id;
			}
			else
			{
				return -1;
			}
		}
		
		public bool UpdateStringValue(StringValue UpdateStringValue)
		{
			var valueToUpdate = GetStringValue(UpdateStringValue.Id);
			if ((UpdateStringValue != null) && (UpdateStringValue.Value != null))
			{
				valueToUpdate.Value = UpdateStringValue.Value;
				return true;
			}
			
			else
			{
				return false;
			}
		}
		
		public bool DeleteStringValue(int Id)
		{
			var valueToDelete = GetStringValue(Id);
			if (valueToDelete != null)
			{
				var exceptList = new List<StringValue>();
				exceptList.Add(valueToDelete);
				Data = (List<StringValue>)Data.Except(exceptList).ToList();
				var index = 0;
				foreach (var sValue in Data)
				{
					sValue.Id = index++;
				}
				return true;
			}
			else
			{
				return false;
			}
		}

	}

}