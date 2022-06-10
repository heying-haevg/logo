
string logo = String.Empty;
string logo90 = String.Empty;

switch (args[0]) 
{
    // case "hok":
    //     foreach (var line in File.ReadAllLines("assets/hok.txt"))
    //         System.Console.WriteLine(line);
    // break;
    // case "mth":
    //     foreach (var line in File.ReadAllLines("assets/mtu.txt"))
    //         System.Console.WriteLine(line);
    // break;
    default:        
        await showLogoAsync();
        break;
}

async Task showLogoAsync()
{
    Console.ForegroundColor = ConsoleColor.Blue;    
    InitLogos();

    for (int i=0; i< 50; i++)     {
        Console.WriteLine(GetLogo(i%4));
        await Task.Delay(200);
        System.Console.Clear();        
    }    
}

void InitLogos()
{
    foreach (var line in File.ReadAllLines("assets/logo_inv_50.txt"))
        logo += $"{line}{Environment.NewLine}";       
    foreach (var line in File.ReadAllLines("assets/logo_rot_inv_50.txt"))
        logo90 += $"{line}{Environment.NewLine}";  
    
}

string GetLogo(int direction)
{
    switch(direction) 
    {
        case 0:
            return logo;
        case 1:
            return logo90;
        case 2:                    
            return Invert(logo);
        case 3:
            return Invert(logo90);       
        default:
            return File.ReadAllText("assets/mtu.txt");
    }    
}

string Invert(string input)
{    
    var arr = input.ToCharArray();
    Array.Reverse(arr);
    return new string(arr);
}