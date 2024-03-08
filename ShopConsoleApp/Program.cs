﻿using log4net.Config;
using System.Text;

[assembly: XmlConfigurator(ConfigFile = "log4net.config", Watch = true)]

namespace ShopConsoleApp
{
    internal class Program
    {
        static void Main()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            Solution.Run();

            var test = new Test();
        }
    }
}
