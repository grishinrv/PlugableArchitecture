using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Autofac;
using Core.Contracts;

namespace Core.Application
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var appPath = Directory.GetCurrentDirectory();
            var pluginsPath = appPath + "\\plugins";
            Console.WriteLine(pluginsPath);
            var plugins = Directory.GetFiles(pluginsPath, "Plugin.*.dll", SearchOption.TopDirectoryOnly);
            var loadedAssemblies = new List<Assembly>(plugins.Length);
            plugins.Where(x => !x.EndsWith("Core.Contracts.dll"))
                    .ToList()
                    .ForEach(x => loadedAssemblies.Add(Assembly.LoadFrom(x)));

            var modules = new Dictionary<Assembly, ModuleBase>();

            foreach (var assembly in loadedAssemblies)
            {
                Console.WriteLine($"Сканируем сборку {assembly}");
                var moduleType = assembly.GetTypes().FirstOrDefault(x => x.BaseType == typeof(ModuleBase));
                if (moduleType != null)
                {
                    Console.WriteLine("Регистрируем описатель модуля...");
                    var module = (ModuleBase)Activator.CreateInstance(moduleType);
                    modules.Add(assembly, module);
                    Console.WriteLine("Регистрируем описатель модуля... Готово");
                }
            }

            Console.WriteLine("Стадия инициализации модулей...");
            var context = new Context();
            foreach (var module in modules)
            {
                Console.WriteLine($"Инициализация модуля {module.Key}...");
                module.Value.Init(context);
                Console.WriteLine($"Инициализация модуля {module.Key}... Готово");
            }
            Console.WriteLine("Стадия инициализации модулей... Готово");

            context.BuildContainer();
            Console.WriteLine("Стадия активации модулей...");
            foreach (var module in modules)
            {
                Console.WriteLine($"Активация модуля {module.Key}...");
                await module.Value.Activate(context);
                Console.WriteLine($"Активация модуля {module.Key}... Готово");
            }
            Console.WriteLine("Стадия активации модулей... Готово");
            Console.WriteLine("Приложение запущено.");
            await (Task.Run(async () =>
             {
                 while (true)
                 {
                     await Task.Delay(3000);
                 }
             }));
        }
    }
}
