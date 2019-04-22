namespace Entities
{
    public class Publisher
    {
        public int Id { get; set; }

        public string PublisherName { get; set; }

        public override bool Equals(object obj)
        {
            Publisher publisher = obj as Publisher;
            if (publisher == null)
            {
                return false;
            }

            return this.PublisherName == publisher.PublisherName;
        }

        public override int GetHashCode()
        {
            return this.PublisherName.GetHashCode();
        }
    }
}