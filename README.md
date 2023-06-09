# Mandatory II for App Development with C#
## By Nicolas Javier Jan

### LEVELS:
There are three basic levels + a presentation page.

Level 1: **Practise.** No goalkeeper, no enemies. The player can move and push a ball to both the goalposts (did you try to score a goal against yourself?).

Level 2: **Goalkeeper.** A goalkeeper was added. It moves horizontally and upon touching the ball it will end the level.

Level 3: **Enemies**. Some enemies have been added. They move in a square (similar to table football). They do not end the level, but it makes it a little harder to push the ball and get to the goalpost easily.

### Features:
**Fun Mode VS Boring Mode:**
I created a "Fun Mode" where there are flashing lights in a rainbow gradient. It's nice, but I don't want to give seizures to anybody, so the option for the "Boring Mode" has been added as well.

**Background change:** The background of the first Screen and the levels changes colors. This is done by adding a Script to the panel. By default, Fun Mode is deactivated.

**Player Trail:** The player has a rainbow trail! The looks of the game have been heavily influenced by NyanCat.

**Story Mode:** A Story Mode has been successfully added. The Player has the button for the first level available at start. When the player makes a goal in Level 01, the game moves to Level 02, and on quit the button for level 2 is interactable. Same with level 02 to level 03.

**Streaker:** The Streaker has been successfully added. It is a crow that appear randomly in the first sixty seconds in every level.

**MultiPlayer:** The Multiplayer feature has been implemented. On S Key pressed, the moving player's script is deactivated and the next player activated. Only one player moves at a time, and it can be recognized because of the Rainbow Trail.

**Multi-Camera Angle:** The Game now has 4 cameras. Three cameras show the ball and follow the ball from different perspectives. The fourth camera follows the active player. They are changed with the key C. It is only available in Levels 2 and 3.

**Time-Limit and Record Tables:** The Game has a table in the Main Page (I had too much text to begin with so it kinda looks ugly) where the player can see their record in each of the levels. If they do a better time, it gets saved, otherwise it does not. If the player takes more time to finish the level the record also does not get saved (for example, if the player takes 35 seconds to finish the first level it won't be saved.). When there's 10% of the time left, the timer glows red and there's a foghorn sound.


