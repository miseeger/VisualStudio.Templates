namespace $safeprojectname$.Services
{

	public interface IMessageService
	{
		string Message { get; set; }
		string Title { get; set; }

		void Notify(string message);
		void Notify(string title, string message);
		bool Confirm(string message);
		bool Confirm(string title, string message);
	}

}