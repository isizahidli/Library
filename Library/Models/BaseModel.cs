using Library.Attributes;

namespace Library.Models
{

    public abstract class BaseModel
    {
        public abstract object this[string name] { get; }

        [Export("№", 0)]
        public int No { get; set; }
        public int Id { get; set; }
    }
}
