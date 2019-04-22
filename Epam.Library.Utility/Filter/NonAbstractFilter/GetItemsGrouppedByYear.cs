namespace Utility.Filter.NonAbstractFilter
{
    public class GetItemsGrouppedByYear : AbstractFilter
    {
        public GetItemsGrouppedByYear(int year)
        {
            this.Year = year;
        }

        public int Year { get; private set; }
    }
}