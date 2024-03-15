# Version history

## Version 1.1.1
- Bonuses can have negative values representing penalties
- Added two DiceTray methods
	- Add, for adding a single IRollable item to the tray
	- AddRange, for adding a list of IRollable items to the tray

## Version 1.1.0
- Added DiceSetTray feature that can:
	- contain multiple DiceSet with different kind of dice and bonuses
	- contain different additional dice
	- contain different bonuses
	- roll the tray together
	- roll dice and bonuses separately
	- roll every DiceSet, additional Dice, and bonuses separately

## Version 1.0.1
- Code documentation and minor revisions

## Version 1.0.0
### Initial release with core functionalities
- Create a custom die of any number of sides (positive integer >= 1) that can be rolled, powered by a cryptographic random number generator that ensures pretty good randomness but also a fair distribution of results (tolerance within 0.25 percent above or below the average in 100M instances)
- Create a set of uniform dice with the possibility of adding a bonus to the roll ("2d4+2" indicates a two 4 sided dice set with an added bonus of 2). The result can be returned as a single number or as a struct with the base result of the dice and the bonus as separated scores

