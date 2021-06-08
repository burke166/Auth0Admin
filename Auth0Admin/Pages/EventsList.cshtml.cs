using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Auth0Admin.Data;

namespace Auth0Admin.Pages
{
    public class EventsListModel : PageModel
    {
        private readonly Db db;
        public List<EventInfo> Events;

        public EventsListModel(Db _db)
        {
            db = _db;
        }
        public void OnGet()
        {
            Events = db.Events?.ToList() ?? new List<EventInfo>();
        }
    }
}
