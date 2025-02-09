using System.Net;
using System.Net.Sockets;

// Uncomment this line to pass the first stage
string input = "";
while (input != "exit 0"){

Console.Write("$ ");

// Wait for user input
input = Console.ReadLine();
if (input == "exit 0"){
    break;
}
Console.WriteLine($"{input}: command not found");
}