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
            const int FailResponse = -1;
            const int HitResponse = 0;
            const int CritResponse = 1;
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
            const int MageSuperAttackMult = 3;
            //DruidStatsLimit
            const int DruidMinHP = 2000;
            const int DruidMaxHP = 2500;
            const int DruidMinDamage = 70;
            const int DruidMaxDamage = 120;
            const int DruidMinDefense = 25;
            const int DruidMaxDefense = 40;
            const int DruidHealingAmount = 500;
            //MonsterStatsLimit
            const int MonsterMinHP = 9000;
            const int MonsterMaxHP = 12000;
            const int MonsterMinDamage = 250;
            const int MonsterMaxDamage = 400;
            const int MonsterMinDefense = 20;
            const int MonsterMaxDefense = 30;
            const string LineJumper = "\n";
            const string ReplaceIcon = "{0}";
            const string ErrorMenuOptionOutsideRange = "Opcion seleccionado en el menu esta fuera del rango permitido, elige una de las opciones que se muestran en pantalla";
            const string ErrorOvercameErrorLimit = "Se ha superado el limite de errores, debera de reintroducir los valores en este apartado";
            const string ErrorOvercameSecondErrorLimit = "Ha cometido 3 errores 3 veces, vuelve al principio";
            const string ErrorOutsideStatRange = "El valor esta fuera del rango solicitado";
            const string ErrorOvercameStartErrorLimit = "Se ha superado el limite de errores en el menu principal, el programa finalizara por ello";
            const string ErrorOvercameFightErrorLimit = "Ha cometido demasiados errores, debera volver al menu principal y empezar de zero.";
            const string ErrorChoosenUnderCooldown = "La habilidad aun estaba bajo tiempo de espera, el heroe es incapaz de utilizarlo";
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
            const string SkillReady = "Listo";
            const string AskStatAssignMethod = "Elige la dificultad";
            const string ShowArcherStats = "Stats de la arquera:";
            const string ShowBarbarianStats = "Stats del barbaro:";
            const string ShowMageStats = "Stats del mago:";
            const string ShowDruidStats = "Stats del druida:";
            const string ShowMonsterStats = "Stats del monstruo:";
            const string ArcherStatAssign = "Proporciona los stats de la arquera";
            const string BarbarianStatAssign = "Proporciona los stats del barbaro";
            const string MageStatAssign = "Proporciona los stats del mago";
            const string DruidStatAssign = "Proporciona los stats del druida";
            const string MonsterStatAssign = "Proporciona los stats del monstruo";
            const string ArcherTurn = "Es el turno de la arquera";
            const string BarbarianTurn = "Es el turno del barbaro";
            const string MageTurn = "Es el turno del mago";
            const string DruidTurn = "Es el turno del druida";
            const string ArcherAttackMsg = "La arquera lanza una flecha al monstruo causando {0} puntos de daño, el monstruo se defiende, solo causando {1} puntos de daño, al monstruo le queda {2} puntos de vida";
            const string ArcherCritsMsg = "La arquera lanza una flecha a un punto critico del monstruo causando {0} puntos de daño, el monstruo se defiende, solo causando {}";
            const string ArcherProtectsMsg = "La arquera se prepara para el impacto del siguiente ataque";
            const string ArcherSkill = "La arquera immobiliza al monstruo con una flecha en la pierna, el monstruo es incapaz de moverse por dos turnos";
            const string BarbarianAttackMsg = "El barbaro se avalanza con su hacha e impacta, causando {0} puntos de daño, el monstruo se defiende, solo causando {1} puntos de daño, al monstruo le queda {2} puntos de vida";
            const string BarbarianProtectsMsg = "El barbaro se prepara para recivir el impacto del siguiente ataque";
            const string BarbarianSkill = "El barbaro toma una postura defensiva impecable, en los proximos 3 turnos su defensa es perfecta y no puede recivir daño";
            const string MageAttack = "El mago prepara y lanza un rayo magico al monstruo causando {0} puntos de daño, el monstruo se defiende, solo causando {1} puntos de daño, al monstruo le queda {2} puntos de vida";
            const string MageProtects = "El mago se prepara para el impacto del siguiente ataque";
            const string MageSkill = "El mago decide tirar logica por la ventana y grita 'FIREBALL AND ONLY FIREBALL' y lanza una tormenta de bolas de fuego causando {0} puntos de daño, el monstruo se defiende, solo causando {1} puntos de daño, al monstruo le queda {2} puntos de vida";
            const string DruidAttack = "El druida da un mamporro con su baston al monstruo causando {0} puntos de daño, el monstruo se defiende, solo causando {1} puntos de daño, al monstruo le queda {2} puntos de vida";
            const string DruidProtects = "El druida se prepara para el impacto del siguiente ataque";
            const string DruidSkill = "El druida prepara un hechizo curativo que envuelve a todos los aventureros que aun quedan en pie y todos estos son sanados {0} puntos de salud";
            const string DruidHealsArcher = "La arquera ahora posee {0} puntos de salud";
            const string DruidHealsBarbarian = "El barbaro ahora posee {0} puntos de salud";
            const string DruidHealsMage = "El mago ahora posee {0} puntos de salud";
            const string DruidHealsDruid = "El druida ahora posee {0} puntos de salud";
            const string MonsterAttacks = "El monstruo lanza un zarpazo, alcanzando a todos los miembros del grupo";
            const string MonsterArcherDamage = "La arquera recive {0} puntos de daño,la arquera se defiende, solo causando {1} puntos de daño, a la arquera le queda {2} puntos de vida";
            const string ArcherDead = "La arquera cae en combate";
            const string MonsterBarbarianDamage = "El barbaro recive {0} puntos de daño, el barbaro se defiende, solo causando {1} puntos de daño al barbaro, le queda {2} puntos de vida";
            const string BarbarianDead = "El barbaro cae en combate";
            const string MonsterMageDamage = "El mago recive {0} puntos de daño, el mago se defiende, solo causando {1} puntos de daño al mago le queda {2} puntos de vida";
            const string MageDead = "El mago cae en combate";
            const string MonsterDruidDamage = "El druida recive {0} puntos de daño, el druida se defiende, solo causando {1} puntos de daño, al druida le queda {2} puntos de vida";
            const string DruidDead = "El druida cae en combate";
            const string MonsterIsStuned = "El monstruo aun sigue siendo incapaz de moverse del impacto de la arquera";
            const string ShowHealthMsg = "La salud de {0} es: {1}";
            const string HeroesWin = "Los heroes consiguen derrotar al monstruo";
            const string MonsterWins = "Los heroes fallecen intentando luchar al monstruo, tu mision ha sido un fracaso";

            bool repeated;
            bool repeatedSecondLoop;
            bool choosenOnCooldown=false;
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
            int archerTurnDefense=0;
            int archerSkillCooldown;
            //BarbarianStats
            int barbarianHP;
            int barbarianTurnHP;
            int barbarianDamage;
            int barbarianDefense = 0;
            int barbarianTurnDefense=0;
            int barbarianSkillCooldown = 0;
            int barbarianPerfectDefense = 0;
            //MageStats
            int mageHP;
            int mageTurnHP;
            int mageDamage;
            int mageDefense = 0;
            int mageTurnDefense=0;
            int mageSkillCooldown = 0;
            //DruidStats
            int druidHP;
            int druidTurnHP;
            int druidDamage;
            int druidDefense = 0;
            int druidTurnDefense = 0;
            int druidSkillCooldown = 0;
            //MonsterStats
            int monsterHP;
            int monsterTurnHP;
            int monsterDamage;
            int monsterDefense = 0;
            int monsterStun = 0;
            string formatedMenu;
            string archerName = "ArcherPlaceholderName";
            string barbarianName = "BarbarianPlaceholderName";
            string mageName = "MagePlaceholderName";
            string druidName = "DruidPlaceholderName";
            
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
                        menuOption = BuildMenu(StartingMenu.Split(LineJumper),GeneralAskInputMsg);
                        Console.WriteLine(MenuSpliter);
                    }
                } while (!InRange(menuOption, MinMenusOption, MaxStartingMenuOpt) && errorProvideNumStartMenuCounter<AllowedErrors);

                if (menuOption == StartGameOption)
                {
                    repeated = false;
                    do
                    {
                        if (repeated)
                        {
                            Console.WriteLine(ErrorMenuOptionOutsideRange);
                        }
                        repeated = true;
                        Console.WriteLine(MenuSpliter);
                        dificultyOption = BuildMenu(StatAssignMenu.Split(LineJumper), GeneralAskInputMsg, AskStatAssignMethod);
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
                            Console.WriteLine(ShowArcherStats);
                            archerHP = AskStat(ProvideHP, ArcherMinHP, ArcherMaxHP, ArcherMaxHP);
                            archerDamage = AskStat(ProvideDamage, ArcherMinDamage, ArcherMaxDamage, ArcherMaxDamage);
                            archerDefense = AskStat(ProvideDefense, ArcherMinDefense, ArcherMaxDefense, ArcherMaxDefense);
                            Console.WriteLine(MenuSpliter);

                            Console.WriteLine(MenuSpliter);
                            Console.WriteLine(ShowBarbarianStats);
                            barbarianHP = AskStat(ProvideHP, BarbarianMinHP, BarbarianMaxHP, BarbarianMaxHP);
                            barbarianDamage = AskStat(ProvideDamage, BarbarianMinDamage, BarbarianMaxDamage, BarbarianMaxDamage);
                            barbarianDefense = AskStat(ProvideDefense, BarbarianMinDefense, BarbarianMaxDefense, BarbarianMaxDefense);
                            Console.WriteLine(MenuSpliter);

                            Console.WriteLine(MenuSpliter);
                            Console.WriteLine(ShowMageStats);
                            mageHP = AskStat(ProvideHP, MageMinHP, MageMaxHP, MageMaxHP);
                            mageDamage = AskStat(ProvideDamage, MageMinDamage, MageMaxDamage, MageMaxDamage);
                            mageDefense = AskStat(ProvideDefense, MageMinDefense, MageMaxDefense, MageMaxDefense);
                            Console.WriteLine(MenuSpliter);

                            Console.WriteLine(MenuSpliter);
                            Console.WriteLine(ShowDruidStats);
                            druidHP = AskStat(ProvideHP, DruidMinHP, DruidMaxHP, DruidMinHP);
                            druidDamage = AskStat(ProvideDamage, DruidMinDamage, DruidMaxDamage, DruidMaxDamage);
                            druidDefense = AskStat(ProvideDefense, DruidMinDefense, DruidMaxDefense, DruidMaxDefense);
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
                            Console.WriteLine(ShowArcherStats);
                            archerHP = AskStat(ProvideHP, ArcherMinHP, ArcherMaxHP, ArcherMinHP);
                            archerDamage = AskStat(ProvideDamage, ArcherMinDamage, ArcherMaxDamage,ArcherMinDamage);
                            archerDefense = AskStat(ProvideDefense, ArcherMinDefense, ArcherMaxDefense,ArcherMinDefense);
                            Console.WriteLine(MenuSpliter);

                            Console.WriteLine(MenuSpliter);
                            Console.WriteLine(ShowBarbarianStats);
                            barbarianHP = AskStat(ProvideHP, BarbarianMinHP, BarbarianMaxHP, BarbarianMinHP);
                            barbarianDamage = AskStat(ProvideDamage, BarbarianMinDamage, BarbarianMaxDamage, BarbarianMinDamage);
                            barbarianDefense = AskStat(ProvideDefense, BarbarianMinDefense, BarbarianMaxDefense, BarbarianMinDefense);
                            Console.WriteLine(MenuSpliter);

                            Console.WriteLine(MenuSpliter);
                            Console.WriteLine(ShowMageStats);
                            mageHP = AskStat(ProvideHP, MageMinHP, MageMaxHP, MageMinHP);
                            mageDamage = AskStat(ProvideDamage, MageMinDamage, MageMaxDamage, MageMinDamage);
                            mageDefense = AskStat(ProvideDefense, MageMinDefense, MageMaxDefense, MageMinDefense);
                            Console.WriteLine(MenuSpliter);

                            Console.WriteLine(MenuSpliter);
                            Console.WriteLine(ShowDruidStats);
                            druidHP = AskStat(ProvideHP, DruidMinHP, DruidMaxHP, DruidMinHP);
                            druidDamage = AskStat(ProvideDamage, DruidMinDamage, DruidMaxDamage, DruidMinDamage);
                            druidDefense = AskStat(ProvideDefense, DruidMinDefense, DruidMaxDefense, DruidMinDefense);
                            Console.WriteLine(MenuSpliter);

                            Console.WriteLine(MenuSpliter);
                            Console.WriteLine(ShowMonsterStats);
                            monsterHP = AskStat(ProvideHP, MonsterMinHP, MonsterMaxHP, MonsterMaxHP);
                            monsterDamage = AskStat(ProvideDamage, MonsterMinDamage, MonsterMaxDamage, MonsterMaxDamage);
                            monsterDefense = AskStat(ProvideDefense, MonsterMinDefense, MonsterMaxDefense, MonsterMaxDefense);
                            Console.WriteLine(MenuSpliter);
                            break;
                        case CustomModeOption:
                            //Asignacion stats arquera
                            repeated = false;
                            while (errorProvideAllStatsCounter < AllowedErrors && !InRange(archerDefense, ArcherMinDefense, ArcherMaxDefense))
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
                                while (!InRange(archerHP, ArcherMinHP, ArcherMaxHP) && errorProvideStatsCounter < AllowedErrors && errorProvideAllStatsCounter < AllowedErrors)
                                {

                                    if (repeatedSecondLoop)
                                    {
                                        Console.WriteLine(ErrorOutsideStatRange);
                                        errorProvideStatsCounter++;
                                    }
                                    repeatedSecondLoop = true;
                                    if (errorProvideStatsCounter < AllowedErrors)
                                    {
                                        archerHP = AskStat(ProvideHP, ArcherMinHP, ArcherMaxHP);
                                    }
                                }
                                if (errorProvideStatsCounter < AllowedErrors)
                                {
                                    errorProvideStatsCounter = 0;
                                }
                                repeatedSecondLoop = false;
                                while (!InRange(archerDamage, ArcherMinDamage, ArcherMaxDamage) && errorProvideStatsCounter < AllowedErrors && errorProvideAllStatsCounter < AllowedErrors)
                                {
                                    if (repeatedSecondLoop)
                                    {
                                        Console.WriteLine(ErrorOutsideStatRange);
                                        errorProvideStatsCounter++;
                                    }
                                    repeatedSecondLoop = true;
                                    if (errorProvideStatsCounter < AllowedErrors)
                                    {
                                        archerDamage = AskStat(ProvideDamage, ArcherMinDamage, ArcherMaxDamage);
                                    }
                                }
                                if (errorProvideStatsCounter < AllowedErrors)
                                {
                                    errorProvideStatsCounter = 0;
                                }
                                repeatedSecondLoop = false;
                                while (!InRange(archerDefense, ArcherMinDefense, ArcherMaxDefense) && errorProvideStatsCounter < AllowedErrors && errorProvideAllStatsCounter < AllowedErrors)
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
                                        archerDefense = AskStat(ProvideDefense, ArcherMinDefense, ArcherMaxDefense);
                                    }
                                }
                                Console.WriteLine(MenuSpliter);
                            }

                            //Asignacion de stats barbaro
                            repeated = false;
                            if (errorProvideAllStatsCounter < AllowedErrors)
                            {
                                errorProvideAllStatsCounter = 0;
                            }
                            while (errorProvideAllStatsCounter < AllowedErrors && !InRange(barbarianDefense, BarbarianMinDefense, BarbarianMaxDefense))
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
                                if (errorProvideAllStatsCounter < AllowedErrors)
                                {
                                    Console.WriteLine(MenuSpliter);
                                    Console.WriteLine(BarbarianStatAssign);
                                }

                                repeated = true;
                                repeatedSecondLoop = false;
                                errorProvideStatsCounter = 0;
                                while (!InRange(barbarianHP, BarbarianMinHP, BarbarianMaxHP) && errorProvideStatsCounter < AllowedErrors && errorProvideAllStatsCounter < AllowedErrors)
                                {

                                    if (repeatedSecondLoop)
                                    {
                                        Console.WriteLine(ErrorOutsideStatRange);
                                        errorProvideStatsCounter++;
                                    }
                                    repeatedSecondLoop = true;
                                    if (errorProvideStatsCounter < AllowedErrors)
                                    {
                                        barbarianHP = AskStat(ProvideHP, BarbarianMinHP, BarbarianMaxHP);
                                    }
                                }
                                if (errorProvideStatsCounter < AllowedErrors)
                                {
                                    errorProvideStatsCounter = 0;
                                }
                                repeatedSecondLoop = false;
                                while (!InRange(barbarianDamage, BarbarianMinDamage, BarbarianMaxDamage) && errorProvideStatsCounter < AllowedErrors && errorProvideAllStatsCounter < AllowedErrors)
                                {
                                    if (repeatedSecondLoop)
                                    {
                                        Console.WriteLine(ErrorOutsideStatRange);
                                        errorProvideStatsCounter++;
                                    }
                                    repeatedSecondLoop = true;
                                    if (errorProvideStatsCounter < AllowedErrors)
                                    {
                                        barbarianDamage = AskStat(ProvideDamage, BarbarianMinDamage, BarbarianMaxDamage);
                                    }
                                }
                                if (errorProvideStatsCounter < AllowedErrors)
                                {
                                    errorProvideStatsCounter = 0;
                                }
                                repeatedSecondLoop = false;
                                while (!InRange(barbarianDefense, BarbarianMinDefense, BarbarianMaxDefense) && errorProvideStatsCounter < AllowedErrors && errorProvideAllStatsCounter < AllowedErrors)
                                {
                                    if (repeatedSecondLoop)
                                    {
                                        Console.WriteLine(ErrorOutsideStatRange);
                                        errorProvideStatsCounter++;
                                    }
                                    repeatedSecondLoop = true;
                                    if (errorProvideStatsCounter < AllowedErrors)
                                    {
                                        barbarianDefense = AskStat(ProvideDefense, BarbarianMinDefense, BarbarianMaxDefense);
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
                            while (errorProvideAllStatsCounter < AllowedErrors && !InRange(mageDefense, MageMinDefense, MageMaxDefense))
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
                                        mageHP = AskStat(ProvideHP, MageMinHP, MageMaxHP);
                                    }
                                }
                                if (errorProvideStatsCounter < AllowedErrors)
                                {
                                    errorProvideStatsCounter = 0;
                                }
                                repeatedSecondLoop = false;
                                while (!InRange(mageDamage, MageMinDamage, MageMaxDamage) && errorProvideStatsCounter < AllowedErrors && errorProvideAllStatsCounter < AllowedErrors)
                                {
                                    if (repeatedSecondLoop)
                                    {
                                        Console.WriteLine(ErrorOutsideStatRange);
                                        errorProvideStatsCounter++;
                                    }
                                    repeatedSecondLoop = true;
                                    if (errorProvideStatsCounter < AllowedErrors)
                                    {
                                        mageDamage = AskStat(ProvideDamage, MageMinDamage, MageMaxDamage);
                                    }
                                }
                                if (errorProvideStatsCounter < AllowedErrors)
                                {
                                    errorProvideStatsCounter = 0;
                                }
                                repeatedSecondLoop = false;
                                while (!InRange(mageDefense, MageMinDefense, MageMaxDefense) && errorProvideStatsCounter < AllowedErrors && errorProvideAllStatsCounter < AllowedErrors)
                                {
                                    if (repeatedSecondLoop)
                                    {
                                        Console.WriteLine(ErrorOutsideStatRange);
                                        errorProvideStatsCounter++;
                                    }
                                    repeatedSecondLoop = true;
                                    if (errorProvideStatsCounter < AllowedErrors)
                                    {
                                        mageDefense = AskStat(ProvideDefense, MageMinDefense, MageMaxDefense);
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
                            while (errorProvideAllStatsCounter < AllowedErrors && !InRange(druidDefense, DruidMinDefense, DruidMaxDefense))
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
                                while (!InRange(druidHP, DruidMinHP, DruidMaxHP) && errorProvideStatsCounter < AllowedErrors && errorProvideAllStatsCounter < AllowedErrors)
                                {

                                    if (repeatedSecondLoop)
                                    {
                                        Console.WriteLine(ErrorOutsideStatRange);
                                        errorProvideStatsCounter++;
                                    }
                                    repeatedSecondLoop = true;
                                    if (errorProvideStatsCounter < AllowedErrors)
                                    {
                                        druidHP = AskStat(ProvideHP, DruidMinHP, DruidMaxHP);
                                    }
                                }
                                if (errorProvideStatsCounter < AllowedErrors)
                                {
                                    errorProvideStatsCounter = 0;
                                }
                                repeatedSecondLoop = false;
                                while (!InRange(druidDamage, DruidMinDamage, DruidMaxDamage) && errorProvideStatsCounter < AllowedErrors && errorProvideAllStatsCounter < AllowedErrors)
                                {
                                    if (repeatedSecondLoop)
                                    {
                                        Console.WriteLine(ErrorOutsideStatRange);
                                        errorProvideStatsCounter++;
                                    }
                                    repeatedSecondLoop = true;
                                    if (errorProvideStatsCounter < AllowedErrors)
                                    {
                                        druidDamage = AskStat(ProvideDamage, DruidMinDamage, DruidMaxDamage);
                                    }
                                }
                                if (errorProvideStatsCounter < AllowedErrors)
                                {
                                    errorProvideStatsCounter = 0;
                                }
                                repeatedSecondLoop = false;
                                while (!InRange(druidDefense, DruidMinDefense, DruidMaxDefense) && errorProvideStatsCounter < AllowedErrors && errorProvideAllStatsCounter < AllowedErrors)
                                {
                                    if (repeatedSecondLoop)
                                    {
                                        Console.WriteLine(ErrorOutsideStatRange);
                                        errorProvideStatsCounter++;
                                    }
                                    repeatedSecondLoop = true;
                                    if (errorProvideStatsCounter < AllowedErrors)
                                    {
                                        druidDefense = AskStat(ProvideDefense, DruidMinDefense, DruidMaxDefense);
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
                            while (errorProvideAllStatsCounter < AllowedErrors && !InRange(monsterDefense, MonsterMinDefense, MonsterMaxDefense))
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
                                while (!InRange(monsterHP, MonsterMinHP, MonsterMaxHP) && errorProvideStatsCounter < AllowedErrors && errorProvideAllStatsCounter < AllowedErrors)
                                {

                                    if (repeatedSecondLoop)
                                    {
                                        Console.WriteLine(ErrorOutsideStatRange);
                                        errorProvideStatsCounter++;
                                    }
                                    repeatedSecondLoop = true;
                                    if (errorProvideStatsCounter < AllowedErrors)
                                    {
                                        monsterHP = AskStat(ProvideHP, MonsterMinHP, MonsterMaxHP);
                                    }
                                }
                                if (errorProvideStatsCounter < AllowedErrors)
                                {
                                    errorProvideStatsCounter = 0;
                                }
                                repeatedSecondLoop = false;
                                while (!InRange(monsterDamage, MonsterMinDamage, MonsterMaxDamage) && errorProvideStatsCounter < AllowedErrors && errorProvideAllStatsCounter < AllowedErrors)
                                {
                                    if (repeatedSecondLoop)
                                    {
                                        Console.WriteLine(ErrorOutsideStatRange);
                                        errorProvideStatsCounter++;
                                    }
                                    repeatedSecondLoop = true;
                                    if (errorProvideStatsCounter < AllowedErrors)
                                    {
                                        monsterDamage = AskStat(ProvideDamage, MonsterMinDamage, MonsterMaxDamage);
                                    }
                                }
                                if (errorProvideStatsCounter < AllowedErrors)
                                {
                                    errorProvideStatsCounter = 0;
                                }
                                repeatedSecondLoop = false;
                                while (!InRange(monsterDefense, MonsterMinDefense, MonsterMaxDefense) && errorProvideStatsCounter < AllowedErrors && errorProvideAllStatsCounter < AllowedErrors)
                                {
                                    if (repeatedSecondLoop)
                                    {
                                        Console.WriteLine(ErrorOutsideStatRange);
                                        errorProvideStatsCounter++;
                                    }
                                    repeatedSecondLoop = true;
                                    if (errorProvideStatsCounter < AllowedErrors)
                                    {
                                        monsterDefense = AskStat(ProvideDefense, MonsterMinDefense, MonsterMaxDefense);
                                    }
                                }
                                Console.WriteLine(MenuSpliter);
                            }
                            break;
                        case RandomModeOption:
                            Console.WriteLine(MenuSpliter);
                            Console.WriteLine(ShowArcherStats);
                            archerHP = AskStat(ProvideHP, ArcherMinHP, ArcherMaxHP, GenerateRandomValue(ArcherMinHP, ArcherMaxHP));
                            archerDamage = AskStat(ProvideDamage, ArcherMinDamage, ArcherMaxDamage, GenerateRandomValue(ArcherMinDamage, ArcherMaxHP));
                            archerDefense = AskStat(ProvideDefense, ArcherMinDefense, ArcherMaxDefense, GenerateRandomValue(ArcherMinDefense, ArcherMaxDefense));
                            Console.WriteLine(MenuSpliter);

                            Console.WriteLine(MenuSpliter);
                            Console.WriteLine(ShowBarbarianStats);
                            barbarianHP = AskStat(ProvideHP, BarbarianMinHP, BarbarianMaxHP, GenerateRandomValue(BarbarianMinHP,BarbarianMaxHP));
                            barbarianDamage = AskStat(ProvideDamage, BarbarianMinDamage, BarbarianMaxDamage, GenerateRandomValue(BarbarianMinDamage,BarbarianMaxDamage));
                            barbarianDefense = AskStat(ProvideDefense, BarbarianMinDefense, BarbarianMaxDefense, GenerateRandomValue(BarbarianMinDefense, BarbarianMaxDefense));
                            Console.WriteLine(MenuSpliter);

                            Console.WriteLine(MenuSpliter);
                            Console.WriteLine(ShowMageStats);
                            mageHP = AskStat(ProvideHP, MageMinHP, MageMaxHP, GenerateRandomValue(MageMinHP, MageMaxHP));
                            mageDamage = AskStat(ProvideDamage, MageMinDamage, MageMaxDamage, GenerateRandomValue(MageMinDamage, MageMaxDamage));
                            mageDefense = AskStat(ProvideDefense, MageMinDefense, MageMaxDefense, GenerateRandomValue(MageMinDefense, MageMaxDefense));
                            Console.WriteLine(MenuSpliter);

                            Console.WriteLine(MenuSpliter);
                            Console.WriteLine(ShowDruidStats);
                            druidHP = AskStat(ProvideHP, DruidMinHP, DruidMaxHP, GenerateRandomValue(DruidMinHP, DruidMaxHP));
                            druidDamage = AskStat(ProvideDamage, DruidMinDamage, DruidMaxDamage, GenerateRandomValue(DruidMinDamage, DruidMaxDamage));
                            druidDefense = AskStat(ProvideDefense, DruidMinDefense, DruidMaxDefense,GenerateRandomValue(DruidMinDefense, DruidMaxDefense));
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
                    if(errorProvideAllStatsCounter < AllowedErrors)
                    {
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

                            //ArcherTurn
                            errorProvideNumFightMenuCounter = 0;
                            fightOption = 0;
                            choosenOnCooldown = true;
                            while (IsActorAlive(archerTurnHP) && IsActorAlive(monsterTurnHP) && errorProvideNumFightMenuCounter < AllowedErrors && (!InRange(fightOption, MinMenusOption, MaxFightMenuOpt) || choosenOnCooldown))
                            {
                                choosenOnCooldown = false;
                                archerTurnDefense = archerDefense;
                                
                                Console.WriteLine(MenuSpliter);
                                formatedMenu = FightMenu.Replace(ReplaceIcon, archerSkillCooldown == 0 ? SkillReady : $"{archerSkillCooldown}");
                                fightOption = BuildMenu(formatedMenu.Split(LineJumper), GeneralAskInputMsg, $"{ArcherIcon}{LineJumper}{ArcherTurn}");
                                switch (fightOption)
                                {
                                    case AtackOption:
                                        critRollNumber = CritFail(FailChance, CritChance)
                                        damageAmount = AttackOption(archerDamage, monsterDefense);
                                        monsterTurnHP -= damageAmount;
                                        Console.WriteLine(ArcherAttackMsg, archerDamage, damageAmount, monsterTurnHP);
                                        break;
                                    case DefendOption:
                                        DefenseAction(ref archerTurnDefense, archerTurnDefense+archerDefense);
                                        Console.WriteLine(ArcherProtectsMsg);
                                        break;
                                    case SkillOption:
                                        if (archerSkillCooldown > 0)
                                        {
                                            choosenOnCooldown= true;
                                            errorProvideNumFightMenuCounter++;
                                            Console.WriteLine(ErrorChoosenUnderCooldown);
                                        }
                                        else
                                        {
                                            monsterStun = ArcherStunDuration;
                                            archerSkillCooldown = GlobalSpecialSkillCooldown;
                                            Console.WriteLine(ArcherSkill);
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
                                Console.WriteLine(MenuSpliter);
                            }

                            //BarbarianTurn
                            if (errorProvideNumFightMenuCounter < AllowedErrors)
                            {
                                errorProvideNumFightMenuCounter = 0;
                            }
                            fightOption = 0;
                            choosenOnCooldown = true;
                            while (IsActorAlive(barbarianTurnHP) && IsActorAlive(monsterTurnHP) && errorProvideNumFightMenuCounter < AllowedErrors && (!InRange(fightOption, MinMenusOption, MaxFightMenuOpt) || choosenOnCooldown))
                            {
                                choosenOnCooldown = false;
                                barbarianTurnDefense = barbarianDefense;

                                Console.WriteLine(MenuSpliter);
                                formatedMenu = FightMenu.Replace(ReplaceIcon, barbarianSkillCooldown == 0 ? SkillReady : $"{barbarianSkillCooldown}");
                                fightOption = BuildMenu(formatedMenu.Split(LineJumper),GeneralAskInputMsg,$"{BarbarianIcon}{LineJumper}{BarbarianTurn}");
                                switch (fightOption)
                                {
                                    case AtackOption:
                                        damageAmount = AttackOption(barbarianDamage, monsterDefense);
                                        monsterTurnHP -= damageAmount;
                                        Console.WriteLine(BarbarianAttackMsg, barbarianDamage, damageAmount,monsterTurnHP);
                                        break;
                                    case DefendOption:
                                        DefenseAction(ref barbarianTurnDefense, barbarianTurnDefense+barbarianDefense);
                                        Console.WriteLine(BarbarianProtectsMsg);
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
                                            Console.WriteLine(BarbarianSkill);
                                        }
                                        break;
                                    default:
                                        errorProvideNumFightMenuCounter++;
                                        Console.WriteLine(ErrorOutsideStatRange);
                                        break;
                                }
                                if(!choosenOnCooldown && InRange(fightOption, MinMenusOption, MaxFightMenuOpt))
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
                                Console.WriteLine(MenuSpliter);
                            }

                            //MageTurn
                            if (errorProvideNumFightMenuCounter < AllowedErrors)
                            {
                                errorProvideNumFightMenuCounter = 0;
                            }
                            fightOption = 0;
                            choosenOnCooldown = true;
                            while (IsActorAlive(mageTurnHP) && IsActorAlive(monsterTurnHP) && errorProvideNumFightMenuCounter < AllowedErrors && (!InRange(fightOption, MinMenusOption, MaxFightMenuOpt) || choosenOnCooldown))
                            {
                                choosenOnCooldown = false;
                                mageTurnDefense = mageDefense;
                                Console.WriteLine(MenuSpliter);
                                formatedMenu = FightMenu.Replace(ReplaceIcon, mageSkillCooldown == 0 ? SkillReady : $"{mageSkillCooldown}");
                                fightOption = BuildMenu(formatedMenu.Split(LineJumper), GeneralAskInputMsg, $"{MageIcon}{LineJumper}{MageTurn}");
                                switch (fightOption)
                                {
                                    case AtackOption:
                                        damageAmount = AttackOption(mageDamage, monsterDefense);
                                        monsterTurnHP -= damageAmount;
                                        Console.WriteLine(MageAttack, mageDamage, damageAmount, monsterTurnHP);
                                        break;
                                    case DefendOption:
                                        DefenseAction(ref mageTurnDefense, mageTurnDefense+mageDefense);
                                        Console.WriteLine(MageProtects);
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
                                            damageAmount = CalcAttackDamage(mageDamage*MageSuperAttackMult, monsterDefense);
                                            monsterTurnHP -= damageAmount;
                                            mageSkillCooldown = GlobalSpecialSkillCooldown;
                                            Console.WriteLine(MageSkill, mageDamage*MageSuperAttackMult, damageAmount,monsterTurnHP);
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
                                Console.WriteLine(MenuSpliter);
                            }

                            //DruidTurn
                            if (errorProvideNumFightMenuCounter < AllowedErrors)
                            {
                                errorProvideNumFightMenuCounter = 0;
                            }
                            fightOption = 0;
                            choosenOnCooldown = true;
                            while (IsActorAlive(druidTurnHP) && IsActorAlive(monsterTurnHP) && errorProvideNumFightMenuCounter < AllowedErrors && (!InRange(fightOption, MinMenusOption, MaxFightMenuOpt) || choosenOnCooldown))
                            {
                                choosenOnCooldown = false;
                                druidTurnDefense = druidDefense;

                                Console.WriteLine(MenuSpliter);
                                formatedMenu = FightMenu.Replace(ReplaceIcon, druidSkillCooldown == 0 ? SkillReady : $"{druidSkillCooldown}");
                                fightOption = BuildMenu(formatedMenu.Split(LineJumper), GeneralAskInputMsg, $"{DruidIcon}{LineJumper}{DruidTurn}");
                                switch (fightOption)
                                {
                                    case AtackOption:
                                        damageAmount = AttackOption(druidDamage,monsterDefense);
                                        monsterTurnHP -= damageAmount;
                                        Console.WriteLine(DruidAttack, druidDamage, damageAmount ,monsterTurnHP);
                                        break;
                                    case DefendOption:
                                        DefenseAction(ref druidTurnDefense, druidTurnDefense+druidDefense);
                                        Console.WriteLine(DruidProtects);
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
                                            Console.WriteLine(DruidSkill , DruidHealingAmount);
                                            if(IsActorAlive(archerTurnHP))
                                            {
                                                HealTarget(ref archerTurnHP,DruidHealingAmount, archerHP);
                                                Console.WriteLine(DruidHealsArcher, archerTurnHP);
                                            }
                                            if (IsActorAlive(barbarianTurnHP))
                                            {
                                                HealTarget(ref barbarianTurnHP, DruidHealingAmount, barbarianHP);
                                                Console.WriteLine(DruidHealsBarbarian, barbarianTurnHP);
                                            }
                                            if (IsActorAlive(mageTurnHP))
                                            {
                                                HealTarget(ref mageTurnHP, DruidHealingAmount, mageHP);
                                                Console.WriteLine(DruidHealsMage, mageTurnHP);
                                            }
                                            HealTarget(ref druidTurnHP, DruidHealingAmount, druidHP);
                                            Console.WriteLine(DruidHealsDruid, druidTurnHP);
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
                                Console.WriteLine(MenuSpliter);
                            }

                            //MonsterTurn
                            if (errorProvideNumFightMenuCounter < AllowedErrors && IsActorAlive(monsterTurnHP) && monsterStun<=0)
                            {
                                Console.WriteLine(MenuSpliter);
                                Console.WriteLine(MonsterIcon);
                                Console.WriteLine(MonsterAttacks);
                                if (IsActorAlive(archerTurnHP))
                                {
                                    damageAmount = CalcAttackDamage(monsterDamage, archerTurnDefense);
                                    archerTurnHP -= damageAmount;
                                    Console.WriteLine(MonsterArcherDamage, monsterDamage, damageAmount, archerTurnHP);
                                    if (!IsActorAlive(archerTurnHP))
                                    {
                                        Console.WriteLine(ArcherDead);
                                    }
                                }
                                if (IsActorAlive(barbarianTurnHP))
                                {
                                    damageAmount = CalcAttackDamage(monsterDamage, barbarianTurnDefense);
                                    barbarianTurnHP -= damageAmount;
                                    Console.WriteLine(MonsterBarbarianDamage, monsterDamage, damageAmount, barbarianTurnHP);
                                    if (!IsActorAlive(barbarianTurnHP))
                                    {
                                        Console.WriteLine(BarbarianDead);
                                    }

                                }
                                if (IsActorAlive(mageTurnHP))
                                {
                                    damageAmount = CalcAttackDamage(monsterDamage,mageTurnDefense);
                                    mageTurnHP -= damageAmount;
                                    Console.WriteLine(MonsterMageDamage, monsterDamage, damageAmount, mageTurnHP);
                                    if (!IsActorAlive(mageTurnHP))
                                    {
                                        Console.WriteLine(MageDead);
                                    }
                                }
                                if (IsActorAlive(druidTurnHP))
                                {
                                    damageAmount = CalcAttackDamage(monsterDamage, druidTurnDefense);
                                    druidTurnHP -= damageAmount;
                                    Console.WriteLine(MonsterDruidDamage,monsterDamage ,damageAmount, druidTurnHP);
                                    if (!IsActorAlive(druidTurnHP))
                                    {
                                        Console.WriteLine(DruidDead);
                                    }
                                }
                                Console.WriteLine(MenuSpliter);
                            } else if(errorProvideNumFightMenuCounter < AllowedErrors && IsActorAlive(monsterTurnHP) && monsterStun>0)
                            {
                                Console.WriteLine(MenuSpliter);
                                Console.WriteLine(MonsterIcon);
                                monsterStun--;
                                Console.WriteLine(MonsterIsStuned);
                                Console.WriteLine(MenuSpliter);
                            }
                            ShowValuesDesc(new int[] { archerTurnHP, barbarianTurnHP, mageTurnHP, druidTurnHP }, new string[] { archerName, barbarianName, mageName, druidName }, ShowHealthMsg);
                        } while (IsActorAlive(monsterTurnHP) && (!AreActorGroupDead(new int[] {archerTurnHP, barbarianTurnHP, mageTurnHP, druidTurnHP})) && errorProvideNumFightMenuCounter<AllowedErrors);
                        if (!IsActorAlive(monsterTurnHP))
                        {
                            Console.WriteLine(HeroesWin);
                        }
                        else if(AreActorGroupDead(new int[] { archerTurnHP, barbarianTurnHP, mageTurnHP, druidTurnHP }))
                        {
                            Console.WriteLine(MonsterWins);
                        }
                        else
                        {
                            Console.WriteLine(ErrorOvercameFightErrorLimit);
                        }
                    }
                }
            }while (menuOption!=ExitGameOption && errorProvideNumStartMenuCounter<AllowedErrors);
            if (errorProvideNumStartMenuCounter==AllowedErrors)
            {
                Console.WriteLine(ErrorOvercameStartErrorLimit);
            }
        }

        
        public static int BuildMenu(string[] options, string askmsg)
        {
            int option;
            for (int i = 0; i < options.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {options[i]}");
            }
            Console.Write(askmsg);
            return Convert.ToInt32(Console.ReadLine());
        }
        public static int BuildMenu(string[] options, string askmsg, string msg)
        {
            int option;

            if (!string.IsNullOrEmpty(msg))
            {
                Console.WriteLine(msg);
            }
            for(int i = 0; i < options.Length; i++)
            {
                Console.WriteLine($"{i+1}. {options[i]}");
            }
            Console.Write(askmsg);
            return Convert.ToInt32(Console.ReadLine());
        }

        public static int CalcAttackDamage(int atackerDamageValue, int targetDefenseValue)
        {
            return atackerDamageValue - ((atackerDamageValue * targetDefenseValue) / 100);
        }
        public static int AttackOption(int attackerDMG, int targetDefense)
        {
            switch (CritFail(5, 10))
            {
                case -1:
                    return 0;
                    break;
                case 1:
                    return CalcAttackDamage(attackerDMG*2, targetDefense);
                    break;
                default:
                    return CalcAttackDamage(attackerDMG, targetDefense);
                    break;
            }
        }
        public static void DefenseAction(ref int actorDefense, int newDefenseValue)
        {
            actorDefense = newDefenseValue;
        }

        public static void HealTarget(ref int targetHP,int healingAmount, int targetMaxHP)
        {
            targetHP += healingAmount;
            if(targetHP > targetMaxHP)
            {
                targetHP = targetMaxHP;
            }
        }
        public static int CritFail(int chanceFail, int chanceCrit)
        {
            int rngValue = GenerateRandomValue(0, 100);

            if(rngValue <= chanceFail)
            {
                return -1;
            }else if (rngValue>=(100-chanceCrit))
            {
                return 1;
            }
            return 0;
        }
        public static int AskStat(string AskMsg, int minPosibleStat, int maxPosibleStat)
        {
            Console.Write(AskMsg, minPosibleStat, maxPosibleStat);
            return Convert.ToInt32(Console.ReadLine());
        }
        public static int AskStat(string AskMsg, int minPosibleStat, int maxPosibleStat, int autoAssign)
        {
            Console.WriteLine(AskMsg+autoAssign, minPosibleStat, maxPosibleStat);
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
            return rng.Next(minValue, maxValue+1);
        }
        public static void ShowValuesDesc(int[] values, string[] characterPerValue, string mainMsg)
        {
            ReorderDesc(ref values,ref characterPerValue);
            for(int i = 0; i < values.Length; i++)
            {
                Console.WriteLine(mainMsg, characterPerValue[i], values[i]);
            }
        }
        public static void ReorderDesc(ref int[] values, ref string[]valuesMsg)
        {
            for(int i = 0; i<values.Length-1; i++) 
            {
                for(int j = i; j<values.Length; j++)
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