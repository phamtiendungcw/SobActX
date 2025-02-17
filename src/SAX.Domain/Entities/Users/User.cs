﻿using SAX.Domain.Entities.Content;
using SAX.Domain.Entities.Logging;

namespace SAX.Domain.Entities.Users;

public class User : BaseEntity
{
    public string Username { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty; // Store hashed password
    public string Email { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public DateTime RegistrationDate { get; set; }
    public DateTime? LastLoginDate { get; set; } // Nullable if user never logged in
    public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>(); // Navigation property
    public ICollection<LogEntry> LogEntries { get; set; } = new List<LogEntry>(); // Navigation property for logs
    public ICollection<Page> Pages { get; set; } = new List<Page>(); // Navigation property for authored pages
    public ICollection<BlogPost> BlogPosts { get; set; } = new List<BlogPost>(); // Navigation property for authored blog posts
}