using SPC.Domain.Models.NOAA.ActiveAlerts;
using SPC.Infrastructure.NOAA.Models.ActiveAlerts;

namespace SPC.Infrastructure.NOAA.Mappers;

internal static class NOAAActiveAlertsMapper
{
    internal static NOAAActiveAlerts ToDomain(this NOAAActiveAlertsDto dto)
    {
        return new NOAAActiveAlerts
        {
            Type = dto.Type,
            Features = dto.Features?.Select(f => f.ToDomain()).ToArray(),
            Title = dto.Title,
            Updated = dto.Updated
        };
    }

    private static Feature ToDomain(this FeatureDto dto)
    {
        return new Feature
        {
            Id = dto.Id,
            Type = dto.Type,
            Properties = dto.Properties?.ToDomain()
        };
    }

    private static Properties ToDomain(this PropertiesDto dto)
    {
        return new Properties
        {
            Id = dto.Id,
            AreaDesc = dto.AreaDesc,
            AffectedZones = dto.AffectedZones,
            Sent = dto.Sent,
            Effective = dto.Effective,
            Onset = dto.Onset,
            Expires = dto.Expires,
            Ends = dto.Ends,
            Status = dto.Status,
            MessageType = dto.MessageType,
            Category = dto.Category,
            Severity = dto.Severity,
            Certainty = dto.Certainty,
            Urgency = dto.Urgency,
            Event = dto.Event,
            Sender = dto.Sender,
            SenderName = dto.SenderName,
            Headline = dto.Headline,
            Description = dto.Description,
            Instruction = dto.Instruction,
            Response = dto.Response,
        };
    }

}