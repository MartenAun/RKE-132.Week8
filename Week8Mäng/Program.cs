////string[] heroes = { "Hulk", "Ironman", "Thor", "Wolverine", "Spiderman" }; 
////string[] villains = {"Dr.Octopus", "Loki", "Magneto", "Juggernaut" };



string folderPath = @"C:/data";
string heroFile = "heroes.txt";
string villainFile = "villains.txt";

string[] heroes = File.ReadAllLines(Path.Combine(folderPath, heroFile));
string[] villains = File.ReadAllLines(Path.Combine(folderPath, villainFile));
string[] weapon = {"Hammer", "Nails", "Teddybear", "Social Media" };


 
string hero = GetRandomValueFromArray(heroes);
string HeroWeapon = GetRandomValueFromArray(weapon);
int heroHP = GetCharacterHP(hero);
int heroStrikeStrenght = heroHP;
Console.WriteLine($"Your hero today is {hero} ({heroHP}HP) with {HeroWeapon}!");


string villain = GetRandomValueFromArray(villains);
string villainWeapon = GetRandomValueFromArray(weapon); 
int villainHP = GetCharacterHP(villain);  
int villainStrikeStrenght = villainHP;
Console.WriteLine($"Todays villain will be {villain} ({villainHP}HP) with {villainWeapon}!");

while(heroHP > 0 && villainHP > 0)
{
    heroHP = heroHP - Hit(villain, villainStrikeStrenght);
    villainHP = villainHP - Hit(hero, heroStrikeStrenght); 
}

Console.WriteLine($"Hero {hero} HP: {heroHP}");
Console.WriteLine($"Villain {villain} HP: {villainHP}");


if (heroHP > 0)
{
    Console.WriteLine($"{hero} saves the day!");
}
else if (villainHP > 0)
{
    Console.WriteLine($"Dark side wins!");
}
else
{
    Console.WriteLine($"Draw");
}
static string GetRandomValueFromArray(string[] someArray)
{
    Random rnd = new Random();
    int randomIndex = rnd.Next(0, someArray.Length);
    string randomStringFromArray = someArray[randomIndex];
    return randomStringFromArray;
}

static int GetCharacterHP(string characterName)
{
    if (characterName.Length < 10)
    {
        return 10;
    }
    else
    {
        return characterName.Length;
    }
}
static int Hit(string characterName, int  characterHP)
{
    Random rnd = new Random();
    int strike = rnd.Next(0, characterHP);

    if (strike == 0)
    {
        Console.WriteLine($"{characterName} missed the target.");
    }
    else if (strike == characterHP - 1)
    {
        Console.WriteLine($" {characterName} made a critical hit!");
    }
    else
    {
        Console.WriteLine($"{characterHP} hit {strike}!");
    }
    return strike;
}