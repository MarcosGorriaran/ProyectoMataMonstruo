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
        [TestMethod]
        public void AttackOptionZeroCase(){
            int damage = 0, defense = 0, HP = 1, expectedHP = 1;
            string text = "Texto{0}{1}{2}";
            string expectedText = "Texto001";
            string result;

            result = Utilities.AttackOption(damage, defense,ref HP, text);

            Assert.AreEqual(expectedText, result);
            Assert.AreEqual(expectedHP, HP);
        }
        [TestMethod]
        public void AttackOptionPerfectDefense(){
            int damage = 50, defense = 100, HP = 1, expectedHP = 1;
            string text = "Texto{0}{1}{2}";
            string expectedText = "Texto5001";
            string result;

            result = Utilities.AttackOption(damage, defense,ref HP, text);

            Assert.AreEqual(expectedText, result);
            Assert.AreEqual(expectedHP, HP);
        }
        [TestMethod]
        public void AttackOptionNormalCase(){
            int damage = 4000, defense = 50, HP = 1999, expectedHP = -1;
            string text = "Texto{0}{1}{2}";
            string expectedText = "Texto40002000-1";
            string result;

            result = Utilities.AttackOption(damage, defense,ref HP, text);

            Assert.AreEqual(expectedText, result);
            Assert.AreEqual(expectedHP, HP);
        }
        [TestMethod]
        public void DefenseAction(){
            int actualDef=0, newDef=4, expected=4;

            Utilities.DefenseAction(ref actualDef, newDef);

            Assert.AreEqual(expected, actualDef);
        }
        [TestMethod]
        public void HealTargetBellowMax()
        {
            int healTarget = 5, healingAmount = 4, maxHP = 10;
            int result, expected = 9;

            result = Utilities.HealTarget(healTarget, healingAmount, maxHP);

            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void HealTargetOnTopOfMax()
        {
            int healTarget = 5, healingAmount = 5, maxHP = 6;
            int result, expected = 6;

            result = Utilities.HealTarget(healTarget, healingAmount, maxHP);

            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void CritFailFailState()
        {
            int failChance = 100, critChance = 0;
            int result, expected = 0;

            result = Utilities.CritFail(failChance,critChance);

            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void CritFailCritState()
        {
            int failChance = 0, critChance = 100;
            int result, expected = 2;

            result = Utilities.CritFail(failChance, critChance);

            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void CritFailHitState()
        {
            int failChance = 0, critChance = 0;
            int result, expected = 1;

            result = Utilities.CritFail(failChance, critChance);

            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void InRangeAreBothIncluded()
        {
            int checkValue = 100, minValue = 100, maxValue = 100;
            bool result;

            result = Utilities.InRange(checkValue, minValue, maxValue);

            Assert.IsTrue(result);
        }
        [TestMethod]
        public void InRangeNormalCase()
        {
            int checkValue = 5, minValue = 0, maxValue = 100;
            bool result;

            result = Utilities.InRange(checkValue, minValue, maxValue);

            Assert.IsTrue(result);
        }
        [TestMethod]
        public void InRangeBellowTarget()
        {
            int checkValue = -1, minValue = 0, maxValue = 100;
            bool result;

            result = Utilities.InRange(checkValue, minValue, maxValue);

            Assert.IsFalse(result);
        }
        [TestMethod]
        public void InRangeOnTopTarget()
        {
            int checkValue = 101, minValue = 0, maxValue = 100;
            bool result;

            result = Utilities.InRange(checkValue, minValue, maxValue);

            Assert.IsFalse(result);
        }
        [TestMethod]
        public void IsActorAliveAliveCase()
        {
            int hp = 100;
            bool result;

            result = Utilities.IsActorAlive(hp);

            Assert.IsTrue(result);
        }
        [TestMethod]
        public void IsActorAliveDeadCase()
        {
            int hp = 0;
            bool result;

            result = Utilities.IsActorAlive(hp);

            Assert.IsFalse(result);
        }
        [TestMethod]
        public void IsActorAliveDeathOnNegativeCase()
        {
            int hp = -100;
            bool result;

            result = Utilities.IsActorAlive(hp);

            Assert.IsFalse(result);
        }
        [TestMethod]
        public void AreActorGroupDeadAllDeadCase()
        {
            int[] charactersHP = { -1, -100 };
            bool result;

            result = Utilities.AreActorGroupDead(charactersHP);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void AreActorGroupDeadOneDead()
        {
            int[] charactersHP = { 0, 1 };
            bool result;

            result = Utilities.AreActorGroupDead(charactersHP);
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void AreActorGroupDeadOneDeadBellowNegative()
        {
            int[] charactersHP = { -1, 1 };
            bool result;

            result = Utilities.AreActorGroupDead(charactersHP);
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void GenerateRandomValueRandomCase()
        {
            int minValue = 0, maxValue = 1;

            for(int i = 0; i < 100; i++)
            {
                int result = Utilities.GenerateRandomValue(minValue, maxValue); 
                if(result < minValue || result > maxValue)
                {
                    Assert.Fail("Uno de los casos se sale del rango especificado de 0 a 1");
                };
            }
        }
        [TestMethod]
        public void GenerateRandomValueRandomForceOneValue()
        {
            int minValue = 1, maxValue = 1;
            int result, expected=1;

            result = Utilities.GenerateRandomValue(minValue,maxValue);
            
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void TrimAllStringsNormalCase()
        {
            string[] trimValues = {" ", " Textos "};
            string[] expected = { "", "Textos" };
            string[] result;

            result = Utilities.TrimAllStrings(trimValues);

            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void ShowValuesDescNormalCase()
        {
            string[] textValues = {"Someone","Yes","no"};
            int[] values = {2,5,4};
            string msg = "Texto{0}{1}";
            string expected = "TextoYes5\nTextono4\nTextoSomeone2";
            string result;

            result = Utilities.ShowValuesDesc(values, textValues, msg);

            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void ReorderDescNormalCase()
        {
            string[] textValues = { "Someone", "Yes", "no" };
            int[] values = { 2, 5, 4 };
            int[] expectedVal = { 5, 4, 2 };
            string[] expectedText = { "Yes", "no", "Someone" };

            Utilities.ReorderDesc(ref values, ref textValues);

            Assert.Fail($"{textValues[0] + textValues[1] + textValues[2]}{expectedText[0] + expectedText[1] + expectedText[2]}");
            Assert.AreEqual(expectedText, textValues);
            Assert.AreEqual(expectedVal, values);
            
        }
    }
}