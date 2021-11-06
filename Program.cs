// See https://aka.ms/new-console-template for more information
using MinecraftConnection;
using System.Text.RegularExpressions;

string address = "127.0.0.1";
ushort port = 25575;
string pass = "minecraft";
MinecraftCommands command = new MinecraftCommands(address, port, pass);

string playerId = "takunology";


while (true)
{
    command.DisplayTitle("Green Light...");
    command.Wait(3000);

    for(int i = 3; i > 0; i--)
    {
        command.DisplayTitle(i);
        command.Wait(1000);
    }

    string data_x = command.SendCommand($"data get entity {playerId} Pos[0]");
    string data_y = command.SendCommand($"data get entity {playerId} Pos[1]");
    string data_z = command.SendCommand($"data get entity {playerId} Pos[2]");

    var pos_x = (int)double.Parse(Regex.Replace(data_x, @"[^0-9.]", ""));
    var pos_y = (int)double.Parse(Regex.Replace(data_y, @"[^0-9.]", ""));
    var pos_z = (int)double.Parse(Regex.Replace(data_z, @"[^0-9.]", ""));

    command.DisplayTitle("Red Light!");

    for (int i = 0; i < 150; i++)
    {
        string data_x2 = command.SendCommand($"data get entity {playerId} Pos[0]");
        string data_y2 = command.SendCommand($"data get entity {playerId} Pos[1]");
        string data_z2 = command.SendCommand($"data get entity {playerId} Pos[2]");

        var pos_x2 = (int)double.Parse(Regex.Replace(data_x2, @"[^0-9.]", ""));
        var pos_y2 = (int)double.Parse(Regex.Replace(data_y2, @"[^0-9.]", ""));
        var pos_z2 = (int)double.Parse(Regex.Replace(data_z2, @"[^0-9.]", ""));

        if (pos_x != pos_x2 || pos_y != pos_y2 || pos_z != pos_z2)
        {
            command.SendCommand($"kill {playerId}");
        }

        Console.WriteLine($"X={pos_x2}\tY={pos_y2}\tZ={pos_z2}");
        command.Wait(20);
    }

}


