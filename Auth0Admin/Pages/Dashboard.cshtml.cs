using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using Auth0Admin.Configuration;
using Auth0Admin.Data;
using Auth0.ManagementApi;

namespace Auth0Admin.Pages
{
    [Authorize(Roles="Admin")]
    [BindProperties(SupportsGet = true)]
    public class DashboardModel : PageModel
    {
        private readonly Db db;
        private readonly ManagementApiClient managementApi;
        private readonly Auth0Options auth0Options;

        public List<Auth0.ManagementApi.Models.User> Users { get; set; }
        public string Message { get; set; }
        public string Id { get; set; }

        public DashboardModel(Db _db, IOptions<Auth0Options> _auth0Options)
        {
            db = _db;
            auth0Options = _auth0Options.Value;

            var token = db.Tokens.OrderByDescending(t => t.Id).FirstOrDefault();

            if (token == null)
            {
                token = new AccessToken(auth0Options.Domain, auth0Options.ClientId, auth0Options.ClientSecret);
                db.Tokens.Add(token);
                db.SaveChanges();
            }
            else
            {
                TimeSpan ts = new TimeSpan(1, 0, 0);
                if (token.Expiration - ts < DateTime.Now)
                {
                    db.Tokens.Remove(token);
                    db.SaveChanges();

                    token = new AccessToken(auth0Options.Domain, auth0Options.ClientId, auth0Options.ClientSecret);
                    db.Tokens.Add(token);
                    db.SaveChanges();
                }
            }

            managementApi = new ManagementApiClient(token.Token, auth0Options.Domain);
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var users = await managementApi.Users.GetAllAsync(new Auth0.ManagementApi.Models.GetUsersRequest(), new Auth0.ManagementApi.Paging.PaginationInfo(0, 50, true));
            Users = users.ToList();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                await managementApi.Users.DeleteAsync(Id);
                Message = "User deleted!";
            }
            catch (Exception ex)
            {
                Message = "An error occurred: " + ex.Message;
            }

            var users = await managementApi.Users.GetAllAsync(new Auth0.ManagementApi.Models.GetUsersRequest(), new Auth0.ManagementApi.Paging.PaginationInfo(0, 50, true));
            Users = users.ToList();

            return Page();
        }
    }
}
