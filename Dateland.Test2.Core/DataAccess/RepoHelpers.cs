using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Dateland.Test2.Core
{
    public static class RepoHelpers
    {
        public static string GetConnectionString(string name)
            => new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .Build()
            .GetSection("ConnectionStrings")
            .GetSection(name)
            .Value;

    }
}
