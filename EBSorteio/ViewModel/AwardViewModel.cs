using System;
using EBSorteio.Rest;

namespace EBSorteio.ViewModel
{
	public class AwardViewModel : BaseViewModel
	{
		private AttendeesResponse AttendeesResponse { get; set; }

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

		public AwardViewModel(AttendeesResponse AttendeesResponse)
		{
			this.AttendeesResponse = AttendeesResponse;
		}

		public void Load()
		{
			var random = new Random();
			var index = random.Next (0, (AttendeesResponse.Attendees.Count - 1));
			Attendee attendee = AttendeesResponse.Attendees[index];

			Data = attendee;
		}
	}
}

