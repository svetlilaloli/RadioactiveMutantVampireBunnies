Console Application<br>
Exercise: Multidimensional Arrays
# RadioactiveMutantVampireBunnies
Browsing through GitHub, you come across an old JS Basics teamwork game. It is about very nasty bunnies that multiply extremely fast. There’s also a player that has to escape from their lair. You really like the game, so you decide to port it to C# because that’s your language of choice. The last thing that is left is the algorithm that decides if the player will escape the lair or not.

First, you will receive a line holding integers __N__ and __M__, which represent the rows and columns in the lair. Then you receive __N__ strings that can __only__ consist of __".", "B", "P"__. The __bunnies__ are marked with "__B__", the __player__ is marked with "__P__", and everything else is __free space__, marked with a dot "__.__". They represent the initial state of the lair. There will be only one player. Then you will receive a string with __commands__ such as __LLRRUUDD__ – where each letter represents the next __move__ of the player (Left, Right, Up, Down).

__After__ each step of the player, each of the bunnies spread to the up, down, left and right (neighboring cells marked as "." __changes__ their value to __B__). If the player __moves__ to a bunny cell or a bunny __reaches__ the player, the player has __died__. If the player __goes out__ of the lair __without__ encountering a bunny, the player has __won__.

When the player __dies__ or __wins__, the game ends. All the activities for __this__ turn continue (e.g. all the bunnies spread normally), but there are no more turns. There will be no stalemates where the moves of the player end before he dies or escapes.
Finally, print the final state of the lair with every row on a separate line. On the last line, print either "__dead: {row} {col}__" or "__won: {row} {col}__". Row and col are the coordinates of the cell where the player has died or the last cell he has been in before escaping the lair.
## Input
- On the first line of input, the numbers __N__ and __M__ are received – the number of __rows__ and __columns__ in the lair
- On the next N lines, each row is received in the form of a string. The string will contain only “.”, “B”, “P”. All strings will be the same length. There will be only one “P” for all the input
- On the last line, the directions are received in the form of a string, containing “R”, “L”, “U”, “D”
## Output
- On the first N lines, print the final state of the bunny lair
- On the last line, print the outcome – “won:” or “dead:” + {row} {col}
## Constraints
- The dimensions of the lair are in range [3…20]
- The directions string length is in range [1…20]
## Examples
Input|Output
-----|------
5 8<br>.......B<br>...B....<br>....B..B<br>........<br>..P.....<br>ULLL|BBBBBBBB<br>BBBBBBBB<br>BBBBBBBB<br>.BBBBBBB<br>..BBBBBB<br>won: 3 0
4 5<br>.....<br>.....<br>.B...<br>...P.<br>LLLLLLLL|.B...<br>BBB..<br>BBBB.<br>BBB..<br>dead: 3 1

