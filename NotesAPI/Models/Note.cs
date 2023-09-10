using System;
using System.Collections.Generic;

namespace NotesAPI.Models;

public partial class Note
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string Header { get; set; } = null!;

    public string Text { get; set; } = null!;

    public DateTime Date { get; set; }
}
