using MataMonstruoFunctions;

namespace GameProjectTests
{
    [TestClass]
    public class MataMonstruoTests
    {
        [TestMethod]
        public void BuildMenuWithText()
        {
            string[] options = {"a", "b", ""};
            string askMsg = "d";
            string expected = "1. a\n2. b\n3. \nd";
            string returned;

            returned = Utilities.BuildMenu(options, askMsg);

            Assert.AreEqual(expected, returned);
        }
        [TestMethod]
        public void BuildMenuWithEmptyText()
        {
            string[] options = new string[0];
            string askMsg = "";
            string expected = "";
            string returned;

            returned = Utilities.BuildMenu(options, askMsg);

            Assert.AreEqual(expected, returned);
        }
        [TestMethod]
        public void BuildMenuWithTextAndTitle()
        {
            string[] options = { "a", "b", "" };
            string msg = "e";
            string askMsg = "d";
            string expected = "e\n1. a\n2. b\n3. \nd";
            string returned;

            returned = Utilities.BuildMenu(options, askMsg, msg);

            Assert.AreEqual(expected, returned);
        }
        [TestMethod]
        public void BuildMenuWithEmptyTextAndTitle()
        {
            string[] options = {};
            string msg = "";
            string askMsg = "";
            string expected = "\n";
            string returned;

            returned = Utilities.BuildMenu(options, askMsg, msg);

            Assert.AreEqual(expected, returned);
        }
        [TestMethod]
        public void FormatStringNormalCase()
        {
            string text = "{0}{1}Texto";
            string[] args = {"a","b"};
            string expected = "abTexto";
            string returned;

            returned = Utilities.FormatString(text, args);
            Assert.AreEqual(expected, returned);
        }
        [TestMethod]
        public void FormatStringEmptyCase()
        {
            string text = "Texto";
            string[] args = {};
            string expected = "Texto";
            string returned;

            returned = Utilities.FormatString(text, args);
            Assert.AreEqual(expected, returned);
        }
        [TestMethod]
        public void FormatStringEmptyCaseWithTextArgs()
        {
            string text = "{0}{1}Texto";
            string[] args = { };
            string expected = "{0}{1}Texto";
            string returned;

            returned = Utilities.FormatString(text, args);
            Assert.AreEqual(expected, returned);
        }
        [TestMethod]
        public void FormatStringArgCaseWithTextWithNoArgs()
        {
            string text = "Texto";
            string[] args = {"a","b"};
            string expected = "Texto";
            string returned;

            returned = Utilities.FormatString(text, args);
            Assert.AreEqual(expected, returned);
        }
        [TestMethod]
        public void CalcAttackDamageZeroCase()
        {
            int damage = 0, defense = 0;
            int expected = 0, result;

            result = Utilities.CalcAttackDamage(damage, defense);

            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void CalcAttackDamagePerfectDefense()
        {
            int damage = 50, defense = 100;
            int expected = 0, result;

            result = Utilities.CalcAttackDamage(damage, defense);

            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void CalcAttackDamageNormalCase()
        {
            int damage = 4000, defense = 50;
            int expected = 2000, result;

            result = Utilities.CalcAttackDamage(damage, defense);

            Assert.AreEqual(expected, result);
        }
    }
}