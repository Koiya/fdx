using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Google.Cloud.BigQuery.V2;

namespace Fedex
{
    public class ToLines
    {
        public static Task<List<string>> Extrapolate(
            List<CompleteTrackResult> dataIn,
            string projectId,
            string datasetId,
            string table)
        {
            var stuShip = new List<string>();
            //destination
            var desData1 = dataIn[0].TrackResults[0]?.RecipientInformation?.Contact?.PersonName;
            var desData2 = dataIn[0].TrackResults[0]?.RecipientInformation?.Contact?.PhoneNumber;
            var desData3 = dataIn[0].TrackResults[0]?.DestinationLocation?.LocationContactAndAddress?.Address?.City;
            var desData4 =
                dataIn[0]?.TrackResults[0]?.DestinationLocation?.LocationContactAndAddress?.Address?.StreetLines is null
                    ? string.Empty
                    : string.Join(", ", dataIn[0]?.TrackResults[0]?.DestinationLocation?.LocationContactAndAddress?.Address?.StreetLines); 
            var desData5 = dataIn[0].TrackResults[0]?.DestinationLocation?.LocationContactAndAddress?.Address?.PostalCode;
            var desData = string.Concat(desData1," | ",desData2," | ",desData3," | ",desData4," | ",desData5);
            //scan
            var scanData1 = dataIn[0].TrackResults[0]?.LatestStatusDetail?.ScanLocation?.City;
            var scanData2 = dataIn[0]?.TrackResults[0]?.LatestStatusDetail?.ScanLocation?.Residential;
            var scanData3 = dataIn[0]?.TrackResults[0]?.LatestStatusDetail?.ScanLocation?.StreetLines is null
                ? string.Empty
                : string.Join(", ", dataIn[0]?.TrackResults[0]?.LatestStatusDetail?.ScanLocation?.StreetLines);
            var scanData = string.Concat(scanData1, " | ", scanData2, " | ", scanData3);
            //delivery
            var delData1 = dataIn[0]?.TrackResults[0]?.DeliveryDetails.ActualDeliveryAddress.City;
            var delData2 = dataIn[0]?.TrackResults[0]?.DeliveryDetails?.ActualDeliveryAddress?.StreetLines is null
                ? string.Empty
                : string.Join(", ", dataIn[0]?.TrackResults[0]?.DeliveryDetails?.ActualDeliveryAddress?.StreetLines);
            var delData3 = dataIn[0]?.TrackResults[0]?.DeliveryDetails?.ActualDeliveryAddress?.PostalCode;
            var delData = string.Concat(delData1, "|", delData2, "|", delData3);
            //Insert into Big Query Row
            try
            {
                table.InsertRow(new BigQueryInsertRow
                {
                    { "tracking_num", dataIn[0]?.TrackingNumber },
                    { "destination_data", desData },
                    { "status", dataIn[0]?.TrackResults[0]?.LatestStatusDetail?.Description },
                    {
                        "latest_details",
                        dataIn[0]?.TrackResults[0]?.LatestStatusDetail?.AncillaryDetails[0].ReasonDescription
                    },
                    { "latest_scan", scanData },
                    { "delivery_attempt_info", dataIn[0]?.TrackResults[0]?.DeliveryDetails.DeliveryAttempts },
                    { "received_by", dataIn[0]?.TrackResults[0]?.DeliveryDetails?.ReceivedByName },
                    { "delivered_data", delData }
                });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            //stringBuild
            stuShip.Add($"'tracking_num' : '{dataIn[0]?.TrackingNumber}'");
            stuShip.Add($"'destination_data' : '{desData}'");
            stuShip.Add($"'status' : '{dataIn[0]?.TrackResults[0]?.LatestStatusDetail?.Description}'");
            stuShip.Add($"'latest_details' : '{dataIn[0]?.TrackResults[0]?.LatestStatusDetail?.AncillaryDetails[0].ReasonDescription}'");
            stuShip.Add($"'latest_scan' : '{scanData}'");
            stuShip.Add($"'delivery_attempt_info' : '{dataIn[0]?.TrackResults[0]?.DeliveryDetails.DeliveryAttempts}'"); 
            stuShip.Add($"'received_by' : '{dataIn[0]?.TrackResults[0]?.DeliveryDetails?.ReceivedByName}'");
            stuShip.Add($"'delivered_data' : '{delData}'");
            return Task.FromResult(stuShip);
        }
    }
}