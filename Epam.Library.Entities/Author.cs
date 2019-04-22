namespace Entities
{
    public class Author
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public override bool Equals(object obj)
        {
            Author author = obj as Author;
            if (author == null)
            {
                return false;
            }

            return
                this.LastName == author.LastName &&
                this.FirstName == author.FirstName;
        }

        public override int GetHashCode()
        {

            if(FirstName == null || LastName == null)
            {
                return Id.GetHashCode();
            }

            return this.FirstName.GetHashCode() ^ this.LastName.GetHashCode();
        }
    }
}