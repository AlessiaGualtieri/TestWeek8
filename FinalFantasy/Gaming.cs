using FinalFantasy.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalFantasy
{
    public class Gaming
    {
        public static IBusinessLayer bl = new MainBusinessLayer();
        public static string nickname = "";
        //MENU INIZIALE DI GESTIONE DELL'UTENTE
        public static void LoginMenu()
        {
            int choice;
            bool accessGameMenu = false;
            do
            {
                Console.WriteLine("----- MENU -----\n" +
                "1 - Login\n" +
                "2 - Register\n" +
                "3 - Exit");

                choice = Helper.ReadInt(1, 3);
                switch (choice)
                {
                    case 1:
                        accessGameMenu = LoginGame();
                        break;
                    case 2:
                        accessGameMenu = RegisterGame();
                        break;
                    case 3:
                        Console.WriteLine("See you soon!");
                        return;
                }
            } while (!accessGameMenu);
            GameMenu();
        }


        public static bool LoginGame()
        {
            bool access = false;
            Console.Write("Nickname: ");
            string insertedNickname = Console.ReadLine();
            if (!bl.Login(insertedNickname))
                Console.WriteLine("Incorrect nickname.");
            else
            {
                access = true;
                nickname = insertedNickname;
            }
            return access;
        }

        public static bool RegisterGame()
        {
            bool access = false;
            Console.Write("Nickname: ");
            string insertedNickname = Console.ReadLine();
            if (!bl.Register(insertedNickname))
                Console.WriteLine("Nickname already in use.");
            else
            {
                Console.WriteLine("Successfully registered");
                access = true;
                nickname = insertedNickname;
            }
            return access;
        }

        private static void GameMenu()
        {
            int choice;
            Console.WriteLine("----- GAME MENU -----\n" +
                "1 - Play\n" +
                "2 - Create new Hero\n" +
                "3 - Delete Hero\n" +
                "4 - Exit");

            choice = Helper.ReadInt(1, 4);

            switch (choice)
            {
                case 1:
                    Play();
                    break;
                case 2:
                    CreateHero();
                    break;
                case 3:
                    DeleteHero();
                    break;
                case 4:
                    nickname = "";
                    LoginMenu();
                    break;
            }
        }

        private static void DeleteHero()
        {
            string heroToDelete;
            bl.ShowHeroes(nickname);
            Console.Write("Which hero you want to delete? Write the name: ");
            heroToDelete = Console.ReadLine();
            if (!bl.DeleteHero(nickname, heroToDelete))
                Console.WriteLine("Incorrect input.");
            else
                Console.WriteLine("Hero correcly deleted.");
            GameMenu();
        }

        private static void CreateHero()
        {
            string nameHero, category, weaponName;
            Console.Write("Insert the name of the hero you want to create ");
            nameHero = Console.ReadLine();
            Console.WriteLine("Insert the category of the hero (Soldier - Wizard)");
            do
            {
                category = Console.ReadLine();
                if (!category.Equals("Soldier") && !category.Equals("Wizard"))
                    Console.Write("Incorrect input. Try again: ");
            } while (!category.Equals("Soldier") && !category.Equals("Wizard"));
            Console.WriteLine("WEAPONS:");
            bl.ShowHeroWeapons(category);
            Console.Write("Insert the weapon name: ");
            weaponName = Console.ReadLine();
            if (!bl.AddHero(nickname, nameHero, category, weaponName))
                Console.WriteLine("There's been an error creating the hero.");
            else
                Console.WriteLine("Hero correcly created.");
            GameMenu();
        }

        private static void Play()
        {
            string heroName = "", monsterName = "", monsterWeapon = "";
            int level = 0, monsterDMG = 0, monsterLvl = 0, monsterHP = 0, heroDMG = 0, heroHP = 0;
            bool heroWin, monsterWin;

            PickHero(ref heroName, ref level, ref heroHP,ref heroDMG);
            bl.SelectMonster(level, ref monsterName, ref monsterWeapon, ref monsterDMG,
                ref monsterLvl, ref monsterHP);

            Console.WriteLine($"Welcome {heroName}, your enemy is:\n{monsterName} " +
                $"(LVL: {monsterLvl}, HP: {monsterHP}, weapon: {monsterWeapon}, DMG: {monsterDMG})");
            Console.WriteLine("----- LET'S FIGHT! -----");
            do
            {
                heroWin = HeroTurn(heroName, heroDMG, ref monsterHP);
                monsterWin = MonsterTurn(monsterName, monsterDMG, ref heroHP);
            } while (!heroWin && !monsterWin);
            if (heroWin)
                bl.ChangeHeroExp(nickname, heroName, monsterLvl * 10);
            else
                bl.ChangeHeroExp(nickname, heroName, -monsterLvl * 5);

        }

        private static bool MonsterTurn(string monsterName, int monsterDMG, ref int heroHP)
        {
            heroHP -= monsterDMG;
            if (heroHP < 0)
            {
                Console.WriteLine($"It's {monsterName}'s turn. You DIED");
                return true;
            }
            Console.WriteLine($"It's {monsterName}'s turn. You have {heroHP}HP left");
            return false;
        }

        private static bool HeroTurn(string heroName, int heroDMG, ref int monsterHP)
        {
            int choice;
            Console.WriteLine($"{heroName}, what you wanna do?\n" +
                $"1 - Attack\n" +
                $"2 - Try escape");
            choice = Helper.ReadInt(1, 2);
            switch(choice)
            {
                case 1:
                    monsterHP -= heroDMG;
                    if(monsterHP < 0)
                    {
                        Console.WriteLine($"You WIN!");
                        return true;
                    }
                    Console.WriteLine($"He has {monsterHP}HP left");
                    break;
                case 2:
                    ///////////////////////////////////
                    break;
            }
            return false;
        }

        private static void PickHero(ref string heroName, ref int heroLvl, ref int heroHP,
            ref int heroDMG)
        {
            bool success;
            Console.WriteLine("Select a hero:");
            bl.ShowHeroes(nickname);
            Console.Write("Insert hero name: ");
            do
            {
                heroName = Console.ReadLine();
                success = bl.GetHeroInfo(nickname, heroName,ref heroLvl,ref heroHP,ref heroDMG);
                if (!success)
                    Console.Write("Uncorrect input. Try again: ");
            } while (!success);
        }

    }
}
