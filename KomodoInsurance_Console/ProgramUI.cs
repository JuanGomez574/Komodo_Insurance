using Developer_Repo;
using DevTeam_Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsurance_Console
{
    class ProgramUI
    {
        private Developer_Repository _developerRepo = new Developer_Repository();
        private DevTeam_Repository _devTeamRepo = new DevTeam_Repository();

        // Method that starts app
        public void Run()
        {
            SeedContentList();
            Menu();
        }
        //Menu
        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {

                Console.WriteLine("Select a menu option:\n" +
                    "1. Add new developer.\n" +
                    "2. View all developers.\n" +
                    "3. View developer by ID.\n" +
                    "4. Update a developer.\n" +
                    "5. Delete developer.\n" +                  
                    "6. Create new team (optional - with up to 3 new devs).\n" +
                    "7. View teams.\n" +                   
                    "8. View existing developers on a specific team.\n" +                   
                    "9. Add a developer to a team.\n" +
                    "10. Remove developer from a team.\n" +
                    "11. Update team (name/ID).\n" +                    
                    "12. Exit");
                // Get the user's input
                string input = Console.ReadLine();


                // Evaluate the user's input and act accordingly
                switch (input)
                {
                    case "1":

                        CreateNewDeveloper();
                        break;
                    case "2":
                        DisplayAllDevelopers();
                        break;
                    case "3":
                        DisplayDeveloperByID();
                        break;
                    case "4":
                        UpdateDeveloper();
                        break;
                    case "5":
                        DeleteDeveloper();
                        break;
                    case "6":

                        CreateNewTeam();
                        break;
                    case "7":
                        DisplayTeams();
                        break;                    
                    case "8":
                        ViewExistingDevelopersOnATeam();
                        break;                    
                    case "9":
                        AddDevToTeam();
                        break;
                    case "10":
                        
                        RemoveDeveloperFromTeam();
                        break;
                    
                    case "11":
                        UpdateTeam();
                        break;                   
                    case "12":
                        Console.WriteLine("Goodbye!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number.");
                        break;
                }

                Console.WriteLine("Please press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }
        // Create new Developer
        private void CreateNewDeveloper()
        {
            Console.Clear();
            Developer newDev = new Developer();

            Console.WriteLine("Enter developer's name.");
            newDev.Name = Console.ReadLine();

            Console.WriteLine("Enter developer's ID number.");
            newDev.IDNumber = int.Parse(Console.ReadLine());

            Console.WriteLine("Does developer have access to Pluralsight? (y/n)");
            string response = Console.ReadLine().ToLower();

            if (response == "y")
            {
                newDev.PluralsightAccess = true;
            }
            else
            {
                newDev.PluralsightAccess = false;
            }

            _developerRepo.AddDevToList(newDev);
        }
        // Display all developers
        private void DisplayAllDevelopers()
        {
            Console.Clear();
            List<Developer> listOfDevs = _developerRepo.GetDeveloperList();

            foreach (var item in listOfDevs)
            {
                Console.WriteLine($"ID: {item.IDNumber}, Name: {item.Name}, Pluralsight access: {item.PluralsightAccess}");


            }
        }
        // Display developer by ID
        private void DisplayDeveloperByID()
        {
            Console.Clear();
            // Prompt the user to give me the dev ID
            Console.WriteLine("Enter the ID of the developer you'd like to see:");
            // Get user's input
            int ID = int.Parse(Console.ReadLine());
            // Find the dev by that ID
            Developer dev = _developerRepo.GetDeveloperInfoByID(ID);
            // Display said dev if it isn't null
            if (dev != null)
            {
                Console.WriteLine($"Name: {dev.Name}\n" +
                    $"ID: {dev.IDNumber}\n" +
                    $"Pluralsight Access: {dev.PluralsightAccess}");
            }
            else
            {
                Console.WriteLine("No dev by that ID.");
            }


        }
        // Update developer
        private void UpdateDeveloper()
        {
            DisplayAllDevelopers();

            Console.WriteLine("Enter the ID of the dev you'd like to update.");

            int oldID = int.Parse(Console.ReadLine());
            // I built a new object
            Developer updatedDev = new Developer();

            Console.WriteLine("Enter the name of the developer:");
            updatedDev.Name = Console.ReadLine();

            Console.WriteLine("Enter the ID number of the developer: ");
            updatedDev.IDNumber = int.Parse(Console.ReadLine());

            Console.WriteLine("Does the developer have Pluralsight access? (y/n) ");
            string pluralsightAccess = Console.ReadLine().ToLower();

            if (pluralsightAccess == "y")
            {
                updatedDev.PluralsightAccess = true;
            }
            else
            {
                updatedDev.PluralsightAccess = false;
            }

            // Verify the update worked
            bool wasUpdated = _developerRepo.UpdateExistingContent(oldID, updatedDev);

            if (wasUpdated)
            {
                Console.WriteLine("Developer was successfully updated!");
            }
            else
            {
                Console.WriteLine("Could not update developer.");
            }
        }
        // Delete Developer (not working as intended)
        private void DeleteDeveloper()
        {
            DisplayAllDevelopers();

            Console.WriteLine("\nEnter the ID of the developer you want to delete.");
            int ID = int.Parse(Console.ReadLine());

            bool wasDeleted = _developerRepo.RemoveContentFromList(ID);

            if (wasDeleted)
            {
                Console.WriteLine("The dev was successfully deleted.");
            }
            else
            {
                Console.WriteLine("The dev was not deleted.");
            }
        }
        // Create new team with option of adding entirely new devs too
        private void CreateNewTeam()
        {
            Console.Clear();
            DevTeam newTeam = new DevTeam();

            Console.WriteLine("Enter team name:");
            newTeam.TeamName = Console.ReadLine();
            Console.WriteLine("Enter team ID:");
            newTeam.TeamID = int.Parse(Console.ReadLine());
            //_devTeamRepo.AddTeamToList(newTeam);

            List<Developer> newDevs = new List<Developer>();
            //DeveloperInfo newDev = new DeveloperInfo();
            Console.WriteLine("Do you want to create new devs (up to 3) for this team? (y/n)");
            string answer = Console.ReadLine().ToLower();

            if (answer == "y")
            {
                Developer newDev = new Developer();

                Console.WriteLine("Enter developer's name.");
                newDev.Name = Console.ReadLine();

                Console.WriteLine("Enter developer's ID number.");
                newDev.IDNumber = int.Parse(Console.ReadLine());

                Console.WriteLine("Does developer have access to Pluralsight? (y/n)");
                string response = Console.ReadLine().ToLower();

                if (response == "y")
                {
                    newDev.PluralsightAccess = true;
                }
                else
                {
                    newDev.PluralsightAccess = false;
                }

                _developerRepo.AddDevToList(newDev);
                newDevs.Add(newDev);

                Console.WriteLine("Do you want to create another developer for this team? (y/n)");
                string answer2 = Console.ReadLine().ToLower();

                if (answer2 == "y")
                {
                    Developer newDev2 = new Developer();

                    Console.WriteLine("Enter developer's name.");
                    newDev2.Name = Console.ReadLine();

                    Console.WriteLine("Enter developer's ID number.");
                    newDev2.IDNumber = int.Parse(Console.ReadLine());

                    Console.WriteLine("Does developer have access to Pluralsight? (y/n)");
                    string response2 = Console.ReadLine().ToLower();

                    if (response2 == "y")
                    {
                        newDev2.PluralsightAccess = true;
                    }
                    else
                    {
                        newDev2.PluralsightAccess = false;
                    }

                    _developerRepo.AddDevToList(newDev2);
                    newDevs.Add(newDev2);
                    Console.WriteLine("Do you want to create another developer for this team? (y/n)");
                    string answer3 = Console.ReadLine().ToLower();
                    if (answer3 == "y")
                    {
                        Developer newDev3 = new Developer();

                        Console.WriteLine("Enter developer's name.");
                        newDev3.Name = Console.ReadLine();

                        Console.WriteLine("Enter developer's ID number.");
                        newDev3.IDNumber = int.Parse(Console.ReadLine());

                        Console.WriteLine("Does developer have access to Pluralsight? (y/n)");
                        string response3 = Console.ReadLine().ToLower();

                        if (response3 == "y")
                        {
                            newDev3.PluralsightAccess = true;
                        }
                        else
                        {
                            newDev3.PluralsightAccess = false;
                        }

                        _developerRepo.AddDevToList(newDev3);
                        newDevs.Add(newDev3);


                    }
                    else
                    {
                        Console.WriteLine("Team with 2 new devs created.");
                    }
                }
                else
                {
                    Console.WriteLine("Team with 1 new dev created.");
                }
            }
            else
            {
                Console.WriteLine("Team created without any devs.");
            }
            newTeam.TeamMembers = newDevs;
            _devTeamRepo.AddTeamToList(newTeam);
        }
        // View existing teams
        private void DisplayTeams()
        {
            Console.Clear();

            List<DevTeam> listOfTeams = _devTeamRepo.GetDevTeamList();
            
            foreach (DevTeam team in listOfTeams)
            {
                Console.WriteLine($"\nTeam Name: {team.TeamName}\n" +
                    $"Team ID: {team.TeamID}\n" +
                    $"Team Members: ");
                foreach (var member in team.TeamMembers)
                {
                    Console.WriteLine($"ID: {member.IDNumber}, Name: {member.Name}, Pluralsight Access: {member.PluralsightAccess}");
                        
                }


            }
        }

        // View existing developers on a team
        private void ViewExistingDevelopersOnATeam()
        {
            Console.Clear();
            List<DevTeam> listOfTeams = _devTeamRepo.GetDevTeamList();

            foreach (DevTeam team in listOfTeams)
            {
                Console.WriteLine($"Team Name: {team.TeamName}");
            }
            Console.WriteLine("\nWrite the team whose developers you want to view.");
            string teamName = Console.ReadLine();

            List<Developer> listOfDevsOnATeam = _devTeamRepo.GetDevelopersByTeamName(teamName);

            foreach (var dev in listOfDevsOnATeam)
            {
                Console.WriteLine($"Name: {dev.Name}, ID: {dev.IDNumber}, Pluralsight access: {dev.PluralsightAccess}");
                   
            }
        }
                      
        // Add Developer to Team
        private void AddDevToTeam()
        {
            DisplayAllDevelopers();
            Console.ReadLine();         
            Console.WriteLine("Give the ID of a developer without a team.");
            int ID = int.Parse(Console.ReadLine());

            Developer dev = _developerRepo.GetDeveloperInfoByID(ID);


            Console.WriteLine("Which team do you wish this developer be added to?");
            string teamName = Console.ReadLine();
            
            _devTeamRepo.AddDevToTeam(dev, teamName);

         }       
        // Remove Developer From Team through their ID.
        private void RemoveDeveloperFromTeam()
        {

            DisplayTeams();
            Console.ReadLine();
            // Get the dev you want to remove from team
            Console.WriteLine("Give the ID of the developer you want to remove.");
            int ID = int.Parse(Console.ReadLine());
            Developer retrievedDev = _developerRepo.GetDeveloperInfoByID(ID);
            // Get the team where the dev resides
            Console.WriteLine("Give the team where the dev resides.");
            string team = Console.ReadLine();

            // Call the delete method
            bool wasDeleted = _devTeamRepo.RemoveDevFromTeam(retrievedDev, team);
            // If the dev was deleted, say so
            // Otherwise state it could not be deleted
            if (wasDeleted)
            {
                Console.WriteLine("The dev was successfully removed from team.");
            }
            else
            {
                Console.WriteLine("The dev could not be removed from team.");
            }
            

        }

        
        
        // Update team
        private void UpdateTeam()
        {
            DisplayTeams();

            Console.WriteLine("\nEnter the name of the team you'd like to update:");
            string oldTeamName = Console.ReadLine();
            // Build new object
            DevTeam newTeam = new DevTeam();
            // Build new list
            List<Developer> newDevs = new List<Developer>();


            Console.WriteLine("Enter the new name for the team:");
            newTeam.TeamName = Console.ReadLine();
            Console.WriteLine("Enter the new ID for the team.");
            newTeam.TeamID = int.Parse(Console.ReadLine());

            bool wasupdated = _devTeamRepo.UpdateExistingTeam(oldTeamName, newTeam);

            if (wasupdated)
            {
                Console.WriteLine("Team (name/ID) was successfully updated!");
            }
            else
            {
                Console.WriteLine("Could not update team (name/ID).");
            }




        }
        // Seed Method
        private void SeedContentList()
        {
            // create new list that will later by added to a team
            List<Developer> elevenFiftyDevs = new List<Developer>();
            // Create new developer
            Developer juan = new Developer("Juan", 32, true);
            // Add that dev to the list
            elevenFiftyDevs.Add(juan);
            Developer alexa = new Developer("Alexa", 21, false);
            elevenFiftyDevs.Add(alexa);
            Developer musa = new Developer("Musa", 42, true);
            elevenFiftyDevs.Add(musa);
            Developer brandon = new Developer("Brandon", 31, false);
            elevenFiftyDevs.Add(brandon);

            // Create new team that will hold devs created above
            DevTeam elevenFifty = new DevTeam();
            elevenFifty.TeamName = "ElevenFifty";
            elevenFifty.TeamMembers = elevenFiftyDevs;
            elevenFifty.TeamID = 111;

            
            List<Developer> redDevs = new List<Developer>();
            Developer john = new Developer("John Doe", 66, false);
            redDevs.Add(john);
            Developer keith = new Developer("Keith Mcgee", 77, false);
            redDevs.Add(keith);

            DevTeam red = new DevTeam(redDevs, "RED", 222);
            
            // Devs created without being added to a team
            Developer Mark = new Developer("Mark", 23, false);
            Developer Steve = new Developer("Steve", 62, false);

            _devTeamRepo.AddTeamToList(elevenFifty);
            _devTeamRepo.AddTeamToList(red);

            _developerRepo.AddDevToList(juan);
            _developerRepo.AddDevToList(alexa);
            _developerRepo.AddDevToList(musa);
            _developerRepo.AddDevToList(brandon);
            _developerRepo.AddDevToList(john);
            _developerRepo.AddDevToList(keith);

            // Devs with no team
            _developerRepo.AddDevToList(Mark);
            _developerRepo.AddDevToList(Steve);
        }


    }




 } 

