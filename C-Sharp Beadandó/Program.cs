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
        public static string playerName;
        public static string place;
        

        public Program() {
            Console.WriteLine("Hogy hívnak?");
            playerName = Console.ReadLine();
            Console.WriteLine("\nÜdv " + playerName + "! Készen állsz egy kalandra? (Igen/Nem)");
            introduction();
        }

        public void introduction() {
            string valasz = Console.ReadLine();
            if (valasz.Equals("Igen"))
            {
                place = "A Sziget";
                Console.WriteLine("Remek, kezdjünk is bele! (A ,,Help'' szóval bármikor kérhetsz segítséget)\n");
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
                dead = true;
            }

            else
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
                dead = true;
            }

            if (valasz.Equals("Help"))
            {
                help();
                sziget();
            }

            if (!valasz.Equals("Balra") && !valasz.Equals("Jobbra") && !valasz.Equals("Előre"))
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
                dead = true;
            }

            if (!valasz.Equals("Balra") && !valasz.Equals("Jobbra") && !valasz.Equals("Előre"))
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
                dead = true;
            }

            if (!valasz.Equals("Balra") && !valasz.Equals("Jobbra"))
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
                    "Visszamész az új társaddal. Jobbra vissza kimehetsz a szigetre, balra pedig elindulhatsz a pislákoló fény felé.\nMerre haladsz tovább? (Balra/Jobbra)");
                newFriend();
            }

            if (valasz.Equals("Nem"))
            {
                Console.WriteLine("Hátat fordítasz a farkasnak, teszel pár lépést és sikerül kiszabadulnia.\n" +
                    "Mivel nem segítettél neki, bosszúból azonnal megöl.");
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
                dead = true;
            }

            if (!valasz.Equals("Igen") && !valasz.Equals("Nem"))
            {
                wrongAnswer();
                farkas();
            }
        }

        public void newFriend() {
            string valasz = Console.ReadLine();

            if (valasz.Equals("Balra"))
            {
                byte madarakAttack = 25;
                place = "A sziget";
                Console.WriteLine("Vissza kiérsz a szigetre, ám veled szemben áll az összes madár. Támadási erejük " + madarakAttack + ". Megtámadod őket? (Igen/nem)");
                battle(attack,madarakAttack);
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
                newFriend();
            }

            if (valasz.Equals("Help"))
            {
                help();
                newFriend();
            }

            if (valasz.Equals("Feladom"))
            {
                dead = true;
            }

            if (!valasz.Equals("Balra") && !valasz.Equals("Jobbra"))
            {
                wrongAnswer();
                newFriend();
            }
        }

        public void erdo() {
        }

        public void battle(byte playerAttack, byte enemyAttack) {
            if (playerAttack >= enemyAttack) {
                Console.WriteLine("Győztél!");
            }

            if (playerAttack < enemyAttack) {
                Console.WriteLine("Az ellenség fölényben volt, így meghaltál.");
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
            Console.WriteLine("Játékos neve: " + playerName);
            Console.WriteLine("Vagyon: " + gold + " arany");
            Console.WriteLine("Éhség: " + hungryness);
            Console.WriteLine("Helyszín: " + place);
            Console.WriteLine("Támadási erő: " + attack);
        }

        public void wrongAnswer() {
            Console.WriteLine("\nHibás válasz. Kérlek, add meg újra a választ!");
        }

        static void Main(string[] args)
        {
            Console.Title = "hdani1337-AdventureGame";
            Console.SetWindowSize(120,40);
            new Program();
            if (hungryness >= 10) {
                dead = true;
            }

            if (dead) {
                Console.WriteLine("Vége a játéknak!");
                Console.WriteLine("\nNyomj egy gombot a kilépéshez...");
                Console.ReadKey();
            }
        }
    }
}
