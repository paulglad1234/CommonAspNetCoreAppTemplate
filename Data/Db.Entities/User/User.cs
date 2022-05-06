﻿namespace Template.Db.Entities;

using Microsoft.AspNetCore.Identity;

public class User : IdentityUser<Guid>
{
    public string Username { get; set; }
}
