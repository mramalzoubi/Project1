using Microsoft.AspNetCore.Components.Routing;
using Yogagym.Models;
using Microsoft.EntityFrameworkCore;

namespace Yogagym.Services
{
    public class PagesViewModel: IPagesViewModel
    {
        private readonly ModelContext _context;
        public PagesViewModel(ModelContext Context)
        {
            _context = Context;
        }

        public ViewModel GetPagesViewModel()
        {
            return new ViewModel
            {
                aboutu = _context.Aboutus.AsNoTracking().FirstOrDefault(),
                header = _context.Headers.AsNoTracking().FirstOrDefault(),
                contactu = _context.Contactus.AsNoTracking().FirstOrDefault(),
                footer = _context.Footers.AsNoTracking().FirstOrDefault()
            };
        }
    }
}
