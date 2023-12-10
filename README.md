# BB_RPG_DiceSet

## Table of Contents

- [Introduction](#introduction)
- [Installation](#installation)
- [Usage](#usage)
- [Examples](#examples)
- [Contributing](#contributing)
- [License](#license)

## Introduction

BB_RPG_DiceSet is a simple C# library for simulating dice rolls. It includes a `DiceSet` class that allows users to define and roll sets of dice, providing both a total result and the result from the dice separated from the bonus for certain RPG Games that might need that. The dice rolls results are determined using a cryptographic random function and the dice distribution has been tested to be uniform within 0.25% in 100 Million Rolls, guaranteeing dice rolls to be sufficiently random but also fair.

## Installation

To use BB_RPG_DiceSet in your C# project, you can install it via NuGet Package Manager Console:

```bash
nuget install BB_RPG_DiceSet
```

## Usage

To get started, create an instance of the `DiceSet` class by providing a description of the dice set. The description follows the format `<number_of_dice>d<sides>+<bonus>`. After initializing, you can use the `Roll()` method to get the total result or `RollSeparate()` to get individual results.

```csharp
using BB_RPG_DiceSet;

// ...

// Example: Create a dice set with 2 six-sided dice and a bonus of 3
DiceSet diceSet = new DiceSet("2d6+3");

// Roll the dice set and get the total result
int totalResult = diceSet.Roll();
Console.WriteLine($"Total Result: {totalResult}");

// Roll the dice set and get dice result and bonus result
DiceResult separateResult = diceSet.RollSeparate();
Console.WriteLine($"Separated Results: Base = {separateResult.Base}, Bonus = {separateResult.Bonus}");
```

## Examples

Here's an example demonstrating how to use the library to simulate different dice rolls:

```csharp
// Simulate a standard six-sided die roll
Die standardDie = new Die(6);
int standardDieResult = standardDie.Roll();
Console.WriteLine($"Standard Die Result: {standardDieResult}");

// Simulate a custom dice set with 3 ten-sided dice and no bonus
DiceSet customDiceSet = new DiceSet("3d10");
int customDiceSetResult = customDiceSet.Roll();
Console.WriteLine($"Custom Dice Set Result: {customDiceSetResult}");
```

## Contributing

Feel free to contribute to the development of BB_RPG_DiceSet. If you encounter any issues or have suggestions for improvement, please [open an issue](https://github.com/AndreaTani/BB_RPG_DiceSet/issues) or submit a pull request.

## License

BB_RPG_DiceSet is licensed under the [MIT License](LICENSE).
