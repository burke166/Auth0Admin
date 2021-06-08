using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Auth0Admin.Data;

namespace Auth0Admin.Pages
{
    [BindProperties(SupportsGet = true)]
    public class EventModel : PageModel
    {
        private readonly Db db;
        public EventInfo Event { get; set; }
        public int Id { get; set; }

        public EventModel(Db _db)
        {
            db = _db;
        }
        public IActionResult OnGet()
        {
            Event = db.Events.Find(Id);

            if (Event == null)
                return NotFound();
            else
                return Page();
        }
    }
}
