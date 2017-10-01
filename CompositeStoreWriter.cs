namespace InterfaceSegregation
{
    public class CompositeStoreWriter : IStoreWriter
    {
        public readonly IStoreWriter[] writers;

        public CompositeStoreWriter(params IStoreWriter[] writers)
        {
            this.writers = writers;
        }
        public void Save(int id, string message)
        {
            foreach (var w in this.writers)
            {
                w.Save(id, message);
            }
        }
    }
}