namespace MenuLibrary
{
    public struct Data
    {
        public string Name { get; private set; }

        public string Country { get; private set; }

        public string Model { get; private set; }

        public Data(string name, string country, string model)
        {
            Name = name;
            Country = country;
            Model = model;
        }
    }
}
