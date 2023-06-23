using FluentAssertions;
using AlphabeticalSorter;

namespace AlphabeticalSorterTest
{
    public class NamesSorterTest
    {
        [Fact]
        public void NamesSorter_ReturnSortedListOfNames()
        {
            //Arrange
            List<string> names = new List<string> { "Kalle", "Maria", "Sandra", "Pedro", "Alice", "Carla" };

            //Act
            NamesSorter namesList = new NamesSorter(names);
            List<string> sortedNames = namesList.GetSortedNames(names);

            //Assert
            sortedNames.Should().StartWith("Alice");
            sortedNames.Should().ContainInConsecutiveOrder("Alice", "Carla", "Kalle", "Maria", "Pedro", "Sandra");
        }

        [Fact]
        public void NamesSorter_ReturnListOfNames_OrderBy()
        {
            //Arrange
            List<string> names = new List<string> { "Kalle", "Maria", "Sandra", "Pedro", "Alice", "Carla" };

            //Act
            NamesSorter namesList = new NamesSorter(names);
            List<string> sortedNames = namesList.GetNamesOrderBy(names);

            //Assert
            sortedNames.Should().StartWith("Alice");
            sortedNames.Should().ContainInConsecutiveOrder("Alice", "Carla", "Kalle", "Maria", "Pedro", "Sandra");
        }

        [Fact]
        public void NamesSorter_QuickSortImplementation()
        {
            //Arrange
            List<string> names = new List<string> { "Kalle", "Maria", "Sandra", "Pedro", "Alice", "Carla" };

            //Act
            NamesSorter namesList = new NamesSorter(names);
            List<string> sortedNames = namesList.QuickSortImplementation(names);

            //Assert
            sortedNames.Should().StartWith("Alice");
            sortedNames.Should().ContainInConsecutiveOrder("Alice", "Carla", "Kalle", "Maria", "Pedro", "Sandra");
        }
    }
}