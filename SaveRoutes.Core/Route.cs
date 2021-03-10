namespace SaveRoutes.Core
{
    public class Route
    {
        public int Id { get; set; }
        public string Container { get; set; }
        public string UserRoute { get; set; }
        public string Shipping { get; set; }
        public string Date { get; set; }

        public override string ToString()
        {
            return Id.ToString() + ";" + Container + ";" + UserRoute + ";" + Shipping + ";" + Date;
        }
    }
}
