using System;
using EBSorteio.Rest;

namespace EBSorteio.ViewModel
{
	public class AwardViewModel : BaseViewModel
	{
		private AttendeesResponse Attendees { get; set; }

		private Attendee _data;

		public Attendee Data
		{
			get { return _data; }
			set 
			{
				if (value != _data) 
				{
					_data = value;
					base.INotifyPropertyChanged ();
				}
			}
		}

		public AwardViewModel(AttendeesResponse Attendees)
		{
			this.Attendees = Attendees;
		}

		public void Load()
		{
			//implementar sorteio aqui
		}
	}
}

