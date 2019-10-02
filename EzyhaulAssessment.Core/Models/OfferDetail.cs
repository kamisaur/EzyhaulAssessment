using System;
using System.Collections.Generic;
using System.Text;

namespace EzyhaulAssessment.Core.Models
{
	public class OfferDetail
	{
		public string offerId { get; set; }
		public Vehicle vehicle { get; set; }
		public double schedule { get; set; }
		public LoadSummary loadSummary { get; set; }
		public int totalPickup { get; set; }
		public int totalDelivery { get; set; }
		public double price { get; set; }
		public string currency { get; set; }
		public bool isRead { get; set; }
		public bool isExclusive { get; set; }
		public List<Location> locations { get; set; }
		public string tenantId { get; set; }
		public string countryId { get; set; }
		public string tenantCode { get; set; }
		public string countryCode { get; set; }
		public string transportCategory { get; set; }
		public string currencyCode { get; set; }
		public string currencyLocale { get; set; }
		public string dateFormat { get; set; }
		public string timeFormat { get; set; }
		public string dateTimeLocale { get; set; }
		public string timeZone { get; set; }
	}
}
