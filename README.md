# PokemonDBSwagger

1. Change the value for DefaultConnection in appSettings.json to connect the project to SSMS
![Screenshot 2024-08-28 135928](https://github.com/user-attachments/assets/9e99917d-b6b8-46b8-bcfa-40dd8b4af289)

2. Open the Package Manage Console then type "add-migration <yourpreferredname>"
   
3. Before updating the database, change TypeAId and TypeBId from ReferentialAction.Cascade to ReferentialAction.NoAction
![Screenshot 2024-08-28 140221](https://github.com/user-attachments/assets/f269570a-05d2-4419-9e3a-9bc3849103ee)

4. Back to the Package Manager Console, type "update-database"
   
5. Run the project, then you have to reset first by executing under ResetRecords to repopulate the original 151 Pokemon
![Screenshot 2024-08-28 140515](https://github.com/user-attachments/assets/2309a3ba-053b-4c73-8c48-a7627f1f6453)

6. You can now explore my project! (Feel free to criticize my project. I'm open to new suggestions!)
