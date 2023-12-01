using System;
using System.Collections.Generic;

namespace Sis.Alcaldia.Server.Models;

public partial class Message
{
    public long Id { get; set; }

    public int FromId { get; set; }

    public int ToId { get; set; }

    public string Content { get; set; } = null!;

    public DateTime SentOn { get; set; }

    public virtual Usuario From { get; set; } = null!;

    public virtual Usuario To { get; set; } = null!;
}
