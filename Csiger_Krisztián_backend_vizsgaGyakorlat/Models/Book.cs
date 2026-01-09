using System;
using System.Collections.Generic;

namespace Csiger_Krisztián_backend_vizsgaGyakorlat.Models;

public partial class Book
{
    public int BookId { get; set; }

    public string? Title { get; set; }

    public DateTime? PublishDate { get; set; }

    public int? AuthorId { get; set; }

    public int? CategoryId { get; set; }

    public virtual Author? Author { get; set; }

    public virtual Category? Category { get; set; }
}
