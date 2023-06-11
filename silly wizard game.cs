namespace silly_wizard_game
{
    class playerWizardBattling
    {
        public static int playerHP = 50;
        public static int playerMP = 5;
        public static int playerSpellDamage = 15;
        public static int playerHealingAmount = 15;
        

        public void playerCastingSpell()
        {
            if (playerMP > 0)
            {
                enemyWizardBattling.enemyHP -= playerSpellDamage;
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\n" + wizardBattling.playerName + " cast " + wizardBattling.spellName + "! It dealt " + playerSpellDamage + " damage!");
                Console.ForegroundColor = ConsoleColor.White;
                playerMP--;
                Console.WriteLine("MP remaining: " + playerMP);
            } else {
                Console.WriteLine("\n" + "You can't cast any spells! You're out of Magic Points!");
            }
        }

        public void playerHealing()
        {
            if (playerHP == 50)
            {
                Console.WriteLine("\n" + wizardBattling.playerName + " is already at full HP!");
            }
            
            if (playerHP >= playerHP - playerHealingAmount && playerHP != 50)
            {
                playerHP = 50;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n" + wizardBattling.playerName + " healed up to full HP!");
                Console.ForegroundColor = ConsoleColor.White;
            }
            
            if (playerHP < playerHP - playerHealingAmount)
            {
                playerHP += playerHealingAmount;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n" + wizardBattling.playerName + " healed " + playerHealingAmount + " health points!");
                Console.ForegroundColor = ConsoleColor.White;
            }

        }

        public void playerMeditate()
        {
            if (playerMP < 5)
            {
                playerMP = 5;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n" + wizardBattling.playerName + " meditates to regain MP!");
                Console.ForegroundColor = ConsoleColor.White;
            } else {
                Console.WriteLine("\n" + wizardBattling.playerName + " already has full MP!");
            }
        }
        
        public void playerLevelUp()
        {
            //might create idk
            //will be called at the end of a battle
            //increase all stats with equations

            /*
            might cause troubles with max hp and healing (like how if the hp is at 50, which
            is the maximum for level 1, you cant heal, but how do i increase that number as
            well with the level ups?)
            */
        }
    }
    
    class enemyWizardBattling
    {
        public static int enemyHP = 125;
        public static int enemyMP = 5;
        public static int enemySpellDamage = 5;
        public static int enemyHealingAmount = 15;

        public static string?[] firstNameOptions = new string[10]
         {
            "Felicia", "Merlin", "Cassius", "Ellan", "Lucius", "Lightroot", "Unora", "Aphiane", "Rhodes", "Clarisse"
         };

        public static string?[] lastNameOptions = new string[10]
        {
            " Hall", " the Wise", " the Powerful", " the Great", " Silverling", " Gooseberry", " Thunderheart", " Partridge", " Bartley", " Ruth"
        };

        public static string? enemyNameGen()
        {
            var random = new Random();
            string? firstName = firstNameOptions[random.Next(0, firstNameOptions.Length)];
            string? lastName = lastNameOptions[random.Next(0, lastNameOptions.Length)];

            return $"{firstName}{lastName}";
        }

        public void enemyTurnChoice()
        {
            var random = new Random();
            int enemyChoice = random.Next(0,2);
            
            if (enemyChoice == 0 && enemyHP < 125)
            {
                enemyHP += enemyHealingAmount;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n" + wizardBattling.enemyName + " heals " + enemyHealingAmount + " HP!");
                Console.ForegroundColor = ConsoleColor.White;

                return;
            }

            if (enemyChoice == 0 && enemyHP == 125)
            {
                Console.WriteLine("\n" + wizardBattling.enemyName + " tried to heal but already has full HP!");
            }

            if (enemyChoice == 1 && enemyMP > 0)
            {
                playerWizardBattling.playerHP -= enemySpellDamage;
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\n" + wizardBattling.enemyName + " cast " + wizardBattling.enemySpellName + "! It dealt " + enemySpellDamage + " damage!");
                enemyMP--;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Enemy MP remaining: " + enemyMP);
            }
            
            if (enemyChoice == 1 && enemyMP == 0)
            {
                Console.WriteLine("\n" + wizardBattling.enemyName + " tried to cast a spell! They're out of Magic Points!");
            }

            if (enemyChoice == 2 && enemyMP < 5)
            {
                enemyMP = 5;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n" + wizardBattling.enemyName + " meditates to regain MP!");
                Console.ForegroundColor = ConsoleColor.White;
            }

            if (enemyChoice == 2 && enemyMP == 5)
            {
                Console.WriteLine("\n" + wizardBattling.enemyName + " tries to meditate, but already has full MP!");
            }
        }

        public void enemyLevelUp()
        {
            //might create idk
            //will be called at the end of a battle
            //increase all stats with equations

            /*
            might cause troubles with max hp and healing (like how if the hp is at 125, which
            is the maximum for level 1, you cant heal, but how do i increase that number as
            well with the level ups?)
            */
        }
    }
    
    
    class wizardBattling
    {
        public static string? playerName;
        public static string? spellName;

        public static string? enemyName;
        public static string? enemySpellName;
        
        public static string? responseForEnemyName;


        public static int turnCount = 1;
        public static int battleCount = 1;

        public static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
            
            playerWizardBattling playerWizard = new playerWizardBattling();
            enemyWizardBattling enemyWizard = new enemyWizardBattling();
    
            
            //making player wizard
            Console.WriteLine("-Build your Wizard:-");

            Console.WriteLine("\n\nEnter your name:");
            playerName = Console.ReadLine();
            
            Console.WriteLine("\nEnter the name of your spell:");
            spellName = Console.ReadLine();


            //making part of enemy wizard
            Console.WriteLine("\n\n\n-Build the Enemy Wizard:-");

            Console.WriteLine("The enemy's name will be auto-generated. Do you want to make the name yourself?");
            Console.WriteLine("\nY/N");

            //simply run enemyWizardBattling.enemyNameGen(); once a new wizard is created
            //also copy the prompt above to name the new wizard instead every time
            responseForEnemyName = Console.ReadLine();

            if (responseForEnemyName == "Y" || responseForEnemyName == "y")
            {
                Console.WriteLine("\nEnter enemy name:");
                enemyName = Console.ReadLine();
            }

            if (responseForEnemyName == "N" || responseForEnemyName == "n")
            {
                enemyName = enemyWizardBattling.enemyNameGen();
                Console.WriteLine("\nName created!");
            }

            Console.WriteLine("\nEnter the name of the enemy's spell:");
            enemySpellName = Console.ReadLine();


            Console.WriteLine("\n\n\n-Battle " + battleCount + "!   " + playerName + " vs. " + enemyName + "-");
             

            //combat
            while (playerWizardBattling.playerHP > 0 && enemyWizardBattling.enemyHP > 0)
            {
                Console.WriteLine("\n--------------------------------------------------");
                Console.WriteLine("|   -Turn " + turnCount + "!-     Player HP: " + playerWizardBattling.playerHP + "   Enemy HP: " + enemyWizardBattling.enemyHP + "   |");
                Console.WriteLine("--------------------------------------------------");
                turnCount++;


                Console.WriteLine("Enter A to attack, H to heal,");
                Console.WriteLine("or M to meditate to regain Magic Points!");
                string? userTurnResponse = Console.ReadLine();
                
                if (userTurnResponse == "A" || userTurnResponse == "a")
                {
                    playerWizard.playerCastingSpell();
                    enemyWizard.enemyTurnChoice();
                }

                if (userTurnResponse == "H" || userTurnResponse == "h")
                {
                    playerWizard.playerHealing();
                    enemyWizard.enemyTurnChoice();
                }

                if (userTurnResponse == "M" || userTurnResponse == "m")
                {
                    playerWizard.playerMeditate();
                    enemyWizard.enemyTurnChoice();
                }
                
            }

            //player loses
            if (playerWizardBattling.playerHP <= 0)
            {
                Console.WriteLine("\n\n\nGame over! You lost.");
                Console.ReadKey();
            }

            //player wins, makes new battle(?)
            if (enemyWizardBattling.enemyHP <= 0)
            {
                battleCount++;
                Console.WriteLine("\n\n\nCongratulations! You won!");
                Console.ReadKey();
            }
        }
    }
}