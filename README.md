# SPRINT 5: 

WHAT WE ACCOMPLISHED:

--Our Sprint 4 Backlog is Complete!
* Collision: Collision is Working with All Game Objects and Handles the Collision Events
* GameStates: Scrolling, Inventory, Pause and Death States are In
* Level Loader: Completely functional. Complete first level is in as well.
* Inventory: Improved and fleshed out HUD that is also dynamic and reacts to Link's Inventory and States.
* Enemies: Improved Enemy Behavior
* GameObjectManager: Improved Game Object Management
* SpriteFactory: Fixed Abnormal Scaling Issues
* Sound: More Sound Effects and Music Are In. Music Now Pauses in the Pause State

--Sprint 5 Feature is Complete (Almost)
* Elemental Link, Link Sword, and Enemies
* Elemental Type Advantages (Critical Hits, Weak Hits)
* XP Boosts when Link Kills an Enemy or Picks up an Item
* Link Will Dawn an Specific Tunic based on the Element he chooses to wear.
* Tunics can be equipped from the Inventory as Link unlocks them
* When Link is at a HIGH Level, enemies will start to gun him down!
  
WHAT WE DID NOT ACCOMPLISH:
* Enemy AI Scaling for Level Medium isn't in. (Enemies dodging out 40% of the time)
  
Please see the Sprint 5 Reflection / Planning Document for more details.

----

CONTROLS:
* Use W, A, S, D to walk around.
* Press I to open the Inventory and from there, use the ARROW keys to select an item, then equip to an item slot by pressing A or B
* Attack Using Item A with N
* Attack Using Item B with M
* Pause the game with P.
* Reset the game with R
* Auto-Damage Link with Y (For Testing)


KNOWN BUGS AND ISSUES:
* Fun Fact: Collision Rectangles are slightly off because the images use a float for scaling, but the width and height gets the decimal value truncated. White space in the SpriteSheets don't help either.
* Certain Song files fade out and start again. Purely because thats how the file was ripped.
* Some animations don't actually animate / animate quickly.
* Link won't start wearing his new tunic until he starts walking again when he equips it
* Collision / Level Loader: There’s a gap between some walls and some doors.
* Enemies Exploit these Gaps and can get to other rooms that way (Design Feature?)
* State Change during scroll affects the draw and freezes the scroll.
* Death Music does not stop upon reset
* Door Collision is magnetic-like and can lead to Scroll Errors
* Damage is consistent with Link Health HUD
* Collision with Certain Blocks Are Weird and Can Soft Lock Link
* Key Equip Causes a Spam to the SFX.
* Skeleton is still collidable even after death
* GOM might not be deleting things lmao
* Backtracking is a little funky.
* Link does not take damage outside of first room.



Please visit the issues for additional bugs that may not have been addressed here. This, by no means, is an exhaustive list.
