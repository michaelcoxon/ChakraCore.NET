using ChakraCore.NET.DebugAdapter.VSCode;
using ChakraCore.NET.Hosting;
using ChakraCore.NET.Plugin.Common;
using System;
using System.IO;
using System.Text;
using System.Threading;

namespace RunScript
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            CancellationTokenSource debugCTS = null;
            ScriptConfig config = null;
            JSApp app = null;
            if (args.Length == 0)
            {
                ShowUsage();
                return;
            }
            else
            {
                try
                {
                    config = ScriptConfig.Parse(args);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("invalid parameter");
                    Console.WriteLine(ex.Message);
                    ShowUsage();
                    Console.WriteLine("Press any key to exit");
                    Console.Read();
                    return;
                }
                var hostingConfig = new JavaScriptHostingConfig();

                hostingConfig
                    .AddPlugin<SysInfoPluginInstaller>()
                    .AddModuleFolder(config.RootFolder)
                    .AddPlugin(new EchoProvider(new Echo()))
                    .AddModuleFolderFromCurrentAssembly()
                    .EnableHosting((moduleName) => { return hostingConfig; })
                    ;
                if (config.DebugMode)
                {
                    debugCTS = new CancellationTokenSource();
                    var adapter = new VSCodeDebugAdapter(true);//wait for launch command from VSCode, user can reconnect with attach command after launch debug is done
                    //var adapter = new VSCodeDebugAdapter(false);//start program, wait for attach command from VSCode
                    adapter.OnLaunch += (sender, arguments) => { Console.WriteLine($"Launch requested,arguments={arguments}"); };
                    adapter.OnAttach += (sender, arguments) => { Console.WriteLine($"Attach requested,arguments={arguments}"); };
                    adapter.OnAdapterMessage += (sender, msg) => { Console.WriteLine(msg); };
                    adapter.OnStatusChang += (sender, e) => { Console.WriteLine(e); };
                    adapter.RunServer(3515, debugCTS.Token);
                    //adapter.RunClient(3515, debugCTS.Token);
                    hostingConfig.DebugAdapter = adapter;
                }

                if (config.IsModule)
                {
                    app = JavaScriptHosting.Default.GetModuleClass<JSApp>(config.FileName, config.ModuleClass, hostingConfig);
                    app.EntryPoint = config.ModuleEntryPoint;
                    app.Run();
                }
                else
                {
                    var script = File.ReadAllText(config.File);
                    Console.WriteLine("---Script Start---");
                    JavaScriptHosting.Default.RunScript(script, hostingConfig);
                }
            }
            if (config.IsModule)
            {
                while (true)
                {
                    Console.WriteLine("input \"exit\" to exit, anything else to run the module again");
                    var command = Console.ReadLine();
                    if (command.ToLower() == "exit")
                    {
                        break;
                    }
                    app.Run();
                }
            }
            else
            {
                Console.WriteLine("Press Enter to exit");
                Console.Read();
            }




            debugCTS?.Cancel();
        }

        private static void ShowUsage()
        {
            var sb = new StringBuilder();
            sb.AppendJoin(
                Environment.NewLine
                , "RunScript useage:"
                , "/file:FileName                    run a javascript file"
                , "/module                           run a javascript as module"
                , "/class:ClassName                  the entrypoint class name of module, default is \"app\""
                , "/entrypoint:FunctionName          the entrypoint function name of module, default is \"main\""
                );
            Console.WriteLine(sb);
        }

    }
}
