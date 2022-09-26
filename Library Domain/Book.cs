namespace Library_Domain
{
    public class Book
    {
        public Book()
        {
            Tasks = new List<Task>();
        }
        public int BookID { get; set; }
        public string BookTitle { get; set; }
        public string BookAuthot { get; set; }
        public int PriceBook { get; set; }
        public int NumberOfBooks { get; set; }
        public DateTime DateOfPuolication { get; set; }
        public List<Task> Tasks { get; set; }

    }
}