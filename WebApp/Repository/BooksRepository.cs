using WebApp.Data;

namespace WebApp.Repository
{
    public class BooksRepository
    {
        private readonly BooksContext _context;

        public BooksRepository(BooksContext context)
        {
            _context = context;
        }
    }
}
