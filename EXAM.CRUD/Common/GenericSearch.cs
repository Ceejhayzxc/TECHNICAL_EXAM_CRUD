using Microsoft.AspNetCore.Mvc;

namespace EXAM.CRUD.Common
{
    public class GenericSearch<T>
    {
        public string? SearchKeyword { get; set; }
        public IEnumerable<T>? Results { get; set; }
    }
}
