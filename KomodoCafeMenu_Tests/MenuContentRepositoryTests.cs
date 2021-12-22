using KomodoCafeMenu;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace KomodoCafeMenu_Tests
{
    [TestClass]
    public class MenuContentRepositoryTests
    {
        public MenuContentRepository _repo;
        public MenuContent _content;

        [TestMethod]
        public void Arrange()
        {
            _repo = new MenuContentRepository();
            _content = new MenuContent(" #1", "Cheeseburger", "A delicious 1/2lb Wagyu beef patty, cooked to perfection.", "Ingredients include your choice of any of the following: Lettuce, Grilled Onion, Tomato, Pickles, and Cheese.", 9.99);

            _repo.AddContentToList(_content);
        }

        [TestMethod]
        public void AddToList_ShouldGetNull()
        {
            MenuContent content = new MenuContent();
            content.MealName = "Cheeseburger";
            MenuContentRepository repository = new MenuContentRepository();

            repository.AddContentToList(content);
            MenuContent contentFromDirectory = repository.GetMenuContentByMealName("Cheeseburger");

            Assert.IsNotNull(contentFromDirectory);
        }

        [TestMethod]
        public void UpdateExistingContent_ShouldReturnTrue()
        {
            MenuContent newContent = new MenuContent("2", "Hot Dog", "Delicious original Frank on a toasted bun", "Ingredients: A lot of random parts of an animal mashed together and pressed to form this sausage like thing", 5.99);

            bool updateResult = _repo.UpdateExistingContent("Cheeseburger", newContent);

            Assert.IsTrue(updateResult);
        }

        [DataTestMethod]
        [DataRow("Cheeseburger", true)]
        [DataRow("Hotdog", false)]
        public void UpdateExistingContent_ShouldMatchGivenBool(string originalTitle, bool shouldUpdate)
        {
            MenuContent newContent = new MenuContent("2", "Hot Dog", "Delicious original Frank on a toasted bun", "Ingredients: A lot of random parts of an animal mashed together and pressed to form this sausage like thing", 5.99);

            bool updateResult = _repo.UpdateExistingContent(originalTitle, newContent);

            Assert.AreEqual(shouldUpdate, updateResult);
        }

        [TestMethod]
        public void DeleteContent_ShouldReturnTrue()
        {
            bool deleteResult = _repo.RemoveContentFromList(_content.MealName);

            Assert.IsTrue(deleteResult);
        }
    }
}
