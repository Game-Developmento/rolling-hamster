# Rolling Hamster Game

המשחק הוא משחק מחשב.
השחקן משחק בתור אוגר שנמצא בתוך כדור. השחקן מתחיל ממעלה ההר ומשם מתגלגל כאשר בדרך למטה הוא נתקל במכשולים שונים מהם הוא צריך להתחמק. בנוסף יש לו power-ups שהוא יכול לקחת שיעזרו לו להגיע עד למטה בקלות יותר. במהלך הדרך השחקן צריך לאסוף את הילדים שלו ולהגיע לסוף המסלול שנמצא למטה בתחתית ההר. השחקן מקבל ניקוד על פי כמות הילדים שהצליח לאסוף ולפי דברים אחרים שאסף בדרך שמזכות אותו בנקודות בונוס.

[קישור לדף הרכיבים](https://github.com/Game-Developmento/rolling-hamster/blob/main/formal-elements.md)

## Introduction

Rolling Hamster is a game where the player takes control of a hamster who is rolling in a ball. The goal of the game is to pass through obstacles while collecting all of the hamster's children.

## Requirements

The game was built using Unity version `2021.3.18f1`.

## Rules & How to Play

1. [Visit the game Rolling Hamster page in your web browser.](https://orihoward.itch.io/rolling-hamster-game)
2. Use the **spacebar** to jump and **right arrow** to accelerate and avoid obstacles.
3. Roll over the small red circles (hamster's children) to collect them.
4. If the player collides with an obstacle, the game restarts.
5. Enjoy the game!

## Main Scripts Used

### KeyboardHandler

This script is used on the PlayerSprite and adds force and impulse to the hamster's movement.

### PositionFollower

This script is used on the camera to follow the player, and on the background to follow the camera since the game keeps moving

### TerrainCreator

This generates the terrain that the player moves on.

### HandleCollision

This script handles collisions. It restarts the game if the player collides with an obstacle, and destroys the children when the player collides with them
