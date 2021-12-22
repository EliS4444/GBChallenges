using KomodoCafeMenu;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace KomodoCafeMenu_Tests
{
    [TestClass]
    public class MenuContentTests
    {
        [TestMethod]
        public void SetTitle_ShouldSetCorrectString()
        {
            MenuContent content = new MenuContent();

            content.MealName = "Cheeseburger";

            string expected = "Cheeseburger";
            string actual = content.MealName;

            Assert.AreEqual(expected, actual);
        }
    }
}
