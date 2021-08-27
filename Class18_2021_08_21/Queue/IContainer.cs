namespace Queue
{
    interface IContainer
    {
        int Size {  get; }

        int Head {  get; }

        int Tale {  get; }

        int Length {  get; }

        object this[int index] {  get; set; }    
    }
}
