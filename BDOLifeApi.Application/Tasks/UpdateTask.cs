using BDOLife.Core.Enums;
using BDOLife.Core.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BDOLife.Application.Tasks
{
    public class UpdateTask
    {
        private readonly HttpClient _client;
        public UpdateTask(HttpClient client)
        {
            _client = client;
        }

        public void Run()
        {
        }
    }
}
