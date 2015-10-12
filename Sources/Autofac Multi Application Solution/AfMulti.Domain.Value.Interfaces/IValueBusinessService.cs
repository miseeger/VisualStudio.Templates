using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using $ext_safeprojectname$.Common.Data.Model;

namespace $safeprojectname$
{

	public interface IValueBusinessService
    {
		string SpecialValue { get; set; }

		IEnumerable<StringValue> GetStringValues();
		StringValue GetStringValue(int Id);
		int CreateStringValue(StringValue NewStringValue);
		bool UpdateStringValue(StringValue NewStringValue);
		bool DeleteStringValue(int Id);

    }

}
