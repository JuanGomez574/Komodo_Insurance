using Developer_Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeam_Repo
{   // POCO
    public class DevTeam
    {
        public List<Developer> TeamMembers { get; set; }
        public string TeamName { get; set; }
        public int TeamID { get; set; }
        public DevTeam() { }
        public DevTeam(List<Developer> teamMembers, string teamName, int teamID)
        {
            TeamMembers = teamMembers;
            TeamName = teamName;
            TeamID = teamID;

        }
    }
}
