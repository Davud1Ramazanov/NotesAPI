using System;
using System.Collections.Generic;

namespace NotesAPI.Models;

public partial class User
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Password { get; set; } = null!;
}
