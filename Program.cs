
using System;

namespace MataMonstruo
{
    class Execute
    {
        public static void Main()
        {
            const int AllowedErrors = 3;
            const int ExitGameOption = 2;
            const int MinMenusOption = 1;
            const int MaxStartingMenuOpt = 2;
            const int MaxFightMenuOpt = 3;
            const int StartGameOption = 1;
            const int GlobalSpecialSkillCooldown = 5;
            const int DeathValue = 0;
            const int AtackOption = 1;
            const int DefendOption = 2;
            const int SkillOption = 3;
            const int PercentageTop = 100;
            //ArcherStatsLimit
            const int ArcherMinHP = 1500;
            const int ArcherMaxHP = 2000;
            const int ArcherMinDamage = 180;
            const int ArcherMaxDamage = 300;
            const int ArcherMinDefense = 25;
            const int ArcherMaxDefense = 40;
            const int ArcherStunDuration = 2;
            //BarbarianStatsLimit
            const int BarbarianMinHP = 3000;
            const int BarbarianMaxHP = 3750;
            const int BarbarianMinDamage = 150;
            const int BarbarianMaxDamage = 250;
            const int BarbarianMinDefense = 35;
            const int BarbarianMaxDefense = 45;
            const int BarbarianPerfectDefenseDuration = 3;
            //MageStatsLimit
            const int MageMinHP = 1000;
            const int MageMaxHP = 1500;
            const int MageMinDamage = 300;
            const int MageMaxDamage = 350;
            const int MageMinDefense = 20;
            const int MageMaxDefense = 35;
            //DruidStatsLimit
            const int DruidMinHP = 2000;
            const int DruidMaxHP = 2500;
            const int DruidMinDamage = 70;
            const int DruidMaxDamage = 120;
            const int DruidMinDefense = 25;
            const int DruidMaxDefense = 40;
            //MonsterStatsLimit
            const int MonsterMinHP = 9000;
            const int MonsterMaxHP = 12000;
            const int MonsterMinDamage = 250;
            const int MonsterMaxDamage = 400;
            const int MonsterMinDefense = 20;
            const int MonsterMaxDefense = 30;
            const string ErrorMenuOptionOutsideRange = "Opcion seleccionado en el menu esta fuera del rango permitido, elige una de las opciones que se muestran en pantalla";
            const string ErrorOvercameErrorLimit = "Se ha superado el limite de errores, debera de reintroducir los valores en este apartado";
            const string ErrorOvercameSecondErrorLimit = "Ha cometido 3 errores 3 veces, vuelve al principio";
            const string ErrorOutsideStatRange = "El valor esta fuera del rango solicitado";
            const string ErrorOvercameStartErrorLimit = "Se ha superado el limite de errores en el menu principal, el programa finalizara por ello";
            const string ErrorChoosenUnderCooldown = "La habilidad aun estaba bajo tiempo de espera, el heroe es incapaz de utilizarlo";
            const string StartingMenu = "1. Iniciar una nueva batalla \n2. Salir \nEscribe el numero de la opcion deseas utilizar: ";
            const string FightMenu = "1. Atacar \n2. Defenderse \n3. Habilidad especial, tiempo de espera {0} \nElige una de las acciones listadas: ";
            const string MenuSpliter = "--------------------------";
            /**
             * FightIcon obtenido de: https://www.asciiart.eu/weapons/swords
             */
            const string FightIcon = "   |\\                     /)\r\n /\\_\\\\__               (_//\r\n|   `>\\-`     _._       //`)\r\n \\ /` \\\\  _.-`:::`-._  //\r\n  `    \\|`    :::    `|/\r\n        |     :::     |\r\n        |.....:::.....|\r\n        |:::::::::::::|\r\n        |     :::     |\r\n        \\     :::     /\r\n         \\    :::    /\r\n          `-. ::: .-'\r\n           //`:::`\\\\\r\n          //   '   \\\\\r\n         |/         \\\\";
            const string ProvideHP = "Vida [{0} - {1}]: ";
            const string ProvideDamage = "Atac [{0} - {1}]: ";
            const string ProvideDefense = "Reduccion de daño (valor percentual) [{0} - {1}]: ";
            const string SkillReady = "Listo";
            const string ArcherStatAssign = "Proporciona los stats de la arquera";
            const string BarbarianStatAssign = "Proporciona los stats del barbaro";
            const string MageStatAssign = "Proporciona los stats del mago";
            const string DruidStatAssign = "Proporciona los stats del druida";
            const string MonsterStatAssign = "Proporciona los stats del monstruo";
            const string ArcherTurn = "Es el turno de la arquera";
            const string BarbarianTurn = "Es el turno del barbaro";
            const string MageTurn = "Es el turno del mago";
            const string DruidTurn = "Es el turno del druida";

            bool repeated;
            bool repeatedSecondLoop;
            bool choosenOnCooldown=false;
            int fightOption = 0;
            int menuOption = 0;
            int errorProvideNumStartMenuCounter;
            int errorProvideAllStatsCounter;
            int errorProvideStatsCounter;
            int errorProvideNumFightMenuCounter;
            //ArcherStats
            int archerHP;
            int archerTurnHP;
            int archerDamage;
            int archerDefense = 0;
            int archerTurnDefense;
            int archerSkillCooldown;
            //BarbarianStats
            int barbarianHP;
            int barbarianTurnHP;
            int barbarianDamage;
            int barbarianDefense = 0;
            int barbarianTurnDefense;
            int barbarianSkillCooldown = 0;
            int barbarianPerfectDefense = 0;
            //MageStats
            int mageHP;
            int mageTurnHP;
            int mageDamage;
            int mageDefense = 0;
            int mageTurnDefense;
            int mageSkillCooldown = 0;
            //DruidStats
            int druidHP;
            int druidTurnHP;
            int druidDamage;
            int druidDefense = 0;
            int druidTurnDefense;
            int druidSkillCooldown = 0;
            //MonsterStats
            int monsterHP;
            int monsterTurnHP;
            int monsterDamage;
            int monsterDefense = 0;
            int monsterStun = 0;
            do
            {
                repeated = false;
                errorProvideNumStartMenuCounter = 0;
                do
                {
                    if (repeated)
                    {
                        errorProvideNumStartMenuCounter++;
                        Console.WriteLine(ErrorMenuOptionOutsideRange);
                    }
                    repeated = true;
                    if (errorProvideNumStartMenuCounter < AllowedErrors)
                    {
                        Console.WriteLine(MenuSpliter);
                        Console.Write(StartingMenu);
                        menuOption = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine(MenuSpliter);
                    }
                } while ((menuOption < MinMenusOption || menuOption > MaxStartingMenuOpt) && errorProvideNumStartMenuCounter<AllowedErrors);

                if (menuOption == StartGameOption)
                {
                    archerHP = 0;
                    archerDamage = 0;
                    archerDefense = 0;
                    archerSkillCooldown = 0;
                    barbarianHP = 0;
                    barbarianDamage = 0;
                    barbarianDefense = 0;
                    barbarianSkillCooldown = 0;
                    mageHP = 0;
                    mageDamage = 0;
                    mageDefense = 0;
                    mageSkillCooldown = 0;
                    druidHP = 0;
                    druidDamage = 0;
                    druidDefense = 0;
                    druidSkillCooldown = 0;
                    monsterHP = 0;
                    monsterDamage = 0;
                    monsterDefense = 0;

                    //Asignacion stats arquera
                    repeated = false;
                    errorProvideAllStatsCounter = 0;
                    while (errorProvideAllStatsCounter < AllowedErrors && (archerDefense < ArcherMinDefense || archerDefense > ArcherMaxDefense))
                    {
                        archerHP = 0;
                        archerDamage = 0;
                        archerDefense = 0;
                        archerSkillCooldown = 0;
                        if (repeated)
                        {
                            errorProvideAllStatsCounter++;
                            Console.WriteLine(errorProvideAllStatsCounter < AllowedErrors ? ErrorOvercameErrorLimit : ErrorOvercameSecondErrorLimit);
                        }
                        if (errorProvideAllStatsCounter < AllowedErrors)
                        {
                            Console.WriteLine(MenuSpliter);
                            Console.WriteLine(ArcherStatAssign);
                        }
                        repeated = true;
                        repeatedSecondLoop = false;
                        errorProvideStatsCounter = 0;
                        while ((archerHP < ArcherMinHP || archerHP > ArcherMaxHP) && errorProvideStatsCounter < AllowedErrors && errorProvideAllStatsCounter < AllowedErrors)
                        {
                            
                            if (repeatedSecondLoop)
                            {
                                Console.WriteLine(ErrorOutsideStatRange);
                                errorProvideStatsCounter++;
                            }
                            repeatedSecondLoop = true;
                            if (errorProvideStatsCounter < AllowedErrors)
                            {
                                Console.Write(ProvideHP, ArcherMinHP, ArcherMaxHP);
                                archerHP = Convert.ToInt32(Console.ReadLine());
                            }
                        }
                        if (errorProvideStatsCounter < AllowedErrors)
                        {
                            errorProvideStatsCounter = 0;
                        }
                        repeatedSecondLoop = false;
                        while ((archerDamage < ArcherMinDamage || archerDamage > ArcherMaxDamage) && errorProvideStatsCounter < AllowedErrors && errorProvideAllStatsCounter < AllowedErrors)
                        {
                            if (repeatedSecondLoop)
                            {
                                Console.WriteLine(ErrorOutsideStatRange);
                                errorProvideStatsCounter++;
                            }
                            repeatedSecondLoop = true;
                            if (errorProvideStatsCounter < AllowedErrors)
                            {
                                Console.Write(ProvideDamage, ArcherMinDamage, ArcherMaxDamage);
                                archerDamage = Convert.ToInt32(Console.ReadLine());
                            }
                        }
                        if (errorProvideStatsCounter < AllowedErrors)
                        {
                            errorProvideStatsCounter = 0;
                        }
                        repeatedSecondLoop = false;
                        while ((archerDefense < ArcherMinDefense || archerDefense > ArcherMaxDefense) && errorProvideStatsCounter < AllowedErrors && errorProvideAllStatsCounter < AllowedErrors)
                        {
                            if (repeatedSecondLoop)
                            {
                                Console.WriteLine(ErrorOutsideStatRange);
                                errorProvideStatsCounter++;
                            }
                            repeatedSecondLoop = true;
                            if (errorProvideStatsCounter < AllowedErrors)
                            {
                                Console.Write(ProvideDefense, ArcherMinDefense, ArcherMaxDefense);
                                archerDefense = Convert.ToInt32(Console.ReadLine());
                            }
                        }
                        Console.WriteLine(MenuSpliter);
                    }

                    //Asignacion de stats barbaro
                    repeated = false;
                    if(errorProvideAllStatsCounter < AllowedErrors)
                    {
                        errorProvideAllStatsCounter = 0;
                    }
                    while (errorProvideAllStatsCounter < AllowedErrors && (barbarianDefense < BarbarianMinDefense || barbarianDefense > BarbarianMaxDefense))
                    {
                        barbarianHP = 0;
                        barbarianDamage = 0;
                        barbarianDefense = 0;
                        barbarianSkillCooldown = 0;
                        if (repeated)
                        {
                            errorProvideAllStatsCounter++;
                            Console.WriteLine(errorProvideAllStatsCounter < AllowedErrors ? ErrorOvercameErrorLimit : ErrorOvercameSecondErrorLimit);
                        }
                        if(errorProvideAllStatsCounter < AllowedErrors)
                        {
                            Console.WriteLine(MenuSpliter);
                            Console.WriteLine(BarbarianStatAssign);
                        }
                        
                        repeated = true;
                        repeatedSecondLoop = false;
                        errorProvideStatsCounter = 0;
                        while ((barbarianHP < BarbarianMinHP || barbarianHP > BarbarianMaxHP) && errorProvideStatsCounter < AllowedErrors && errorProvideAllStatsCounter < AllowedErrors)
                        {
                            
                            if (repeatedSecondLoop)
                            {
                                Console.WriteLine(ErrorOutsideStatRange);
                                errorProvideStatsCounter++;
                            }
                            repeatedSecondLoop = true;
                            if (errorProvideStatsCounter < AllowedErrors)
                            {
                                Console.Write(ProvideHP, BarbarianMinHP, BarbarianMaxHP);
                                barbarianHP = Convert.ToInt32(Console.ReadLine());
                            }
                        }
                        if (errorProvideStatsCounter < AllowedErrors)
                        {
                            errorProvideStatsCounter = 0;
                        }
                        repeatedSecondLoop = false;
                        while ((barbarianDamage < BarbarianMinDamage || barbarianDamage > BarbarianMaxDamage) && errorProvideStatsCounter < AllowedErrors && errorProvideAllStatsCounter < AllowedErrors)
                        {
                            if (repeatedSecondLoop)
                            {
                                Console.WriteLine(ErrorOutsideStatRange);
                                errorProvideStatsCounter++;
                            }
                            repeatedSecondLoop = true;
                            if (errorProvideStatsCounter < AllowedErrors)
                            {
                                Console.Write(ProvideDamage, BarbarianMinDamage, BarbarianMaxDamage);
                                barbarianDamage = Convert.ToInt32(Console.ReadLine());
                            }
                        }
                        if (errorProvideStatsCounter < AllowedErrors)
                        {
                            errorProvideStatsCounter = 0;
                        }
                        repeatedSecondLoop = false;
                        while ((barbarianDefense < BarbarianMinDefense || barbarianDefense > BarbarianMaxDefense) && errorProvideStatsCounter < AllowedErrors && errorProvideAllStatsCounter < AllowedErrors)
                        {
                            if (repeatedSecondLoop)
                            {
                                Console.WriteLine(ErrorOutsideStatRange);
                                errorProvideStatsCounter++;
                            }
                            repeatedSecondLoop = true;
                            if (errorProvideStatsCounter < AllowedErrors)
                            {
                                Console.Write(ProvideDefense, BarbarianMinDefense, BarbarianMaxDefense);
                                barbarianDefense = Convert.ToInt32(Console.ReadLine());
                            }
                        }
                        Console.WriteLine(MenuSpliter);
                    }

                    //Asignacion de stats mago
                    repeated = false;
                    if (errorProvideAllStatsCounter < AllowedErrors)
                    {
                        errorProvideAllStatsCounter = 0;
                    }
                    while (errorProvideAllStatsCounter < AllowedErrors && (mageDefense < MageMinDefense || mageDefense > MageMaxDefense))
                    {
                        mageHP = 0;
                        mageDamage = 0;
                        mageDefense = 0;
                        mageSkillCooldown = 0;
                        if (repeated)
                        {
                            errorProvideAllStatsCounter++;
                            Console.WriteLine(errorProvideAllStatsCounter < AllowedErrors ? ErrorOvercameErrorLimit : ErrorOvercameSecondErrorLimit);
                        }
                        if (errorProvideAllStatsCounter < AllowedErrors)
                        {
                            Console.WriteLine(MenuSpliter);
                            Console.WriteLine(MageStatAssign);
                        }

                        repeated = true;
                        repeatedSecondLoop = false;
                        errorProvideStatsCounter = 0;
                        while ((mageHP < MageMinHP || mageHP > MageMaxHP) && errorProvideStatsCounter < AllowedErrors && errorProvideAllStatsCounter < AllowedErrors)
                        {

                            if (repeatedSecondLoop)
                            {
                                Console.WriteLine(ErrorOutsideStatRange);
                                errorProvideStatsCounter++;
                            }
                            repeatedSecondLoop = true;
                            if (errorProvideStatsCounter < AllowedErrors)
                            {
                                Console.Write(ProvideHP, MageMinHP, MageMaxHP);
                                mageHP = Convert.ToInt32(Console.ReadLine());
                            }
                        }
                        if (errorProvideStatsCounter < AllowedErrors)
                        {
                            errorProvideStatsCounter = 0;
                        }
                        repeatedSecondLoop = false;
                        while ((mageDamage < MageMinDamage || mageDamage > MageMaxDamage) && errorProvideStatsCounter < AllowedErrors && errorProvideAllStatsCounter < AllowedErrors)
                        {
                            if (repeatedSecondLoop)
                            {
                                Console.WriteLine(ErrorOutsideStatRange);
                                errorProvideStatsCounter++;
                            }
                            repeatedSecondLoop = true;
                            if (errorProvideStatsCounter < AllowedErrors)
                            {
                                Console.Write(ProvideDamage, MageMinDamage, MageMaxDamage);
                                mageDamage = Convert.ToInt32(Console.ReadLine());
                            }
                        }
                        if (errorProvideStatsCounter < AllowedErrors)
                        {
                            errorProvideStatsCounter = 0;
                        }
                        repeatedSecondLoop = false;
                        while ((mageDefense < MageMinDefense || mageDefense > MageMaxDefense) && errorProvideStatsCounter < AllowedErrors && errorProvideAllStatsCounter < AllowedErrors)
                        {
                            if (repeatedSecondLoop)
                            {
                                Console.WriteLine(ErrorOutsideStatRange);
                                errorProvideStatsCounter++;
                            }
                            repeatedSecondLoop = true;
                            if (errorProvideStatsCounter < AllowedErrors)
                            {
                                Console.Write(ProvideDefense, MageMinDefense, MageMaxDefense);
                                mageDefense = Convert.ToInt32(Console.ReadLine());
                            }
                        }
                        Console.WriteLine(MenuSpliter);
                    }
                    
                    //Asignacion de stats druida
                    repeated = false;
                    if (errorProvideAllStatsCounter < AllowedErrors)
                    {
                        errorProvideAllStatsCounter = 0;
                    }
                    while (errorProvideAllStatsCounter < AllowedErrors && (druidDefense < DruidMinDefense || druidDefense > DruidMaxDefense))
                    {
                        druidHP = 0;
                        druidDamage = 0;
                        druidDefense = 0;
                        druidSkillCooldown = 0;
                        if (repeated)
                        {
                            errorProvideAllStatsCounter++;
                            Console.WriteLine(errorProvideAllStatsCounter < AllowedErrors ? ErrorOvercameErrorLimit : ErrorOvercameSecondErrorLimit);
                        }
                        if (errorProvideAllStatsCounter < AllowedErrors)
                        {
                            Console.WriteLine(MenuSpliter);
                            Console.WriteLine(DruidStatAssign);
                        }

                        repeated = true;
                        repeatedSecondLoop = false;
                        errorProvideStatsCounter = 0;
                        while ((druidHP < DruidMinHP || druidHP > DruidMaxHP) && errorProvideStatsCounter < AllowedErrors && errorProvideAllStatsCounter < AllowedErrors)
                        {

                            if (repeatedSecondLoop)
                            {
                                Console.WriteLine(ErrorOutsideStatRange);
                                errorProvideStatsCounter++;
                            }
                            repeatedSecondLoop = true;
                            if (errorProvideStatsCounter < AllowedErrors)
                            {
                                Console.Write(ProvideHP, DruidMinHP, DruidMaxHP);
                                druidHP = Convert.ToInt32(Console.ReadLine());
                            }
                        }
                        if (errorProvideStatsCounter < AllowedErrors)
                        {
                            errorProvideStatsCounter = 0;
                        }
                        repeatedSecondLoop = false;
                        while ((druidDamage < DruidMinDamage || druidDamage > DruidMaxDamage) && errorProvideStatsCounter < AllowedErrors && errorProvideAllStatsCounter < AllowedErrors)
                        {
                            if (repeatedSecondLoop)
                            {
                                Console.WriteLine(ErrorOutsideStatRange);
                                errorProvideStatsCounter++;
                            }
                            repeatedSecondLoop = true;
                            if (errorProvideStatsCounter < AllowedErrors)
                            {
                                Console.Write(ProvideDamage, DruidMinDamage, DruidMaxDamage);
                                druidDamage = Convert.ToInt32(Console.ReadLine());
                            }
                        }
                        if (errorProvideStatsCounter < AllowedErrors)
                        {
                            errorProvideStatsCounter = 0;
                        }
                        repeatedSecondLoop = false;
                        while ((druidDefense < DruidMinDefense || druidDefense > DruidMaxDefense) && errorProvideStatsCounter < AllowedErrors && errorProvideAllStatsCounter < AllowedErrors)
                        {
                            if (repeatedSecondLoop)
                            {
                                Console.WriteLine(ErrorOutsideStatRange);
                                errorProvideStatsCounter++;
                            }
                            repeatedSecondLoop = true;
                            if (errorProvideStatsCounter < AllowedErrors)
                            {
                                Console.Write(ProvideDefense, DruidMinDefense, DruidMaxDefense);
                                druidDefense = Convert.ToInt32(Console.ReadLine());
                            }
                        }
                        Console.WriteLine(MenuSpliter);
                    }

                    //Asignacion de stats monstruo
                    repeated = false;
                    if (errorProvideAllStatsCounter < AllowedErrors)
                    {
                        errorProvideAllStatsCounter = 0;
                    }
                    while (errorProvideAllStatsCounter < AllowedErrors && (monsterDefense < MonsterMinDefense || monsterDefense > MonsterMaxDefense))
                    {
                        monsterHP = 0;
                        monsterDamage = 0;
                        monsterDefense = 0;
                        if (repeated)
                        {
                            errorProvideAllStatsCounter++;
                            Console.WriteLine(errorProvideAllStatsCounter < AllowedErrors ? ErrorOvercameErrorLimit : ErrorOvercameSecondErrorLimit);
                        }
                        if (errorProvideAllStatsCounter < AllowedErrors)
                        {
                            Console.WriteLine(MenuSpliter);
                            Console.WriteLine(MonsterStatAssign);
                        }

                        repeated = true;
                        repeatedSecondLoop = false;
                        errorProvideStatsCounter = 0;
                        while ((monsterHP < MonsterMinHP || monsterHP > MonsterMaxHP) && errorProvideStatsCounter < AllowedErrors && errorProvideAllStatsCounter < AllowedErrors)
                        {

                            if (repeatedSecondLoop)
                            {
                                Console.WriteLine(ErrorOutsideStatRange);
                                errorProvideStatsCounter++;
                            }
                            repeatedSecondLoop = true;
                            if (errorProvideStatsCounter < AllowedErrors)
                            {
                                Console.Write(ProvideHP, MonsterMinHP, MonsterMaxHP);
                                monsterHP = Convert.ToInt32(Console.ReadLine());
                            }
                        }
                        if (errorProvideStatsCounter < AllowedErrors)
                        {
                            errorProvideStatsCounter = 0;
                        }
                        repeatedSecondLoop = false;
                        while ((monsterDamage < MonsterMinDamage || monsterDamage > MonsterMaxDamage) && errorProvideStatsCounter < AllowedErrors && errorProvideAllStatsCounter < AllowedErrors)
                        {
                            if (repeatedSecondLoop)
                            {
                                Console.WriteLine(ErrorOutsideStatRange);
                                errorProvideStatsCounter++;
                            }
                            repeatedSecondLoop = true;
                            if (errorProvideStatsCounter < AllowedErrors)
                            {
                                Console.Write(ProvideDamage, MonsterMinDamage, MonsterMaxDamage);
                                monsterDamage = Convert.ToInt32(Console.ReadLine());
                            }
                        }
                        if (errorProvideStatsCounter < AllowedErrors)
                        {
                            errorProvideStatsCounter = 0;
                        }
                        repeatedSecondLoop = false;
                        while ((monsterDefense < MonsterMinDefense || monsterDefense > MonsterMaxDefense) && errorProvideStatsCounter < AllowedErrors && errorProvideAllStatsCounter < AllowedErrors)
                        {
                            if (repeatedSecondLoop)
                            {
                                Console.WriteLine(ErrorOutsideStatRange);
                                errorProvideStatsCounter++;
                            }
                            repeatedSecondLoop = true;
                            if (errorProvideStatsCounter < AllowedErrors)
                            {
                                Console.Write(ProvideDefense, MonsterMinDefense, MonsterMaxDefense);
                                monsterDefense = Convert.ToInt32(Console.ReadLine());
                            }
                        }
                        Console.WriteLine(MenuSpliter);
                    }
                    if(errorProvideAllStatsCounter < AllowedErrors)
                    {
                        archerTurnHP = archerHP;
                        barbarianTurnHP = barbarianHP;
                        mageTurnHP = mageHP;
                        druidTurnHP = druidHP;
                        monsterTurnHP = monsterHP;
                        errorProvideNumFightMenuCounter = 0;

                        Console.WriteLine(FightIcon);
                        do
                        {
                            //ArcherTurn
                            repeated = false;
                            errorProvideNumFightMenuCounter = 0;
                            fightOption = MinMenusOption; 
                            while (fightOption < MinMenusOption && fightOption > MaxFightMenuOpt && archerTurnHP>DeathValue && monsterHP>DeathValue && !choosenOnCooldown)
                            {
                                if (repeated)
                                {
                                    Console.WriteLine(fightOption==SkillOption ? ErrorChoosenUnderCooldown : ErrorMenuOptionOutsideRange);
                                }
                                choosenOnCooldown = false;
                                archerTurnDefense = archerDefense;
                                
                                Console.WriteLine(MenuSpliter);
                                Console.Write(FightMenu, archerSkillCooldown==0 ? SkillReady : archerSkillCooldown);
                                fightOption = Convert.ToInt32(Console.ReadLine());
                                switch (fightOption)
                                {
                                    case AtackOption:
                                        monsterTurnHP -= (archerDamage * monsterDefense) / PercentageTop;
                                        break;
                                    case DefendOption:
                                        archerTurnDefense+= archerDefense;
                                        break;
                                    case SkillOption:
                                        if (archerSkillCooldown > 0)
                                        {
                                            choosenOnCooldown= true;
                                            errorProvideNumFightMenuCounter++;
                                        }
                                        else
                                        {
                                            monsterStun = ArcherStunDuration;
                                        }
                                        break;
                                    default:
                                        errorProvideNumFightMenuCounter++;
                                        break;
                                }
                                
                            }

                            //BarbarianTurn
                            repeated = false;
                            errorProvideNumFightMenuCounter = 0;
                            fightOption = MinMenusOption;
                            while (fightOption < MinMenusOption && fightOption > MaxFightMenuOpt && barbarianTurnHP > DeathValue && monsterHP > DeathValue && !choosenOnCooldown)
                            {
                                if (repeated)
                                {
                                    Console.WriteLine(fightOption == SkillOption ? ErrorChoosenUnderCooldown : ErrorMenuOptionOutsideRange);
                                }
                                choosenOnCooldown = false;
                                barbarianTurnDefense = barbarianDefense;

                                Console.WriteLine(MenuSpliter);
                                Console.Write(FightMenu, archerSkillCooldown == 0 ? SkillReady : archerSkillCooldown);
                                fightOption = Convert.ToInt32(Console.ReadLine());
                                switch (fightOption)
                                {
                                    case AtackOption:
                                        monsterTurnHP -= (archerDamage * monsterDefense) / PercentageTop;
                                        break;
                                    case DefendOption:
                                        barbarianTurnDefense += barbarianDefense;
                                        break;
                                    case SkillOption:
                                        if (barbarianSkillCooldown > 0)
                                        {
                                            choosenOnCooldown = true;
                                            errorProvideNumFightMenuCounter++;
                                        }
                                        else
                                        {
                                            barbarianPerfectDefense = BarbarianPerfectDefenseDuration;
                                        }
                                        break;
                                    default:
                                        errorProvideNumFightMenuCounter++;
                                        break;
                                }
                                if(barbarianPerfectDefense>0 && !choosenOnCooldown && fightOption<=MaxFightMenuOpt && fightOption<=MinMenusOption)
                                {
                                    barbarianTurnDefense = PercentageTop;
                                }
                            }
                        } while (monsterTurnHP>DeathValue && (archerTurnHP>DeathValue || barbarianTurnHP>DeathValue || mageTurnHP>DeathValue || druidTurnHP>DeathValue) && errorProvideNumFightMenuCounter<AllowedErrors);
                    }
                    
                }
            }while (menuOption!=ExitGameOption && errorProvideNumStartMenuCounter<AllowedErrors);
            if (errorProvideNumStartMenuCounter==AllowedErrors)
            {
                Console.WriteLine(ErrorOvercameStartErrorLimit);
            }
        }
    }
}