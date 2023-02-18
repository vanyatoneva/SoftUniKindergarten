using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniKindergarten
{
    public class Kindergarten
    {
        public Kindergarten(string name, int capacity)
        {
            Name = name.Trim();
            Capacity = capacity;
            Registry = new List<Child>();
        }
        public string Name { get; set; }
        public int Capacity { get; set; }

        private List<Child> Registry;

        public int ChildrenCount { get => Registry.Count; }

        public bool AddChild(Child child)
        {
            if (Registry.Count < Capacity)
            {
                Registry.Add(child);
                return true;
            }
            return false;
        }

        public bool RemoveChild(string childFullName)
        {
            if (Registry.Count > 0)
            {
                string[] names = childFullName.Split(" ", System.StringSplitOptions.RemoveEmptyEntries);
                Child childToRemove = Registry.FirstOrDefault(x => (x.FirstName == names[0] && x.LastName == names[1]));
                if (childToRemove != null)
                {
                    return Registry.Remove(childToRemove);
                }
            }
            return false;
        }

        public Child GetChild(string childFullName)
        {
            string[] names = childFullName.Split(" ", System.StringSplitOptions.RemoveEmptyEntries);
            //return Registry.FirstOrDefault(x => (x.FirstName == names[0] && x.LastName == names[1]));
            Child childToReturn = null;
            foreach(Child child in Registry)
            {
                if(child.FirstName == names[0] && child.LastName == names[1])
                {
                    childToReturn = child;
                    break;
                }
            }
            return childToReturn;
        }

        public string RegistryReport()
        {
            StringBuilder sb = new();
            if (Registry.Count > 0)
            {
                sb.AppendLine($"Registered children in {Name}:");
                foreach (Child child in Registry.OrderByDescending(x => x.Age).ThenBy(x => x.LastName).ThenBy(x => x.FirstName))
                {
                    sb.AppendLine(child.ToString());
                }
            }
            return sb.ToString().TrimEnd();
        }
    }
}
