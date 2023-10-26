/**
 * Author: Gorriaran Caamaño Marcos Facundo
 * Date: 26/10/2023 V1.1
 * Descripcion: Juego en el que el usuario al elegir jugar a traves de un menu tendra que
 * asignar los stats de los heroes que controlara y del monstruo que se enfrentara.
 * La lucha va por turnos y finaliza cuando todos los miembros de un lado caigan.
 * Sources:
 *  ASCII Drawings: https://www.asciiart.eu
 */
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
            const string ErrorMenuOptionOutsideRange = "Opcion seleccionado en el menu esta fuera del rango permitido, elige una de las opciones que se muestran en pantalla";
            const string ErrorOvercameErrorLimit = "Se ha superado el limite de errores, debera de reintroducir los valores en este apartado";
            const string ErrorOvercameSecondErrorLimit = "Ha cometido 3 errores 3 veces, vuelve al principio";
            const string ErrorOutsideStatRange = "El valor esta fuera del rango solicitado";
            const string ErrorOvercameStartErrorLimit = "Se ha superado el limite de errores en el menu principal, el programa finalizara por ello";
            const string ErrorChoosenUnderCooldown = "La habilidad aun estaba bajo tiempo de espera, el heroe es incapaz de utilizarlo";
            const string StartingMenu = "1. Iniciar una nueva batalla \n2. Salir \nEscribe el numero de la opcion deseas utilizar: ";
            const string FightMenu = "1. Atacar \n2. Defenderse \n3. Habilidad especial, tiempo de espera {0} \nElige una de las acciones listadas: ";
            const string MenuSpliter = "--------------------------";
            const string FightIcon = "   |\\                     /)\r\n /\\_\\\\__               (_//\r\n|   `>\\-`     _._       //`)\r\n \\ /` \\\\  _.-`:::`-._  //\r\n  `    \\|`    :::    `|/\r\n        |     :::     |\r\n        |.....:::.....|\r\n        |:::::::::::::|\r\n        |     :::     |\r\n        \\     :::     /\r\n         \\    :::    /\r\n          `-. ::: .-'\r\n           //`:::`\\\\\r\n          //   '   \\\\\r\n         |/         \\\\";
            const string ProvideHP = "Vida [{0} - {1}]: ";
            const string ProvideDamage = "Ataque [{0} - {1}]: ";
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
            const string ArcherAttackMsg = "La arquera lanza una flecha al monstruo causando {0} puntos de daño, al monstruo le queda {1} puntos de vida";
            const string ArcherProtectsMsg = "La arquera se prepara para el impacto del siguiente ataque";
            const string ArcherSkill = "La arquera immobiliza al monstruo con una flecha en la pierna, el monstruo es incapaz de moverse por dos turnos";
            const string BarbarianAttackMsg = "El barbaro se avalanza con su hacha e impacta, causando {0} puntos de daño, al monstruo le queda {1} puntos de vida";
            const string BarbarianProtectsMsg = "El barbaro se prepara para recivir el impacto del siguiente ataque";
            const string BarbarianSkill = "El barbaro toma una postura defensiva impecable, en los proximos 3 turnos su defensa es perfecta y no puede recivir daño";
            const string MageAttack = "El mago prepara y lanza un rayo magico al monstruo causando {0} puntos de daño, al monstruo le queda {1} puntos de vida";
            const string MageProtects = "El mago se prepara para el impacto del siguiente ataque";
            const string MageSkill = "El mago decide tirar logica por la ventana y grita 'FIREBALL AND ONLY FIREBALL' y lanza una tormenta de bolas de fuego causando {0}, al monstruo le queda {1} puntos de vida";
            const string DruidAttack = "El druida da un mamporro con su baston al monstruo causando {0} puntos de daño, al monstruo le queda {1} puntos de vida";
            const string DruidProtects = "El druida se prepara para el impacto del siguiente ataque";
            const string DruidSkill = "El druida prepara un hechizo curativo que envuelve a todos los aventureros que aun quedan en pie y todos estos son sanados {0} puntos de salud";
            const string MonsterAttacks = "El monstruo lanza un zarpazo, alcanzando a todos los miembros del grupo";
            const string MonsterArcherDamage = "La arquera recive {0} puntos de daño, ahora posee {1} puntos de salud";
            const string MonsterBarbarianDamage = "El barbaro recive {0} puntos de daño, ahora posee {1} puntos de salud";
            const string MonsterMageDamage = "El mago recive {0} puntos de daño, ahora posee {1} puntos de salud";
            const string MonsterDruidDamage = "El druid recive {0} puntos de daño, ahora posee {1} puntos de salud";
            const string MonsterIsStuned = "El monstruo aun sigue siendo incapaz de moverse del impacto de la arquera";
            const string HeroesWin = "Los heroes consiguen derrotar al monstruo";
            const string MonsterWins = "Los heroes fallecen intentando luchar al monstruo, tu mision ha sido un fracaso";

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

                    //Start of Combat
                    if(errorProvideAllStatsCounter < AllowedErrors)
                    {
                        archerTurnHP = archerHP;
                        barbarianTurnHP = barbarianHP;
                        mageTurnHP = mageHP;
                        druidTurnHP = druidHP;
                        monsterTurnHP = monsterHP;

                        Console.WriteLine(FightIcon);
                        do
                        {
                            //ArcherTurn
                            errorProvideNumFightMenuCounter = 0;
                            fightOption = 0;
                            choosenOnCooldown = true;
                            while (archerTurnHP>DeathValue && monsterTurnHP>DeathValue && errorProvideNumFightMenuCounter < AllowedErrors && (fightOption > MaxFightMenuOpt || fightOption < MinMenusOption || choosenOnCooldown))
                            {
                                choosenOnCooldown = false;
                                archerTurnDefense = archerDefense;
                                
                                Console.WriteLine(MenuSpliter);
                                Console.WriteLine(ArcherTurn);
                                Console.Write(FightMenu, archerSkillCooldown==0 ? SkillReady : archerSkillCooldown);
                                fightOption = Convert.ToInt32(Console.ReadLine());
                                switch (fightOption)
                                {
                                    case AtackOption:
                                        monsterTurnHP -= archerDamage-((archerDamage * monsterDefense) / PercentageTop);
                                        Console.WriteLine(ArcherAttackMsg, archerDamage - ((archerDamage * monsterDefense) / PercentageTop), monsterTurnHP);
                                        break;
                                    case DefendOption:
                                        archerTurnDefense+= archerDefense;
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
                                if (!choosenOnCooldown && fightOption <= MaxFightMenuOpt && fightOption <= MinMenusOption)
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
                            while (barbarianTurnHP > DeathValue && monsterTurnHP > DeathValue && errorProvideNumFightMenuCounter < AllowedErrors && (fightOption > MaxFightMenuOpt || fightOption < MinMenusOption || choosenOnCooldown))
                            {
                                choosenOnCooldown = false;
                                barbarianTurnDefense = barbarianDefense;

                                Console.WriteLine(MenuSpliter);
                                Console.WriteLine(BarbarianTurn);
                                Console.Write(FightMenu, barbarianSkillCooldown == 0 ? SkillReady : barbarianSkillCooldown);
                                fightOption = Convert.ToInt32(Console.ReadLine());
                                switch (fightOption)
                                {
                                    case AtackOption:
                                        monsterTurnHP -= barbarianDamage-((barbarianDamage * monsterDefense) / PercentageTop);
                                        Console.WriteLine(BarbarianAttackMsg, barbarianDamage - ((barbarianDamage * monsterDefense) / PercentageTop),monsterTurnHP);
                                        break;
                                    case DefendOption:
                                        barbarianTurnDefense += barbarianDefense;
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
                                if(!choosenOnCooldown && fightOption<=MaxFightMenuOpt && fightOption>=MinMenusOption)
                                {
                                    if (barbarianPerfectDefense > 0)
                                    {
                                        barbarianTurnDefense = PercentageTop;
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
                            while (mageTurnHP > DeathValue && monsterTurnHP > DeathValue && errorProvideNumFightMenuCounter < AllowedErrors && (fightOption > MaxFightMenuOpt || fightOption < MinMenusOption || choosenOnCooldown))
                            {
                                choosenOnCooldown = false;
                                mageTurnDefense = mageDefense;

                                Console.WriteLine(MenuSpliter);
                                Console.WriteLine(MageTurn);
                                Console.Write(FightMenu, mageSkillCooldown == 0 ? SkillReady : mageSkillCooldown);
                                fightOption = Convert.ToInt32(Console.ReadLine());
                                switch (fightOption)
                                {
                                    case AtackOption:
                                        monsterTurnHP -= mageDamage-((mageDamage * monsterDefense) / PercentageTop);
                                        Console.WriteLine(MageAttack, mageDamage - ((mageDamage * monsterDefense) / PercentageTop), monsterTurnHP);
                                        break;
                                    case DefendOption:
                                        mageTurnDefense += mageDefense;
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
                                            monsterTurnHP -= (mageDamage*MageSuperAttackMult)-(((mageDamage * MageSuperAttackMult)) / PercentageTop);
                                            mageSkillCooldown = GlobalSpecialSkillCooldown;
                                            Console.WriteLine(MageSkill, (mageDamage * MageSuperAttackMult) - (((mageDamage * MageSuperAttackMult)) / PercentageTop),monsterTurnHP);
                                        }
                                        break;
                                    default:
                                        errorProvideNumFightMenuCounter++;
                                        Console.WriteLine(ErrorMenuOptionOutsideRange);
                                        break;
                                }
                                if (!choosenOnCooldown && fightOption <= MaxFightMenuOpt && fightOption <= MinMenusOption)
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
                            while (druidTurnHP > DeathValue && monsterTurnHP > DeathValue && errorProvideNumFightMenuCounter < AllowedErrors && (fightOption > MaxFightMenuOpt || fightOption < MinMenusOption || choosenOnCooldown))
                            {
                                choosenOnCooldown = false;
                                druidTurnDefense = druidDefense;

                                Console.WriteLine(MenuSpliter);
                                Console.WriteLine(DruidTurn);
                                Console.Write(FightMenu, druidSkillCooldown == 0 ? SkillReady : druidSkillCooldown);
                                fightOption = Convert.ToInt32(Console.ReadLine());
                                switch (fightOption)
                                {
                                    case AtackOption:
                                        monsterTurnHP -= druidDamage-((druidDamage * monsterDefense) / PercentageTop);
                                        Console.WriteLine(DruidAttack, druidDamage - ((druidDamage * monsterDefense) / PercentageTop),monsterTurnHP);
                                        break;
                                    case DefendOption:
                                        druidTurnDefense += druidDefense;
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
                                            if(archerTurnHP > DeathValue)
                                            {
                                                archerTurnHP += DruidHealingAmount;
                                                if(archerTurnHP > archerHP)
                                                {
                                                    archerTurnHP = archerHP;
                                                }
                                            }
                                            if (barbarianTurnHP > DeathValue)
                                            {
                                                barbarianTurnHP += DruidHealingAmount;
                                                if (barbarianTurnHP > barbarianHP)
                                                {
                                                    barbarianTurnHP = barbarianHP;
                                                }
                                            }
                                            if (mageTurnHP > DeathValue)
                                            {
                                                mageTurnHP += DruidHealingAmount;
                                                if (mageTurnHP > mageHP)
                                                {
                                                    mageTurnHP = mageHP;
                                                }
                                            }
                                            druidTurnHP += DruidHealingAmount;
                                            if (druidTurnHP > druidHP)
                                            {
                                                druidTurnHP = druidHP;
                                            }
                                            druidSkillCooldown = GlobalSpecialSkillCooldown;
                                        }
                                        break;
                                    default:
                                        errorProvideNumFightMenuCounter++;
                                        Console.WriteLine(ErrorMenuOptionOutsideRange);
                                        break;
                                }
                                if (!choosenOnCooldown && fightOption <= MaxFightMenuOpt && fightOption <= MinMenusOption)
                                {
                                    if (druidSkillCooldown > 0)
                                    {
                                        druidSkillCooldown--;
                                    }
                                }
                                Console.WriteLine(MenuSpliter);
                            }

                            //MonsterTurn
                            if (errorProvideNumFightMenuCounter < AllowedErrors && monsterTurnHP > DeathValue && monsterStun<=0)
                            {
                                Console.WriteLine(MenuSpliter);
                                Console.WriteLine(MonsterAttacks);
                                if (archerTurnHP>DeathValue)
                                {
                                    archerTurnHP -= monsterDamage - ((monsterDamage * archerTurnDefense) / PercentageTop);
                                    Console.WriteLine(MonsterArcherDamage, monsterDamage - ((monsterDamage * archerTurnDefense) / PercentageTop), archerTurnHP);
                                }
                                if (barbarianTurnHP > DeathValue)
                                {
                                    barbarianTurnHP -= monsterDamage - ((monsterDamage * barbarianTurnDefense) / PercentageTop);
                                    Console.WriteLine(MonsterBarbarianDamage, monsterDamage - ((monsterDamage * barbarianTurnDefense) / PercentageTop), barbarianTurnHP);

                                }
                                if (mageTurnHP > DeathValue)
                                {
                                    mageTurnHP -= monsterDamage-((monsterDamage * mageTurnDefense) / PercentageTop);
                                    Console.WriteLine(MonsterMageDamage, monsterDamage - ((monsterDamage * mageTurnDefense) / PercentageTop), mageTurnHP);
                                }
                                if (druidTurnHP > DeathValue)
                                {
                                    druidTurnHP -= monsterDamage-((monsterDamage * druidTurnDefense) / PercentageTop);
                                    Console.WriteLine(MonsterDruidDamage, monsterDamage - ((monsterDamage * druidTurnDefense) / PercentageTop), druidTurnHP);
                                }
                                Console.WriteLine(MenuSpliter);
                            } else if(errorProvideNumFightMenuCounter < AllowedErrors && monsterTurnHP > DeathValue && monsterStun>0)
                            {
                                Console.WriteLine(MenuSpliter);
                                monsterStun--;
                                Console.WriteLine(MonsterIsStuned);
                                Console.WriteLine(MenuSpliter);
                            }
                        } while (monsterTurnHP>DeathValue && (archerTurnHP>DeathValue || barbarianTurnHP>DeathValue || mageTurnHP>DeathValue || druidTurnHP>DeathValue) && errorProvideNumFightMenuCounter<AllowedErrors);
                        if (monsterTurnHP <= DeathValue)
                        {
                            Console.WriteLine(HeroesWin);
                        }
                        else if(archerTurnHP > DeathValue && barbarianTurnHP > DeathValue && mageTurnHP > DeathValue && druidTurnHP > DeathValue)
                        {
                            Console.WriteLine(MonsterWins);
                        }
                        else
                        {
                            Console.WriteLine(ErrorOvercameErrorLimit);
                        }
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