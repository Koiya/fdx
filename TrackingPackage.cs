using System;
using System.Collections.Generic;

namespace Fedex
{
    public class TrackResponse
    {
        public string TransactionId { get; set; }
        public string CustomerTransactionId { get; set; }
        public TrackResult Output { get; set; }
    }

    public class TrackResult
    {
        public List<CompleteTrackResult> CompleteTrackResults { get; set; }
        //public string Alerts { get; set; } // holds alert messages if any
    }

    public class CompleteTrackResult
    {
        public string TrackingNumber { get; set; }
        public List<TrackResultDetail> TrackResults { get; set; }
    }
    
        public class PackageTrackingResult
    {
        public string TrackingNumber { get; set; }
        public List<TrackResult> TrackResults { get; set; }
    }

    public class TrackResultDetail
    {
        public TrackingNumberInfo TrackingNumberInfo { get; set; }
        public AdditionalTrackingInfo AdditionalTrackingInfo { get; set; }
        public DistanceToDestination DistanceToDestination { get; set; }
        public List<ConsolidationDetail> ConsolidationDetail { get; set; }
        public string MeterNumber { get; set; } // "8468376"
        public ReturnDetail ReturnDetail { get; set; }
        public ServiceDetail ServiceDetail { get; set; }
        public DestinationLocation DestinationLocation { get; set; }
        public LatestStatusDetail LatestStatusDetail { get; set; }
        public ServiceCommitMessage ServiceCommitMessage { get; set; }
        public List<InformationNote> InformationNotes { get; set; }
        public DeliveryDetails DeliveryDetails { get; set; }
        public List<ScanEvent> ScanEvents { get; set; }
        public PackageDetails PackageDetails { get; set; }
        public string GoodsClassificationCode { get; set; } // "goodsClassificationCode"
        public HoldAtLocation HoldAtLocation { get; set; }
        public EstimatedDeliveryTimeWindow EstimatedDeliveryTimeWindow { get; set; }
        public OriginLocation OriginLocation { get; set; }
        public RecipientInformation RecipientInformation { get; set; }
        public StandardTransitTimeWindow StandardTransitTimeWindow { get; set; }
        public ShipmentDetails ShipmentDetails { get; set; }
        public ReasonDetail ReasonDetail { get; set; }
        public List<string> AvailableNotifications { get; set; }
        public ShipperInformation ShipperInformation { get; set; }
        public LastUpdatedDestinationAddress LastUpdatedDestinationAddress { get; set; }
    }
    public class LastUpdatedDestinationAddress
    {
        public string AddressClassification { get; set; } // "BUSINESS"
        public bool Residential { get; set; } // false
        public List<string> StreetLines { get; set; } // ["1043 North Easy Street", "Suite 999"]
        public string City { get; set; } // "SEATTLE"
        public string UrbanizationCode { get; set; } // "RAFAEL"
        public string StateOrProvinceCode { get; set; } // "WA"
        public string PostalCode { get; set; } // "98101"
        public string CountryCode { get; set; } // "US"
        public string CountryName { get; set; } // "United States"
    }
    
    public class EstimatedDeliveryTimeWindow
    {
        public string Description { get; set; } // "Description field"
        public TimeWindow Window { get; set; }
        public string Type { get; set; } // "ESTIMATED_DELIVERY"
    }
    
    public class HoldAtLocation
    {
        public string LocationId { get; set; } // "SEA"
        public LocationContactAndAddress LocationContactAndAddress { get; set; }
        public string LocationType { get; set; } // "PICKUP_LOCATION"
    }

    public class InformationNote
    {
        public string Code { get; set; }
        public string Description { get; set; }
    }

    public class ServiceCommitMessage
    {
        public string Message { get; set; }
        public string Typer { get; set; }
    }

    public class DestinationLocation
    {
        public string LocationId { get; set; } // "SEA"
        public LocationContactAndAddress LocationContactAndAddress { get; set; }
        public string LocationType { get; set; } // "PICKUP_LOCATION"
    }

    public class Address
    {
        public string AddressClassification { get; set; } // "BUSINESS"
        public bool Residential { get; set; } // false
        public List<string> StreetLines { get; set; } // ["1043 North Easy Street", "Suite 999"]
        public string City { get; set; } // "SEATTLE"
        public string UrbanizationCode { get; set; } // "RAFAEL"
        public string StateOrProvinceCode { get; set; } // "WA"
        public string PostalCode { get; set; } // "98101"
        public string CountryCode { get; set; } // "US"
        public string CountryName { get; set; } // "United States"
    }

    public class DistanceToDestination
    {
        public string Units { get; set; }
        public float Value { get; set; }
    }
    
