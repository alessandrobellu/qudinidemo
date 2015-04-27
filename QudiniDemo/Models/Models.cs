using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QudiniDemo.Models
{
	public class Language
	{
		public string IsoCode { get; set; }
		public string Name { get; set; }
	}

	public class MerchantCustomer
	{
		public int Id { get; set; }
	}

	public class Customer
	{
		public string EmailAddress { get; set; }
		public int Id { get; set; }
		public Language Language { get; set; }
		public MerchantCustomer MerchantCustomer { get; set; }
		public object MobileNetwork { get; set; }
		public string MobileNumber { get; set; }
		public string Name { get; set; }
		public string Notes { get; set; }
	}

	public class Product
	{
		public int Id { get; set; }
		public string Name { get; set; }
	}

	public class CustomersToday
	{
		public object BookingStartTime { get; set; }
		public object CollectingServer { get; set; }
		public int CurrentPosition { get; set; }
		public Customer Customer { get; set; }
		public string ExpectedTime { get; set; }
		public bool HasBeenSentReturnMessage { get; set; }
		public int Id { get; set; }
		public bool InStore { get; set; }
		public bool IsArrived { get; set; }
		public bool IsFixed { get; set; }
		public string JoinedTime { get; set; }
		public object LastSMSStatus { get; set; }
		public string OriginalExpectedTime { get; set; }
		public Product Product { get; set; }
		public object ProductDescription { get; set; }
		public object TimeArrivedInStore { get; set; }
		public string TimeSentReturnMessage { get; set; }
		public int UnreadMessages { get; set; }
		public object WaitTime { get; set; }
	}

	public class Server
	{
		public string DisplayName { get; set; }
		public int Id { get; set; }
	}

	public class Venue
	{
		public string Name { get; set; }
	}

	public class Queue
	{
		public int AverageServeTimeMinutes { get; set; }
		public List<CustomersToday> CustomersToday { get; set; }
		public object FinishReminder { get; set; }
		public int Id { get; set; }
		public string Identifier { get; set; }
		public bool IsBookingAllowed { get; set; }
		public bool IsTabletCollectionEnabled { get; set; }
		public object MaxQueueLength { get; set; }
		public string Name { get; set; }
		public object RequiredMpn { get; set; }
		public List<Server> Servers { get; set; }
		public List<object> ServingServers { get; set; }
		public object ShowAssignedCustomerPopup { get; set; }
		public int UnreadMessagesForQueue { get; set; }
		public Venue Venue { get; set; }
	}

	public class Server2
	{
		public object CurrentBreakReason { get; set; }
		public string DisplayName { get; set; }
		public int Id { get; set; }
	}

	public class ServersAvailable
	{
		public int MinutesUntilNextAvailability { get; set; }
		public int NextAvailableMinutes { get; set; }
		public Server2 Server { get; set; }
	}

	public class QueueData
	{
		public string CurrentUserRole { get; set; }
		public object CustomerServed { get; set; }
		public bool IsActive { get; set; }
		public bool IsMyLastCustomer { get; set; }
		public int MinutesToNextFree { get; set; }
		public Queue Queue { get; set; }
		public List<ServersAvailable> ServersAvailable { get; set; }
	}

	public class ResponseModel
	{
		public QueueData QueueData { get; set; }
		public string Status { get; set; }
	}
}
