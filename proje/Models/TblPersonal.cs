using System;
using System.Collections.Generic;

namespace proje.Models;

public partial class TblPersonal
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string Mail { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string Title { get; set; } = null!;

    public string PersonalNumber { get; set; } = null!;
}
