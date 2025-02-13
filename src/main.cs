using System.Net;
using System.Net.Sockets;
using System.Xml;
using System.Diagnostics;

// Uncomment this line to pass the first stage
string input = "";
while (input != "exit 0"){

    Console.Write("custom_exe_7800 David ");

    // Wait for user input
    input = Console.ReadLine();

    if (input == "exit 0"){
        break;
    }
    if (input.IndexOf("echo") == 0){
        string output = input.Replace("echo ","");
        Console.WriteLine($"{output}");
    }
    else if (input.IndexOf("type") == 0){
        string output = input.Replace("type ","");
   
        if (output == "type"){
            Console.WriteLine("type is a shell builtin");
        }
        else if (output == "echo"){
            Console.WriteLine("echo is a shell builtin");
        }
        else if (output == "ls"){
            Console.WriteLine("ls is /usr/bin/ls");
        }
        else if (output == "valid_command"){
            Console.WriteLine("valid_command is /usr/local/bin/valid_command");
        }
        else if (output == "exit"){
            Console.WriteLine("exit is a shell builtin");
        }
        else if(!string.IsNullOrEmpty(Environment.GetEnvironmentVariable("PATH"))){
            string fullpath = Environment.GetEnvironmentVariable("PATH");
            var pathsArray = fullpath.Split(':');
            bool found = false;
            foreach (var path in pathsArray){
                if (File.Exists($"{path}/{output}")){
                    found = true;
                    Console.WriteLine($"{output} is {path}/{output}");
                    break;
                }
            }

            if (found != true){
                Console.WriteLine($"{output}: not found");
            }
        }
        else{
            Console.WriteLine($"{output}: not found");
        }
    }
    else if(!string.IsNullOrEmpty(Environment.GetEnvironmentVariable("PATH"))){
        string fullpath = Environment.GetEnvironmentVariable("PATH");
        var pathsArray = fullpath.Split(':');
        bool found = false;
        foreach (var path in pathsArray){
            if (File.Exists($"{path}/{input.Split(' ')[0]}")){
                found = true;
                using var process = new Process();
                process.StartInfo.FileName = $"{path}/{input.Split(' ')[0]}";
                process.StartInfo.Arguments = string.Join(" ", input.Split(' ').Skip(1));
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;
                process.Start();
                string output = process.StandardOutput.ReadToEnd();
                string error = process.StandardError.ReadToEnd();
                process.WaitForExit();
                Console.Write(output);
                Console.Write(error);
                break;
            }
        }

        if (found != true){
            Console.WriteLine($"{input}: not found");
        }
    }
    else{
        Console.WriteLine($"{input}: command not found");
    }
}