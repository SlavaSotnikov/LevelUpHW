namespace MenuDLL
{
    public struct Data
    {
        public string Name { get; private set; }

        public string Country { get; private set; }

        public byte Model { get; private set; }

        public Data(string name, string country, byte model)
        {
            Name = name;
            Country = country;
            Model = model;
        }
    }
}
