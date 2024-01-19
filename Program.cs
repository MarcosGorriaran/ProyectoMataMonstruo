/**
 * Author: Gorriaran Caamaño Marcos Facundo
 * Date: 28/10/2023 V1.2
 * Descripcion: Juego en el que el usuario al elegir jugar a traves de un menu tendra que
 * asignar los stats de los heroes que controlara y del monstruo que se enfrentara.
 * La lucha va por turnos y finaliza cuando todos los miembros de un lado caigan.
 * Sources:
 *  ASCII Drawings: https://www.asciiart.eu
 */
using System;

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
            const int ArcherMinDamage = 180;
            const int ArcherMaxDamage = 300;
            const int ArcherMinDefense = 25;
            const int ArcherMaxDefense = 40;
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
            const int BarbarianPerfectDefenseDuration = 3;
            const int BarbariaNameLocation = 1;
            //MageConstants
            const int MageMinHP = 1000;
            const int MageMaxHP = 1500;
            const int MageMinDamage = 300;
            const int MageMaxDamage = 350;
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
            const int MonsterMinHP = 9000;
            const int MonsterMaxHP = 12000;
            const int MonsterMinDamage = 250;
            const int MonsterMaxDamage = 400;
            const int MonsterMinDefense = 20;
            const int MonsterMaxDefense = 30;
            const char CharacterSpliter = ',';
            const string LineJumper = "\n";
            const string ErrorMenuOptionOutsideRange = "Opcion seleccionado en el menu esta fuera del rango permitido, elige una de las opciones que se muestran en pantalla";
            const string ErrorOvercameErrorLimit = "Se ha superado el limite de errores, se asignara el stat minimo en este apartado";
            const string ErrorOvercameSecondErrorLimit = "Ha cometido 3 errores 3 veces, vuelve al principio";
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
            const string MonsterStatAssign = "Proporciona los stats del monstruo";
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
            bool choosenOnCooldown = false;
            int fightOption = 0;
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
            int archerDefense = 0;
            int archerTurnDefense = 0;
            int archerAgility = 0;
            int archerSkillCooldown;
            //BarbarianStats
            int barbarianHP;
            int barbarianTurnHP;
            int barbarianDamage;
            int barbarianDefense = 0;
            int barbarianTurnDefense = 0;
            int barbarianAgility = 0;
            int barbarianSkillCooldown = 0;
            int barbarianPerfectDefense = 0;
            //MageStats
            int mageHP;
            int mageTurnHP;
            int mageDamage;
            int mageDefense = 0;
            int mageTurnDefense = 0;
            int mageAgility = 0;
            int mageSkillCooldown = 0;
            //DruidStats
            int druidHP;
            int druidTurnHP;
            int druidDamage;
            int druidDefense = 0;
            int druidTurnDefense = 0;
            int druidAgility = 0;
            int druidSkillCooldown = 0;
            //MonsterStats
            int monsterHP;
            int monsterTurnHP;
            int monsterDamage;
            int monsterDefense = 0;
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
                        Console.Write(BuildMenu(StartingMenu.Split(LineJumper), GeneralAskInputMsg));
                        menuOption = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine(MenuSpliter);
                    }
                } while (!InRange(menuOption, MinMenusOption, MaxStartingMenuOpt) && errorProvideNumStartMenuCounter < AllowedErrors);

                if (menuOption == StartGameOption)
                {
                    string[] nameStore = new string[AmountCharacters];
                    repeated = false;
                    do
                    {
                        Console.Write(AskCharactersName);
                        nameStore = TrimAllStrings(Console.ReadLine().Split(CharacterSpliter));
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
                        Console.Write(BuildMenu(StatAssignMenu.Split(LineJumper), GeneralAskInputMsg, AskStatAssignMethod));
                        dificultyOption = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine(MenuSpliter);
                    } while (!InRange(dificultyOption, MinMenusOption, MaxStatAssignMenuOpt));
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

                    switch (dificultyOption)
                    {
                        case EasyModeOption:
                            Console.WriteLine(MenuSpliter);
                            Console.WriteLine(ShowCharacterStats, archerName);
                            archerHP = AskStat(ProvideHP, ArcherMinHP, ArcherMaxHP, ArcherMaxHP);
                            archerDamage = AskStat(ProvideDamage, ArcherMinDamage, ArcherMaxDamage, ArcherMaxDamage);
                            archerDefense = AskStat(ProvideDefense, ArcherMinDefense, ArcherMaxDefense, ArcherMaxDefense);
                            archerAgility = AskStat(ProvideAgility, ArcherMinAgility, ArcherMaxAgility, ArcherMaxAgility);
                            Console.WriteLine(MenuSpliter);

                            Console.WriteLine(MenuSpliter);
                            Console.WriteLine(ShowCharacterStats, barbarianName);
                            barbarianHP = AskStat(ProvideHP, BarbarianMinHP, BarbarianMaxHP, BarbarianMaxHP);
                            barbarianDamage = AskStat(ProvideDamage, BarbarianMinDamage, BarbarianMaxDamage, BarbarianMaxDamage);
                            barbarianDefense = AskStat(ProvideDefense, BarbarianMinDefense, BarbarianMaxDefense, BarbarianMaxDefense);
                            barbarianAgility = AskStat(ProvideAgility, BarbarianMinAgility, BarbarianMaxAgility, BarbarianMaxAgility);
                            Console.WriteLine(MenuSpliter);

                            Console.WriteLine(MenuSpliter);
                            Console.WriteLine(ShowCharacterStats, mageName);
                            mageHP = AskStat(ProvideHP, MageMinHP, MageMaxHP, MageMaxHP);
                            mageDamage = AskStat(ProvideDamage, MageMinDamage, MageMaxDamage, MageMaxDamage);
                            mageDefense = AskStat(ProvideDefense, MageMinDefense, MageMaxDefense, MageMaxDefense);
                            mageAgility = AskStat(ProvideAgility, MageMinAgility, MageMaxAgility, MageMaxAgility);
                            Console.WriteLine(MenuSpliter);

                            Console.WriteLine(MenuSpliter);
                            Console.WriteLine(ShowCharacterStats, druidName);
                            druidHP = AskStat(ProvideHP, DruidMinHP, DruidMaxHP, DruidMinHP);
                            druidDamage = AskStat(ProvideDamage, DruidMinDamage, DruidMaxDamage, DruidMaxDamage);
                            druidDefense = AskStat(ProvideDefense, DruidMinDefense, DruidMaxDefense, DruidMaxDefense);
                            druidAgility = AskStat(ProvideAgility, DruidMinAgility, DruidMaxAgility, DruidMaxAgility);
                            Console.WriteLine(MenuSpliter);

                            Console.WriteLine(MenuSpliter);
                            Console.WriteLine(ShowMonsterStats);
                            monsterHP = AskStat(ProvideHP, MonsterMinHP, MonsterMaxHP, MonsterMinHP);
                            monsterDamage = AskStat(ProvideDamage, MonsterMinDamage, MonsterMaxDamage, MonsterMinDamage);
                            monsterDefense = AskStat(ProvideDefense, MonsterMinDefense, MonsterMaxDefense, MonsterMinDefense);
                            Console.WriteLine(MenuSpliter);
                            break;
                        case HardModeOption:
                            Console.WriteLine(MenuSpliter);
                            Console.WriteLine(ShowCharacterStats, archerName);
                            archerHP = AskStat(ProvideHP, ArcherMinHP, ArcherMaxHP, ArcherMinHP);
                            archerDamage = AskStat(ProvideDamage, ArcherMinDamage, ArcherMaxDamage, ArcherMinDamage);
                            archerDefense = AskStat(ProvideDefense, ArcherMinDefense, ArcherMaxDefense, ArcherMinDefense);
                            archerAgility = AskStat(ProvideAgility, ArcherMinAgility, ArcherMaxAgility, ArcherMinAgility);
                            Console.WriteLine(MenuSpliter);

                            Console.WriteLine(MenuSpliter);
                            Console.WriteLine(ShowCharacterStats, barbarianName);
                            barbarianHP = AskStat(ProvideHP, BarbarianMinHP, BarbarianMaxHP, BarbarianMinHP);
                            barbarianDamage = AskStat(ProvideDamage, BarbarianMinDamage, BarbarianMaxDamage, BarbarianMinDamage);
                            barbarianDefense = AskStat(ProvideDefense, BarbarianMinDefense, BarbarianMaxDefense, BarbarianMinDefense);
                            barbarianAgility = AskStat(ProvideAgility, BarbarianMinAgility, BarbarianMaxAgility, BarbarianMinAgility);
                            Console.WriteLine(MenuSpliter);

                            Console.WriteLine(MenuSpliter);
                            Console.WriteLine(ShowCharacterStats, mageName);
                            mageHP = AskStat(ProvideHP, MageMinHP, MageMaxHP, MageMinHP);
                            mageDamage = AskStat(ProvideDamage, MageMinDamage, MageMaxDamage, MageMinDamage);
                            mageDefense = AskStat(ProvideDefense, MageMinDefense, MageMaxDefense, MageMinDefense);
                            mageAgility = AskStat(ProvideAgility, MageMinAgility, MageMaxAgility, MageMaxAgility);
                            Console.WriteLine(MenuSpliter);

                            Console.WriteLine(MenuSpliter);
                            Console.WriteLine(ShowCharacterStats, druidName);
                            druidHP = AskStat(ProvideHP, DruidMinHP, DruidMaxHP, DruidMinHP);
                            druidDamage = AskStat(ProvideDamage, DruidMinDamage, DruidMaxDamage, DruidMinDamage);
                            druidDefense = AskStat(ProvideDefense, DruidMinDefense, DruidMaxDefense, DruidMinDefense);
                            druidAgility = AskStat(ProvideAgility, DruidMinAgility, DruidMaxAgility, DruidMinAgility);
                            Console.WriteLine(MenuSpliter);

                            Console.WriteLine(MenuSpliter);
                            Console.WriteLine(ShowMonsterStats);
                            monsterHP = AskStat(ProvideHP, MonsterMinHP, MonsterMaxHP, MonsterMaxHP);
                            monsterDamage = AskStat(ProvideDamage, MonsterMinDamage, MonsterMaxDamage, MonsterMaxDamage);
                            monsterDefense = AskStat(ProvideDefense, MonsterMinDefense, MonsterMaxDefense, MonsterMinDefense);
                            Console.WriteLine(MenuSpliter);
                            break;
                        case CustomModeOption:
                            //Asignacion stats arquera
                            Console.WriteLine(MenuSpliter);
                            Console.WriteLine(CharacterStatAssign, archerName);
                            repeated = false;
                            errorProvideStatsCounter = 0;
                            while (!InRange(archerHP, ArcherMinHP, ArcherMaxHP) && errorProvideStatsCounter < AllowedErrors)
                            {

                                if (repeated)
                                {
                                    Console.WriteLine(ErrorOutsideStatRange);
                                    errorProvideStatsCounter++;
                                }
                                repeated = true;
                                if (errorProvideStatsCounter < AllowedErrors)
                                {
                                    archerHP = AskStat(ProvideHP, ArcherMinHP, ArcherMaxHP);
                                }
                            }
                            if (errorProvideStatsCounter >= AllowedErrors)
                            {
                                archerHP = ArcherMinHP;
                                Console.WriteLine(ErrorOvercameErrorLimit);
                            }

                            errorProvideStatsCounter = 0;
                            repeated = false;
                            while (!InRange(archerDamage, ArcherMinDamage, ArcherMaxDamage) && errorProvideStatsCounter < AllowedErrors)
                            {
                                if (repeated)
                                {
                                    Console.WriteLine(ErrorOutsideStatRange);
                                    errorProvideStatsCounter++;
                                }
                                repeated = true;
                                if (errorProvideStatsCounter < AllowedErrors)
                                {
                                    archerDamage = AskStat(ProvideDamage, ArcherMinDamage, ArcherMaxDamage);
                                }
                            }
                            if (errorProvideStatsCounter >= AllowedErrors)
                            {
                                archerDamage = ArcherMinDamage;
                                Console.WriteLine(ErrorOvercameErrorLimit);
                            }
                            errorProvideStatsCounter = 0;
                            repeated = false;
                            while (!InRange(archerDefense, ArcherMinDefense, ArcherMaxDefense) && errorProvideStatsCounter < AllowedErrors)
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
                            while (!InRange(archerAgility, ArcherMinAgility, ArcherMaxAgility) && errorProvideStatsCounter < AllowedErrors)
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
                            while (!InRange(barbarianHP, BarbarianMinHP, BarbarianMaxHP) && errorProvideStatsCounter < AllowedErrors)
                            {

                                if (repeated)
                                {
                                    Console.WriteLine(ErrorOutsideStatRange);
                                    errorProvideStatsCounter++;
                                }
                                repeated = true;
                                if (errorProvideStatsCounter < AllowedErrors)
                                {
                                    barbarianHP = AskStat(ProvideHP, BarbarianMinHP, BarbarianMaxHP);
                                }
                            }
                            if (errorProvideStatsCounter >= AllowedErrors)
                            {
                                barbarianHP = BarbarianMinHP;
                                Console.WriteLine(ErrorOvercameErrorLimit);
                            }

                            errorProvideStatsCounter = 0;
                            repeated = false;
                            while (!InRange(barbarianDamage, BarbarianMinDamage, BarbarianMaxDamage) && errorProvideStatsCounter < AllowedErrors)
                            {
                                if (repeated)
                                {
                                    Console.WriteLine(ErrorOutsideStatRange);
                                    errorProvideStatsCounter++;
                                }
                                repeated = true;
                                if (errorProvideStatsCounter < AllowedErrors)
                                {
                                    barbarianDamage = AskStat(ProvideDamage, BarbarianMinDamage, BarbarianMaxDamage);
                                }
                            }
                            if (errorProvideStatsCounter >= AllowedErrors)
                            {
                                barbarianDamage = BarbarianMinDamage;
                                Console.WriteLine(ErrorOvercameErrorLimit);
                            }

                            errorProvideStatsCounter = 0;
                            repeated = false;
                            while (!InRange(barbarianDefense, BarbarianMinDefense, BarbarianMaxDefense) && errorProvideStatsCounter < AllowedErrors)
                            {
                                if (repeated)
                                {
                                    Console.WriteLine(ErrorOutsideStatRange);
                                    errorProvideStatsCounter++;
                                }
                                repeated = true;
                                if (errorProvideStatsCounter < AllowedErrors)
                                {
                                    barbarianDefense = AskStat(ProvideDefense, BarbarianMinDefense, BarbarianMaxDefense);
                                }
                            }
                            if (errorProvideStatsCounter >= AllowedErrors)
                            {
                                barbarianDefense = BarbarianMinDefense;
                                Console.WriteLine(ErrorOvercameErrorLimit);
                            }

                            errorProvideStatsCounter = 0;
                            repeated = false;
                            while (!InRange(barbarianAgility, BarbarianMinAgility, BarbarianMaxAgility) && errorProvideStatsCounter < AllowedErrors)
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
                                    mageHP = AskStat(ProvideHP, MageMinHP, MageMaxHP);
                                }
                            }
                            if (errorProvideStatsCounter >= AllowedErrors)
                            {
                                mageHP = MageMinHP;
                                Console.WriteLine(ErrorOvercameErrorLimit);
                            }

                            errorProvideStatsCounter = 0;
                            repeated = false;
                            while (!InRange(mageDamage, MageMinDamage, MageMaxDamage) && errorProvideStatsCounter < AllowedErrors)
                            {
                                if (repeated)
                                {
                                    Console.WriteLine(ErrorOutsideStatRange);
                                    errorProvideStatsCounter++;
                                }
                                repeated = true;
                                if (errorProvideStatsCounter < AllowedErrors)
                                {
                                    mageDamage = AskStat(ProvideDamage, MageMinDamage, MageMaxDamage);
                                }
                            }
                            if (errorProvideStatsCounter >= AllowedErrors)
                            {
                                mageDamage = MageMinDamage;
                                Console.WriteLine(ErrorOvercameErrorLimit);
                            }

                            errorProvideStatsCounter = 0;
                            repeated = false;
                            while (!InRange(mageDefense, MageMinDefense, MageMaxDefense) && errorProvideStatsCounter < AllowedErrors)
                            {
                                if (repeated)
                                {
                                    Console.WriteLine(ErrorOutsideStatRange);
                                    errorProvideStatsCounter++;
                                }
                                repeated = true;
                                if (errorProvideStatsCounter < AllowedErrors)
                                {
                                    mageDefense = AskStat(ProvideDefense, MageMinDefense, MageMaxDefense);
                                }
                            }
                            if (errorProvideStatsCounter >= AllowedErrors)
                            {
                                mageDefense = MageMinDefense;
                                Console.WriteLine(ErrorOvercameErrorLimit);
                            }

                            errorProvideStatsCounter = 0;
                            repeated = false;
                            while (!InRange(mageAgility, MageMinAgility, MageMaxAgility) && errorProvideStatsCounter < AllowedErrors)
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
                            while (!InRange(druidHP, DruidMinHP, DruidMaxHP) && errorProvideStatsCounter < AllowedErrors)
                            {

                                if (repeated)
                                {
                                    Console.WriteLine(ErrorOutsideStatRange);
                                    errorProvideStatsCounter++;
                                }
                                repeated = true;
                                if (errorProvideStatsCounter < AllowedErrors)
                                {
                                    druidHP = AskStat(ProvideHP, DruidMinHP, DruidMaxHP);
                                }
                            }
                            if (errorProvideStatsCounter >= AllowedErrors)
                            {
                                druidHP = DruidMinHP;
                                Console.WriteLine(ErrorOvercameErrorLimit);
                            }

                            errorProvideStatsCounter = 0;
                            repeated = false;
                            while (!InRange(druidDamage, DruidMinDamage, DruidMaxDamage) && errorProvideStatsCounter < AllowedErrors)
                            {
                                if (repeated)
                                {
                                    Console.WriteLine(ErrorOutsideStatRange);
                                    errorProvideStatsCounter++;
                                }
                                repeated = true;
                                if (errorProvideStatsCounter < AllowedErrors)
                                {
                                    druidDamage = AskStat(ProvideDamage, DruidMinDamage, DruidMaxDamage);
                                }
                            }
                            if (errorProvideStatsCounter >= AllowedErrors)
                            {
                                druidDamage = DruidMinDamage;
                                Console.WriteLine(ErrorOvercameErrorLimit);
                            }

                            errorProvideStatsCounter = 0;
                            repeated = false;
                            while (!InRange(druidDefense, DruidMinDefense, DruidMaxDefense) && errorProvideStatsCounter < AllowedErrors)
                            {
                                if (repeated)
                                {
                                    Console.WriteLine(ErrorOutsideStatRange);
                                    errorProvideStatsCounter++;
                                }
                                repeated = true;
                                if (errorProvideStatsCounter < AllowedErrors)
                                {
                                    druidDefense = AskStat(ProvideDefense, DruidMinDefense, DruidMaxDefense);
                                }
                            }
                            if (errorProvideStatsCounter >= AllowedErrors)
                            {
                                druidDefense = DruidMinDefense;
                                Console.WriteLine(ErrorOvercameErrorLimit);
                            }

                            errorProvideStatsCounter = 0;
                            repeated = false;
                            while (!InRange(druidAgility, DruidMinAgility, DruidMaxAgility) && errorProvideStatsCounter < AllowedErrors)
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
                            while (!InRange(monsterHP, MonsterMinHP, MonsterMaxHP) && errorProvideStatsCounter < AllowedErrors)
                            {

                                if (repeated)
                                {
                                    Console.WriteLine(ErrorOutsideStatRange);
                                    errorProvideStatsCounter++;
                                }
                                repeated = true;
                                if (errorProvideStatsCounter < AllowedErrors)
                                {
                                    monsterHP = AskStat(ProvideHP, MonsterMinHP, MonsterMaxHP);
                                }
                            }
                            if (errorProvideStatsCounter >= AllowedErrors)
                            {
                                monsterHP = MonsterMinHP;
                                Console.WriteLine(ErrorOvercameErrorLimit);
                            }

                            errorProvideStatsCounter = 0;
                            repeated = false;
                            while (!InRange(monsterDamage, MonsterMinDamage, MonsterMaxDamage) && errorProvideStatsCounter < AllowedErrors)
                            {
                                if (repeated)
                                {
                                    Console.WriteLine(ErrorOutsideStatRange);
                                    errorProvideStatsCounter++;
                                }
                                repeated = true;
                                if (errorProvideStatsCounter < AllowedErrors)
                                {
                                    monsterDamage = AskStat(ProvideDamage, MonsterMinDamage, MonsterMaxDamage);
                                }
                            }
                            if (errorProvideStatsCounter >= AllowedErrors)
                            {
                                monsterDamage = MonsterMinDamage;
                                Console.WriteLine(ErrorOvercameErrorLimit);
                            }

                            errorProvideStatsCounter = 0;
                            repeated = false;
                            while (!InRange(monsterDefense, MonsterMinDefense, MonsterMaxDefense) && errorProvideStatsCounter < AllowedErrors)
                            {
                                if (repeated)
                                {
                                    Console.WriteLine(ErrorOutsideStatRange);
                                    errorProvideStatsCounter++;
                                }
                                repeated = true;
                                if (errorProvideStatsCounter < AllowedErrors)
                                {
                                    monsterDefense = AskStat(ProvideDefense, MonsterMinDefense, MonsterMaxDefense);
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
                            Console.WriteLine(MenuSpliter);
                            Console.WriteLine(ShowCharacterStats, archerName);
                            archerHP = AskStat(ProvideHP, ArcherMinHP, ArcherMaxHP, GenerateRandomValue(ArcherMinHP, ArcherMaxHP));
                            archerDamage = AskStat(ProvideDamage, ArcherMinDamage, ArcherMaxDamage, GenerateRandomValue(ArcherMinDamage, ArcherMaxHP));
                            archerDefense = AskStat(ProvideDefense, ArcherMinDefense, ArcherMaxDefense, GenerateRandomValue(ArcherMinDefense, ArcherMaxDefense));
                            archerAgility = AskStat(ProvideAgility, ArcherMinAgility, ArcherMaxAgility, GenerateRandomValue(ArcherMinAgility, ArcherMaxAgility));
                            Console.WriteLine(MenuSpliter);

                            Console.WriteLine(MenuSpliter);
                            Console.WriteLine(ShowCharacterStats, barbarianName);
                            barbarianHP = AskStat(ProvideHP, BarbarianMinHP, BarbarianMaxHP, GenerateRandomValue(BarbarianMinHP, BarbarianMaxHP));
                            barbarianDamage = AskStat(ProvideDamage, BarbarianMinDamage, BarbarianMaxDamage, GenerateRandomValue(BarbarianMinDamage, BarbarianMaxDamage));
                            barbarianDefense = AskStat(ProvideDefense, BarbarianMinDefense, BarbarianMaxDefense, GenerateRandomValue(BarbarianMinDefense, BarbarianMaxDefense));
                            barbarianAgility = AskStat(ProvideAgility, BarbarianMinAgility, BarbarianMaxAgility, GenerateRandomValue(BarbarianMinAgility, BarbarianMaxAgility));
                            Console.WriteLine(MenuSpliter);

                            Console.WriteLine(MenuSpliter);
                            Console.WriteLine(ShowCharacterStats, mageName);
                            mageHP = AskStat(ProvideHP, MageMinHP, MageMaxHP, GenerateRandomValue(MageMinHP, MageMaxHP));
                            mageDamage = AskStat(ProvideDamage, MageMinDamage, MageMaxDamage, GenerateRandomValue(MageMinDamage, MageMaxDamage));
                            mageDefense = AskStat(ProvideDefense, MageMinDefense, MageMaxDefense, GenerateRandomValue(MageMinDefense, MageMaxDefense));
                            archerAgility = AskStat(ProvideAgility, MageMinAgility, MageMaxAgility, GenerateRandomValue(MageMinAgility, MageMaxAgility));
                            Console.WriteLine(MenuSpliter);

                            Console.WriteLine(MenuSpliter);
                            Console.WriteLine(ShowCharacterStats, druidName);
                            druidHP = AskStat(ProvideHP, DruidMinHP, DruidMaxHP, GenerateRandomValue(DruidMinHP, DruidMaxHP));
                            druidDamage = AskStat(ProvideDamage, DruidMinDamage, DruidMaxDamage, GenerateRandomValue(DruidMinDamage, DruidMaxDamage));
                            druidDefense = AskStat(ProvideDefense, DruidMinDefense, DruidMaxDefense, GenerateRandomValue(DruidMinDefense, DruidMaxDefense));
                            druidAgility = AskStat(ProvideAgility, DruidMinAgility, DruidMaxAgility, GenerateRandomValue(DruidMinAgility, DruidMaxAgility));
                            Console.WriteLine(MenuSpliter);

                            Console.WriteLine(MenuSpliter);
                            Console.WriteLine(ShowMonsterStats);
                            monsterHP = AskStat(ProvideHP, MonsterMinHP, MonsterMaxHP, GenerateRandomValue(MonsterMinHP, MonsterMaxHP));
                            monsterDamage = AskStat(ProvideDamage, MonsterMinDamage, MonsterMaxDamage, GenerateRandomValue(MonsterMinDamage, MonsterMaxDamage));
                            monsterDefense = AskStat(ProvideDefense, MonsterMinDefense, MonsterMaxDefense, GenerateRandomValue(MonsterMinDefense, MonsterMaxDefense));
                            Console.WriteLine(MenuSpliter);
                            break;
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
                        int[] everyoneAgilityScores = new int[] {GenerateRandomValue(0,PercentageTop)+archerAgility,
                                                                 GenerateRandomValue(0,PercentageTop)+barbarianAgility,
                                                                 GenerateRandomValue(0,PercentageTop)+mageAgility,
                                                                 GenerateRandomValue(0,PercentageTop)+druidAgility};
                        ReorderDesc(ref everyoneAgilityScores, ref turnPicker);
                        for(int i = 0; i < everyoneAgilityScores.Length; i++)
                        {
                            string nameActualTurn = turnPicker[i];

                            errorProvideNumFightMenuCounter = 0;
                            fightOption = 0;
                            choosenOnCooldown = true;
                            if (nameActualTurn.Equals(archerName))
                            {
                                while (IsActorAlive(archerTurnHP) && IsActorAlive(monsterTurnHP) && errorProvideNumFightMenuCounter < AllowedErrors && (!InRange(fightOption, MinMenusOption, MaxFightMenuOpt) || choosenOnCooldown))
                                {
                                    choosenOnCooldown = false;
                                    archerTurnDefense = archerDefense;

                                    Console.WriteLine(MenuSpliter);
                                    formatedMenu = FormatString(FightMenu, archerSkillCooldown == 0 ? SkillReady : $"{archerSkillCooldown}");
                                    Console.Write(BuildMenu(formatedMenu.Split(LineJumper), GeneralAskInputMsg, $"{ArcherIcon}{LineJumper}{FormatString(CharacterTurn, archerName)}"));
                                    fightOption = Convert.ToInt32(Console.ReadLine());
                                    switch (fightOption)
                                    {
                                        case AtackOption:
                                            critRollNumber = CritFail(FailChance, CritChance);
                                            AttackOption(archerDamage * critRollNumber, monsterDefense, ref monsterTurnHP, FormatString(critRollNumber switch
                                            {
                                                FailResponse => ArcherMissMsg,
                                                CritResponse => ArcherCritsMsg,
                                                _ => ArcherAttackMsg
                                            }, archerName) + GeneralAttackSection);
                                            break;
                                        case DefendOption:
                                            DefenseAction(ref archerTurnDefense, archerTurnDefense + archerDefense);
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
                                    if (!choosenOnCooldown && InRange(fightOption, MinMenusOption, MaxFightMenuOpt))
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
                                while (IsActorAlive(barbarianTurnHP) && IsActorAlive(monsterTurnHP) && errorProvideNumFightMenuCounter < AllowedErrors && (!InRange(fightOption, MinMenusOption, MaxFightMenuOpt) || choosenOnCooldown))
                                {
                                    choosenOnCooldown = false;
                                    barbarianTurnDefense = barbarianDefense;

                                    Console.WriteLine(MenuSpliter);
                                    formatedMenu = FormatString(FightMenu, barbarianSkillCooldown == 0 ? SkillReady : $"{barbarianSkillCooldown}");
                                    Console.Write(BuildMenu(formatedMenu.Split(LineJumper), GeneralAskInputMsg, $"{BarbarianIcon}{LineJumper}{FormatString(CharacterTurn, barbarianName)}"));
                                    fightOption = Convert.ToInt32(Console.ReadLine());
                                    switch (fightOption)
                                    {
                                        case AtackOption:
                                            critRollNumber = CritFail(FailChance, CritChance);
                                            AttackOption(barbarianDamage * critRollNumber, monsterDefense, ref monsterTurnHP, FormatString(critRollNumber switch
                                            {
                                                FailResponse => BarbarianMissMsg,
                                                CritResponse => BarbarianCritsMsg,
                                                _ => BarbarianAttackMsg
                                            }, archerName) + GeneralAttackSection);
                                            break;
                                        case DefendOption:
                                            DefenseAction(ref barbarianTurnDefense, barbarianTurnDefense + barbarianDefense);
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
                                    if (!choosenOnCooldown && InRange(fightOption, MinMenusOption, MaxFightMenuOpt))
                                    {
                                        if (barbarianPerfectDefense > 0)
                                        {
                                            DefenseAction(ref barbarianTurnDefense, PercentageTop);
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
                                while (IsActorAlive(mageTurnHP) && IsActorAlive(monsterTurnHP) && errorProvideNumFightMenuCounter < AllowedErrors && (!InRange(fightOption, MinMenusOption, MaxFightMenuOpt) || choosenOnCooldown))
                                {
                                    choosenOnCooldown = false;
                                    mageTurnDefense = mageDefense;
                                    Console.WriteLine(MenuSpliter);
                                    formatedMenu = FormatString(FightMenu, mageSkillCooldown == 0 ? SkillReady : $"{mageSkillCooldown}");
                                    Console.Write(BuildMenu(formatedMenu.Split(LineJumper), GeneralAskInputMsg, $"{MageIcon}{LineJumper}{FormatString(CharacterTurn, mageName)}"));
                                    fightOption = Convert.ToInt32(Console.ReadLine());
                                    switch (fightOption)
                                    {
                                        case AtackOption:
                                            critRollNumber = CritFail(FailChance, CritChance);
                                            AttackOption(mageDamage * critRollNumber, monsterDefense, ref monsterTurnHP, FormatString(critRollNumber switch
                                            {
                                                FailResponse => MageMissMsg,
                                                CritResponse => MageCritsMsg,
                                                _ => MageAttackMsg,
                                            }, mageName) + GeneralAttackSection);
                                            break;
                                        case DefendOption:
                                            DefenseAction(ref mageTurnDefense, mageTurnDefense + mageDefense);
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
                                                AttackOption(mageDamage * MageSuperAttackMult, monsterDefense, ref monsterTurnHP, FormatString(MageSkill, mageName) + GeneralAttackSection); ;
                                            }
                                            break;
                                        default:
                                            errorProvideNumFightMenuCounter++;
                                            Console.WriteLine(ErrorMenuOptionOutsideRange);
                                            break;
                                    }
                                    if (!choosenOnCooldown && InRange(fightOption, MinMenusOption, MaxFightMenuOpt))
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
                                while (IsActorAlive(druidTurnHP) && IsActorAlive(monsterTurnHP) && errorProvideNumFightMenuCounter < AllowedErrors && (!InRange(fightOption, MinMenusOption, MaxFightMenuOpt) || choosenOnCooldown))
                                {
                                    choosenOnCooldown = false;
                                    druidTurnDefense = druidDefense;

                                    Console.WriteLine(MenuSpliter);
                                    formatedMenu = FormatString(FightMenu, druidSkillCooldown == 0 ? SkillReady : $"{druidSkillCooldown}");
                                    Console.Write(BuildMenu(formatedMenu.Split(LineJumper), GeneralAskInputMsg, $"{DruidIcon}{LineJumper}{FormatString(CharacterTurn, druidName)}"));
                                    fightOption = Convert.ToInt32(Console.ReadLine());
                                    switch (fightOption)
                                    {
                                        case AtackOption:
                                            critRollNumber = CritFail(FailChance, CritChance);
                                            AttackOption(druidDamage * critRollNumber, monsterDefense, ref monsterTurnHP, critRollNumber switch
                                            {
                                                FailResponse => DruidMissMsg,
                                                CritResponse => DruidCritsMsg,
                                                _ => DruidAttackMsg,
                                            } + GeneralAttackSection);
                                            break;
                                        case DefendOption:
                                            DefenseAction(ref druidTurnDefense, druidTurnDefense + druidDefense);
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
                                                if (IsActorAlive(archerTurnHP))
                                                {
                                                    HealTarget(ref archerTurnHP, DruidHealingAmount, archerHP);
                                                    Console.WriteLine(DruidHealsCharacters, archerName, archerTurnHP);
                                                }
                                                if (IsActorAlive(barbarianTurnHP))
                                                {
                                                    HealTarget(ref barbarianTurnHP, DruidHealingAmount, barbarianHP);
                                                    Console.WriteLine(DruidHealsCharacters, barbarianName, barbarianTurnHP);
                                                }
                                                if (IsActorAlive(mageTurnHP))
                                                {
                                                    HealTarget(ref mageTurnHP, DruidHealingAmount, mageHP);
                                                    Console.WriteLine(DruidHealsCharacters, mageName, mageTurnHP);
                                                }
                                                HealTarget(ref druidTurnHP, DruidHealingAmount, druidHP);
                                                Console.WriteLine(DruidHealsCharacters, druidName, druidTurnHP);
                                                druidSkillCooldown = GlobalSpecialSkillCooldown;
                                            }
                                            break;
                                        default:
                                            errorProvideNumFightMenuCounter++;
                                            Console.WriteLine(ErrorMenuOptionOutsideRange);
                                            break;
                                    }
                                    if (!choosenOnCooldown && InRange(fightOption, MinMenusOption, MaxFightMenuOpt))
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
                        if (IsActorAlive(monsterTurnHP) && monsterStun <= 0)
                        {
                            Console.WriteLine(MenuSpliter);
                            Console.WriteLine(MonsterIcon);
                            Console.WriteLine(MonsterAttacks);
                            if (IsActorAlive(archerTurnHP))
                            {
                                damageAmount = CalcAttackDamage(monsterDamage, archerTurnDefense);
                                archerTurnHP -= damageAmount;
                                Console.WriteLine(MonsterCharDamage, monsterDamage, damageAmount, archerTurnHP, archerName);
                                if (!IsActorAlive(archerTurnHP))
                                {
                                    Console.WriteLine(CharDead, archerName);
                                }
                            }
                            if (IsActorAlive(barbarianTurnHP))
                            {
                                damageAmount = CalcAttackDamage(monsterDamage, barbarianTurnDefense);
                                barbarianTurnHP -= damageAmount;
                                Console.WriteLine(MonsterCharDamage, monsterDamage, damageAmount, barbarianTurnHP, barbarianName);
                                if (!IsActorAlive(barbarianTurnHP))
                                {
                                    Console.WriteLine(CharDead, barbarianName);
                                }

                            }
                            if (IsActorAlive(mageTurnHP))
                            {
                                damageAmount = CalcAttackDamage(monsterDamage, mageTurnDefense);
                                mageTurnHP -= damageAmount;
                                Console.WriteLine(MonsterCharDamage, monsterDamage, damageAmount, mageTurnHP, mageName);
                                if (!IsActorAlive(mageTurnHP))
                                {
                                    Console.WriteLine(CharDead, mageName);
                                }
                            }
                            if (IsActorAlive(druidTurnHP))
                            {
                                damageAmount = CalcAttackDamage(monsterDamage, druidTurnDefense);
                                druidTurnHP -= damageAmount;
                                Console.WriteLine(MonsterCharDamage, monsterDamage, damageAmount, druidTurnHP, druidName);
                                if (!IsActorAlive(druidTurnHP))
                                {
                                    Console.WriteLine(CharDead, druidName);
                                }
                            }
                            Console.WriteLine(MenuSpliter);
                        }
                        else if (IsActorAlive(monsterTurnHP) && monsterStun > 0)
                        {
                            Console.WriteLine(MenuSpliter);
                            Console.WriteLine(MonsterIcon);
                            monsterStun--;
                            Console.WriteLine(MonsterIsStuned, archerName);
                            Console.WriteLine(MenuSpliter);
                        }
                        ShowValuesDesc(new int[] { archerTurnHP, barbarianTurnHP, mageTurnHP, druidTurnHP }, new string[] { archerName, barbarianName, mageName, druidName }, ShowHealthMsg);
                    } while (IsActorAlive(monsterTurnHP) && (!AreActorGroupDead(new int[] { archerTurnHP, barbarianTurnHP, mageTurnHP, druidTurnHP })));
                    Console.WriteLine(!IsActorAlive(monsterTurnHP) ? HeroesWin : MonsterWins);
                    
                }
            } while (menuOption != ExitGameOption && errorProvideNumStartMenuCounter < AllowedErrors);
            if (errorProvideNumStartMenuCounter == AllowedErrors)
            {
                Console.WriteLine(ErrorOvercameStartErrorLimit);
            }
        }


        public static string BuildMenu(string[] options, string askmsg)
        {
            const char LineJumper = '\n';
            string menu="";
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
            menu += msg+LineJumper;
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
        public static void AttackOption(int attackerDMG, int targetDefense, ref int targetHP, string msg)
        {
            int damageAmount = CalcAttackDamage(attackerDMG, targetDefense);
            targetHP -= damageAmount;
            Console.WriteLine(msg, attackerDMG, damageAmount, targetHP);
        }
        public static void DefenseAction(ref int actorDefense, int newDefenseValue)
        {
            actorDefense = newDefenseValue;
        }
        public static void HealTarget(ref int targetHP, int healingAmount, int targetMaxHP)
        {
            targetHP += healingAmount;
            if (targetHP > targetMaxHP)
            {
                targetHP = targetMaxHP;
            }
        }
        public static int CritFail(int chanceFail, int chanceCrit)
        {
            int rngValue = GenerateRandomValue(0, 100);

            if (rngValue <= chanceFail)
            {
                return 0;
            }
            else if (rngValue >= (100 - chanceCrit))
            {
                return 2;
            }
            return 1;
        }
        public static int AskStat(string AskMsg, int minPosibleStat, int maxPosibleStat)
        {
            Console.Write(AskMsg, minPosibleStat, maxPosibleStat);
            return Convert.ToInt32(Console.ReadLine());
        }
        public static int AskStat(string AskMsg, int minPosibleStat, int maxPosibleStat, int autoAssign)
        {
            Console.WriteLine(AskMsg + autoAssign, minPosibleStat, maxPosibleStat);
            return autoAssign;
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
            for(int i = 0; i< texts.Length; i++)
            {
                texts[i] = texts[i].Trim();
            }
            return texts;
        }
        public static void ShowValuesDesc(int[] values, string[] characterPerValue, string mainMsg)
        {
            ReorderDesc(ref values, ref characterPerValue);
            for (int i = 0; i < values.Length; i++)
            {
                Console.WriteLine(mainMsg, characterPerValue[i], values[i]);
            }
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