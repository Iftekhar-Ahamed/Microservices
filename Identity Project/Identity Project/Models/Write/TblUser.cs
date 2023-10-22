using System;
using System.Collections.Generic;

namespace Identity_Project.Models.Write;

public partial class TblUser
{
    public string UserName { get; set; } = null!;

    public string PassWord { get; set; } = null!;

    public decimal UserId { get; set; }
}
