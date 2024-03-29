﻿/**
 * Author: Gorriaran Caamaño Marcos Facundo
 * Date: 21/01/2024 V2.0
 * Descripcion: Juego en el que el usuario al elegir jugar a traves de un menu tendra que
 * asignar los stats de los heroes que controlara y del monstruo que se enfrentara.
 * La lucha va por turnos y finaliza cuando todos los miembros de un lado caigan.
 * Sources:
 *  ASCII Drawings: https://www.asciiart.eu
 */
using System;
using MataMonstruoFunctions;

namespace GameProject
{
    class GorriaranMarcosCode
    {
        public static void Main()
        {
            const int AllowedErrors = 3;
            const int ExitGameOption = 2;
            const int MinMenusOption = 1;
            const int MaxStartingMenuOpt = 2;
            const int MaxFightMenuOpt = 3;
            const int MaxStatAssignMenuOpt = 4;
            const int StartGameOption = 1;
            const int EasyModeOption = 1;
            const int HardModeOption = 2;
            const int CustomModeOption = 3;
            const int RandomModeOption = 4;
            const int GlobalSpecialSkillCooldown = 5;
            const int AtackOption = 1;
            const int DefendOption = 2;
            const int SkillOption = 3;
            const int PercentageTop = 100;
            const int FailChance = 5;
            const int CritChance = 10;
            const int FailResponse = 0;
            const int AmountCharacters = 4;
            const int CritResponse = 2;
            //ArcherConstants
            const int ArcherMinHP = 1500;
            const int ArcherMaxHP = 2000;
            const int ArcherMinDamage = 200;
            const int ArcherMaxDamage = 300;
            const int ArcherMinDefense = 25;
            const int ArcherMaxDefense = 35;
            const int ArcherMinAgility = 40;
            const int ArcherMaxAgility = 50;
            const int ArcherStunDuration = 2;
            const int ArcherNameLocation = 0;
            //BarbarianConstants
            const int BarbarianMinHP = 3000;
            const int BarbarianMaxHP = 3750;
            const int BarbarianMinDamage = 150;
            const int BarbarianMaxDamage = 250;
            const int BarbarianMinDefense = 35;
            const int BarbarianMaxDefense = 45;
            const int BarbarianMinAgility = 15;
            const int BarbarianMaxAgility = 30;
            const int BarbarianPerfectDefenseDuration = 2;
            const int BarbariaNameLocation = 1;
            //MageConstants
            const int MageMinHP = 1100;
            const int MageMaxHP = 1500;
            const int MageMinDamage = 300;
            const int MageMaxDamage = 400;
            const int MageMinDefense = 20;
            const int MageMaxDefense = 35;
            const int MageMinAgility = 20;
            const int MageMaxAgility = 35;
            const int MageSuperAttackMult = 3;
            const int MageNameLocation = 2;
            //DruidStatsLimit
            const int DruidMinHP = 2000;
            const int DruidMaxHP = 2500;
            const int DruidMinDamage = 70;
            const int DruidMaxDamage = 120;
            const int DruidMinDefense = 25;
            const int DruidMaxDefense = 40;
            const int DruidMinAgility = 25;
            const int DruidMaxAgility = 40;
            const int DruidHealingAmount = 500;
            const int DruidNameLocation = 3;
            //MonsterStatsLimit
            const int MonsterMinHP = 7000;
            const int MonsterMaxHP = 10000;
            const int MonsterMinDamage = 300;
            const int MonsterMaxDamage = 400;
            const int MonsterMinDefense = 20;
            const int MonsterMaxDefense = 30;
            const char CharacterSpliter = ',';
            const string LineJumper = "\n";
            const string ErrorMenuOptionOutsideRange = "Opcion seleccionado en el menu esta fuera del rango permitido, elige una de las opciones que se muestran en pantalla";
            const string ErrorOvercameErrorLimit = "Se ha superado el limite de errores, se asignara el stat minimo en este apartado";
            const string ErrorOutsideStatRange = "El valor esta fuera del rango solicitado";
            const string ErrorOvercameStartErrorLimit = "Se ha superado el limite de errores en el menu principal, el programa finalizara por ello";
            const string ErrorOvercameFightErrorLimit = "Ha cometido demasiados errores, el turno de {0} se saltara";
            const string ErrorChoosenUnderCooldown = "La habilidad aun estaba bajo tiempo de espera, el heroe es incapaz de utilizarlo";
            const string ErrorTooManyNames = "Solo hay {0} personajes a nombrar y hay {1} nombres en la lista proporcionada, vuelve a introducir los nombres.";
            const string ErrorFewNames = "Hay {0} personajes a nombrar y hay {1} nombres en la lista proporcionada, vuelve a introducir los nombres.";
            const string GeneralAskInputMsg = "Escribe el numero de la opcion deseas utilizar: ";
            const string StartingMenu = "Iniciar una nueva batalla\nSalir";
            const string StatAssignMenu = "Facil\nDificil\nPersonalizado\nStats random";
            const string FightMenu = "Atacar \nDefenderse \nHabilidad especial, tiempo de espera {0}";
            const string AnounceTurn = "Turno {0}:";
            const string MenuSpliter = "--------------------------";
            const string FightIcon = "   |\\                     /)\r\n /\\_\\\\__               (_//\r\n|   `>\\-`     _._       //`)\r\n \\ /` \\\\  _.-`:::`-._  //\r\n  `    \\|`    :::    `|/\r\n        |     :::     |\r\n        |.....:::.....|\r\n        |:::::::::::::|\r\n        |     :::     |\r\n        \\     :::     /\r\n         \\    :::    /\r\n          `-. ::: .-'\r\n           //`:::`\\\\\r\n          //   '   \\\\\r\n         |/         \\\\";
            const string ArcherIcon = "          4$$-.                          \r\n           4   \".                                        \r\n           4    ^.                                       \r\n           4     $                                       \r\n           4     'b                                      \r\n           4      \"b.                                    \r\n           4        $                                    \r\n           4        $r                                   \r\n           4        $F                                   \r\n-$b========4========$b====*P=-                           \r\n           4       *$$F                                  \r\n           4        $$\"                                  \r\n           4       .$F                                   \r\n           4       dP                                    \r\n           4      F                                      \r\n           4     @                                       \r\n           4    .                                        \r\n           J.                                            \r\n          '$$ ";
            const string BarbarianIcon = "                                           _.gd8888888bp._\r\n                                        .g88888888888888888p.\r\n                                      .d8888P\"\"       \"\"Y8888b.\r\n                                      \"Y8P\"               \"Y8P'\r\n                                         `.               ,'\r\n                                           \\     .-.     /\r\n                                            \\   (___)   /\r\n .------------------._______________________:__________j\r\n/                   |                      |           |`-.,_\r\n\\###################|######################|###########|,-'`\r\n `------------------'                       :    ___   l\r\n                                            /   (   )   \\\r\n                                           /     `-'     \\\r\n                                         ,'               `.\r\n                                      .d8b.               .d8b.\r\n                                      \"Y8888p..       ,.d8888P\"\r\n                                        \"Y88888888888888888P\"\r\n                                           \"\"YY8888888PP\"\"";
            const string MageIcon = "                (                           )\r\n          ) )( (                           ( ) )( (\r\n       ( ( ( )  ) )                     ( (   (  ) )(\r\n      ) )     ,,\\\\\\                     ///,,       ) (\r\n   (  ((    (\\\\\\\\//                     \\\\////)      )\r\n    ) )    (-(__//                       \\\\__)-)     (\r\n   (((   ((-(__||                         ||__)-))    ) )\r\n  ) )   ((-(-(_||           ```\\__        ||_)-)-))   ((\r\n  ((   ((-(-(/(/\\\\        ''; 9.- `      //\\)\\)-)-))    )\r\n   )   (-(-(/(/(/\\\\      '';;;;-\\~      //\\)\\)\\)-)-)   (   )\r\n(  (   ((-(-(/(/(/\\======,:;:;:;:,======/\\)\\)\\)-)-))   )\r\n    )  '(((-(/(/(/(//////:%%%%%%%:\\\\\\\\\\\\)\\)\\)\\)-)))`  ( (\r\n   ((   '((-(/(/(/('uuuu:WWWWWWWWW:uuuu`)\\)\\)\\)-))`    )\r\n     ))  '((-(/(/(/('|||:wwwwwwwww:|||')\\)\\)\\)-))`    ((\r\n  (   ((   '((((/(/('uuu:WWWWWWWWW:uuu`)\\)\\))))`     ))\r\n        ))   '':::UUUUUU:wwwwwwwww:UUUUUU:::``     ((   )\r\n          ((      '''''''\\uuuuuuuu/``````         ))\r\n           ))            `JJJJJJJJJ`           ((\r\n             ((            LLLLLLLLLLL         ))\r\n               ))         ///|||||||\\\\\\       ((\r\n                 ))      (/(/(/(^)\\)\\)\\)       ((\r\n                  ((                           ))\r\n                    ((                       ((\r\n                      ( )( ))( ( ( ) )( ) (()";
            const string DruidIcon = "        ,\r\n        }`-.   ,          ,\r\n        \\ \\ '-' \\      .-'{\r\n        _} .  | ,`\\   /  ' ;    .-;\\\r\n       {    \\ |    | / `/  '-.,/ ; |\r\n       { -- -.  '  '`-, .--._.' ;  \\__\r\n        \\     \\ | '  /  |`.    ;    _,`\\\r\n         '. '-     ' `_- '.`;  ; ,-`_.-'\r\n     ,--.  \\    `   /` '--'  `;.` (`  _\r\n  .--.\\  '._) '-. \\ \\ `-.    ;     `-';|  \r\n  '. -. '         __ '.  ;  ;     _,-' /\r\n   { __'.\\  ' '-,/; `-'   ';`.- `   .-'\r\n    '-.  `-._'  | `;     ;`'   .-'`\r\n      <_ -'   ` .\\  `;  ;     (_.'`\\\r\n      _.;-\"``\"'-._'. `:;  ___, _.-' |\r\n  .-'\\'. '.` \\ \\_,_`\\ ;##`   `';  _.'\r\n /_'._\\ \\  \\__;#####./###.      \\`\r\n \\.' .'`/\"`/ (#######)###::.. _.'\r\n  '.' .'  ; , |:.  `|()##`\"\"\"`\r\n    `'-../__/_\\::   /O()()o\r\n             ()'._.'`()()'";
            const string MonsterIcon = "                 ___====-_  _-====___\r\n           _--^^^#####//      \\\\#####^^^--_\r\n        _-^##########// (    ) \\\\##########^-_\r\n       -############//  |\\^^/|  \\\\############-\r\n     _/############//   (@::@)   \\\\############\\_\r\n    /#############((     \\\\//     ))#############\\\r\n   -###############\\\\    (oo)    //###############-\r\n  -#################\\\\  / VV \\  //#################-\r\n -###################\\\\/      \\//###################-\r\n_#/|##########/\\######(   /\\   )######/\\##########|\\#_\r\n|/ |#/\\#/\\#/\\/  \\#/\\##\\  |  |  /##/\\#/  \\/\\#/\\#/\\#| \\|\r\n`  |/  V  V  `   V  \\#\\| |  | |/#/  V   '  V  V  \\|  '\r\n   `   `  `      `   / | |  | | \\   '      '  '   '\r\n                    (  | |  | |  )\r\n                   __\\ | |  | | /__\r\n                  (vvv(VVV)(VVV)vvv)";
            const string ProvideHP = "Vida [{0} - {1}]: ";
            const string ProvideDamage = "Ataque [{0} - {1}]: ";
            const string ProvideDefense = "Reduccion de daño (valor percentual) [{0} - {1}]: ";
            const string ProvideAgility = "Agilidad [{0}-{1}]: ";
            const string SkillReady = "Listo";
            const string AskStatAssignMethod = "Elige la dificultad";
            const string AskCharactersName = "Introduce el nombre de la arquera, barbaro, mago y druida del grupo: ";
            const string ShowCharacterStats = "Stats de {0}: ";
            const string ShowMonsterStats = "Stats del monstruo:";
            const string CharacterStatAssign = "Proporciona los stats de {0}";
            const string CharacterTurn = "Es el turno de {0}";
            const string CharacterDefends = "{0} se prepara para el impacto del siguiente ataque";
            const string GeneralAttackSection = "causando {0} puntos de daño, el monstruo se defiende, solo causando {1} puntos de daño, al monstruo le queda {2} puntos de vida";
            const string ArcherAttackMsg = "{0} lanza una flecha al monstruo ";
            const string ArcherCritsMsg = "{0} lanza una flecha a un punto critico del monstruo ";
            const string ArcherMissMsg = "{0} falla su tiro, ";
            const string ArcherSkill = "{0} immobiliza al monstruo con una flecha en la pierna, el monstruo es incapaz de moverse por dos turnos";
            const string BarbarianAttackMsg = "{0} se avalanza con su hacha e impacta, ";
            const string BarbarianCritsMsg = "{0} causa un ataque brutal con su hacha, ";
            const string BarbarianMissMsg = "{0} se avalanza al monstruo con su hacha y NAT 1... Sip falla, ";
            const string BarbarianSkill = "{0} toma una postura defensiva impecable, en los proximos 3 turnos su defensa es perfecta y no puede recivir daño";
            const string MageAttackMsg = "{0} prepara y lanza un rayo magico al monstruo ";
            const string MageCritsMsg = "{0} prepara y lanza un rayo magico directo al ojo ";
            const string MageMissMsg = "{0} intenta hacer kaboom pero le sale kaploom, fallando el ataque. ";
            const string MageSkill = "{0} decide tirar logica por la ventana y grita 'FIREBALL AND ONLY FIREBALL' y lanza una tormenta de bolas de fuego ";
            const string DruidAttackMsg = "{0} da un mamporro con su baston al monstruo ";
            const string DruidCritsMsg = "{0} le da un mamporrazo en la cabeza al monstruo ";
            const string DruidMissMsg = "{0} intenta dar un mamporro con su baston pero no hace nada mas que enfadar mas al monstruo. ";
            const string DruidSkill = "{0} prepara un hechizo curativo que envuelve a todos los aventureros que aun quedan en pie y todos estos son sanados {0} puntos de salud";
            const string DruidHealsCharacters = "{0} ahora posee {1} puntos de salud";
            const string MonsterAttacks = "El monstruo lanza un zarpazo, alcanzando a todos los miembros del grupo";
            const string MonsterCharDamage = "{3} recive {0} puntos de daño,{3} se defiende, solo causando {1} puntos de daño, a {3} le queda {2} puntos de vida";
            const string CharDead = "{0} cae en combate";
            const string MonsterIsStuned = "El monstruo aun sigue siendo incapaz de moverse del impacto de {0}";
            const string ShowHealthMsg = "La salud de {0} es: {1}";
            const string HeroesWin = "Los heroes consiguen derrotar al monstruo";
            const string MonsterWins = "Los heroes fallecen intentando luchar al monstruo, tu mision ha sido un fracaso";

            bool repeated;
            bool choosenOnCooldown;
            int fightOption;
            int dificultyOption;
            int menuOption = 0;
            int errorProvideNumStartMenuCounter;
            int errorProvideAllStatsCounter;
            int errorProvideStatsCounter;
            int errorProvideNumFightMenuCounter;
            int turnTracker;
            int damageAmount;
            int critRollNumber;
            //ArcherStats
            int archerHP;
            int archerTurnHP;
            int archerDamage;
            int archerDefense;
            int archerTurnDefense = 0;
            int archerAgility = 0;
            int archerSkillCooldown;
            //BarbarianStats
            int barbarianHP;
            int barbarianTurnHP;
            int barbarianDamage;
            int barbarianDefense;
            int barbarianTurnDefense = 0;
            int barbarianAgility = 0;
            int barbarianSkillCooldown;
            int barbarianPerfectDefense = 0;
            //MageStats
            int mageHP;
            int mageTurnHP;
            int mageDamage;
            int mageDefense;
            int mageTurnDefense = 0;
            int mageAgility = 0;
            int mageSkillCooldown;
            //DruidStats
            int druidHP;
            int druidTurnHP;
            int druidDamage;
            int druidDefense;
            int druidTurnDefense = 0;
            int druidAgility = 0;
            int druidSkillCooldown;
            //MonsterStats
            int monsterHP;
            int monsterTurnHP;
            int monsterDamage;
            int monsterDefense;
            int monsterStun = 0;
            string formatedMenu;
            string archerName;
            string barbarianName;
            string mageName;
            string druidName;

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
                        Console.Write(Utilities.BuildMenu(StartingMenu.Split(LineJumper), GeneralAskInputMsg));
                        menuOption = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine(MenuSpliter);
                    }
                } while (!Utilities.InRange(menuOption, MinMenusOption, MaxStartingMenuOpt) && errorProvideNumStartMenuCounter < AllowedErrors);

