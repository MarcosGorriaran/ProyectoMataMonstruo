namespace MataMonstruoFunctions
{
    public class Utilities
    {
        public static string BuildMenu(string[] options, string askmsg)
        {
            const char LineJumper = '\n';
            string menu = "";
            for (int i = 0; i < options.Length; i++)
            {
                menu += $"{i + 1}. {options[i]}{LineJumper}";
            }
            menu += askmsg;
            return menu;
        }
        public static string BuildMenu(string[] options, string askmsg, string msg)
        {
            const char LineJumper = '\n';
            string menu = "";
            menu += msg + LineJumper;
            for (int i = 0; i < options.Length; i++)
            {
                menu += $"{i + 1}. {options[i]}{LineJumper}";
            }
            menu += askmsg;
            return menu;
        }
        public static string FormatString(string text, params string[] args)
        {
            string searchTarget;
            for (int i = 0; i < args.Length; i++)
            {
                searchTarget = "{" + i + "}";
                text = text.Replace(searchTarget, args[i]);
            }
            return text;
        }
        public static int CalcAttackDamage(int atackerDamageValue, int targetDefenseValue)
        {
            return atackerDamageValue - ((atackerDamageValue * targetDefenseValue) / 100);
        }
        public static string AttackOption(int attackerDMG, int targetDefense, ref int targetHP, string msg)
        {
            int damageAmount = CalcAttackDamage(attackerDMG, targetDefense);
            targetHP -= damageAmount;
            return FormatString(msg, $"{attackerDMG}", $"{damageAmount}", $"{targetHP}");
        }
        public static void DefenseAction(ref int actorDefense, int newDefenseValue)
        {
            actorDefense = newDefenseValue;
        }
        public static int HealTarget(int targetHP, int healingAmount, int targetMaxHP)
        {
            targetHP += healingAmount;
            if (targetHP > targetMaxHP)
            {
                targetHP = targetMaxHP;
            }
            return targetHP;
        }
        public static int CritFail(int chanceFail, int chanceCrit)
        {
            const int TopPercent = 100;
            const int FailOutcome = 0;
            const int HitOutcome = 1;
            const int CritOutcome = 2;
            int rngValue = GenerateRandomValue(0, TopPercent);

            if (rngValue <= chanceFail)
            {
                return FailOutcome;
            }
            else if (rngValue >= (TopPercent - chanceCrit))
            {
                return CritOutcome;
            }
            return HitOutcome;
        }
        public static bool InRange(int checkValue, int smallRangeValue, int bigRangeValue)
        {
            return checkValue >= smallRangeValue && checkValue <= bigRangeValue;
        }
        public static bool IsActorAlive(int actorHP)
        {
            return actorHP > 0;
        }
        public static bool AreActorGroupDead(int[] actorsHP)
        {
            for (int i = 0; i < actorsHP.Length; i++)
            {
                if (IsActorAlive(actorsHP[i]))
                {
                    return false;
                }
            }
            return true;
        }
        public static int GenerateRandomValue(int minValue, int maxValue)
        {
            Random rng = new Random();
            return rng.Next(minValue, maxValue + 1);
        }
        public static string[] TrimAllStrings(string[] texts)
        {
            for (int i = 0; i < texts.Length; i++)
            {
                texts[i] = texts[i].Trim();
            }
            return texts;
        }
        public static string ShowValuesDesc(int[] values, string[] arg, string mainMsg)
        {
            ReorderDesc(ref values, ref arg);
            const char LineJumper = '\n';
            string result = "";
            for (int i = 0; i < values.Length; i++)
            {
                result += FormatString(mainMsg + LineJumper, arg[i], $"{values[i]}");
            }
            return result;
        }
        public static void ReorderDesc(ref int[] values, ref string[] valuesMsg)
        {
            for (int i = 0; i < values.Length - 1; i++)
            {
                for (int j = i; j < values.Length; j++)
                {
                    if (values[j] > values[i])
                    {
                        int aux = values[j];
                        values[j] = values[i];
                        values[i] = aux;
                        string sAux = valuesMsg[j];
                        valuesMsg[j] = valuesMsg[i];
                        valuesMsg[i] = sAux;
                    }
                }
            }
        }
    }
}
