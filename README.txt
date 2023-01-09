These scripts were part of the Multiplayer Unity Game "Serious Game Hochdorf". The Game itself was built in different scenes, which were changing between the game-steps. 
In this file it is shortly explained what each script is doing: 

- ActorButtons: All Actors can open an income-overview depending on their properties. The values of this overview are saved in the PlayerPrefs, 
and been updated always just before the Panel is shown to the Player. This script is needed as well for Adding Storeys or Buying Houses (etc.; 
Actions), to change then the property-values. 

- AppealApproval: The shop-Income is calculated based on an random simulator, which is more often positiv with an higher Appeal and more often 
negatively influenced if the Appeal is negative. After the calculation it is displayed on each Player-Display.

- ChangeScene: If we change scene, the players want to go on with a next step in the game. To continue always all players need to press the button, 
and only if everyone agrees on continuing, the scene will be changed. Otherwise the Server can press and all players are send to the new scene. 

- ClickMainMenu: In the Projects & Action Phase all informations can be displayed on panels. This script manages the closing of this panels 
if they are no longer used and open new panels if they are clicked to be open. 

- Events: This are eventcards which should be shown one per game. Using a Array the script is able to manage the randomize sorting of this 
cards and show them one by one to the players (always 3 per round) 

- Goals: All Players have an aim in this game. All players should only see their own vision and theirfore only their goal-panel is visible for them. 

- IncomeCalculator: In every round all players get income based on their properties. First all values were saved on the server side and 
then send to the client to calculate their incomes, which then is send back to the server to save globally. Every player will get a yearly 
income each round. 

- ownership: Checks for owner of the parcel to allow porjects or actions 

- PayPlayer_AdditionalOfStorey: Example of how Actions can be paid using slider-inputs of all four players. If the payment is accepted 
it will check if all players have enough money and let them pay their wished amount; for each Action seperatly 

- PayPlayer_Arealentwicklung: Same Procedere as for Actions but for Projects. If Project is accepted, players discuss about the share of 
the costs and then pay them; for each Project seperatly

- S00Update: Updating all values for Scene 0 (Start). Reset everthing - Everything shoul be zero. 

- S01_PlayerDependent: Displays all values (Asset & PlayerName) for active player; repeated in each scene

- S01Update: Update the appeal & approval scale; repeated in each scene 

- S03_PlayerDependent: Same as S01_PlayerDependent, but additionally change value if municipality raise taxes for active person 

- S04Update: Same as S01Update, but additionally check which projects were already implemented before. Do not show them anymore on 
the dashboard if already implemented. 

- servercontrol: prints on the server computer, which player managed to log in correctly 

- Taxes: Changes of the Tyes made from the municipality are managed in this script 

- Tiefgarage_Split: Example of an Project where additional parking lots needs to be splitted between the players. 

- Time_Countdown: During the Project & Action Phase the Player were stopped after 10 Minutes. Timer shows an Countdown and automatically 
change scene if time is over. 






