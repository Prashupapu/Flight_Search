namespace Flight_Search.Server.Data
{
    public static class AirportData
    {
        public static Dictionary<string, List<string>> Destinations = new()
        {
            { "NYC", new List<string> { "LON", "PAR", "LAX", "BLR" } },
            { "LON", new List<string> { "NYC", "PAR", "BER" } },
            { "BLR", new List<string> { "DEL", "DXB", "SIN" } }
        };
    }

}
