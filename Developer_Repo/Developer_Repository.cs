using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developer_Repo
{
    public class Developer_Repository
    {
        public List<Developer> _listOfDevs = new List<Developer>();

        //Create
        public void AddDevToList(Developer content)
        {
            _listOfDevs.Add(content);
        }

        //Read
        public List<Developer> GetDeveloperList()
        {
            return _listOfDevs;
        }
        
        //Update
        public bool UpdateExistingContent(int originalID, Developer newContent)
        {
            // Find ID
            Developer oldContent = GetDeveloperInfoByID(originalID);

            // Update the content 
            if (oldContent != null)
            {
                oldContent.Name = newContent.Name;
                oldContent.IDNumber = newContent.IDNumber;
                oldContent.PluralsightAccess = newContent.PluralsightAccess;

                return true;
            }
            else
            {
                return false;
            }
        }
        //Delete
        public bool RemoveContentFromList(int ID)
        {
            Developer content = GetDeveloperInfoByID(ID);

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
        public Developer GetDeveloperInfoByID(int ID)
        {
            foreach (Developer content in _listOfDevs)
            {
                if (content.IDNumber == ID)
                {
                    return content;
                }
            }
            return null;
        }
        // Helper Method
        public Developer GetDeveloperInfoByName(string name)
        {
            foreach (Developer content in _listOfDevs)
            {
                if (content.Name.ToLower() == name.ToLower())
                {
                    return content;
                }
            }

            return null;
        }

    }
}
