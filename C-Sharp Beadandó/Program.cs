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
        public static Boolean torch = false;
        public static Boolean map = false;
        public static string playerName;
        public static string dogName;
        public static string place;
        public static string mission;


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
                mission = "Készíts egy fáklyát!";
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
                mission = "Kezdd el az utad!";
                torch = true;
                Console.WriteLine("Sikeresen elkészítetted a fáklyát!");
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
            mission = "Kezdd el az utad!";
            if (valasz.Equals("Balra"))
            {
                Console.WriteLine("Mégis bemész a vízbe, ám olyan mély, hogy azonnal lesüllyedsz az aljára és megfulladsz.");
                Console.ReadKey();
                dead = true;
            }

            if (valasz.Equals("Jobbra"))
            {
                place = "A barlang";
                mission = "Döntsd el, hogy merre szeretnél továbbmenni!";
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
                mission = "Szabadítsd ki a farkast!";
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
                    "Hálájából veled tart az utadon. Milyen nevet adsz neki?");
                nameDog();
                Console.WriteLine("A támadási értéked " + attack + "-ra nőtt, ám az éhséged is " + hungryness + "-es szintre emelkedett!\n" +
                    dogName +" társaságában visszamész, s elindultok a fény felé.");
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

        public void nameDog() {
            string valasz = Console.ReadLine();
            if (valasz == "")
            {
                Console.WriteLine("Adj egy nevet a kutyának!");
                nameDog();
            }
            else
            {
                dogName = valasz;
            }
        }

        public void newFriend() {
            place = "Az erdő";
            mission = "Döntsd el, hogy merre szeretnél menni!";
            Console.WriteLine("A fény egyre erősödik, s egy erdőbe érkezel.\n" +
                "Balra találsz egy almafát, előre egy dombot, jobbra pedig pár erősebb botot és köveket.\n" +
                "Furdal a kíváncsiság, hogy mi lehet a domb mögött, így csak EGYSZER választhatsz.\n" +
                "Dönts okosan! " +
                "Merre mész? (Balra/Előre/Jobbra)");
            erdo();
        }

        public void erdo() {
            string valasz = Console.ReadLine();
            place = "A puma árnyékában";
            mission = "A puma legyőzése";
            if (valasz.Equals("Balra"))
            {
                Console.WriteLine("Eszel az almából, aminek tápértéke 2. Ezután elindulsz a dombhoz.");
                hungryness -= 2;
                puma();
            }

            if (valasz.Equals("Jobbra"))
            {
                Console.WriteLine("A botokból és kövekből lándzsát készítesz, így támadási értéked 15-tel növekszik! Ezután elindulsz a dombhoz.");
                attack += 15;
                puma();
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
                    Console.WriteLine("Gratulálok, legyőzted a pumát!\nA puma megölése után tovább indulsz.\n" +
                        "Körülbelül fél óra séta után találsz egy holttestet.\n" +
                        "Az öltözetéből ítélve egy bányász volt.\n" +
                        "Kirabolod? (Igen/Nem)");
                    place = "A bányász nyughelye";
                    mission = "Hozd meg a helyes döntést!";
                    holttest();
                }
            }

            if (valasz.Equals("Nem"))
            {
                Console.WriteLine("Nem támadod meg a pumát, úgyhogy visszamész az erdőbe.");
                place = "Újra az erdőben";
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
                Console.WriteLine("Ezután tovább indulsz, és egy tisztásra érkezel.");
                helikopter();
            }

            if (valasz.Equals("Nem"))
            {
                Console.WriteLine("A lelkiismereted miatt nem veszed el a halott cuccait, szóval tovább mész. Egy tisztásra érkezel.");
                helikopter();
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

        public void helikopter() {
            Console.WriteLine("A tisztáson " + dogName + " valami szagot fogott, s elindul a forrása felé.\n" +
                "Egy lezuhant helikopterhez vezet. Sehol senki, még egy holttestet sem találsz, azonban egy térképet igen.\n" +
                "Ez a térkép néhány szigetet ábrázol, az egyik sziget úticélnak van megjelölve. Elteszed, hátha jól jön.\n" +
                "Töröd a fejed egy próbán, beindítod a helikoptert?");
            map = true;
            place = "A helikopter történetének nyomában";
            mission = "Döntsd el, hogy megéri-e engedni a kíváncsiságnak!";
            string valasz = Console.ReadLine();
            if (valasz.Equals("Igen"))
            {
                Console.WriteLine("Pár elszakadt vezeték zárlatot okoz, emiatt felgyullad a gép. A tűz egyre csak terjed, és az egész\n" +
                    "sziget lángba borul. Mivel nincs hova menned, élve elégsz a szigeten.");
                Console.WriteLine("Vége a játéknak.\nNyomj egy gombot a kilépéshez...");
                Console.ReadKey();
                dead = true;
            }

            if (valasz.Equals("Nem"))
            {
                Console.WriteLine("Mivel gyanús a helikopter, ezért elkezdesz a környéken nyomok után kutatni.\n" +
                    "Először a helikopterben kezdesz el kutatni.");
                keresesHelikopterben();
            }

            if (valasz.Equals("Statisztika"))
            {
                stats();
                helikopter();
            }

            if (valasz.Equals("Help"))
            {
                help();
                helikopter();
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
                helikopter();
            }
        }

        public void keresesHelikopterben() {
            place = "Keresés - 1.rész";
            mission = "Kutass nyomok után!";
            string valasz = Console.ReadLine();
            if (valasz.Equals("lehetőség2"))
            {
                //to be continued...
            }

            if (valasz.Equals("lehetőség1"))
            {
                //to be continued...
            }

            if (valasz.Equals("Statisztika"))
            {
                stats();
                keresesHelikopterben();
            }

            if (valasz.Equals("Help"))
            {
                help();
                keresesHelikopterben();
            }

            if (valasz.Equals("Feladom"))
            {
                Console.WriteLine("Majd legközelebb!");
                Console.WriteLine("Nyomj egy gombot a kilépéshez...");
                Console.ReadKey();
                dead = true;
            }

            if (!valasz.Equals("lehetőség1") && !valasz.Equals("lehetőség2") && !valasz.Equals("Feladom") && !valasz.Equals("Help"))
            {
                wrongAnswer();
                keresesHelikopterben();
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
            if (dogName != "") {
                Console.WriteLine("Játékos kutyájának neve: " + dogName);
            }
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Vagyon: " + gold + " arany");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Éhség: " + hungryness);
            Console.WriteLine("Támadási erő: " + attack);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Helyszín: " + place);
            Console.WriteLine("Küldetés: " + mission);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\nRendelkezésre álló tárgyak:");

            if (torch)
            {
                Console.WriteLine(" - Fáklya");
            }
                if (!torch)
                {
                    Console.WriteLine(" - ??? (Ismeretlen tárgy)");
                }

            if (pickaxe) {
                Console.WriteLine(" - Csákány");
            }
                if (!pickaxe) {
                    Console.WriteLine(" - ??? (Ismeretlen tárgy)");
                }

            if (map)
            {
                Console.WriteLine(" - Térkép");
            }
            if (!map)
            {
                Console.WriteLine(" - ??? (Ismeretlen tárgy)");
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
