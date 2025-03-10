﻿namespace SAX.Domain.Entities.Marketing;

public class EmailTemplate : BaseEntity
{
    public string TemplateName { get; set; } = string.Empty;
    public string Subject { get; set; } = string.Empty;
    public string? Body { get; set; }
    public ICollection<EmailCampaign> EmailCampaigns { get; set; } = new List<EmailCampaign>();
}