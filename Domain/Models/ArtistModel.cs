namespace Domain.Models
{
    public class ArtistModel
    {
        public string ArtistName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public override bool Equals(object obj)
        {
            return obj is ArtistModel model &&
                   ArtistName.Equals(model.ArtistName, StringComparison.InvariantCultureIgnoreCase) &&
                   FirstName.Equals(model.FirstName, StringComparison.InvariantCultureIgnoreCase) &&
                   LastName.Equals(model.LastName, StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
