namespace BL
{
    public abstract class GameObject : IView
    {
        public int OreContainer { get; set; }
        public ObjectView View { get; }
        

        internal GameObject(int ore, ObjectView view)
        {
            OreContainer = ore;
            View = view;
        }
    }
}
