﻿
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
            const int StartGameOption = 1;
            const int GlobalSpecialSkillCooldown = 5;
            //ArcherStatsLimit
            const int ArcherMinHP = 1500;
            const int ArcherMaxHP = 2000;
            const int ArcherMinDamage = 180;
            const int ArcherMaxDamage = 300;
            const int ArcherMinDefense = 25;
            const int ArcherMaxDefense = 40;
            //BarbarianStatsLimit
            const int BarbarianMinHP = 3000;
            const int BarbarianMaxHP = 3750;
            const int BarbarianMinDamage = 150;
            const int BarbarianMaxDamage = 250;
            const int BarbarianMinDefense = 35;
            const int BarbarianMaxDefense = 45;
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
            const string StartingMenu = "1. Iniciar una nueva batalla \n2. Salir \nEscribe el numero de la opcion deseas utilizar: ";
            const string MenuSpliter = "--------------------------";
            const string ProvideHP = "Vida [{0} - {1}]: ";
            const string ProvideDamage = "Atac [{0} - {1}]: ";
            const string ProvideDefense = "Reduccion de daño (valor percentual) [{0} - {1}]: ";
            const string ArcherStatAssign = "Proporciona los stats de la arquera";
            const string BarbarianStatAssign = "Proporciona los stats del barbaro";
            const string MageStatAssign = "Proporciona los stats del mago";
            const string DruidStatAssign = "Proporciona los stats del druida";
            const string MonsterStatAssign = "Proporciona los stats del monstruo";

            bool repeated;
            bool repeatedSecondLoop;
            int menuOption = 0;
            int errorProvideNumStartMenuCounter;
            int errorProvideAllStatsCounter;
            int errorProvideStatsCounter;
            //ArcherStats
            int archerHP;
            int archerDamage;
            int archerDefense = 0;
            int archerTurnDefense;
            int archerSkillCooldown;
            //BarbarianStats
            int barbarianHP;
            int barbarianDamage;
            int barbarianDefense = 0;
            int barbarianTurnDefense;
            int barbarianSkillCooldown = 0;
            //MageStats
            int mageHP;
            int mageDamage;
            int mageDefense = 0;
            int mageTurnDefense;
            int mageSkillCooldown = 0;
            //DruidStats
            int druidHP;
            int druidDamage;
            int druidDefense = 0;
            int druidTurnDefense;
            int druidSkillCooldown = 0;
            //MonsterStats
            int monsterHP;
            int monsterDamage;
            int monsterDefense = 0;
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
                }
            }while (menuOption!=ExitGameOption && errorProvideNumStartMenuCounter<AllowedErrors);
            if (errorProvideNumStartMenuCounter==AllowedErrors)
            {
                Console.WriteLine(ErrorOvercameStartErrorLimit);
            }
        }
    }
}