    public class ConsolidationDetail
    {
        public DateTime TimeStamp { get; set; } // "2020-10-13T03:54:44-06:00"
        public string ConsolidationId { get; set; } // "47936927"
        public ReasonDetail ReasonDetail { get; set; }
        public int PackageCount { get; set; } // 25
        public string EventType { get; set; } // "PACKAGE_ADDED_TO_CONSOLIDATION"
    }

    public class Contact
    {
        public string PersonName { get; set; }
        public string PhoneNumber { get; set; }
        public string CompanyName { get; set; }
    }

    public class ReturnDetail
    {
        public string AuthorizationName { get; set; }
        public List<ReasonDetail> ReasonDetail { get; set; }
    }

    public class ReasonDetail
    {
        public string Description { get; set; }
        public string Type { get; set; }
    }

    public class StandardTransitTimeWindow
    {
        public TimeWindow Window { get; set; }
    }

    public class TimeWindow
    {
        public DateTime Ends { get; set; }
    }
    
    public class ServiceDetail
    {
        public string Type { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
    }

    public class OriginLocation
    {
        public LocationContactAndAddress LocationContactAndAddress { get; set; }
    }

    public class LocationContactAndAddress
    {
        public Address Address { get; set; }
    }

    public class DeliveryDetails
    {
        public Address ActualDeliveryAddress { get; set; }
        public string DeliveryAttempts { get; set; }
        public string ReceivedByName { get; set; }
        public List<DeliveryOptionEligibilityDetail> DeliveryOptionEligibilityDetails { get; set; }
    }
    
    public class DeliveryOptionEligibilityDetail
    {
        public string Option { get; set; }
        public string Eligibility { get; set; }
    }

    public class ScanEvent
    {
        public DateTime Date { get; set; }
        public string EventType { get; set; }
        public string EventDescription { get; set; }
        public string ExceptionCode { get; set; }
        public string ExceptionDescription { get; set; }
        public ScanLocation ScanLocation { get; set; }
        public string LocationType { get; set; }
        public string DerivedStatusCode { get; set; }
        public string DerivedStatus { get; set; }
    }

    public class ShipmentDetails
    {
        public List<string> ShipmentDet { get; set; }
    }

    public class TrackingNumberInfo
    {
        public string TrackingNumber { get; set; }
        public string TrackingNumberUniqueId { get; set; }
        public string CarrierCode { get; set; }
    }

    public class AdditionalTrackingInfo
    {
        public string Nickname { get; set; }
        public List<PackageIdentifier> PackageIdentifiers { get; set; }
        public bool HasAssociatedShipments { get; set; }
    }

    public class PackageIdentifier
    {
        public string Type { get; set; }
        public List<string> Values { get; set; }
        public string TrackingNumberUniqueId { get; set; }
        public string CarrierCode { get; set; }
    }

    public class ShipperInformation
    {
        public Contact Contact { get; set; }
        public Address Address { get; set; }
    }

    public class RecipientInformation
    {
        public Contact Contact { get; set; }
        public Address Address { get; set; }
    }

    public class LatestStatusDetail
    {
        public string Code { get; set; }
        public string DerivedCode { get; set; }
        public string StatusByLocale { get; set; }
        public string Description { get; set; }
        public ScanLocation ScanLocation { get; set; }
        public List<AncillaryDetail> AncillaryDetails { get; set; }
    }

    public class ScanLocation
    {
        public string City { get; set; }
        public string StateOrProvinceCode { get; set; }
        public string CountryCode { get; set; }
        public bool Residential { get; set; }
        public string CountryName { get; set; }
        public List<string> StreetLines { get; set; }
    }

    public class AncillaryDetail
    {
        public string Reason { get; set; }
        public string ReasonDescription { get; set; }
        public string Action { get; set; }
        public string ActionDescription { get; set; }
    }

    public class DateTimeInfo
    {
        public string Type { get; set; }
        public DateTime DateTime { get; set; }
    }

    public class PackageDetails
    {
        public PackagingDescription PackagingDescription { get; set; }
        public string PhysicalPackagingType { get; set; }
        public string SequenceNumber { get; set; }
        public string Count { get; set; }
        public WeightAndDimensions WeightAndDimensions { get; set; }
        public List<PackageContent> PackageContent { get; set; }
        public int ContentPieceCount { get; set; }
        public DeclaredValue DeclaredValue { get; set; }
    }

    public class PackageContent
    {
        public string Item { get; set; }
    }

    public class PackagingDescription
    {
        public string Type { get; set; }
        public string Description { get; set; }
    }

    public class WeightAndDimensions
    {
        public List<Weight> Weight { get; set; }
        public List<Dimension> Dimensions { get; set; }
    }

    public class Weight
    {
        public double Value { get; set; }
        public string Unit { get; set; }
    }

    public class Dimension
    {
        public double Length { get; set; }
        public double Width { get; set; }
    }

    public class DeclaredValue
    {
        public string Currency { get; set; }
        public double Value { get; set; }
    }

}