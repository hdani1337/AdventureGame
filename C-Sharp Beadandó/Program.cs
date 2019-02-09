using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Beadandó
{
    class Program
    {
        public static byte gold = 0;
        public static byte attack = 10;
        public static byte hungryness = 0;
        public static Boolean dead = false;
        public static Boolean pickaxe = false;
        public static string playerName;
        public static string place;


        public Program()
        {  
            if (!dead) {
                Console.WriteLine("Hogy hívnak?");
                playerName = Console.ReadLine();
                Console.WriteLine("\nÜdv " + playerName + "! Készen állsz egy kalandra? (Igen/Nem)");
                introduction();
            }    
        }

        public void introduction() {
            string valasz = Console.ReadLine();
            if (valasz.Equals("Igen"))
            {
                place = "A Sziget";
                Console.WriteLine("Remek, kezdjünk is bele! (A ,,Help'' szóval bármikor kérhetsz segítséget)\nNyomj egy gombot a játék indításához!");
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine("Olyan furcsán érzed magad. Kinyitod a szemed, s egy szigeten találod magad furcsa öltözetben.\nKörülnézel, " +
                    "s támadt pár gondolatod.\nBalra melletted vannak ágak és zsinegek. " +
                    "Készíthetsz belőle fáklyát.\nElőtted van egy sötét barlang." +
                    "\nJobbra pedig pár madár keres valami eledelt a homokban." +
                    "\nMerre mész tovább? (Balra/Előre/Jobbra)");
                sziget();
            }

            else if (valasz.Equals("Nem"))
            {
                Console.WriteLine("Ezek szerint még nem vagy elég érett erre a feladatra. Majd legközelebb!");
                Console.WriteLine("Nyomj egy gombot a kilépéshez!");
                Console.ReadKey();
            }

            else if (valasz.Equals("Help")) {
                help();
            }

            if (valasz.Equals("Feladom"))
            {
                Console.WriteLine("Majd legközelebb!");
                Console.WriteLine("Nyomj egy gombot a kilépéshez...");
                Console.ReadKey();
                dead = true;
            }

            if (!valasz.Equals("Igen") && !valasz.Equals("Nem") && !valasz.Equals("Feladom") && !valasz.Equals("Help"))
            {
                wrongAnswer();
                introduction();
            }
        }

        public void sziget() {
            string valasz = Console.ReadLine();
            if (valasz.Equals("Balra")) {
                place = "Fáklyakészítő hely";
                Console.WriteLine("Elkészítetted a fáklyát!");
                hungryness++;
                Console.WriteLine("A munka miatt az éhséged " + hungryness + "-re nőtt. Vigyázz, ha az éhséged eléri a 10-es szintet, éhenhalsz!\n" +
                    "Balra nem tudsz menni, mert arra a tenger van. Jobbra a barlang található, előre pedig magas sziklák.\n" +
                    "Merre tovább? (Balra/Előre/Jobbra)");
                sziget2();
            }

            if (valasz.Equals("Jobbra")) {
                Console.WriteLine("Elindulsz a madarak felé. Észrevesznek, s nagyon mérgesek lesznek.\nMivel az öltözetednek gyenge a védőereje, ezért megölnek, s felfalják a holttested.");
                Console.ReadKey();
                dead = true;
            }

            if (valasz.Equals("Előre"))
            {
                Console.WriteLine("Mivel nincs fáklyád, ezért nem mehetsz be a barlangba! Szóval merre mész?");
                sziget();
            }

            if (valasz.Equals("Statisztika")) {
                stats();
                sziget();
            }

            if (valasz.Equals("Feladom"))
            {
                Console.WriteLine("Majd legközelebb!");
                Console.WriteLine("Nyomj egy gombot a kilépéshez...");
                Console.ReadKey();
                dead = true;
            }

            if (valasz.Equals("Help"))
            {
                help();
                sziget();
            }

            if (!valasz.Equals("Balra") && !valasz.Equals("Jobbra") && !valasz.Equals("Előre") && !valasz.Equals("Feladom") && !valasz.Equals("Help"))
            {
                wrongAnswer();
                sziget();
            }
        }

        public void sziget2() {
            string valasz = Console.ReadLine();
            if (valasz.Equals("Balra"))
            {
                Console.WriteLine("Mégis bemész a vízbe, ám olyan mély, hogy azonnal lesüllyedsz az aljára és megfulladsz.");
                Console.ReadKey();
                dead = true;
            }

            if (valasz.Equals("Jobbra"))
            {
                place = "A barlang";
                Console.WriteLine("Beértél a barlangba és meggyújtod a fákját. Azonnal kettéoszlik a barlang.\n" +
                    "Balról kutyaugatást hallasz, jobbról pedig gyenge fény pislákol. Merre mész? (Balra/Jobbra)");
                barlang();
            }

            if (valasz.Equals("Előre"))
            {
                Console.WriteLine("Mivel nem tudsz falat mászni, ezért nem mehetsz fel a sziklára! Szóval merre mész?");
                sziget2();
            }

            if (valasz.Equals("Statisztika"))
            {
                stats();
                sziget2();
            }

            if (valasz.Equals("Help"))
            {
                help();
                sziget2();
            }

            if (valasz.Equals("Feladom"))
            {
                Console.WriteLine("Majd legközelebb!");
                Console.WriteLine("Nyomj egy gombot a kilépéshez...");
                Console.ReadKey();
                dead = true;
            }

            if (!valasz.Equals("Balra") && !valasz.Equals("Jobbra") && !valasz.Equals("Előre") && !valasz.Equals("Feladom") && !valasz.Equals("Help"))
            {
                wrongAnswer();
                sziget2();
            }
        }

        public void barlang() {
            string valasz = Console.ReadLine();
            if (valasz.Equals("Balra"))
            {
                place = "A farkas";
                Console.WriteLine("Erőt veszel magadon, és elindulsz az ugatás felé." +
                    "\nMeglepő, egy farkaskutya az, akinek beszorult a lába egy kő alá. Segítesz neki? (Igen/Nem)");
                farkas();
            }

            if (valasz.Equals("Jobbra"))
            {
                place = "Az erdő";
                Console.WriteLine("Elindulsz a fény felé, ami egyre erősödik, s egy erdőbe érkezel.");
                erdo();
            }

            if (valasz.Equals("Statisztika"))
            {
                stats();
                barlang();
            }

            if (valasz.Equals("Help"))
            {
                help();
                barlang();
            }

            if (valasz.Equals("Feladom"))
            {
                Console.WriteLine("Majd legközelebb!");
                Console.WriteLine("Nyomj egy gombot a kilépéshez...");
                Console.ReadKey();
                dead = true;
            }

            if (!valasz.Equals("Balra") && !valasz.Equals("Jobbra") && !valasz.Equals("Feladom") && !valasz.Equals("Help"))
            {
                wrongAnswer();
                barlang();
            }
        }

        public void farkas() {
            string valasz = Console.ReadLine();
            if (valasz.Equals("Igen"))
            {
                attack += 10;
                hungryness += 1;
                Console.WriteLine("Sikerült kiszabadítanod a farkast, aki azonnal odafut hozzád és örömében megnyalogat.\n" +
                    "Hálájából veled tart az utadon, így a támadási értéked " + attack + "-ra nőtt, ám az éhséged is " + hungryness + "-es szintre emelkedett!\n" +
                    "Visszamész az új társaddal, s elindultok a fény felé.");
                newFriend();
            }

            if (valasz.Equals("Nem"))
            {
                Console.WriteLine("Hátat fordítasz a farkasnak, teszel pár lépést és sikerül kiszabadulnia.\n" +
                    "Mivel nem segítettél neki, bosszúból azonnal megöl.");
                Console.WriteLine("Vége a játéknak!");
                Console.WriteLine("\nNyomj egy gombot a kilépéshez...");
                Console.ReadKey();
                dead = true;
            }

            if (valasz.Equals("Statisztika"))
            {
                stats();
                farkas();
            }

            if (valasz.Equals("Help"))
            {
                help();
                farkas();
            }

            if (valasz.Equals("Feladom"))
            {
                Console.WriteLine("Majd legközelebb!");
                Console.WriteLine("Nyomj egy gombot a kilépéshez...");
                Console.ReadKey();
                dead = true;
            }

            if (!valasz.Equals("Igen") && !valasz.Equals("Nem") && !valasz.Equals("Feladom") && !valasz.Equals("Help"))
            {
                wrongAnswer();
                farkas();
            }
        }

        public void newFriend() {
            place = "Az erdő";
            Console.WriteLine("A fény egyre erősödik, s egy erdőbe érkezel.\n" +
                "Balra találsz egy almafát, előre egy dombot, jobbra pedig pár erősebb botot és köveket.\nMerre mész? (Balra/Előre/Jobbra)");
            erdo();
        }

        public void erdo() {
            string valasz = Console.ReadLine();
            if (valasz.Equals("Balra"))
            {
                Console.WriteLine("Eszel az almából, aminek tápértéke 2.");
                hungryness -= 2;
            }

            if (valasz.Equals("Jobbra"))
            {
                Console.WriteLine("A botokból és kövekből lándzsát készítesz, így támadási értéked 15-tel növekszik!");
                attack += 15;
            }

            if (valasz.Equals("Előre"))
            {
                Console.WriteLine("A dombon túl egy pumát pillantasz meg. Támadási értéke 30. megtámadod? (Igen/Nem)");
                puma();
            }

            if (valasz.Equals("Statisztika"))
            {
                stats();
                erdo();
            }

            if (valasz.Equals("Help"))
            {
                help();
                erdo();
            }

            if (valasz.Equals("Feladom"))
            {
                Console.WriteLine("Majd legközelebb!");
                Console.WriteLine("Nyomj egy gombot a kilépéshez...");
                Console.ReadKey();
                dead = true;
            }

            if (!valasz.Equals("Balra") && !valasz.Equals("Jobbra") && !valasz.Equals("Előre") && !valasz.Equals("Feladom") && !valasz.Equals("Help"))
            {
                wrongAnswer();
                erdo();
            }
        }

        public void puma() {
            string valasz = Console.ReadLine();
            byte pumaAttack = 15;

            if (valasz.Equals("Igen"))
            {
                battle(attack, pumaAttack);
                if (!dead) {
                    Console.WriteLine("Gratulálok, legyőzted a pumát!\nA puma megölése után tovább indulsz. Körülbelül fél óra séta után találsz egy holttestet. Kirabolod? (Igen/Nem)");
                    holttest();
                }
            }

            if (valasz.Equals("Nem"))
            {
                Console.WriteLine("Nem támadod meg a pumát, úgyhogy visszamész az erdőbe.");
                erdo();
            }

            if (valasz.Equals("Statisztika"))
            {
                stats();
                puma();
            }

            if (valasz.Equals("Help"))
            {
                help();
                puma();
            }

            if (valasz.Equals("Feladom"))
            {
                Console.WriteLine("Majd legközelebb!");
                Console.WriteLine("Nyomj egy gombot a kilépéshez...");
                Console.ReadKey();
                dead = true;
            }

            if (!valasz.Equals("Igen") && !valasz.Equals("Nem") && !valasz.Equals("Feladom") && !valasz.Equals("Help"))
            {
                wrongAnswer();
                puma();
            }
        }

        public void holttest() {
            string valasz = Console.ReadLine();
            if (valasz.Equals("Igen"))
            {
                Console.WriteLine("A hullánál találsz 10 aranyat és egy csákányt, amivel tudsz falat mászni.");
                gold += 10;
                pickaxe = true;
            }

            if (valasz.Equals("Nem"))
            {
                
            }

            if (valasz.Equals("Statisztika"))
            {
                stats();
                holttest();
            }

            if (valasz.Equals("Help"))
            {
                help();
                holttest();
            }

            if (valasz.Equals("Feladom"))
            {
                Console.WriteLine("Majd legközelebb!");
                Console.WriteLine("Nyomj egy gombot a kilépéshez...");
                Console.ReadKey();
                dead = true;
            }

            if (!valasz.Equals("Igen") && !valasz.Equals("Nem") && !valasz.Equals("Feladom") && !valasz.Equals("Help"))
            {
                wrongAnswer();
                holttest();
            }
        }

        public void battle(byte playerAttack, byte enemyAttack) {
            if (playerAttack >= enemyAttack) {
                dead = false;
            }

            if (playerAttack < enemyAttack) {
                dead = true;
            }
        }

        public void help() {
            Console.WriteLine("\nEz egy szöveg alapú kalandjáték. Csak a zárojelben megadott válaszleghetőségek elfogadottak.\n" +
                "A játékban bármikor használhatod a ,,Statisztika'' parancsot, ami leírja a pontos információidat.\n" +
                "A játékot bármikor befejezheted a ,,Feladom'' szóval.\n" +
                "Sok sikert a játékhoz!");
        }

        public void stats() {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Támadási erő: " + attack);
            Console.WriteLine("\nStatisztika:\n");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Játékos neve: " + playerName);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Vagyon: " + gold + " arany");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Éhség: " + hungryness);
            Console.WriteLine("Támadási erő: " + attack);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Helyszín: " + place);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\nRendelkezésre álló tárgyak:");
            if (pickaxe) {
                Console.WriteLine(" - Csákány");
            }
            if (!pickaxe) {
                Console.WriteLine(" - ?");
            }
            Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void wrongAnswer() {
            Console.WriteLine("\nHibás válasz. Kérlek, add meg újra a választ!");
        }

        static void Main(string[] args)
        {
            Console.Title = "hdani1337-AdventureGame";
            Console.SetWindowSize(120,40);
            if (hungryness >= 10)
            {
                dead = true;
            }

            if (dead)
            {
                Console.WriteLine("Vége a játéknak!");
                Console.WriteLine("\nNyomj egy gombot a kilépéshez...");
                Console.ReadKey();
            }

            if (!dead)
            {
                new Program();
            }
        }
    }
}
