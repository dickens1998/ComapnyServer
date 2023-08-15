using System;

namespace CompanyServer.Api.Models;

public class UserInfo
{
    public Guid Id { get; set; }
    public string CompanyId { get; set; }
    public string Email { get; set; }
    public string Username { get; set; }
}