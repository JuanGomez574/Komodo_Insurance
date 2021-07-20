using Developer_Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeam_Repo
{
    public class DevTeam_Repository
    {
        private List<DevTeam> _listOfDevs = new List<DevTeam>();

        //Create
        public void AddTeamToList(DevTeam content)
        {
            _listOfDevs.Add(content);
        }
        // Create
        public void AddDevToTeam(Developer name, string teamName)
        {
            DevTeam retrievedTeam = GetDevTeamByTeamName(teamName);
            retrievedTeam.TeamMembers.Add(name);
        }
        //Read
        public List<DevTeam> GetDevTeamList()
        {
            return _listOfDevs;
        }
        //Update
        public bool UpdateExistingTeam(string originalTeamName, DevTeam newcontent)
        {
            // Find the team 
            DevTeam oldContent = GetDevTeamByTeamName(originalTeamName);
            // Update the team
            if (oldContent != null)
            {
                oldContent.TeamName = newcontent.TeamName;
                oldContent.TeamID = newcontent.TeamID;
                //oldContent.TeamMembers = newcontent.TeamMembers;

                return true;
            }
            else
            {
                return false;
            }
        }
        //Update
        public bool UpdateExistingContent(string originalName, DevTeam newContent)
        {
            // Find Name
            DevTeam oldContent = GetDevTeamByTeamName(originalName);

            // Update the content 
            if (oldContent != null)
            {
                oldContent.TeamName = newContent.TeamName;
                oldContent.TeamID = newContent.TeamID;
                oldContent.TeamMembers = newContent.TeamMembers;

                return true;
            }
            else
            {
                return false;
            }
        }
        // Delete
        public bool RemoveDevFromTeam(Developer content, string teamName)
        {
            DevTeam retrievedTeam = GetDevTeamByTeamName(teamName);


            if (retrievedTeam == null)
            {
                return false;
            }
            int initialCount = retrievedTeam.TeamMembers.Count;
            retrievedTeam.TeamMembers.Remove(content);

            if (initialCount > retrievedTeam.TeamMembers.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }                     
        //Delete
        public bool RemoveTeamFromList(string name)
        {
            DevTeam content = GetDevTeamByTeamName(name);

            if (content == null)
            {
                return false;
            }

            int intitialCount = _listOfDevs.Count;
            _listOfDevs.Remove(content);

            if (intitialCount > _listOfDevs.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Helper Method
        public DevTeam GetDevTeamByTeamName(string name)
        {
            foreach (DevTeam content in _listOfDevs)
            {
                if (content.TeamName.ToLower() == name.ToLower())
                {
                    return content;
                }
            }
            return null;

        }
        //Helper Method
        public List<Developer> GetDevelopersByTeamName(string teamName)
        {
            foreach (DevTeam team in _listOfDevs)
            {
                if (team.TeamName == teamName)
                {
                    return team.TeamMembers;
                }
            }

            return null;
        }
        // Helper Method
        public List<Developer> GetAllDevsInAllTeams()
        {
            foreach (DevTeam team in _listOfDevs)
            {

                return team.TeamMembers;

            }

            return null;
        }


    }


}
