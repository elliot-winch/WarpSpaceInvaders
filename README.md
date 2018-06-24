# WarpSpaceInvaders
## Unity Code Test for Squint Opera ##

My twist on Space Invaders: the game is played in a circle, with enemies spawning in the center and the player rotating aroudn the center.

Variables can be tweaked from the inspector. The "Player" object in the hierarchy contains variables pertaining to the player, the "Enemy" prefab (in the Prefabs folder) contains enemy-specific variables and the "Enemy Spawner" object variables about spawn rates. The number of lives can b changed on th Game Manager object.

There is a main menu, where saved scores are displayed, and a restart page.

I didn't have time to: 
- Track the number of plays. This information is easy to obtain (it is simply the number of scores in the text file) and just needs to be parsed and displayed.
- Make accomodations for variable screen sizes. Though it is fairly easy to modify the scene (change the bounds of the play area, change player radius), it would be nice to have a script to automatically calculate these positions at runtime.
