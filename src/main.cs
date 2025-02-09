using System.Net;
using System.Net.Sockets;

// Uncomment this line to pass the first stage
string input = "";
while (input != "exit"){

Console.Write("$ ");

// Wait for user input
input = Console.ReadLine();
Console.WriteLine($"{input}: command not found");
}