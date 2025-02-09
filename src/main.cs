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
else{
    Console.WriteLine($"{input}: command not found");
}
}