                if (menuOption == StartGameOption)
                {
                    string[] nameStore;
                    do
                    {
                        Console.Write(AskCharactersName);
                        nameStore = Utilities.TrimAllStrings(Console.ReadLine().Split(CharacterSpliter));
                        repeated = nameStore.Length != AmountCharacters;
                        if (repeated)
                        {
                            Console.WriteLine(nameStore.Length < AmountCharacters ? ErrorFewNames : ErrorTooManyNames, AmountCharacters, nameStore.Length);
                        }
                    } while (repeated);
                    archerName = nameStore[ArcherNameLocation];
                    barbarianName = nameStore[BarbariaNameLocation];
                    mageName = nameStore[MageNameLocation];
                    druidName = nameStore[DruidNameLocation];

                    repeated = false;
                    do
                    {
                        if (repeated)
                        {
                            Console.WriteLine(ErrorMenuOptionOutsideRange);
                        }
                        repeated = true;
                        Console.WriteLine(MenuSpliter);
                        Console.Write(Utilities.BuildMenu(StatAssignMenu.Split(LineJumper), GeneralAskInputMsg, AskStatAssignMethod));
                        dificultyOption = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine(MenuSpliter);
                    } while (!Utilities.InRange(dificultyOption, MinMenusOption, MaxStatAssignMenuOpt));
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
                    errorProvideAllStatsCounter = 0;
                    bool showStatMsgLater = false;

                    switch (dificultyOption)
                    {
                        case EasyModeOption:
                            showStatMsgLater = true;

                            archerHP = ArcherMaxHP;
                            archerDamage = ArcherMaxDamage;
                            archerDefense = ArcherMaxDefense;
                            archerAgility = ArcherMaxAgility;

                            barbarianHP = BarbarianMaxHP;
                            barbarianDamage = BarbarianMaxDamage;
                            barbarianDefense = BarbarianMaxDefense;
                            barbarianAgility = BarbarianMaxAgility;

                            mageHP = MageMaxHP;
                            mageDamage = MageMaxDamage;
                            mageDefense = MageMaxDefense;
                            mageAgility = MageMaxAgility;

                            druidHP = DruidMaxHP;
                            druidDamage = DruidMaxDamage;
                            druidDefense = DruidMaxDefense;
                            druidAgility = DruidMaxAgility;

                            monsterHP = MonsterMinHP;
                            monsterDamage = MonsterMinDamage;
                            monsterDefense = MonsterMinDefense;
                            break;
                        case HardModeOption:
                            showStatMsgLater = true;

                            archerHP =  ArcherMinHP;
                            archerDamage = ArcherMinDamage;
                            archerDefense = ArcherMinDefense;
                            archerAgility = ArcherMinAgility;

                            barbarianHP = BarbarianMinHP;
                            barbarianDamage = BarbarianMinDamage;
                            barbarianDefense = BarbarianMinDefense;
                            barbarianAgility = BarbarianMinAgility;

                            mageHP = MageMinHP;
                            mageDamage = MageMinDamage;
                            mageDefense = MageMinDefense;
                            mageAgility = MageMinAgility;

                            druidHP = DruidMinHP;
                            druidDamage = DruidMinDamage;
                            druidDefense = DruidMinDefense;
                            druidAgility = DruidMinAgility;

                            monsterHP = MonsterMaxHP;
                            monsterDamage = MonsterMaxDamage;
                            monsterDefense = MonsterMaxDefense;
                            break;
                        case CustomModeOption:
                            //Asignacion stats arquera
                            Console.WriteLine(MenuSpliter);
                            Console.WriteLine(CharacterStatAssign, archerName);
                            repeated = false;
                            errorProvideStatsCounter = 0;
                            while (!Utilities.InRange(archerHP, ArcherMinHP, ArcherMaxHP) && errorProvideStatsCounter < AllowedErrors)
                            {

                                if (repeated)
                                {
                                    Console.WriteLine(ErrorOutsideStatRange);
                                    errorProvideStatsCounter++;
                                }
                                repeated = true;
                                if (errorProvideStatsCounter < AllowedErrors)
                                {
                                    Console.Write(ProvideHP, ArcherMinHP, ArcherMaxHP);
                                    archerHP = Convert.ToInt32(Console.ReadLine());
                                }
                            }
                            if (errorProvideStatsCounter >= AllowedErrors)
                            {
                                archerHP = ArcherMinHP;
                                Console.WriteLine(ErrorOvercameErrorLimit);
                            }

                            errorProvideStatsCounter = 0;
                            repeated = false;
                            while (!Utilities.InRange(archerDamage, ArcherMinDamage, ArcherMaxDamage) && errorProvideStatsCounter < AllowedErrors)
                            {
                                if (repeated)
                                {
                                    Console.WriteLine(ErrorOutsideStatRange);
                                    errorProvideStatsCounter++;
                                }
                                repeated = true;
                                if (errorProvideStatsCounter < AllowedErrors)
                                {
                                    Console.Write(ProvideDamage, ArcherMinDamage, ArcherMaxDamage);
                                    archerDamage = Convert.ToInt32(Console.ReadLine());
                                }
                            }
                            if (errorProvideStatsCounter >= AllowedErrors)
                            {
                                archerDamage = ArcherMinDamage;
                                Console.WriteLine(ErrorOvercameErrorLimit);
                            }
                            errorProvideStatsCounter = 0;
                            repeated = false;
                            while (!Utilities.InRange(archerDefense, ArcherMinDefense, ArcherMaxDefense) && errorProvideStatsCounter < AllowedErrors)
                            {
                                if (repeated)
                                {
                                    Console.WriteLine(ErrorOutsideStatRange);
                                    errorProvideStatsCounter++;
                                }
                                repeated = true;
                                if (errorProvideStatsCounter < AllowedErrors)
                                {
                                    Console.Write(ProvideDefense, ArcherMinDefense, ArcherMaxDefense);
                                    archerDefense = Convert.ToInt32(Console.ReadLine());
                                }
                            }
                            if (errorProvideStatsCounter >= AllowedErrors)
                            {
                                archerDefense = ArcherMinDefense;
                                Console.WriteLine(ErrorOvercameErrorLimit);
                            }

                            errorProvideStatsCounter = 0;
                            repeated = false;
                            while (!Utilities.InRange(archerAgility, ArcherMinAgility, ArcherMaxAgility) && errorProvideStatsCounter < AllowedErrors)
                            {
                                if (repeated)
                                {
                                    Console.WriteLine(ErrorOutsideStatRange);
                                    errorProvideStatsCounter++;
                                }
                                repeated = true;
                                if (errorProvideStatsCounter < AllowedErrors)
                                {
                                    Console.Write(ProvideAgility, ArcherMinAgility, ArcherMaxAgility);
                                    archerAgility = Convert.ToInt32(Console.ReadLine());
                                }
                            }
                            if (errorProvideStatsCounter >= AllowedErrors)
                            {
                                archerAgility = ArcherMinAgility;
                                Console.WriteLine(ErrorOvercameErrorLimit);
                            }
                            
                            Console.WriteLine(MenuSpliter);


                            //Asignacion de stats barbaro
                            Console.WriteLine(MenuSpliter);
                            Console.WriteLine(CharacterStatAssign, barbarianName);
                            repeated = false;
                            errorProvideStatsCounter = 0;
                            while (!Utilities.InRange(barbarianHP, BarbarianMinHP, BarbarianMaxHP) && errorProvideStatsCounter < AllowedErrors)
                            {

                                if (repeated)
                                {
                                    Console.WriteLine(ErrorOutsideStatRange);
                                    errorProvideStatsCounter++;
                                }
                                repeated = true;
                                if (errorProvideStatsCounter < AllowedErrors)
                                {
                                    Console.Write(ProvideHP, BarbarianMinHP, BarbarianMaxHP);
                                    barbarianHP = Convert.ToInt32(Console.ReadLine());
                                }
                            }
                            if (errorProvideStatsCounter >= AllowedErrors)
                            {
                                barbarianHP = BarbarianMinHP;
                                Console.WriteLine(ErrorOvercameErrorLimit);
                            }

                            errorProvideStatsCounter = 0;
                            repeated = false;
                            while (!Utilities.InRange(barbarianDamage, BarbarianMinDamage, BarbarianMaxDamage) && errorProvideStatsCounter < AllowedErrors)
                            {
                                if (repeated)
                                {
                                    Console.WriteLine(ErrorOutsideStatRange);
                                    errorProvideStatsCounter++;
                                }
                                repeated = true;
                                if (errorProvideStatsCounter < AllowedErrors)
                                {
                                    Console.Write(ProvideDamage, BarbarianMinDamage, BarbarianMaxDamage);
                                    barbarianDamage = Convert.ToInt32(Console.ReadLine());
                                }
                            }
                            if (errorProvideStatsCounter >= AllowedErrors)
                            {
                                barbarianDamage = BarbarianMinDamage;
                                Console.WriteLine(ErrorOvercameErrorLimit);
                            }

                            errorProvideStatsCounter = 0;
                            repeated = false;
                            while (!Utilities.InRange(barbarianDefense, BarbarianMinDefense, BarbarianMaxDefense) && errorProvideStatsCounter < AllowedErrors)
                            {
                                if (repeated)
                                {
                                    Console.WriteLine(ErrorOutsideStatRange);
                                    errorProvideStatsCounter++;
                                }
                                repeated = true;
                                if (errorProvideStatsCounter < AllowedErrors)
                                {
                                    Console.Write(ProvideDefense, BarbarianMinDefense, BarbarianMaxDefense);
                                    barbarianDefense = Convert.ToInt32(Console.ReadLine());
                                }
                            }
                            if (errorProvideStatsCounter >= AllowedErrors)
                            {
                                barbarianDefense = BarbarianMinDefense;
                                Console.WriteLine(ErrorOvercameErrorLimit);
                            }

                            errorProvideStatsCounter = 0;
                            repeated = false;
                            while (!Utilities.InRange(barbarianAgility, BarbarianMinAgility, BarbarianMaxAgility) && errorProvideStatsCounter < AllowedErrors)
                            {
                                if (repeated)
                                {
                                    Console.WriteLine(ErrorOutsideStatRange);
                                    errorProvideStatsCounter++;
                                }
                                repeated = true;
                                if (errorProvideStatsCounter < AllowedErrors)
                                {
                                    Console.Write(ProvideAgility, BarbarianMinAgility, BarbarianMaxAgility);
                                    barbarianAgility = Convert.ToInt32(Console.ReadLine());
                                }
                            }
                            if (errorProvideStatsCounter >= AllowedErrors)
                            {
                                barbarianAgility = BarbarianMinAgility;
                                Console.WriteLine(ErrorOvercameErrorLimit);
                            }

                            Console.WriteLine(MenuSpliter);

                            //Asignacion de stats mago
                            Console.WriteLine(MenuSpliter);
                            Console.WriteLine(CharacterStatAssign, mageName);
                            repeated = false;
                            errorProvideStatsCounter = 0;
                            while ((mageHP < MageMinHP || mageHP > MageMaxHP) && errorProvideStatsCounter < AllowedErrors && errorProvideAllStatsCounter < AllowedErrors)
                            {

                                if (repeated)
                                {
                                    Console.WriteLine(ErrorOutsideStatRange);
                                    errorProvideStatsCounter++;
                                }
                                repeated = true;
                                if (errorProvideStatsCounter < AllowedErrors)
                                {
                                    Console.Write(ProvideHP, MageMinHP, MageMaxHP);
                                    mageHP = Convert.ToInt32(Console.ReadLine());
                                }
                            }
                            if (errorProvideStatsCounter >= AllowedErrors)
                            {
                                mageHP = MageMinHP;
                                Console.WriteLine(ErrorOvercameErrorLimit);
                            }

                            errorProvideStatsCounter = 0;
                            repeated = false;
                            while (!Utilities.InRange(mageDamage, MageMinDamage, MageMaxDamage) && errorProvideStatsCounter < AllowedErrors)
                            {
                                if (repeated)
                                {
                                    Console.WriteLine(ErrorOutsideStatRange);
                                    errorProvideStatsCounter++;
                                }
                                repeated = true;
                                if (errorProvideStatsCounter < AllowedErrors)
                                {
                                    Console.Write(ProvideDamage, MageMinDamage, MageMaxDamage);
                                    mageDamage = Convert.ToInt32(Console.ReadLine());
                                }
                            }
                            if (errorProvideStatsCounter >= AllowedErrors)
                            {
                                mageDamage = MageMinDamage;
                                Console.WriteLine(ErrorOvercameErrorLimit);
                            }

                            errorProvideStatsCounter = 0;
                            repeated = false;
                            while (!Utilities.InRange(mageDefense, MageMinDefense, MageMaxDefense) && errorProvideStatsCounter < AllowedErrors)
                            {
                                if (repeated)
                                {
                                    Console.WriteLine(ErrorOutsideStatRange);
                                    errorProvideStatsCounter++;
                                }
                                repeated = true;
                                if (errorProvideStatsCounter < AllowedErrors)
                                {
                                    Console.Write(ProvideDefense, MageMinDefense, MageMaxDefense);
                                    mageDefense = Convert.ToInt32(Console.ReadLine());
                                }
                            }
                            if (errorProvideStatsCounter >= AllowedErrors)
                            {
                                mageDefense = MageMinDefense;
                                Console.WriteLine(ErrorOvercameErrorLimit);
                            }

                            errorProvideStatsCounter = 0;
                            repeated = false;
                            while (!Utilities.InRange(mageAgility, MageMinAgility, MageMaxAgility) && errorProvideStatsCounter < AllowedErrors)
                            {
                                if (repeated)
                                {
                                    Console.WriteLine(ErrorOutsideStatRange);
                                    errorProvideStatsCounter++;
                                }
                                repeated = true;
                                if (errorProvideStatsCounter < AllowedErrors)
                                {
                                    Console.Write(ProvideAgility, MageMinAgility, MageMaxAgility);
                                    mageAgility = Convert.ToInt32(Console.ReadLine());
                                }
                            }
                            if (errorProvideStatsCounter >= AllowedErrors)
                            {
                                mageAgility = BarbarianMinAgility;
                                Console.WriteLine(ErrorOvercameErrorLimit);
                            }
                            Console.WriteLine(MenuSpliter);


                            //Asignacion de stats druida
                            Console.WriteLine(MenuSpliter);
                            Console.WriteLine(CharacterStatAssign, druidName);
                            repeated = false;
                            errorProvideStatsCounter = 0;
                            while (!Utilities.InRange(druidHP, DruidMinHP, DruidMaxHP) && errorProvideStatsCounter < AllowedErrors)
                            {

                                if (repeated)
                                {
                                    Console.WriteLine(ErrorOutsideStatRange);
                                    errorProvideStatsCounter++;
                                }
                                repeated = true;
                                if (errorProvideStatsCounter < AllowedErrors)
                                {
                                    Console.Write(ProvideHP, DruidMinHP, DruidMaxHP);
                                    druidHP = Convert.ToInt32(Console.ReadLine());
                                }
                            }
                            if (errorProvideStatsCounter >= AllowedErrors)
                            {
                                druidHP = DruidMinHP;
                                Console.WriteLine(ErrorOvercameErrorLimit);
                            }

                            errorProvideStatsCounter = 0;
                            repeated = false;
                            while (!Utilities.InRange(druidDamage, DruidMinDamage, DruidMaxDamage) && errorProvideStatsCounter < AllowedErrors)
                            {
                                if (repeated)
                                {
                                    Console.WriteLine(ErrorOutsideStatRange);
                                    errorProvideStatsCounter++;
                                }
                                repeated = true;
                                if (errorProvideStatsCounter < AllowedErrors)
                                {
                                    Console.Write(ProvideDamage, DruidMinDamage, DruidMaxDamage);
                                    druidDamage = Convert.ToInt32(Console.ReadLine());
                                }
                            }
                            if (errorProvideStatsCounter >= AllowedErrors)
                            {
                                druidDamage = DruidMinDamage;
                                Console.WriteLine(ErrorOvercameErrorLimit);
                            }

                            errorProvideStatsCounter = 0;
                            repeated = false;
                            while (!Utilities.InRange(druidDefense, DruidMinDefense, DruidMaxDefense) && errorProvideStatsCounter < AllowedErrors)
                            {
                                if (repeated)
                                {
                                    Console.WriteLine(ErrorOutsideStatRange);
                                    errorProvideStatsCounter++;
                                }
                                repeated = true;
                                if (errorProvideStatsCounter < AllowedErrors)
                                {
                                    Console.Write(ProvideDefense, DruidMinDefense, DruidMaxDefense);
                                    druidDefense = Convert.ToInt32(Console.ReadLine());
                                }
                            }
                            if (errorProvideStatsCounter >= AllowedErrors)
                            {
                                druidDefense = DruidMinDefense;
                                Console.WriteLine(ErrorOvercameErrorLimit);
                            }

                            errorProvideStatsCounter = 0;
                            repeated = false;
                            while (!Utilities.InRange(druidAgility, DruidMinAgility, DruidMaxAgility) && errorProvideStatsCounter < AllowedErrors)
                            {
                                if (repeated)
                                {
                                    Console.WriteLine(ErrorOutsideStatRange);
                                    errorProvideStatsCounter++;
                                }
                                repeated = true;
                                if (errorProvideStatsCounter < AllowedErrors)
                                {
                                    Console.Write(ProvideAgility, DruidMinAgility, DruidMaxAgility);
                                    druidAgility = Convert.ToInt32(Console.ReadLine());
                                }
                            }
                            if (errorProvideStatsCounter >= AllowedErrors)
                            {
                                druidAgility = DruidMinAgility;
                                Console.WriteLine(ErrorOvercameErrorLimit);
                            }
                            Console.WriteLine(MenuSpliter);
                            
                            //Asignacion de stats monstruo
                            monsterHP = 0;
                            monsterDamage = 0;
                            monsterDefense = 0;

                            repeated = false;
                            errorProvideStatsCounter = 0;
                            while (!Utilities.InRange(monsterHP, MonsterMinHP, MonsterMaxHP) && errorProvideStatsCounter < AllowedErrors)
                            {

                                if (repeated)
                                {
                                    Console.WriteLine(ErrorOutsideStatRange);
                                    errorProvideStatsCounter++;
                                }
                                repeated = true;
                                if (errorProvideStatsCounter < AllowedErrors)
                                {
                                    Console.Write(ProvideHP, MonsterMinHP, MonsterMaxHP);
                                    monsterHP = Convert.ToInt32(Console.ReadLine());
                                }
                            }
                            if (errorProvideStatsCounter >= AllowedErrors)
                            {
                                monsterHP = MonsterMinHP;
                                Console.WriteLine(ErrorOvercameErrorLimit);
                            }

                            errorProvideStatsCounter = 0;
                            repeated = false;
                            while (!Utilities.InRange(monsterDamage, MonsterMinDamage, MonsterMaxDamage) && errorProvideStatsCounter < AllowedErrors)
                            {
                                if (repeated)
                                {
                                    Console.WriteLine(ErrorOutsideStatRange);
                                    errorProvideStatsCounter++;
                                }
                                repeated = true;
                                if (errorProvideStatsCounter < AllowedErrors)
                                {
                                    Console.Write(ProvideDamage, MonsterMinDamage, MonsterMaxDamage);
                                    monsterDamage = Convert.ToInt32(Console.ReadLine());
                                }
                            }
                            if (errorProvideStatsCounter >= AllowedErrors)
                            {
                                monsterDamage = MonsterMinDamage;
                                Console.WriteLine(ErrorOvercameErrorLimit);
                            }

                            errorProvideStatsCounter = 0;
                            repeated = false;
                            while (!Utilities.InRange(monsterDefense, MonsterMinDefense, MonsterMaxDefense) && errorProvideStatsCounter < AllowedErrors)
                            {
                                if (repeated)
                                {
                                    Console.WriteLine(ErrorOutsideStatRange);
                                    errorProvideStatsCounter++;
                                }
                                repeated = true;
                                if (errorProvideStatsCounter < AllowedErrors)
                                {
                                    Console.Write(ProvideDefense, MonsterMinDefense, MonsterMaxDefense);
                                    monsterDefense = Convert.ToInt32(Console.ReadLine());
                                }
                            }

                            if (errorProvideStatsCounter >= AllowedErrors)
                            {
                                monsterDefense = MonsterMinDefense;
                                Console.WriteLine(ErrorOvercameErrorLimit);
                            }
                            Console.WriteLine(MenuSpliter);
                            break;
                        case RandomModeOption:
                            showStatMsgLater = true;

                            archerHP = Utilities.GenerateRandomValue(ArcherMinHP, ArcherMaxHP);
                            archerDamage = Utilities.GenerateRandomValue(ArcherMinDamage, ArcherMaxHP);
                            archerDefense = Utilities.GenerateRandomValue(ArcherMinDefense, ArcherMaxDefense);
                            archerAgility = Utilities.GenerateRandomValue(ArcherMinAgility, ArcherMaxAgility);

                            barbarianHP = Utilities.GenerateRandomValue(BarbarianMinHP, BarbarianMaxHP);
                            barbarianDamage = Utilities.GenerateRandomValue(BarbarianMinDamage, BarbarianMaxDamage);
                            barbarianDefense = Utilities.GenerateRandomValue(BarbarianMinDefense, BarbarianMaxDefense);
                            barbarianAgility = Utilities.GenerateRandomValue(BarbarianMinAgility, BarbarianMaxAgility);

                            mageHP = Utilities.GenerateRandomValue(MageMinHP, MageMaxHP);
                            mageDamage = Utilities.GenerateRandomValue(MageMinDamage, MageMaxDamage);
                            mageDefense = Utilities.GenerateRandomValue(MageMinDefense, MageMaxDefense);
                            mageAgility = Utilities.GenerateRandomValue(MageMinAgility, MageMaxAgility);

                            druidHP = Utilities.GenerateRandomValue(DruidMinHP, DruidMaxHP);
                            druidDamage = Utilities.GenerateRandomValue(DruidMinDamage, DruidMaxDamage);
                            druidDefense = Utilities.GenerateRandomValue(DruidMinDefense, DruidMaxDefense);
                            druidAgility = Utilities.GenerateRandomValue(DruidMinAgility, DruidMaxAgility);

                            monsterHP = Utilities.GenerateRandomValue(MonsterMinHP, MonsterMaxHP);
                            monsterDamage = Utilities.GenerateRandomValue(MonsterMinDamage, MonsterMaxDamage);
                            monsterDefense = Utilities.GenerateRandomValue(MonsterMinDefense, MonsterMaxDefense);
                            break;
                    }
                    if (showStatMsgLater)
                    {
                        Console.WriteLine(ShowCharacterStats, archerName);
                        Console.WriteLine(ProvideHP + archerHP, ArcherMinHP, ArcherMaxHP);
                        Console.WriteLine(ProvideDamage + archerDamage, ArcherMinDamage, ArcherMaxDamage);
                        Console.WriteLine(ProvideDefense + archerDefense, ArcherMinDefense, ArcherMaxDefense);
                        Console.WriteLine(ProvideHP + archerAgility, ArcherMinAgility, ArcherMaxAgility);
                        Console.WriteLine(MenuSpliter);

                        Console.WriteLine(ShowCharacterStats, barbarianName);
                        Console.WriteLine(ProvideHP + barbarianHP, BarbarianMinHP, BarbarianMaxHP);
                        Console.WriteLine(ProvideDamage + barbarianDamage, BarbarianMinDamage, BarbarianMaxDamage);
                        Console.WriteLine(ProvideDefense + barbarianDefense, BarbarianMinDefense, BarbarianMaxDefense);
                        Console.WriteLine(ProvideAgility + barbarianAgility, BarbarianMinAgility, BarbarianMaxAgility);
                        Console.WriteLine(MenuSpliter);

                        Console.WriteLine(ShowCharacterStats, mageName);
                        Console.WriteLine(ProvideHP + mageHP, MageMinHP, MageMaxHP);
                        Console.WriteLine(ProvideDamage + mageDamage, MageMinDamage, MageMaxDamage);
                        Console.WriteLine(ProvideDefense + mageDefense, MageMinDefense, MageMaxDefense);
                        Console.WriteLine(ProvideAgility + mageAgility, MageMinAgility, MageMaxAgility);
                        Console.WriteLine(MenuSpliter);

                        Console.WriteLine(ShowCharacterStats, druidName);
                        Console.WriteLine(ProvideHP + druidHP, DruidMinHP, DruidMaxHP);
                        Console.WriteLine(ProvideDamage + druidDamage, DruidMinDamage, DruidMaxDamage);
                        Console.WriteLine(ProvideDefense + druidDefense, DruidMinDefense, DruidMaxDefense);
                        Console.WriteLine(ProvideAgility + druidAgility, DruidMinAgility, DruidMaxAgility);
                        Console.WriteLine(MenuSpliter);

                        Console.WriteLine(ShowMonsterStats);
                        Console.WriteLine(ProvideHP + monsterHP, MonsterMinHP, MonsterMaxHP);
                        Console.WriteLine(ProvideDamage + monsterDamage, MonsterMinDamage, MonsterMaxDamage);
                        Console.WriteLine(ProvideDefense + monsterDefense, MonsterMinDefense, MonsterMaxDefense);
                        Console.WriteLine(MenuSpliter);
                    }


                    //Start of Combat
                    archerTurnHP = archerHP;
                    barbarianTurnHP = barbarianHP;
                    mageTurnHP = mageHP;
                    druidTurnHP = druidHP;
                    monsterTurnHP = monsterHP;
                    turnTracker = 0;

                    Console.WriteLine(FightIcon);
                    do
                    {
                        turnTracker++;
                        Console.WriteLine(AnounceTurn, turnTracker);
                        string[] turnPicker = new string[] {archerName, barbarianName, mageName, druidName};
                        int[] everyoneAgilityScores = new int[] {Utilities.GenerateRandomValue(0,PercentageTop)+archerAgility,
                                                                 Utilities.GenerateRandomValue(0,PercentageTop)+barbarianAgility,
                                                                 Utilities.GenerateRandomValue(0,PercentageTop)+mageAgility,
                                                                 Utilities.GenerateRandomValue(0,PercentageTop)+druidAgility};
                        Utilities.ReorderDesc(ref everyoneAgilityScores, ref turnPicker);
                        for(int i = 0; i < everyoneAgilityScores.Length; i++)
                        {
                            string nameActualTurn = turnPicker[i];

                            errorProvideNumFightMenuCounter = 0;
                            fightOption = 0;
                            choosenOnCooldown = true;
                            if (nameActualTurn.Equals(archerName))
                            {
                                while (Utilities.IsActorAlive(archerTurnHP) && Utilities.IsActorAlive(monsterTurnHP) && errorProvideNumFightMenuCounter < AllowedErrors && (!Utilities.InRange(fightOption, MinMenusOption, MaxFightMenuOpt) || choosenOnCooldown))
                                {
                                    choosenOnCooldown = false;
                                    archerTurnDefense = archerDefense;

                                    Console.WriteLine(MenuSpliter);
                                    formatedMenu = Utilities.FormatString(FightMenu, archerSkillCooldown == 0 ? SkillReady : $"{archerSkillCooldown}");
                                    Console.Write(Utilities.BuildMenu(formatedMenu.Split(LineJumper), GeneralAskInputMsg, $"{ArcherIcon}{LineJumper}{Utilities.FormatString(CharacterTurn, archerName)}"));
                                    fightOption = Convert.ToInt32(Console.ReadLine());
                                    switch (fightOption)
                                    {
                                        case AtackOption:
                                            critRollNumber = Utilities.CritFail(FailChance, CritChance);
                                            Console.WriteLine(Utilities.AttackOption(archerDamage * critRollNumber, monsterDefense, ref monsterTurnHP, Utilities.FormatString(critRollNumber switch
                                            {
                                                FailResponse => ArcherMissMsg,
                                                CritResponse => ArcherCritsMsg,
                                                _ => ArcherAttackMsg
                                            }, archerName) + GeneralAttackSection));
                                            break;
                                        case DefendOption:
                                            Utilities.DefenseAction(ref archerTurnDefense, archerTurnDefense + archerDefense);
                                            Console.WriteLine(CharacterDefends, archerName);
                                            break;
                                        case SkillOption:
                                            if (archerSkillCooldown > 0)
                                            {
                                                choosenOnCooldown = true;
                                                errorProvideNumFightMenuCounter++;
                                                Console.WriteLine(ErrorChoosenUnderCooldown);
                                            }
                                            else
                                            {
                                                monsterStun = ArcherStunDuration;
                                                archerSkillCooldown = GlobalSpecialSkillCooldown;
                                                Console.WriteLine(ArcherSkill, archerName);
                                            }
                                            break;
                                        default:
                                            Console.WriteLine(ErrorMenuOptionOutsideRange);
                                            errorProvideNumFightMenuCounter++;
                                            break;
                                    }
                                    if (!choosenOnCooldown && Utilities.InRange(fightOption, MinMenusOption, MaxFightMenuOpt))
                                    {
                                        if (archerSkillCooldown > 0)
                                        {
                                            archerSkillCooldown--;
                                        }
                                    }
                                    if (errorProvideNumFightMenuCounter >= AllowedErrors) Console.WriteLine(ErrorOvercameFightErrorLimit, barbarianName);
                                    Console.WriteLine(MenuSpliter);
                                }
                            }
                            else if (nameActualTurn.Equals(barbarianName))
                            {
                                while (Utilities.IsActorAlive(barbarianTurnHP) && Utilities.IsActorAlive(monsterTurnHP) && errorProvideNumFightMenuCounter < AllowedErrors && (!Utilities.InRange(fightOption, MinMenusOption, MaxFightMenuOpt) || choosenOnCooldown))
                                {
                                    choosenOnCooldown = false;
                                    barbarianTurnDefense = barbarianDefense;

                                    Console.WriteLine(MenuSpliter);
                                    formatedMenu = Utilities.FormatString(FightMenu, barbarianSkillCooldown == 0 ? SkillReady : $"{barbarianSkillCooldown}");
                                    Console.Write(Utilities.BuildMenu(formatedMenu.Split(LineJumper), GeneralAskInputMsg, $"{BarbarianIcon}{LineJumper}{Utilities.FormatString(CharacterTurn, barbarianName)}"));
                                    fightOption = Convert.ToInt32(Console.ReadLine());
                                    switch (fightOption)
                                    {
                                        case AtackOption:
                                            critRollNumber = Utilities.CritFail(FailChance, CritChance);
                                            Console.WriteLine(Utilities.AttackOption(barbarianDamage * critRollNumber, monsterDefense, ref monsterTurnHP, Utilities.FormatString(critRollNumber switch
                                            {
                                                FailResponse => BarbarianMissMsg,
                                                CritResponse => BarbarianCritsMsg,
                                                _ => BarbarianAttackMsg
                                            }, archerName) + GeneralAttackSection));
                                            break;
                                        case DefendOption:
                                            Utilities.DefenseAction(ref barbarianTurnDefense, barbarianTurnDefense + barbarianDefense);
                                            Console.WriteLine(CharacterDefends, barbarianName);
                                            break;
                                        case SkillOption:
                                            if (barbarianSkillCooldown > 0)
                                            {
                                                choosenOnCooldown = true;
                                                errorProvideNumFightMenuCounter++;
                                                Console.WriteLine(ErrorChoosenUnderCooldown);
                                            }
                                            else
                                            {
                                                barbarianPerfectDefense = BarbarianPerfectDefenseDuration;
                                                barbarianSkillCooldown = GlobalSpecialSkillCooldown;
                                                Console.WriteLine(BarbarianSkill, barbarianName);
                                            }
                                            break;
                                        default:
                                            errorProvideNumFightMenuCounter++;
                                            Console.WriteLine(ErrorOutsideStatRange);
                                            break;
                                    }
                                    if (!choosenOnCooldown && Utilities.InRange(fightOption, MinMenusOption, MaxFightMenuOpt))
                                    {
                                        if (barbarianPerfectDefense > 0)
                                        {
                                            Utilities.DefenseAction(ref barbarianTurnDefense, PercentageTop);
                                            barbarianPerfectDefense--;
                                        }
                                        if (barbarianSkillCooldown > 0)
                                        {
                                            barbarianSkillCooldown--;
                                        }
                                    }
                                    if (errorProvideNumFightMenuCounter >= AllowedErrors) Console.WriteLine(ErrorOvercameFightErrorLimit, barbarianName);
                                    Console.WriteLine(MenuSpliter);
                                }
                            }
                            else if (nameActualTurn.Equals(mageName))
                            {
                                while (Utilities.IsActorAlive(mageTurnHP) && Utilities.IsActorAlive(monsterTurnHP) && errorProvideNumFightMenuCounter < AllowedErrors && (!Utilities.InRange(fightOption, MinMenusOption, MaxFightMenuOpt) || choosenOnCooldown))
                                {
                                    choosenOnCooldown = false;
                                    mageTurnDefense = mageDefense;
                                    Console.WriteLine(MenuSpliter);
                                    formatedMenu = Utilities.FormatString(FightMenu, mageSkillCooldown == 0 ? SkillReady : $"{mageSkillCooldown}");
                                    Console.Write(Utilities.BuildMenu(formatedMenu.Split(LineJumper), GeneralAskInputMsg, $"{MageIcon}{LineJumper}{Utilities.FormatString(CharacterTurn, mageName)}"));
                                    fightOption = Convert.ToInt32(Console.ReadLine());
                                    switch (fightOption)
                                    {
                                        case AtackOption:
                                            critRollNumber = Utilities.CritFail(FailChance, CritChance);
                                            Console.WriteLine(Utilities.AttackOption(mageDamage * critRollNumber, monsterDefense, ref monsterTurnHP, Utilities.FormatString(critRollNumber switch
                                            {
                                                FailResponse => MageMissMsg,
                                                CritResponse => MageCritsMsg,
                                                _ => MageAttackMsg,
                                            }, mageName) + GeneralAttackSection));
                                            break;
                                        case DefendOption:
                                            Utilities.DefenseAction(ref mageTurnDefense, mageTurnDefense + mageDefense);
                                            Console.WriteLine(CharacterDefends, mageName);
                                            break;
                                        case SkillOption:
                                            if (mageSkillCooldown > 0)
                                            {
                                                choosenOnCooldown = true;
                                                errorProvideNumFightMenuCounter++;
                                                Console.WriteLine(ErrorChoosenUnderCooldown);
                                            }
                                            else
                                            {
                                                mageSkillCooldown = GlobalSpecialSkillCooldown; ;
                                                Console.WriteLine(Utilities.AttackOption(mageDamage * MageSuperAttackMult, monsterDefense, ref monsterTurnHP, Utilities.FormatString(MageSkill, mageName) + GeneralAttackSection));
                                            }
                                            break;
                                        default:
                                            errorProvideNumFightMenuCounter++;
                                            Console.WriteLine(ErrorMenuOptionOutsideRange);
                                            break;
                                    }
                                    if (!choosenOnCooldown && Utilities.InRange(fightOption, MinMenusOption, MaxFightMenuOpt))
                                    {
                                        if (mageSkillCooldown > 0)
                                        {
                                            mageSkillCooldown--;
                                        }
                                    }
                                    if (errorProvideNumFightMenuCounter >= AllowedErrors) Console.WriteLine(ErrorOvercameFightErrorLimit, mageName);
                                    Console.WriteLine(MenuSpliter);
                                }
                            }
                            else if (nameActualTurn.Equals(druidName))
                            {
                                while (Utilities.IsActorAlive(druidTurnHP) && Utilities.IsActorAlive(monsterTurnHP) && errorProvideNumFightMenuCounter < AllowedErrors && (!Utilities.InRange(fightOption, MinMenusOption, MaxFightMenuOpt) || choosenOnCooldown))
                                {
                                    choosenOnCooldown = false;
                                    druidTurnDefense = druidDefense;

                                    Console.WriteLine(MenuSpliter);
                                    formatedMenu = Utilities.FormatString(FightMenu, druidSkillCooldown == 0 ? SkillReady : $"{druidSkillCooldown}");
                                    Console.Write(Utilities.BuildMenu(formatedMenu.Split(LineJumper), GeneralAskInputMsg, $"{DruidIcon}{LineJumper}{Utilities.FormatString(CharacterTurn, druidName)}"));
                                    fightOption = Convert.ToInt32(Console.ReadLine());
                                    switch (fightOption)
                                    {
                                        case AtackOption:
                                            critRollNumber = Utilities.CritFail(FailChance, CritChance);
                                            Console.WriteLine(Utilities.AttackOption(druidDamage * critRollNumber, monsterDefense, ref monsterTurnHP, critRollNumber switch
                                            {
                                                FailResponse => DruidMissMsg,
                                                CritResponse => DruidCritsMsg,
                                                _ => DruidAttackMsg,
                                            } + GeneralAttackSection));
                                            break;
                                        case DefendOption:
                                            Utilities.DefenseAction(ref druidTurnDefense, druidTurnDefense + druidDefense);
                                            Console.WriteLine(CharacterDefends, druidName);
                                            break;
                                        case SkillOption:
                                            if (druidSkillCooldown > 0)
                                            {
                                                choosenOnCooldown = true;
                                                errorProvideNumFightMenuCounter++;
                                                Console.WriteLine(choosenOnCooldown);
                                            }
                                            else
                                            {
                                                Console.WriteLine(DruidSkill, DruidHealingAmount);
                                                if (Utilities.IsActorAlive(archerTurnHP))
                                                {
                                                    archerTurnHP = Utilities.HealTarget(archerTurnHP, DruidHealingAmount, archerHP);
                                                    Console.WriteLine(DruidHealsCharacters, archerName, archerTurnHP);
                                                }
                                                if (Utilities.IsActorAlive(barbarianTurnHP))
                                                {
                                                    barbarianTurnHP = Utilities.HealTarget(barbarianTurnHP, DruidHealingAmount, barbarianHP);
                                                    Console.WriteLine(DruidHealsCharacters, barbarianName, barbarianTurnHP);
                                                }
                                                if (Utilities.IsActorAlive(mageTurnHP))
                                                {
                                                    mageTurnHP = Utilities.HealTarget(mageTurnHP, DruidHealingAmount, mageHP);
                                                    Console.WriteLine(DruidHealsCharacters, mageName, mageTurnHP);
                                                }
                                                druidTurnHP = Utilities.HealTarget(druidTurnHP, DruidHealingAmount, druidHP);
                                                Console.WriteLine(DruidHealsCharacters, druidName, druidTurnHP);
                                                druidSkillCooldown = GlobalSpecialSkillCooldown;
                                            }
                                            break;
                                        default:
                                            errorProvideNumFightMenuCounter++;
                                            Console.WriteLine(ErrorMenuOptionOutsideRange);
                                            break;
                                    }
                                    if (!choosenOnCooldown && Utilities.InRange(fightOption, MinMenusOption, MaxFightMenuOpt))
                                    {
                                        if (druidSkillCooldown > 0)
                                        {
                                            druidSkillCooldown--;
                                        }
                                    }
                                    if (errorProvideNumFightMenuCounter >= AllowedErrors) Console.WriteLine(ErrorOvercameFightErrorLimit, druidName);
                                    Console.WriteLine(MenuSpliter);
                                }
                            }
                        }
                        
                        //MonsterTurn
                        if (Utilities.IsActorAlive(monsterTurnHP) && monsterStun <= 0)
                        {
                            Console.WriteLine(MenuSpliter);
                            Console.WriteLine(MonsterIcon);
                            Console.WriteLine(MonsterAttacks);
                            if (Utilities.IsActorAlive(archerTurnHP))
                            {
                                damageAmount = Utilities.CalcAttackDamage(monsterDamage, archerTurnDefense);
                                archerTurnHP -= damageAmount;
                                Console.WriteLine(MonsterCharDamage, monsterDamage, damageAmount, archerTurnHP, archerName);
                                if (!Utilities.IsActorAlive(archerTurnHP))
                                {
                                    Console.WriteLine(CharDead, archerName);
                                }
                            }
                            if (Utilities.IsActorAlive(barbarianTurnHP))
                            {
                                damageAmount = Utilities.CalcAttackDamage(monsterDamage, barbarianTurnDefense);
                                barbarianTurnHP -= damageAmount;
                                Console.WriteLine(MonsterCharDamage, monsterDamage, damageAmount, barbarianTurnHP, barbarianName);
                                if (!Utilities.IsActorAlive(barbarianTurnHP))
                                {
                                    Console.WriteLine(CharDead, barbarianName);
                                }

                            }
                            if (Utilities.IsActorAlive(mageTurnHP))
                            {
                                damageAmount = Utilities.CalcAttackDamage(monsterDamage, mageTurnDefense);
                                mageTurnHP -= damageAmount;
                                Console.WriteLine(MonsterCharDamage, monsterDamage, damageAmount, mageTurnHP, mageName);
                                if (!Utilities.IsActorAlive(mageTurnHP))
                                {
                                    Console.WriteLine(CharDead, mageName);
                                }
                            }
                            if (Utilities.IsActorAlive(druidTurnHP))
                            {
                                damageAmount = Utilities.CalcAttackDamage(monsterDamage, druidTurnDefense);
                                druidTurnHP -= damageAmount;
                                Console.WriteLine(MonsterCharDamage, monsterDamage, damageAmount, druidTurnHP, druidName);
                                if (!Utilities.IsActorAlive(druidTurnHP))
                                {
                                    Console.WriteLine(CharDead, druidName);
                                }
                            }
                            Console.WriteLine(MenuSpliter);
                        }
                        else if (Utilities.IsActorAlive(monsterTurnHP) && monsterStun > 0)
                        {
                            Console.WriteLine(MenuSpliter);
                            Console.WriteLine(MonsterIcon);
                            monsterStun--;
                            Console.WriteLine(MonsterIsStuned, archerName);
                            Console.WriteLine(MenuSpliter);
                        }
                        Console.Write(Utilities.ShowValuesDesc(new int[] { archerTurnHP, barbarianTurnHP, mageTurnHP, druidTurnHP }, new string[] { archerName, barbarianName, mageName, druidName }, ShowHealthMsg));
                    } while (Utilities.IsActorAlive(monsterTurnHP) && (!Utilities.AreActorGroupDead(new int[] { archerTurnHP, barbarianTurnHP, mageTurnHP, druidTurnHP })));
                    Console.WriteLine(!Utilities.IsActorAlive(monsterTurnHP) ? HeroesWin : MonsterWins);
                    
                }
            } while (menuOption != ExitGameOption && errorProvideNumStartMenuCounter < AllowedErrors);
            if (errorProvideNumStartMenuCounter == AllowedErrors)
            {
                Console.WriteLine(ErrorOvercameStartErrorLimit);
            }
        }


        
    }
}