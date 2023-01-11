# D&D Character Collection

### Introduction
This project is targeted towards people that, like me, play the world-spread roleplaying game Dungeons & Dragons. This project is built using ASP.NET MVC, which includes programming languages such as C# for the backend and HTML and CSS for the frontend. The database used is a SQL Server, connected with the webapplication using Entity Framework.

*This project is not yet in a state where all required data for a character is implemented and thus far works as more of a back-up to your physical character sheets.*

### The Application
- First of all, the webapplication requires you to register an account and be logged in, or you will not be able to access any othr part of the website than the inital home page.
![image](https://user-images.githubusercontent.com/114908266/211822561-cb40bd2b-ac49-43bf-875a-c787655d3c5c.png)

- To create a character, all fiels must recieve a value. For choise of race, class and alignment, a dropdown menu has been added to fill these choises. Limitations has been set to the classes and races found in the *Player's Handbook*. Custom classes and races are not available in this application.
 ![image](https://user-images.githubusercontent.com/114908266/211828176-f24038c6-2e31-4689-a81c-f1c067ebfa96.png)
  - Ability scores is default at 10, which is the human average. Adjust to fit your scores. Your modifiers gets calculated automatically and can be seen on your character sheet after the finalized character creation.
  - Buttons to create or abort creation can be found at the bottom of the page. Aborting the process can also be accomplished by navigating to any page in the application menu.

- Only characters of the signed in user will be available to view. You can not see characters belonging to other players.
![image](https://user-images.githubusercontent.com/114908266/211833735-fca453ab-94fe-41ad-86a6-406cb97e5d30.png)
  - Information on the character sheet, like the current hp, amount of coins and armor class can be changed at any point in the game.
    - Hp can be subtracted or added to the *current hp* value by entering the amount of hp to be changed and clicking on *recover* or *damage* depending on the situation. Recovery past your *maximum hp* is not posibble. If value exceeds your max, current hp will only fill up to your max value and any remaining points of recovery is lost.
    
      ![image](https://user-images.githubusercontent.com/114908266/211834836-662be13b-01c7-48fb-936d-4dd8a22abcea.png)
    
    - AC can be updated as needed when game circumstances causes it to rise och decrease. Fill in the new total value of your AC.
      ![image](https://user-images.githubusercontent.com/114908266/211835162-04205590-c107-4a11-973f-eab81c9bfad5.png)
      
    - The characters wealth increades and decreases as you adventure around, finding loot or buying items. Type in the amount of coins and click *income* och *expense* depending if your character gets more money or spends it.
      ![image](https://user-images.githubusercontent.com/114908266/211835497-90e005fb-e7c3-4a23-85d7-433748e42a7e.png)
    
    - Experience points gets delivered according to your DM as you progress in the adventure.
      ![image](https://user-images.githubusercontent.com/114908266/211835770-f3b4b1d0-57a2-4419-8755-0d29ba64afce.png)
      
      - As you gain EXP you level up your character. At level 4, 8, 12, 16 and 19 you get the chance to raise your ability scores (as image bellow) according to the rules in *Player's Handbook*. At any other level you can only change AC and Max HP.
        ![image](https://user-images.githubusercontent.com/114908266/211845156-c78f8ee2-38d6-477c-887a-ecbe41d8071b.png)
        
- For deleting a character, you press delete in the bottom corner of the character sheet. Before deleting the character from the database, confirm the deletion by pressing delete again.
  ![image](https://user-images.githubusercontent.com/114908266/211846411-4755304f-dc4f-4f4b-8523-c56f1e9f2ac8.png)

