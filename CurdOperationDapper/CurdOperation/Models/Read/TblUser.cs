using System;
using System.Collections.Generic;

namespace CurdOperation.Models.Read;

public partial class TblUser
{
    public string UserName { get; set; } = null!;

    public string PassWord { get; set; } = null!;

    public decimal UserId { get; set; }
}
