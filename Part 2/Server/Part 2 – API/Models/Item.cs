namespace Part_2___API.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public Owner Owner { get; set; } = null!;
    }
}
