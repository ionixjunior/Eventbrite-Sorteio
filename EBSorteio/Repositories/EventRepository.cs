using System;
using EBSorteio.Rest;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EBSorteio
{
	public class EventRepository
	{
		private EventBriteService _eventBriteService;

		public EventRepository (EventBriteService eventBriteService)
		{
			this._eventBriteService = eventBriteService;
		}

		public async Task<List<EventViewModel>> getAllEventsByServiceId(string serviceId)
		{
			if (serviceId == "eventBrite") 
			{
				try
				{				
					var resultItems = await _eventBriteService.getAllEvents();	

					if (resultItems != null) {
						var resultItemsVM = resultItems.ToList ().Select (x => newEventViewModel (x)).ToList();
						return (resultItemsVM != null ? resultItemsVM : null);
					}
				} 
				catch(Exception e) 
				{
				
				}

			}
			return null;				
		}


		private EventViewModel newEventViewModel(object eventObject)
		{
			if (eventObject.GetType ().Name == "Events")
			{
				var EBEvent = eventObject as Events;
				return new EventViewModel () {
					id = EBEvent.id,
					Name = EBEvent.Name.Event,
					Html = EBEvent.Name.Html
				};
			}
			return null;
		}
	}
}

