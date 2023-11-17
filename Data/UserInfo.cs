using System;
using System.Collections.Generic;

namespace mvc_web_app.Data;

public partial class UserInfo
{
    public int IdCard { get; set; }

    public string Name { get; set; } = null!;

    public int? Old { get; set; }

    public DateTime? DateBrithday { get; set; }

    public string? Address { get; set; }

    public DateTime? CreateTime { get; set; }

    public DateTime? UpdateTime { get; set; }

    public string? CreatedBy { get; set; }
}
