using System;
using System.IO;
using System.Reflection;
using Autofac;

namespace Core.Application
{
    class Program
    {
        static void Main(string[] args)
        {
            var appPath = Directory.GetCurrentDirectory();
            var pluginsPath = Path.Combine(appPath + "plugins");
            var plugins = Directory.GetFiles(pluginsPath, "", SearchOption.TopDirectoryOnly);
            Assembly.L
            Console.WriteLine("Hello World!");
            var builder = new ContainerBuilder();
        }
    }
}
