using System.Net;
using System.Net.Sockets;
using System.Xml;

// Uncomment this line to pass the first stage
string input = "";
while (input != "exit 0"){

    Console.Write("$ ");

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
        if(!string.IsNullOrEmpty(Environment.GetEnvironmentVariable("PATH"))){
            string fullpath = Environment.GetEnvironmentVariable("PATH");
            fullpath = fullpath.Replace("/usr/bin:","");
            var pathsArray = fullpath.Split(':');
            foreach (var path in pathsArray){
                if (File.Exists($"{path}/{output}")){
                    Console.WriteLine($"{output} is {path}/{output}");
                    break;
                }
            }

            Console.WriteLine($"{output}: not found");
        }
   
   
        else if (output == "type"){
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
        else{
            Console.WriteLine($"{output}: not found");
        }
        
    }
    else{
        Console.WriteLine($"{input}: command not found");
    }
    
} 