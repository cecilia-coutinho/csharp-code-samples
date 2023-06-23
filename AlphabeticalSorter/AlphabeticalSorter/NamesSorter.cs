using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphabeticalSorter
{
    public class NamesSorter
    {

        public List<string> Names = new List<string> { "Kalle", "Maria", "Sandra", "Pedro", "Alice", "Carla" };

        public NamesSorter(List<string> names)
        {
            Names = names;
        }

        public List<string> GetSortedNames(List<string> names)
        {
            names.Sort(); //if two elements are equal, their order might not be preserved
            return names;
        }

        public List<string> GetNamesOrderBy(List<string> names)
        {
            List<string> result = names.OrderBy(name => name).ToList(); //if the keys of two elements are equal, the order of the elements is preserved. 
            return result;
        }

        public List<string> QuickSortImplementation(List<string> names)
        {
            // if the list has only one element or is empty
            if (names.Count <= 1)
            {
                return names;
            }

            string lastElement = names[names.Count - 1]; // Select the last element as the pivot

            // lists to hold elements lesser and greater than the pivot
            List<string> lesser = new List<string>();
            List<string> greater = new List<string>();

            int lastIndex = names.Count - 1;

            for (int i = 0; i < lastIndex; i++)
            {
                // Compare each element with the pivot(last element) and add it to the appropriate list
                if (string.Compare(names[i], lastElement, StringComparison.OrdinalIgnoreCase) <= 0)
                {
                    lesser.Add(names[i]);
                }
                else
                {
                    greater.Add(names[i]);
                }
            }

            // Recursively sort lists using same algorithm
            List<string> sorted = new List<string>();
            sorted.AddRange(QuickSortImplementation(lesser)); // Sort and add lesser elements
            sorted.Add(lastElement); // Add the pivot element
            sorted.AddRange(QuickSortImplementation(greater)); // Sort and add greater elements

            return sorted;
        }
    }
}
