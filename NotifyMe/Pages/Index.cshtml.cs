﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using NotifyMe.Services;

namespace NotifyMe.Pages
{
    public class IndexModel : PageModel
    {

        private readonly IHubContext<Notify> _hub;

        public IndexModel(IHubContext<Notify> hub)
        {
            _hub = hub;
        }

        public async void OnGetAsync(string status="")
        {
            if (!string.IsNullOrEmpty(status))
            {
                var userName = User.Identity.Name;
                if (!string.IsNullOrEmpty(userName))
                {
                    //Another way to say hello from codebehind of a Razor page
                    await _hub.Clients.All.SendAsync("SayHello", $"I'm {status}");
                }

            }


        }

       
    }
}
