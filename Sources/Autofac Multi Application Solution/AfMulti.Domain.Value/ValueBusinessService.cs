using System.Collections.Generic;
using System.Linq;
using $ext_safeprojectname$.Common.Data.Model;
using $ext_safeprojectname$.Common.Interfaces.Services;
using $safeprojectname$.Interfaces;
using AutofacModularity;

namespace $safeprojectname$
{
    
	[RegisterService]
	public class ValueBusinessService : IValueBusinessService
    {

	    private IMemDataService _memData;
		
		public string SpecialValue { get; set; }

		
		public ValueBusinessService(string specialValue, IMemDataService memData)
		{
			_memData = memData;
			SpecialValue = specialValue;
		}

		
		public IEnumerable<StringValue> GetStringValues()
		{
			return _memData.Data;
		}

		public StringValue GetStringValue(int Id)
		{
			return _memData.Data.FirstOrDefault(d => d.Id == Id);
		}

		public int CreateStringValue(StringValue NewStringValue)
		{
			if ((_memData.Data != null) && (NewStringValue != null))
			{
				NewStringValue.Id = _memData.Data.Count();
				_memData.Data.Add(NewStringValue);
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
				_memData.Data = (List<StringValue>)_memData.Data.Except(exceptList).ToList();
				var index = 0;
				foreach (var sValue in _memData.Data)
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
