using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configuration
{
    public class AuthoriseConfiguration
    {
        public string Url { get; set; } = null!;
        public string Audience { get; set; } = null!;
    }

}
