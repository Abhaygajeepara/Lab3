namespace Lab3.Model
{
    public class IdGenerator
    {
        private static int nextId = 1;

        public static int GenerateId()
        {
            lock (typeof(IdGenerator))
            {
                int generatedId = nextId;
                nextId++;
                return generatedId;
            }
        }
    }
}
