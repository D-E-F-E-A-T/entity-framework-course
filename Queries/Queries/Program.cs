namespace Queries
{
    partial class Program
    {
        static void Main(string[] args)
        {
            using (var context = new PlutoContext())
            {
                CRUDExample.ChangeTrackerExample(context);
            }
        }
    }
}
