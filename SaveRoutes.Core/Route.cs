namespace SaveRoutes.Core
{
    public class Route
    {
        public int Id { get; private set; }
        public string Container { get; private set; }
        public string UserRoute { get; private set; }
        public string Shipping { get; private set; }
        public string Date { get; private set; }

        public Route(int id, string container, string userRoute, string shipping, string date)
        {
            Id = id;
            Container = container;
            UserRoute = userRoute;
            Shipping = shipping;
            Date = date;
        }

        public override string ToString()
        {
            return Id.ToString() + ";" + Container + ";" + UserRoute + ";" + Shipping + ";" + Date;
        }
    }
}
