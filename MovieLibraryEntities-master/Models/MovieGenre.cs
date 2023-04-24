using System.Collections;

namespace MovieLibraryEntities.Models
{
    public class MovieGenre : IEnumerable
    {
        public int Id { get; set; }
        public virtual Movie Movie { get; set; }
        public virtual Genre Genre { get; set; }
        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
