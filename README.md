
# BB_RPG_DiceSet

## Table of Contents

- [Introduction](#introduction)
- [Installation](#installation)
- [Usage](#usage)
- [Examples](#examples)
- [Contributing](#contributing)
- [License](#license)

## Introduction

BB_RPG_DiceSet is a simple C# library for simulating dice rolls. It includes a `DiceSet` class that allows users to define and roll sets of dice, providing both a total result and the result from the dice separated from the bonus or penalty for certain RPG Games that might need that. The dice rolls results are determined using a cryptographic random function and the dice distribution has been tested to be uniform within 0.25% in 100 Million Rolls, guaranteeing dice rolls to be sufficiently random but also fair.

## Installation

To use BB_RPG_DiceSet in your C# project, you can install it via NuGet Package Manager Console:

```bash
nuget install BB_RPG_DiceSet
```

## Usage

To get started, create an instance of the  `Die`, `DiceSet`, or  `DiceTray` class by providing a description of the die, dice set or dice tray.
The description for the Dice set follows the classic notation format `<number_of_dice>d<sides>+<bonus>` or `<number_of_dice>d<sides>-<penalty>`. 
After initializing, you can use the `Roll()` method to get the total result or `RollSeparate()` to get individual results.
In case of a `DiceTray` you can also call the method `RollTray()` and get a result for each element of the tray.

## Examples

Here's an example demonstrating how to use the library to simulate different dice rolls:

### Single Die
```csharp
using BB_RPG_DiceSet;

// Simulate a standard six-sided die roll
Die standardDie = new Die(6);
int standardDieResult = standardDie.Roll();
Console.WriteLine($"Standard Die Result: {standardDieResult}");
```

### Dice Set
```csharp
using BB_RPG_DiceSet;

// Simulate a custom dice set containing 3 ten-sided dice and no bonus or penalty
DiceSet customDiceSet = new DiceSet("3d10");
int customDiceSetResult = customDiceSet.Roll();
Console.WriteLine($"Dice Set Result: {customDiceSetResult}");

// Simulate a custom dice set containing 2 six-sided dice with a bonus of 3
DiceSet diceSet = new DiceSet("2d6+3");
int totalResult = diceSet.Roll();
Console.WriteLine($"Dice Set Result: {totalResult}");

// Roll the dice set and get dice result and bonus/penalty result
DiceResult separateResult = diceSet.RollSeparate();
Console.WriteLine($"Separated Results: Base = {separateResult.Base}, Bonus = {separateResult.Bonus}");
```

### Dice Set Tray
```csharp
using BB_RPG_DiceSet;

// Simulate a dice tray, for example a special damage with multiple dice types and a bonus
// Create the dice tray
DiceSetTray tray = new DiceSetTray();
// add a new d6
tray.Add(new Die(6));
// add a new set of 3 ten-sided dice plus a penalty of 4
tray.Add(new DiceSet("3d10-4"));
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
