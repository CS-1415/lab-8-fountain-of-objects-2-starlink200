# Lab-8-Fountain-of-Objects-2

Lab 8 - Fountain of Objects 2
General Learning Objectives

Use a modern operating system and utilities.

Use an integrated development environment to develop a program.

Solve problems and develop programs using the control structures of sequence, selection, and repetition, following a disciplined approach.

Classes Classes Classes
Objectives
Practice working with overloaded constructors
More practice with unit testing
More practice with using composition in OO Design
Take what we've been discussing in class and bring it all together.
Basic Environment Setup
Accept the GitHub Classroom Assignment.Links to an external site.
Open a terminal.
Navigate to your code directory for the course (e.g.: cd my-cs1415-dir).
Run git clone {yourUrl} to make a local copy of your repository.
Run code {nameOfYourRepo} to open that directory in VS Code.
Open the integrated terminal in VS Code (Ctrl+`, or the Terminal menu -> New Terminal).
Creating the Library and Test Projects
Navigate to your repository folder in the VS Code terminal.
Create the following three projects:
dotnet new classlib -o Lab08
dotnet new nunit -o Lab08.Tests
dotnet new console -o Lab08.Main
Add references to the tests and main driver from the libary:
dotnet add Lab08.Tests reference Lab05
dotnet add Lab08.Main reference Lab05
Create a solution pointing to all three projects:
dotnet new sln
dotnet sln add Lab08 Lab08.Tests Lab08.Main
The sample test should run and pass:
dotnet test
Programming

Follow Test Driven Development (TDD) practices to implement the following functionality:

Read and implement The Fountain of Objects, Chapter 31 of The C# Player's Guide, page 242 (hopefully you've already done this)
Using classes/interfaces add the following functionality:
Remove any 'instant death' from the game. 
Rather than just a single monster, there should be an interface/class of Monster. There should be an assortment of monsters that implement/inherit from Monster (at least 3). Every room should have a chance of a monster in it (25%? 50%? 75%?) and that monster should randomly be chosen from the various monsters you've chosen to create.
Each monster and the main player should have AT LEAST an amount of health, an amount of defense, a way to attack, and an inventory of items. You may invent your own, or use the D&D approach.  D&D concept (These are concepts, please be creative!!) :
Each monster/player has hit points. Monsters are eliminated when they reach 0, if the player reaches 0 their game is over
Each monster/player has an armor class, which is how hard it is to hit them. A roll of a 20 sided dice (random number between 1 and 20) by the attacker must be equal to or higher than the targets armor class to successfully hit them. 
Each monster/player has a way to attack using the strongest weapon in their inventory. Weapons can be made into a class and given tons of characteristics, or everyone could just be wielding their fist, you decide. But the weapon will have a range of damage, say 1-4, that should be randomly determined. If they hit their target, this is the amount of damage they sustain.
When the player kills a monster, anything in its inventory is added to the players inventory. 
If the monster has a better weapon than the player has, the player will instantly wield the new improved weapon. 
If you wish to keep pits in the game, instead of 'killing' the player, it will just do damage
The Maelstroms will now be one of your 'monsters' it may choose to attack the player or it may choose to send them off to another room. There should be a random chance of either of those events happening. Being thrown to another room can be implemented anyway you want, not just the knight moves described in the original problem. You can give this 'teleport' ability to any of your monsters if you'd like. 
Eliminate the randomly shooting arrows into another room, cuz that is just lame.
Once a monster has been encountered, the room is 'clean' and will be empty when you back out of the room. 
Consider making the game more playable. Perhaps an inventory item can be potions that heal our player.  
There is freedom to implement this in many different ways.  Will combat be one round at a time, or will it just play out for someone to win? Can we add bonus attacks like spells or drink potions in battle. These are all decisions for you to make. 
EXTRA CREDIT:  If time permits and you want to make the game more interested consider drawing the entire grid in say red, and as rooms are visited and 'cleaned' they will become white, and the fountain room will turn blue after the fountain is activated. 

* As always submit your final code through github, and arrange for a review with me. 
