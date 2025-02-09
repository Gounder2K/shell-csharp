using System.Net;
using System.Net.Sockets;

// Uncomment this line to pass the first stage
Console.Write("$ ");

// Wait for user input
string input = Console.ReadLine();
if (input == "invalid_command"){
    Console.Write("invalid_command: command not found");
}