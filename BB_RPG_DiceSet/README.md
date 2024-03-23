# BB_RPG_DiceSet

## Table of Contents

- [Introduction](#introduction)
- [Installation](#installation)
- [Features](#features)
- [Version History](#versions)
- [Usage](#usage)
- [Examples](#examples)
- [Contributing](#contributing)
- [License](#license)

## Introduction

BB_RPG_DiceSet empowers you to integrate comprehensive dice rolling mechanics into your tabletop RPG (TTRPG) development projects. It offers a user-friendly and versatile API for rolling various dice types, applying modifiers, and combining rolls for dynamic gameplay experiences.

The dice rolls results are determined using a cryptographic random function and the dice distribution has been tested to be uniform within 0.25% in 100 Million Rolls, guaranteeing dice rolls to be sufficiently random but also fair in distribution.

## Features

- Standard Dice Types: Roll any of the commonly used dice types, including d4, d6, d8, d10, d12, d20, and d100.
- Custom Dice Types: Create dice with any number of sides using the Die class constructor. This allows you to define unique dice types like D32 or D7 for specialized game mechanics.
- Multiple Dice Roll using Dice Set: Specify the number of dice and their type with a concise notation like "3d10" to roll three ten-sided dice simultaneously.
- Modifiers: Apply bonuses or penalties directly within the notation. For example, "3d10+5" rolls three ten-sided dice and adds a +5 modifier to the final result.
- Dice Trays: Combine a variety of dice rolls (including dice sets and bonuses). This allows you to efficiently roll multiple dice types together and potentially track individual results.


## Installation

You can install BB_RPG_DiceSet dsirectly from Visual Studio following these steps:

1. Right-click on your project in the Solution Explorer.
2. Select "Manage NuGet Packages..."
3. In the search bar, type "BB_RPG_DiceSet".
4. Select the package and click "Install".


Or you can install it via NuGet Package Manager Console:

```bash
nuget install BB_RPG_DiceSet
```

## Versions
Here are listed the latest versions with the description of their most prominent features, see the [Changelog](CHANGELOG.md) for more details
- **Version 1.2.0:** Added a modifier example implementing IModifier interface
- **Version 1.1.2:** Added dice from the standard set (d4, d6, d8, d10, d12, d20, d100)
- **Version 1.1.1:** Bonuses can have negative values representing penalties

## Usage

To get started, create an instance of the  `Die`, `DiceSet`, or  `DiceSetTray` class by providing a description of the die, dice set or dice tray.
The description for the Dice set follows the classic notation format `<number_of_dice>d<sides>+<bonus>`. 
After initializing, you can use the `Roll()` method to get the total result or `RollSeparate()` to get individual results.
In case of a `DiceSetTray` you can also call the method `RollTray()` and get a result for each element of the tray.

## Examples

Here's an example demonstrating how to use the library to simulate different dice rolls:

### Single standard die
```csharp
using BB_RPG_DiceSet;

public class Example
{
  public static void Main(string[] args)
  {
    Die die = new D20(); // Create a classic d20 die object
    int result = die.Roll(); // Roll the die

    Console.WriteLine("Result: {0}", result);
  }
}
```

### Single custom die
```csharp
using BB_RPG_DiceSet;

public class Example
{
  public static void Main(string[] args)
  {
    Die die = new Die(32); // Create a custom d32 die object
    int result = die.Roll(); // Roll the die

    Console.WriteLine("Result: {0}", result);
  }
}
```

### Multiple dice roll with modifiers via DiceSet
```csharp
using BB_RPG_DiceSet;

public class Example
{
  public static void Main(string[] args)
  {
    int result = new DiceSet("3d10+5").Roll(); // Roll 3d10 with a +5 modifier

    Console.WriteLine("Result: {0}", result);
  }
}
```

### DiceSet Tray
```csharp
using BB_RPG_DiceSet;

// Simulate a dice tray, for example a special damage with multiple dice types and a bonus
// Create the dice tray
DiceSetTray tray = new DiceSetTray();
// add a new d6
tray.Add(new Die(6));
// add a new set of 3 ten-sided dice plus a penalty of 4
tray.Add(new DiceSet("3d10-4");
// add a separate bonus
tray.Add(new Bonus(15));

// roll the entire tray for a total number
int result = tray.Roll();
Console.WriteLine($"Dice Set Result: {result}");

// roll the dice tray for dice result and bonus result separeately
DiceResult setresult = tray.RollSeparate();
Console.WriteLine($"Separated Results: Base = {setresult.Base}, Bonus = {setresult.Bonus}");

// roll every element present in the tray separately and obtain
// a list of separate results (die and bonus) for each element
List<DiceResult> resultList = tray.RollTray();
foreach (DiceResult item in resultList)
{
	Console.WriteLine($"Tray item Results: Base = {item .Base}, Bonus = {item .Bonus}");
}
```

## Contributing

Feel free to contribute to the development of BB_RPG_DiceSet.
If you encounter any issues or have suggestions for improvement, please [open an issue](https://github.com/AndreaTani/BB_RPG_DiceSet/issues) or submit a pull request.

## License

BB_RPG_DiceSet is licensed under the [MIT License](LICENSE).
