using System;
using EBSorteio.ViewModel;

namespace EBSorteio
{
	public class EventViewModel : BaseViewModel
	{
		private string _id;
		private string _name;
		private string _html;

		public EventViewModel ()
		{
			
		}

		public string id {
			
			get { return _id; }
			set 
			{
				if (value != _id) 
				{
					_id = value;
					base.INotifyPropertyChanged ();
				}
			}
		}
		public string Name {
			get { return _name; }
			set {
				
				if (value != _name) {
					_name = value;
					base.INotifyPropertyChanged ();
				}
			}
		}
		public string Html {
			
			get { return _html; }
			set {

				if (value != _html) {
					_html = value;
					base.INotifyPropertyChanged ();
				}
			}
		}

	}
}

