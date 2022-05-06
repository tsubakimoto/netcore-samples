using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GrpcGreeter;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace GrpcGreeterWebClient.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly Greeter.GreeterClient _client;

        public IndexModel(ILogger<IndexModel> logger, Greeter.GreeterClient client)
        {
            _logger = logger;
            _client = client;
        }

        public string Message { get; private set; }

        public void OnGet()
        {
            var request = new HelloRequest { Name = "from GrpcGreeterWebClient" };
            var reply = _client.SayHello(request);
            Message = reply.Message;
        }
    }
}
