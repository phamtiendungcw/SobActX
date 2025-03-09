﻿namespace SAX.Application.Features.Users.DTOs.Role;

public class UpdateRoleDto
{
    public Guid Id { get; set; }
    public string RoleName { get; set; } = string.Empty;
    public string? Description { get; set; }
}