using System.Runtime.Serialization;

namespace Entities
{
    [KnownType(typeof(Book))]
    [KnownType(typeof(PaperIssue))]
    [KnownType(typeof(Patent))]
    public abstract class LibraryItem
    {
        
        public int Id { get; set; }

        public int YearOfPublishing { get; set; }
    }
}