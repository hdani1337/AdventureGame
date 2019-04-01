using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Beadandó
{
    class Program
    {
        public static byte gold = 0;//A játékos vagyona, ha te vagy Mészáros Lőrinc, el se indítsd, mert nem lesz elég a byte
        public static byte firecracker = 0;//Petárdák, harcnál jól jöhet
        public static byte attack = 10;//Játékos kezdő támadási érték
        public static byte lockpick = 0;//Zárfeltörők
        public static byte hungryness = 0;//Éhségi szint, ha eléri a 10-et, meghal a játékos
        public static byte match = 0;//Gyufa mennyisége
        public static byte lives = 5;//Életek
        public static Boolean dead = false;
        public static Boolean pickaxe = false;//Csákány falmászáshoz
        public static Boolean torch = false;//Fáklya sötétben látáshoz
        public static Boolean map = false;//Térkép
        public static Boolean samanPorkolt = false;//Németh Szilárd szent eledele
        public static Boolean quest = false;//Van e mellékküldetés folyamatban
        public static Boolean kisvasut = false;//A törpe kismozdonya
        public static Boolean superGoat = false;//A kecskefejű ember
        public static Random random = new Random();
        public static string playerName;//Játékos neve
        public static string dogName = "";//Játékos kutyájának neve
        public static string place;//Helyszín
        public static string mission;//Jelenlegi fő küldetés

        //Robi takarodj innen mert eltöröm a kezed :D

        public Program()
        {
            if (!dead) {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Hogy hívnak? ");
                Console.ForegroundColor = ConsoleColor.Green;
                playerName = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("\nÜdv " + playerName + "! Készen állsz egy kalandra? (Igen/Nem) ");
                introduction();
            }    
        }

        public void introduction()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            string valasz = Console.ReadLine();
            if (valasz.Equals("Igen"))
            {
                place = "A Sziget";
                mission = "Készíts egy fáklyát!";
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\nSzabályok:");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(" - A válaszaidat a megadott formában add meg!");
                Console.WriteLine(" - Minden egyes döntésed befolyásolja a játék menetét. Dönts bölcsen!");
                Console.WriteLine(" - Ne feledd, néhol a sikeredet csak a szerencse fogja eldönteni!");
                Console.WriteLine(" - Az esetleges politikai nézeteltérések miatt a fejlesztő nem vállal felelősséget.");
                Console.WriteLine(" - A ,,Help'' szóval bármikor kérhetsz segítséget.");
                Console.WriteLine("\nNyomj egy gombot a játék indításához!");
                Console.ReadKey();
                Console.Clear();
                title(place);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Olyan furcsán érzed magad. Kinyitod a szemed, s egy szigeten találod magad furcsa öltözetben.\nKörülnézel, " +
                    "s támadt pár gondolatod.\n");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Balra melletted vannak ágak, zsinegek és egy gyufa. Készíthetsz belőle fáklyát.");
                Console.WriteLine("Előtted van egy sötét barlang.");
                Console.WriteLine("Jobbra pedig pár madár keres valami eledelt a homokban.");

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("\nMerre mész tovább? (Balra/Előre/Jobbra) ");
                sziget();
            }

            else if (valasz.Equals("Nem"))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ezek szerint még nem vagy elég érett erre a feladatra. Majd legközelebb!");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Nyomj egy gombot a kilépéshez!");
                Console.ReadKey();
            }

            else if (valasz.Equals("Help"))
            {
                help();
            }

            if (valasz.Equals("Feladom"))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Majd legközelebb!");
                Console.ForegroundColor = ConsoleColor.Green;
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

        public void sziget()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            string valasz = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            if (valasz.Equals("Balra"))
            {
                place = "Fáklyakészítő hely";
                mission = "Kezdd el az utad!";
                title(place);
                torch = true;
                match += 1;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nSikeresen elkészítetted a fáklyát!");
                Console.ForegroundColor = ConsoleColor.White;
                hungryness++;
                if (hungryness >= 10)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Mivel az éhségi szinted " + hungryness + ", ezért éhenhaltál.");
                    newChance();
                    sziget();
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nA munka miatt az éhséged " + hungryness + "-re nőtt. Vigyázz, ha az éhséged eléri a 10-es szintet, éhenhalsz!\n");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Balra nem tudsz menni, mert arra a tenger van.");
                Console.WriteLine("Jobbra a barlang található.");
                Console.WriteLine("Előre pedig magas sziklák vannak.");

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("\nMerre tovább? (Balra/Előre/Jobbra) ");
                sziget2();
            }

            if (valasz.Equals("Jobbra"))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Elindulsz a madarak felé. Észrevesznek, s nagyon mérgesek lesznek.\nMivel az öltözetednek gyenge a védőereje, ezért megölnek, s felfalják a holttested.");
                newChance();
                sziget();
            }

            if (valasz.Equals("Előre"))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Mivel nincs fáklyád, ezért nem mehetsz be a barlangba!");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("\nSzóval merre mész? ");
                sziget();
            }

            if (valasz.Equals("Statisztika"))
            {
                stats();
                sziget();
            }

            if (valasz.Equals("Feladom"))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Majd legközelebb!");
                Console.ForegroundColor = ConsoleColor.Green;
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

        public void newChance()
        {
            if (lives >= 0)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("Folytatod a játékot? (Igen/Nem) ");
                Console.ForegroundColor = ConsoleColor.Green;
                string valasz = Console.ReadLine();
                switch (valasz)
                {
                    case "Igen":
                        {
                            lives--;
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine("Folytatod a játékot.");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("Életeid száma: " + lives);
                            if (hungryness >= 10) hungryness = 0;
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.Write("Válasz a halálod előtti kérdésre: ");
                            break;
                        }

                    case "Nem":
                        {
                            Console.WriteLine("Nyomj egy gombot a kilépéshez...");
                            Console.ReadKey();
                            break;
                        }

                    default:
                        {
                            wrongAnswer();
                            newChance();
                            break;
                        }
                }
            }
            else
            {
                Console.WriteLine("Sajnos nincs több életed.");
                Console.WriteLine("Vége a játéknak.");
                Console.WriteLine("Nyomj egy gombot a kilépéshez...");
                Console.ReadKey();
            }
        }

        public void sziget2()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            string valasz = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            mission = "Kezdd el az utad!";
            if (valasz.Equals("Balra"))
            {
                Console.WriteLine("Mégis bemész a vízbe, ám olyan mély, hogy azonnal lesüllyedsz az aljára és megfulladsz.");
                Console.WriteLine("Nyomj egy gombot a kilépéshez...");
                newChance();
                sziget2();
            }

            if (valasz.Equals("Jobbra"))
            {
                place = "A barlang";
                mission = "Döntsd el, hogy merre szeretnél továbbmenni!";
                title(place);
                Console.WriteLine("\nBeértél a barlangba és meggyújtod a fákját. Azonnal kettéoszlik a barlang.\n");
                match -= 1;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Balról kutyaugatást hallasz.");
                Console.WriteLine("Jobbról gyenge fény pislákol.");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("\nMerre mész? (Balra/Jobbra) ");
                barlang();
            }

            if (valasz.Equals("Előre"))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Mivel nem tudsz falat mászni, ezért nem mehetsz fel a sziklára!");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("\nSzóval merre mész? ");
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
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Majd legközelebb!");
                Console.ForegroundColor = ConsoleColor.Green;
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

        public void barlang()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            string valasz = Console.ReadLine();
            if (valasz.Equals("Balra"))
            {
                place = "A farkas";
                mission = "Szabadítsd ki a farkast!";
                title(place);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("\nErőt veszel magadon, és elindulsz az ugatás felé." +
                    "\nMeglepő, egy farkaskutya az, akinek beszorult a lába egy kő alá.");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("\nSegítesz neki? (Igen/Nem) "); 
                farkas();
            }

            if (valasz.Equals("Jobbra"))
            {
                place = "Az erdő";
                title(place);
                Console.WriteLine("Elindulsz a fény felé, ami egyre erősödik, s egy erdőbe érkezel.");
                place = "Az erdő";
                mission = "Döntsd el, hogy merre szeretnél menni!";
                title(place);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Balra találsz egy almafát.");
                Console.WriteLine("Előre egy domb van.");
                Console.WriteLine("Jobbra pedig pár erősebb botot és köveket találsz.\n");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Furdal a kíváncsiság, hogy mi lehet a domb mögött, így csak EGYSZER választhatsz.\n" +
                    "Dönts okosan! " +
                    "Merre mész? (Balra/Előre/Jobbra)");
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
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Majd legközelebb!");
                Console.ForegroundColor = ConsoleColor.Green;
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

        public void farkas()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            string valasz = Console.ReadLine();
            if (valasz.Equals("Igen"))
            {
                attack += 10;
                hungryness += 1;
                if (hungryness >= 10)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Mivel az éhségi szinted " + hungryness + ", ezért éhenhaltál.");
                    newChance();
                    farkas();
                }
                Console.WriteLine("Sikerült kiszabadítanod a farkast, aki azonnal odafut hozzád és örömében megnyalogat.\n" +
                    "Hálájából veled tart az utadon.");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("Milyen nevet adsz neki? ");
                nameDog();
                Console.WriteLine("\nA támadási értéked " + attack + "-ra nőtt, ám az éhséged is " + hungryness + "-es szintre emelkedett!\n" +
                    dogName +" társaságában visszamész, s elindultok a fény felé.");
                newFriend();
            }

            if (valasz.Equals("Nem"))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Hátat fordítasz a farkasnak, teszel pár lépést és sikerül kiszabadulnia.");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Mivel nem segítettél neki, bosszúból azonnal megöl.");
                newChance();
                farkas();
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
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Majd legközelebb!");
                Console.ForegroundColor = ConsoleColor.Green;
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

        public void nameDog()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            string valasz = Console.ReadLine();
            if (valasz == "")
            {
                Console.Write("\nAdj egy nevet a kutyának! ");
                nameDog();
            }
            else
            {
                dogName = valasz;
            }
        }

        public void newFriend()
        {
            place = "Az erdő";
            mission = "Döntsd el, hogy merre szeretnél menni!";
            title(place);
            Console.WriteLine("A fény egyre erősödik, s egy erdőbe érkezel.\n");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Balra találsz egy almafát.");
            Console.WriteLine("Előre egy domb van.");
            Console.WriteLine("Jobbra pedig pár erősebb botot és köveket találsz.\n");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("Dönts okosan! Merre mész? (Balra/Előre/Jobbra) ");
            erdo();
        }

        Boolean almaElfogyasztva = false;
        Boolean landzsaElkeszitve = false;
        Boolean pumaLegyozve = false;

        public void erdo()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            string valasz = Console.ReadLine();
            place = "A puma árnyékában";
            mission = "A puma legyőzése";
            title(place);
            if (valasz.Equals("Balra"))
            {                
                if (!almaElfogyasztva)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Eszel az almából, aminek tápértéke 2. Ezután elindulsz a dombhoz.");
                    hungryness -= 2;
                    if (hungryness < 0) hungryness = 0;
                    almaElfogyasztva = true;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Balra találsz egy almafát.");
                    Console.WriteLine("Előre egy domb van.");
                    Console.WriteLine("Jobbra pedig pár erősebb botot és köveket találsz.\n");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write("Dönts okosan! Merre mész? (Balra/Előre/Jobbra) ");
                    erdo();
                }
                else {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Már megetted az almát!");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Balra találsz egy almafát.");
                    Console.WriteLine("Előre egy domb van.");
                    Console.WriteLine("Jobbra pedig pár erősebb botot és köveket találsz.\n");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write("Dönts okosan! Merre mész? (Balra/Előre/Jobbra) ");
                    erdo();
                }
            }

            if (valasz.Equals("Jobbra"))
            {
                if (!landzsaElkeszitve)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("A botokból és kövekből lándzsát készítesz, így támadási értéked 15-tel növekszik! Ezután elindulsz a dombhoz.");
                    attack += 15;
                    landzsaElkeszitve = true;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Balra találsz egy almafát.");
                    Console.WriteLine("Előre egy domb van.");
                    Console.WriteLine("Jobbra pedig pár erősebb botot és köveket találsz.\n");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write("Dönts okosan! Merre mész? (Balra/Előre/Jobbra) ");
                    erdo();
                }

                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Már elkészítetted a lándzsát!");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Balra találsz egy almafát.");
                    Console.WriteLine("Előre egy domb van.");
                    Console.WriteLine("Jobbra pedig pár erősebb botot és köveket találsz.\n");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write("Dönts okosan! Merre mész? (Balra/Előre/Jobbra) ");
                    erdo();
                }
                
            }

            if (valasz.Equals("Előre"))
            {               
                if (!pumaLegyozve)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("A dombon túl egy pumát pillantasz meg. Támadási értéke 30.");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write("Megtámadod? (Igen/Nem) ");
                    puma();
                }

                else
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Mivel már legyőzted a pumát, ezért csak simán átmész a dombon.");
                    if (!pickaxe)//ha nincs a játékosnál csákány, akkor biztos, hogy nem rabolta ki a hullát
                    {
                        Console.WriteLine("Körülbelül fél óra séta után találsz egy holttestet.\n" + " Az öltözetéből ítélve egy bányász volt.\n");
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("\nKirabolod? (Igen/Nem) ");
                        place = "A bányász nyughelye";
                        mission = "Hozd meg a helyes döntést!";
                        Console.Title = "hdani1337-AdventureGame - " + place;
                        holttest();
                    }
                    else
                    {//ha pedig már kirabolta, akkor menjen tovább
                        Console.WriteLine("Hosszú séta vár rád.");
                        Console.WriteLine("Elhaladsz a bányász holtteste és a helikopter mellett is.");
                    }
                }
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
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Majd legközelebb!");
                Console.ForegroundColor = ConsoleColor.Green;
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

        public void puma()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            string valasz = Console.ReadLine();
            byte pumaAttack = 15;

            if (valasz.Equals("Igen"))
            {
                battle(attack, pumaAttack);
                if (!dead)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Gratulálok, legyőzted a pumát!");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("A puma megölése után tovább indulsz.");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Körülbelül fél óra séta után találsz egy holttestet. Az öltözetéből ítélve egy bányász volt.");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write("Kirabolod? (Igen/Nem) ");
                    place = "A bányász nyughelye";
                    mission = "Hozd meg a helyes döntést!";
                    Console.Title = "hdani1337-AdventureGame - " + place;
                    holttest();
                }
                else
                {
                    newChance();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Most ismét az erdőben vagy!");
                    place = "Újra az erdőben";
                    title(place);
                    Console.WriteLine("Balra találsz egy almafát.");
                    Console.WriteLine("Előre egy domb van.");
                    Console.WriteLine("Jobbra pedig pár erősebb botot és köveket találsz.\n");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write("Dönts okosan! Merre mész? (Balra/Előre/Jobbra) ");
                    erdo();                  
                }
            }

            if (valasz.Equals("Nem"))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Nem támadod meg a pumát, úgyhogy visszamész az erdőbe.");
                place = "Újra az erdőben";
                title(place);               
                Console.WriteLine("Balra találsz egy almafát.");
                Console.WriteLine("Előre egy domb van.");
                Console.WriteLine("Jobbra pedig pár erősebb botot és köveket találsz.\n");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("Dönts okosan! Merre mész? (Balra/Előre/Jobbra) ");
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
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Majd legközelebb!");
                Console.ForegroundColor = ConsoleColor.Green;
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

        public void holttest()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            string valasz = Console.ReadLine();
            if (valasz.Equals("Igen"))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("A hullánál találsz 10 aranyat és egy csákányt, amivel tudsz falat mászni.");
                gold += 10;
                pickaxe = true;
                if (!map)
                {//ekkor biztosan nem volt még a helikopternél
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Ezután tovább indulsz, és egy tisztásra érkezel.");
                    helikopter();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("A holttest kifosztása után tovább sétálsz. Elhaladsz a helikopter mellett is.");
                    hungryness += 3;
                    if (hungryness >= 10)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Mivel az éhségi szinted " + hungryness + ", ezért éhenhaltál.");
                        Console.WriteLine("Vége a játéknak!");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Nyomj egy gombot a kilépéshez...");
                    }
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ismét elkap az éhség. Éhségi szinted: " + hungryness);
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write("Elmész ételt keresni? (Igen/Nem)");
                    ladaKajaDontes();
                }
            }

            if (valasz.Equals("Nem"))
            {
                if (!map)
                {
                    Console.WriteLine("A lelkiismereted miatt nem veszed el a halott cuccait, szóval tovább mész. Egy tisztásra érkezel.");
                    helikopter();
                }
                else
                {
                    Console.WriteLine("Nem fosztod ki a hullát, úgyhogy tovább sétálsz. Elhaladsz a helikopter mellett is.");
                }
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
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Majd legközelebb!");
                Console.ForegroundColor = ConsoleColor.Green;
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

        public void helikopter()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("A tisztáson " + dogName + " valami szagot fogott, s elindul a forrása felé.\n" +
                "Egy lezuhant helikopterhez vezet. Sehol senki, még egy holttestet sem találsz, azonban egy térképet igen.\n" +
                "Ez a térkép néhány szigetet ábrázol, az egyik sziget úticélnak van megjelölve. Elteszed, hátha jól jön.");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("Töröd a fejed egy próbán, beindítod a helikoptert? (Igen/Nem) ");
            map = true;
            place = "A helikopter történetének nyomában";
            mission = "Döntsd el, hogy megéri-e engedni a kíváncsiságnak!";
            title(place);
            Console.ForegroundColor = ConsoleColor.Green;
            string valasz = Console.ReadLine();
            if (valasz.Equals("Igen"))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Pár elszakadt vezeték zárlatot okoz, emiatt felgyullad a gép. A tűz egyre csak terjed, és az egész\n" +
                    "sziget lángba borul. Mivel nincs hova menned, élve elégsz a szigeten.");
                newChance();
                helikopter();
            }

            if (valasz.Equals("Nem"))
            {
                Console.WriteLine("Mivel gyanús a helikopter, ezért elkezdesz a környéken nyomok után kutatni.\n" +
                    "Először a helikopterben kezdesz el kutatni. Észreveszel egy ládát, egy kesztyűtartót és egy bőröndöt.");
                Console.Write("Melyiket nyitod ki? (Láda/Kesztyűtartó/Bőrönd)");
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
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Majd legközelebb!");
                Console.ForegroundColor = ConsoleColor.Green;
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

        public void keresesHelikopterben()
        {
            place = "Keresés - 1.rész";
            mission = "Kutass nyomok után!";
            title(place);
            Console.ForegroundColor = ConsoleColor.Green;
            string valasz = Console.ReadLine();
            if (valasz.Equals("Láda"))
            {
                Console.WriteLine("Próbálod feszegetni a ládát, de kulcs kell hozzá. Válassz mást!");
                keresesHelikopterben();
            }

            if (valasz.Equals("Kesztyűtartó"))
            {
                Console.WriteLine("A kesztyűtartóban megtalálod a pilóta papírjait.");
                pilotData();
                Console.WriteLine("Mivel a bőrönd számkódos, próbálkozol a kinyitásával az adatok alapján.");
                Console.WriteLine("Milyen számot választasz?");
                borond();
            }

            if (valasz.Equals("Bőrönd"))
            {
                Console.WriteLine("Megpróbálod kinyitni a bőröndöt, de egy számkóddal le van zárva. Válassz mást!");
                keresesHelikopterben();
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
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Majd legközelebb!");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Nyomj egy gombot a kilépéshez...");
                Console.ReadKey();
                dead = true;
            }

            if (!valasz.Equals("Láda") && !valasz.Equals("Kesztyűtartó") && !valasz.Equals("Bőrönd") && !valasz.Equals("Feladom") && !valasz.Equals("Help"))
            {
                wrongAnswer();
                keresesHelikopterben();
            }
        }

        public void borond()
        {
            place = "A bőrönd";
            mission = "Fejtsd meg a kódot!";
            title(place);
            Console.ForegroundColor = ConsoleColor.Green;
            string valasz = Console.ReadLine();

            if (!valasz.Equals("0323"))
            {
                Console.WriteLine("Nem nyílik ki a bőrönd. Próbáld újra");
            }

            if (valasz.Equals("0323"))
            {
                Console.WriteLine("Kinyitottad a bőröndöt.");
                Console.WriteLine("Találsz benne egy kulcsot és némi élelmiszert.");
                Console.ForegroundColor = ConsoleColor.Green;
                hungryness = 2;
                Console.WriteLine("Miután elfogyasztottad az ételt, az éhséged " + hungryness + " szintre csökkent.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Ezután a talált kulccsal megpróbálod kinyitni a ládát.");
                lada();
            }

            if (valasz.Equals("Statisztika"))
            {
                stats();
                borond();
            }

            if (valasz.Equals("Help"))
            {
                help();
                borond();
            }

            if (valasz.Equals("Feladom"))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Majd legközelebb!");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Nyomj egy gombot a kilépéshez...");
                Console.ReadKey();
                dead = true;
            }

            else
            {
                wrongAnswer();
                borond();
            }
        }

        public void lada()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("A ládában találsz 7 petárdát. Sebzési értékük 5.");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Használatukhoz gyufa szükséges!");
            firecracker = 7;
            hungryness += 3;
            if (hungryness >= 10)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Mivel az éhségi szinted " + hungryness + ", ezért éhenhaltál.");
                Console.WriteLine("Vége a játéknak!");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Nyomj egy gombot a kilépéshez...");
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Ettől a sok kalandtól az éhséged " + hungryness + ". szintre nőtt. Lassan kéne enni valamit.");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("\nSzeretnél ételt keresni? (Igen/Nem) ");
            ladaKajaDontes();
        }

        public void ladaKajaDontes()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            string valasz = Console.ReadLine();

            if (valasz.Equals("Igen"))
            {
                Console.WriteLine("Két irányba indulhatsz el ételt keresni.");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Balra találsz egy üres táborhelyet.");
                Console.WriteLine("Jobbra pedig egy gyümölcsöst veszel észre.");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("\nMerre mész? (Balra/Jobbra) ");

                kajaKereses();
            }

            if (valasz.Equals("Nem"))
            {
                Console.WriteLine("Útközben találkozol egy medvével.");
                Console.WriteLine("Támadási értéke 40.");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("\nMegtámadod? (Igen/Nem) ");

                maciLaci();
            }

            if (valasz.Equals("Help"))
            {
                help();
                ladaKajaDontes();
            }

            if (valasz.Equals("Statisztika"))
            {
                stats();
                ladaKajaDontes();
            }

            if (valasz.Equals("Feladom"))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Majd legközelebb!");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Nyomj egy gombot a kilépéshez...");
                Console.ReadKey();
                dead = true;
            }

            else
            {
                wrongAnswer();
                ladaKajaDontes();
            }
        }

        public void kajaKereses()
        {
            place = "Az éhség nagy úr";
            mission = "Kutakodj étel után!";
            title(place);
            Console.ForegroundColor = ConsoleColor.Green;
            string valasz = Console.ReadLine();

            if (valasz.Equals("Balra"))
            {
                Console.WriteLine("A táborban találtál pár tápláló konzervet, így az éhséges 0-ra csökken.");
                hungryness = 0;
                Console.WriteLine("A lakoma miatt elálmosodsz, és alszol egyet.");
                Console.WriteLine("A homokos parton ébredsz. Ott, ahol kezdted a kalandot.\nFogalmad sincs, hogy hogyan kerültél vissza.");
                Console.WriteLine("Minden holmid és " + dogName + " is veled van.");
                if (pickaxe)
                {
                    Console.WriteLine("Mivel van nálad csákány, megtudod mászni a sziklát.");
                    //to be continued...
                }

                if (!pickaxe)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Mivel nincs nálad csákány, ezért nem tudod megmászni a sziklát.");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Elindulsz a barlangba, mivel már van fáklyád.");
                    if (match > 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Sikeresen meggyújtottad a gyufát");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        if (dogName != "")
                        {
                            Console.WriteLine("Mivel már kiszabadítottad " + dogName + "t, ezért balra semmi keresnivalód, szóval kimész az erdőbe.");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("Balra találsz egy almafát.");
                            Console.WriteLine("Előre egy domb van.");
                            Console.WriteLine("Jobbra pedig pár erősebb botot és köveket találsz.\n");
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.Write("\nDönts okosan! Merre mész? (Balra/Előre/Jobbra) ");
                            erdo();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("Balról kutyaugatást hallasz.");
                            Console.WriteLine("Jobbról gyenge fény pislákol.");
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.Write("\nMerre mész? (Balra/Jobbra)");
                            barlang();
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Mivel nincs nálad egy darab gyufa sem, így nem tudod meggyújtani a fáklyát.");
                        Console.WriteLine("Mivel nem tudsz menni semerre sem, ezért meghalsz a szigeten.");
                        Console.WriteLine("Vége a játéknak");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Nyomj egy gombot a kilépéshez...");
                        Console.ReadKey();
                    }
                }
            }

            if (valasz.Equals("Jobbra"))
            {
                Console.WriteLine("A gyümölcsösben elfogyasztasz pár körtét és epret.");
                hungryness -= 2;
                if (hungryness < 0) hungryness = 0;
                Console.WriteLine("Az éhséged " + hungryness + ". szintre csökkent.");
                Console.WriteLine("A friss gyümölcstől hirtelen egy kis energiára kaptál.");
                if (dogName != "")
                {
                    Console.WriteLine("Játszol egy kicsit " + dogName + "val?");
                }
                gameWithDog();
            }

            if (valasz.Equals("Help"))
            {
                help();
                kajaKereses();
            }

            if (valasz.Equals("Statisztika"))
            {
                stats();
                kajaKereses();
            }

            if (valasz.Equals("Feladom"))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Majd legközelebb!");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Nyomj egy gombot a kilépéshez...");
                Console.ReadKey();
                dead = true;
            }

            else
            {
                wrongAnswer();
                kajaKereses();
            }
        }

        public void gameWithDog()
        {
            if (dogName != "")
            {
                place = "Az ember legjobb barátja";
                mission = "Hozz döntést!";
                title(place);
                Console.ForegroundColor = ConsoleColor.Green;
                string valasz = Console.ReadLine();

                if (valasz.Equals("Igen"))
                {
                    Console.WriteLine(dogName + " nagyon örült a játéknak.");
                    Console.WriteLine("Támadási ereje 5-tel növekedett.");
                    attack += 5;
                    Console.WriteLine("Tovább folytatjátok az utatokat.");
                    Console.WriteLine("Egy hídhoz érkeztek.");
                    Console.WriteLine("Pár tartógerendája már repedt vagy eltörött. Régóta nem tartja karban senki.");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write("\nÁtmentek rajta? (Igen/Nem) ");
                    hid();
                }

                if (valasz.Equals("Nem"))
                {
                    Console.WriteLine("Tovább folytatjátok az utatokat.");
                    Console.WriteLine("Egy hídhoz érkeztek.");
                    Console.WriteLine("Pár tartógerendája már repedt vagy eltörött. Régóta nem tartja karban senki.");
                    Console.Write("\nÁtmentek rajta? (Igen/Nem) ");
                    hid();
                }

                if (valasz.Equals("Help"))
                {
                    help();
                    gameWithDog();
                }

                if (valasz.Equals("Statisztika"))
                {
                    stats();
                    gameWithDog();
                }

                if (valasz.Equals("Feladom"))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Majd legközelebb!");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Nyomj egy gombot a kilépéshez...");
                    Console.ReadKey();
                    dead = true;
                }

                else
                {
                    wrongAnswer();
                    gameWithDog();
                }
            }
            else
            {
                Console.WriteLine("Tovább folytatod az utad.");
                Console.WriteLine("Egy hídhoz érkezel.");
                Console.WriteLine("Pár tartógerendája már repedt vagy eltörött. Régóta nem tartja karban senki.");
                Console.Write("\nÁtmész rajta? (Igen/Nem) ");
                hid();
            }
        }

        public void hid()
        {
            place = "A híd";
            title(place);
            mission = "Kelj át a hídon, sok szerencsét!";
            Console.ForegroundColor = ConsoleColor.Green;
            string valasz = Console.ReadLine();

            if (valasz.Equals("Igen"))
            {
                byte luck = (byte)random.Next(1, 10);

                if (luck <= 7)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Sikeresen átkeltél a hídon.");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Ismét elindulhatsz több irányba.");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Balra egy kihalt tömbházat találsz.");
                    Console.WriteLine("Előre egy kisboltot veszel észre.");
                    Console.WriteLine("Jobbra pedig egy bunkerrel találkozol.");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write("\nMerre mész? (Balra/Előre/Jobbra) ");
                    afterBridge();
                }

                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Sajnos leestél a hídról.");
                    newChance();
                    hid();
                }
            }

            if (valasz.Equals("Nem"))
            {
                Console.WriteLine("Megtorpansz a hídnál.");
            }

            if (valasz.Equals("Help"))
            {
                help();
                hid();
            }

            if (valasz.Equals("Statisztika"))
            {
                stats();
                hid();
            }

            if (valasz.Equals("Feladom"))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Majd legközelebb!");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Nyomj egy gombot a kilépéshez...");
                Console.ReadKey();
                dead = true;
            }

            else
            {
                wrongAnswer();
                hid();
            }
        }

        public void afterBridge()
        {
            place = "A híd után";
            mission = "Döntsd el az úticélod!";
            title(place);
            Console.ForegroundColor = ConsoleColor.Green;
            string valasz = Console.ReadLine();

            if (valasz.Equals("Balra"))//tömbház
            {
                Console.WriteLine("Beléptél a tömbházba. Melyik emeletre mész?");
                tombhazText();
            }

            if (valasz.Equals("Előre"))//kisbolt
            {
                Console.WriteLine("Beléptél a kisboltba. Mit szeretnél venni?");
                shopText();
            }

            if (valasz.Equals("Jobbra"))//bunker
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Beléptél a bunkerbe.");
                Console.ForegroundColor = ConsoleColor.Yellow;
                //balra legyenek valami kommunista propagandák
                //jobbra legyen egy újabb folyosó
                //előre pedig legyen egy bezárt ajtó
                Console.WriteLine("Balra pár furcsa képet látsz.");
                Console.WriteLine("Veled szemben egy ajtó van.");
                Console.WriteLine("Jobbra egy másik folyosó van.");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("Merre mész? (Balra/Előre/Jobbra) ");
                bunker();
            }

            if (valasz.Equals("Help"))
            {
                help();
                afterBridge();
            }

            if (valasz.Equals("Statisztika"))
            {
                stats();
                afterBridge();
            }

            if (valasz.Equals("Feladom"))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Majd legközelebb!");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Nyomj egy gombot a kilépéshez...");
                Console.ReadKey();
                dead = true;
            }

            else
            {
                wrongAnswer();
                afterBridge();
            }
        }

        public void bunker()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            string valasz = Console.ReadLine();

            switch (valasz)
            {
                case "Jobbra":
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("Elindulsz a folyosón.");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Találkozol egy hajléktalannal, akinek küldetése van számodra.");
                        Console.WriteLine("De mielőtt elmondaná, kíváncsi a politikai nézetedre.");
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("Kommunista vagy vagy fasiszta? (Kommunista/Fasiszta) ");
                        idealizmus();
                        break;
                    }

                case "Balra":
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Itt kommunista propagandákat találsz.");
                        break;
                    }

                case "Előre":
                    {
                        Console.WriteLine("Az ajtó zárva van.");
                        if (lockpick > 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.Write("Feltöröd? (Igen/Nem) ");
                            closedDoor();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.Write("Merre mész? (Balra/Jobbra) ");
                            bunker();
                        }
                        break;
                    }

                case "Statisztika":
                    {
                        stats();
                        bunker();
                        break;
                    }
                case "Help":
                    {
                        help();
                        bunker();
                        break;
                    }
                case "Feladom":
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Majd legközelebb!");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Nyomj egy gombot a kilépéshez...");
                        Console.ReadKey();
                        break;
                    }

                default:
                    {
                        wrongAnswer();
                        bunker();
                        break;
                    }
            }
        }

        public void idealizmus()
        {
            place = "Politika tabuk nélkül";
            title(place);
            mission = "Légy őszinte!";
            Console.ForegroundColor = ConsoleColor.Green;
            string valasz = Console.ReadLine();

            switch (valasz)
            {
                case "Kommunista":
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("A hajléktalan azonnal megörül a válaszodnak.");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Megkaptad az Elvtárs címet!");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("+2 éhség!");
                        hungryness += 2;
                        if (hungryness >= 10)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Mivel az éhségi szinted " + hungryness + ", ezért éhenhaltál.");
                            newChance();
                            idealizmus();
                        }
                        else
                        {
                            playerName += " Elvtárs";
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("Azzal bíz meg, hogy valósítsd meg a kommunizmust.");
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.Write("Elfogadod a küldetést? (Igen/Nem) ");
                            kommunizms();
                        }
                        break;
                    }

                case "Fasiszta":
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("A hajléktalan elmondja, hogy ő kommunista, ezért megöl.");
                        newChance();
                        idealizmus();
                        break;
                    }

                case "Statisztika":
                    {
                        stats();
                        closedDoor();
                        break;
                    }
                case "Help":
                    {
                        help();
                        closedDoor();
                        break;
                    }
                case "Feladom":
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Majd legközelebb!");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Nyomj egy gombot a kilépéshez...");
                        Console.ReadKey();
                        break;
                    }

                default:
                    {
                        wrongAnswer();
                        closedDoor();
                        break;
                    }
            }
        }

        public void kommunizms()
        {
            place = "Sztálin 2.0";
            title(place);
            mission = "Hozz döntést!";
            Console.ForegroundColor = ConsoleColor.Green;
            string valasz = Console.ReadLine();

            switch (valasz)
            {
                case "Igen":
                    {
                        mission = "Valósítsd meg a kommunizmust, " + playerName+ "!";
                        quest = true;
                        //SOVIET ANTHEM GETS STRONGER
                        break;
                    }

                case "Nem":
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("A hajléktalan dühös lesz, s megöl.");
                        newChance();
                        kommunizms();
                        break;
                    }

                case "Statisztika":
                    {
                        stats();
                        closedDoor();
                        break;
                    }
                case "Help":
                    {
                        help();
                        closedDoor();
                        break;
                    }
                case "Feladom":
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Majd legközelebb!");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Nyomj egy gombot a kilépéshez...");
                        Console.ReadKey();
                        break;
                    }

                default:
                    {
                        wrongAnswer();
                        closedDoor();
                        break;
                    }

            }
        }

        public void closedDoor()
        {
            place = "Az ajtó előtt";
            title(place);
            mission = "Hozz döntést!";
            Console.ForegroundColor = ConsoleColor.Green;
            string valasz = Console.ReadLine();
            
            switch (valasz) {
                case "Igen":
                    {
                        closedDoorLuck();
                        break;
                    }

                case "Nem": {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("Merre mész? (Balra/Jobbra) ");
                        bunker();
                        break;
                    }

                case "Statisztika":
                    {
                        stats();
                        closedDoor();
                        break;
                    }
                case "Help":
                    {
                        help();
                        closedDoor();
                        break;
                    }
                case "Feladom":
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Majd legközelebb!");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Nyomj egy gombot a kilépéshez...");
                        Console.ReadKey();
                        break;
                    }

                default:
                    {
                        wrongAnswer();
                        closedDoor();
                        break;
                    }

            }
            
        }

        public void closedDoorLuck()
        {
            byte luck = (byte)random.Next(1, 10);

            if (luck <= 7)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Sikerült feltörnöd az ajtót!");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Két irányba indulhatsz el, balra és jobbra.");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("\nMerre mész (Balra/Jobbra) ");
                inTheDoor();
            }

            else
            {
                lockpick--;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Nem sikerült feltörni az ajtót.");
                if (lockpick > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("Újrapróbálod? (Igen/Nem) ");
                    string valasz = Console.ReadLine();
                    switch (valasz) {
                        case "Igen":
                            {
                                closedDoorLuck();
                                break;
                            }

                        case "Nem":
                            {
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                Console.Write("Merre mész? (Balra/Jobbra) ");
                                bunker();
                                break;
                            }

                        case "Statisztika":
                            {
                                stats();
                                closedDoorLuck();
                                break;
                            }
                        case "Help":
                            {
                                help();
                                closedDoorLuck();
                                break;
                            }
                        case "Feladom":
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Majd legközelebb!");
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Nyomj egy gombot a kilépéshez...");
                                Console.ReadKey();
                                break;
                            }

                        default:
                            {
                                wrongAnswer();
                                closedDoorLuck();
                                break;
                            }

                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write("Merre mész? (Balra/Jobbra) ");
                    bunker();
                }
            }
        }

        public void inTheDoor()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            string valasz = Console.ReadLine();
            switch (valasz)
            {
                case "Balra":
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("Elindulnál, de nem veszed észre magad alatt a csapdát.");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Beleesel egy gödörbe, amiben felnyársalnak a tüskék, s meghalsz.");
                        newChance();
                        inTheDoor();
                        break;
                    }

                case "Jobbra":
                    {
                        //fasztudja mi lesz itt
                        break;
                    }

                case "Statisztika":
                    {
                        stats();
                        closedDoor();
                        break;
                    }
                case "Help":
                    {
                        help();
                        inTheDoor();
                        break;
                    }
                case "Feladom":
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Majd legközelebb!");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Nyomj egy gombot a kilépéshez...");
                        Console.ReadKey();
                        break;
                    }

                default:
                    {
                        wrongAnswer();
                        inTheDoor();
                        break;
                    }

            }
        }

        public void tombhazText()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Emeletek:");
            Console.WriteLine(" 1. emelet");
            Console.WriteLine(" 2. emelet");
            Console.WriteLine(" 3. emelet");
            Console.WriteLine(" 4. emelet");
            Console.WriteLine(" 5. kijárat");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("\nEmelet: ");
            tombhaz();
        }

        Boolean collectedFireckracker = false;
        Boolean collectedMoney = false;
        Boolean deadNyuszi = false;

        public void tombhaz()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            byte emelet = 0;
            try
            {
                emelet = Convert.ToByte(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\nSzámot kértem, nem szöveget!");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("Válassz emeletet: ");
                tombhaz();
            }
            catch (OverflowException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\nAz emelet száma nem lehet nagyobb 255-nél, mivel ez a byte maximum értéke!");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("Válassz emeletet: ");
                tombhaz();
            }

            switch (emelet)
            {
                case 1:
                    {
                        place = "Tömbház - 1. emelet";
                        title(place);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Itt két szobát találsz.");
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("Hányadik szobába mész?");
                        Console.ForegroundColor = ConsoleColor.Green;

                        byte szoba = 0;
                        try
                        {
                            szoba = Convert.ToByte(Console.ReadLine());
                        }
                        catch (FormatException)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("\nSzámot kértem, nem szöveget!");
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.Write("Válassz emeletet: ");
                            tombhaz();
                        }
                        catch (OverflowException)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("\nA szoba száma nem lehet nagyobb 255-nél, mivel ez a byte maximum értéke!");
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.Write("Válassz emeletet: ");
                            tombhaz();
                        }

                        switch (szoba)
                        {
                            case 1:
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine("Itt egy síró törpével találkozol, akinek van egy feladata számodra.");
                                    Console.WriteLine("A harmadik emeleten van egy nyúljelmezbe öltözött alak, aki elvette a játékmozdonyát.");
                                    Console.WriteLine("Azt kéri, hogy szerezd neki vissza, mert ő túl kicsi hozzá.");
                                    Console.WriteLine("30 aranyat ajánl jutalmul.");
                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                    Console.Write("\nElfogadod a küldetést? (Igen/Nem) ");

                                    torpeQuest();

                                    break;
                                }

                            case 2:
                                {
                                    Console.WriteLine("Ez a szoba üres.");
                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                    Console.Write("\nMelyik emeletre mész tovább?");
                                    tombhaz();
                                    break;
                                }

                            default:
                                {
                                    Console.WriteLine("Nincs ilyen szoba!");
                                    Console.Write("\nVálassz emeletet: ");
                                    tombhaz();
                                    break;
                                }
                        }

                        break;
                    }

                case 2:
                    {
                        place = "Tömbház - 2. emelet";
                        title(place);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Itt három szobát találsz.");
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("Hányadik szobába mész?");
                        Console.ForegroundColor = ConsoleColor.Green;

                        byte szoba = 0;
                        try
                        {
                            szoba = Convert.ToByte(Console.ReadLine());
                        }
                        catch (FormatException)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("\nSzámot kértem, nem szöveget!");
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.Write("Válassz emeletet: ");
                            tombhaz();
                        }
                        catch (OverflowException)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("\nA szoba száma nem lehet nagyobb 255-nél, mivel ez a byte maximum értéke!");
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.Write("Válassz emeletet: ");
                            tombhaz();
                        }

                        switch (szoba)
                        {
                            case 1:
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine("Ez a szoba üres.");
                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                    Console.Write("\nMelyik emeletre mész tovább?");
                                    tombhaz();
                                    break;
                                }

                            case 2:
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    if (!collectedMoney)
                                    {
                                        Console.WriteLine("A szobában találsz 15 aranyat.");
                                        gold += 15;
                                        collectedMoney = true;
                                    }
                                    else {
                                        Console.WriteLine("Már begyűjtötted az aranyat!");
                                    }
                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                    Console.Write("\nMelyik emeletre mész tovább?");
                                    tombhaz();
                                    break;
                                }

                            case 3:
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine("Ez a szoba üres.");
                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                    Console.Write("\nMelyik emeletre mész tovább?");
                                    tombhaz();
                                    break;
                                }

                            default:
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Nincs ilyen szoba!");
                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                    Console.Write("\nVálassz emeletet: ");
                                    tombhaz();
                                    break;
                                }
                        }

                        break;
                    }

                case 3:
                    {
                        place = "Tömbház - 3. emelet";//nyusziiii
                        title(place);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Itt egy szobát találsz");
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("Bemész a szobába? (Igen/Nem) ");
                        Console.ForegroundColor = ConsoleColor.Green;

                        string szoba = Console.ReadLine();

                        switch (szoba)
                        {
                            case "Igen":
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    if (!deadNyuszi)
                                    {
                                        Console.WriteLine("Egy ijesztő nyúljelmezbe öltözött emberrel találkozol, aki azonnal feléd iramodik.");
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Támadási értéke 50.");
                                        Console.ForegroundColor = ConsoleColor.Magenta;
                                        Console.Write("\nMegtámadod, vagy elfutsz előle? (Megtámadom/Elfutok) ");
                                        nyuszi();
                                    }
                                    else
                                    {
                                        Console.WriteLine("Már legyőzted a nyulat!");
                                        Console.ForegroundColor = ConsoleColor.Magenta;
                                        Console.Write("\nMelyik emeletre mész tovább? ");
                                        tombhaz();
                                    }
                                    break;
                                }

                            case "Nem":
                                {
                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                    Console.Write("\nVálassz emeletet: ");
                                    tombhaz();
                                    break;
                                }

                            default:
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Nincs ilyen válasz!");
                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                    Console.Write("\nVálassz emeletet: ");
                                    tombhaz();
                                    break;
                                }
                        }
                        break;
                    }

                case 4:
                    {                       
                        place = "Tömbház - 4. emelet";
                        byte szoba = 0;
                        title(place);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Itt három szobát találsz.");
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("Hányadik szobába mész?");
                        Console.ForegroundColor = ConsoleColor.Green;

                        try
                        {
                            szoba = Convert.ToByte(Console.ReadLine());
                        }
                        catch (FormatException)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("\nSzámot kértem, nem szöveget!");
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.Write("Válassz emeletet: ");
                            tombhaz();
                        }
                        catch (OverflowException) {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("\nA szoba száma nem lehet nagyobb 255-nél, mivel ez a byte maximum értéke!");
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.Write("Válassz emeletet: ");
                            tombhaz();
                        }

                        switch (szoba)
                        {
                            case 1:
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine("Ez a szoba üres.");
                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                    Console.Write("\nMelyik emeletre mész tovább?");
                                    tombhaz();
                                    break;
                                }

                            case 2:
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine("Ez a szoba üres.");
                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                    Console.Write("\nMelyik emeletre mész tovább?");
                                    tombhaz();
                                    break;
                                }

                            case 3:
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    if (!collectedFireckracker)
                                    {
                                        Console.WriteLine("Ebben a szobában találsz 5 petárdát.");
                                        firecracker += 5;
                                        collectedFireckracker = true;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Már begyűjtötted a petárdákat!");
                                    }                                  
                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                    Console.Write("\nMelyik emeletre mész tovább?");
                                    tombhaz();
                                    break;
                                }

                            default:
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Nincs ilyen szoba!");
                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                    Console.Write("\nVálassz emeletet: ");
                                    tombhaz();
                                    break;
                                }
                        }

                        break;
                    }

                case 5:
                    {
                        Console.WriteLine("Ismét a híd után vagy.");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Balra egy kihalt tömbházat találsz.");
                        Console.WriteLine("Előre egy kisboltot veszel észre.");
                        Console.WriteLine("Jobbra pedig egy bunkerrel találkozol.");
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("\nMerre mész? (Balra/Előre/Jobbra) ");
                        afterBridge();
                        break;
                    }

                default:
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Nincs ilyen emelet!");
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("\nVálassz emeletet: ");
                        tombhaz();
                        break;
                    }
            }
        }

        public void nyuszi()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            string valasz = Console.ReadLine();

            switch (valasz) {
                case "Megtámadom": {
                        battle(attack,50);
                        deadNyuszi = true;
                        if (!quest)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("\nA nyúlembernél találsz egy játékmozdonyt.");
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.Write("Elteszed? (Igen/Nem)");
                            mozdony();
                        }
                        else {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("\nA nyúlembernél megtalálod a törpe játékmozdonyát.");
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.Write("\nMelyik emeletre mész tovább?");
                            tombhaz();
                            break;
                        }
                        break;
                    }

                case "Elfutok": {
                        break;
                    }

                case "Feladom":
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Majd legközelebb!");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Nyomj egy gombot a kilépéshez...");
                    Console.ReadKey();
                    break;

                case "Statisztika":
                    {
                        stats();
                        nyuszi();
                        break;
                    }

                case "Help":
                    {
                        help();
                        nyuszi();
                        break;
                    }

                default: {
                        wrongAnswer();
                        nyuszi();
                        break;
                    }
            }
        }

        public void mozdony()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            string valasz = Console.ReadLine();
            switch (valasz)
            {
                case "Igen":
                    {
                        kisvasut = true;
                        break;
                    }

                case "Nem":
                    {
                        kisvasut = false;
                        break;
                    }

                case "Feladom":
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Majd legközelebb!");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Nyomj egy gombot a kilépéshez...");
                    Console.ReadKey();
                    break;

                case "Statisztika":
                    {
                        stats();
                        mozdony();
                        break;
                    }

                case "Help":
                    {
                        help();
                        mozdony();
                        break;
                    }

                default:
                    {
                        wrongAnswer();
                        mozdony();
                        break;
                    }

            }
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("\nMelyik emeletre mész tovább?");
            tombhaz();
        }

        public void torpeQuest()
        {
            string valasz = Console.ReadLine();

            switch (valasz)
            {
                case "Igen":
                    {
                        quest = true;
                        Console.WriteLine("Elfogadtad a kihívást.");
                        Console.WriteLine("Melyik emeletre mész tovább?");
                        tombhaz();
                        break;
                    }

                case "Nem":
                    {
                        Console.WriteLine("A törpe annyira elkeseredik, hogy öngyilkos lesz.");
                        Console.WriteLine("Melyik emeletre mész tovább?");
                        quest = false;
                        tombhaz();
                        break;
                    }

                case "Feladom":
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Majd legközelebb!");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Nyomj egy gombot a kilépéshez...");
                        Console.ReadKey();
                        break;
                    }

                case "Statisztika": stats(); torpeQuest(); break;
                case "Help": help(); torpeQuest(); break;

                default:
                    {
                        wrongAnswer();
                        torpeQuest();
                        break;
                    }
            }
        }

        public void shopText()
        {
            place = "Gizi néni kisboltja";
            mission = "Vegyél meg mindent amíg tart a Black Friday!";
            title(place);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Válassz kategóriát!");
            Console.WriteLine(" 1. Fegyverek");
            Console.WriteLine(" 2. Ételek");
            Console.WriteLine(" 3. Kiegészítők");
            Console.WriteLine(" 4. Kilépés");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("\nKategória: ");
            shop();
        }

        public void shop()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            byte kategoria = 0;
            try
            {
                kategoria = Convert.ToByte(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Számot kértem, nem szöveget!");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("Válassz kategóriát: ");
                shop();
            }
            catch (OverflowException) {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\nA kategóra száma nem lehet nagyobb 255-nél, mivel ez a byte maximum értéke!");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("Válassz kategóriát: ");
                shop();
            }

            switch (kategoria)
            {
                case 1:
                    {
                        Console.WriteLine("Kategória: Fegyverek");
                        Console.WriteLine(" 1. Petárda (Sebzés: 5) (Ár: 1 arany) (Darab: 3)");
                        Console.WriteLine(" 2. Balta (Sebzés: 40) (Ár: 8 arany) (Darab: 1)");

                        byte fegyver = 0;
                        try
                        {
                            fegyver = Convert.ToByte(Console.ReadLine());
                        }
                        catch (FormatException)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Számot kértem, nem szöveget!");
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.Write("Válassz kategóriát: ");
                            shop();
                        }
                        catch (OverflowException)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("\nA kategóra száma nem lehet nagyobb 255-nél, mivel ez a byte maximum értéke!");
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.Write("Válassz kategóriát: ");
                            shop();
                        }

                        switch (fegyver)
                        {
                            case 1:
                                {
                                    if (gold >= 1)
                                    {
                                        gold -= 1;
                                        firecracker += 3;
                                        Console.WriteLine("Sikeresen vettél három petárdát.");
                                        Console.WriteLine(firecracker + " darab petárdád van.");
                                        Console.WriteLine(gold + " aranyad maradt.");
                                    }

                                    else
                                    {
                                        Console.WriteLine("Nincs elég pénzed a vásárláshoz.");
                                    }

                                    break;
                                }

                            case 2:
                                {
                                    if (gold >= 8)
                                    {
                                        attack += 40;
                                        gold -= 8;
                                        Console.WriteLine("Sikeresen vettél egy baltát.");
                                        Console.WriteLine("Támadási értéked: " + attack);
                                        Console.WriteLine(gold + " aranyad maradt.");
                                    }

                                    else
                                    {
                                        Console.WriteLine("Nincs elég pénzed a vásárláshoz.");
                                    }

                                    break;
                                }

                            default:
                                {
                                    Console.WriteLine("Helytelen árucikk!");
                                    Console.Write("\nKategória: ");
                                    shop();
                                    break;
                                }
                        }

                        break;
                    }

                case 2:
                    {
                        Console.WriteLine("Kategória: Ételek");
                        Console.WriteLine(" 1. Barack (Tápérték: 1) (Ár: 1 arany)");
                        Console.WriteLine(" 2. Kolbász (Tápérték: 2) (Ár: 2 arany)");
                        Console.WriteLine(" 3. Pörkölt nokedlivel (Tápérték: Végtelen) (Ár: 5 arany)");

                        byte kaja = 0;
                        try
                        {
                            kaja = Convert.ToByte(Console.ReadLine());
                        }
                        catch (FormatException)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Számot kértem, nem szöveget!");
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.Write("Válassz kategóriát: ");
                            shop();
                        }
                        catch (OverflowException)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("\nA kategóra száma nem lehet nagyobb 255-nél, mivel ez a byte maximum értéke!");
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.Write("Válassz kategóriát: ");
                            shop();
                        }

                        switch (kaja)
                        {
                            case 1:
                                {
                                    if (gold >= 1)
                                    {
                                        hungryness -= 1;
                                        if (hungryness < 0) hungryness = 0;
                                        gold -= 1;
                                        Console.WriteLine("Sikeresen vettél egy barackot.");
                                        Console.WriteLine(gold + " aranyad maradt.");
                                        Console.WriteLine("Éhségi szinted: " + hungryness);
                                        shopContinue();
                                    }

                                    else
                                    {
                                        Console.WriteLine("Nincs elég pénzed a vásárláshoz.");
                                        Console.Write("\nKategória: ");
                                        shop();
                                    }

                                    break;
                                }

                            case 2:
                                {
                                    if (gold >= 2)
                                    {
                                        hungryness -= 2;
                                        if (hungryness < 0) hungryness = 0;
                                        gold -= 2;
                                        Console.WriteLine("Sikeresen vettél egy kolbászt.");
                                        Console.WriteLine(gold + " aranyad maradt.");
                                        Console.WriteLine("Éhségi szinted: " + hungryness);
                                        shopContinue();
                                    }

                                    else
                                    {
                                        Console.WriteLine("Nincs elég pénzed a vásárláshoz.");
                                        Console.Write("\nKategória: ");
                                        shop();
                                    }

                                    break;
                                }

                            case 3:
                                {
                                    if (gold >= 5)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine("Németh Szilárd sámán által főzött szent étel elfogyasztása után a játékmenet végéig nem leszel éhes!");
                                        Console.WriteLine(gold + " aranyad maradt.");
                                        hungryness = 0;
                                        gold -= 5;
                                        samanPorkolt = true;
                                        shopContinue();
                                    }
                                    
                                    else
                                    {
                                        Console.WriteLine("Nincs elég pénzed a vásárláshoz.");
                                        Console.Write("\nKategória: ");
                                        shop();
                                    }

                                    break;
                                }

                            case 4:
                                {
                                    Console.WriteLine("Ismét a híd után vagy.");
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine("Balra egy kihalt tömbházat találsz.");
                                    Console.WriteLine("Előre egy kisboltot veszel észre.");
                                    Console.WriteLine("Jobbra pedig egy bunkerrel találkozol.");
                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                    Console.Write("\nMerre mész? (Balra/Előre/Jobbra) ");
                                    afterBridge();
                                    break;
                                }

                            default:
                                {
                                    Console.WriteLine("Helytelen árucikk!");
                                    Console.Write("\nKategória: ");
                                    shop();
                                    break;
                                }
                        }

                        break;
                    }

                case 3:
                    {
                        Console.WriteLine("Kategória: Kiegészítők");
                        Console.WriteLine(" 1. Zárfeltörő (Darab: 5) (Ár: 2 arany)");
                        Console.WriteLine(" 2. Gyufa (Darab: 20) (Ár: 1 arany)");

                        byte egyebek = 0;
                        try
                        {
                            egyebek = Convert.ToByte(Console.ReadLine());
                        }
                        catch (FormatException)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Számot kértem, nem szöveget!");
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.Write("Válassz kategóriát: ");
                            shop();
                        }
                        catch (OverflowException)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("\nA kategóra száma nem lehet nagyobb 255-nél, mivel ez a byte maximum értéke!");
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.Write("Válassz kategóriát: ");
                            shop();
                        }

                        switch (egyebek)
                        {
                            case 1:
                                {
                                    if (gold >= 2)
                                    {
                                        lockpick += 5;
                                        gold -= 2;
                                        Console.WriteLine("Sikeresen vettél 5 zárfeltörőt.");
                                        Console.WriteLine(gold + " aranyad maradt.");
                                        shopContinue();
                                    }

                                    else
                                    {
                                        Console.WriteLine("Nincs elég pénzed a vásárláshoz.");
                                        Console.Write("\nKategória: ");
                                        shop();
                                    }

                                    break;
                                }

                            case 2:
                                {
                                    if (gold >= 1)
                                    {
                                        match += 20;
                                        gold -= 1;
                                        Console.WriteLine("Sikeresen vettél 20 gyufát.");
                                        Console.WriteLine(gold + " aranyad maradt.");
                                        shopContinue();
                                    }

                                    else
                                    {
                                        Console.WriteLine("Nincs elég pénzed a vásárláshoz.");
                                        Console.Write("\nKategória: ");
                                        shop();
                                    }

                                    break;
                                }

                            default:
                                {
                                    Console.WriteLine("Helytelen árucikk!");
                                    Console.Write("\nKategória: ");
                                    shop();
                                    break;
                                }
                        }

                        break;
                    }

                default:
                    {
                        Console.WriteLine("Helytelen kategória!");
                        Console.Write("\nVálassz kategóriát: ");
                        shop();
                        break;
                    }
            }
        }

        public void shopContinue()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("\nSzeretnéd folytatni a vásárlást? (Igen/Nem) ");
            Console.ForegroundColor = ConsoleColor.Green;
            string valasz = Console.ReadLine();

            if (valasz.Equals("Igen")) {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("\nKategória: ");
                shop();
            }

            if (valasz.Equals("Nem"))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Várunk vissza minél hamarabb Gizi néni kisboltjába!");
                Console.WriteLine("Újra a híd után vagy.");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("\nMerre mész tovább?");
                afterBridge();
            }

            else {
                wrongAnswer();
            }
        }

        public void maciLaci()
        {
            place = "Medve László";
            mission = "Győzd le a medvét!";
            title(place);
            Console.ForegroundColor = ConsoleColor.Green;
            string valasz = Console.ReadLine();

            if (valasz.Equals("Igen"))
            {
                battle(attack,40);

                if (!dead) {
                    Console.WriteLine(dogName + " ismét valami szagot fog, úgyhogy elindulsz utána.");
                    Console.WriteLine("Pár keselyű teteméhez vezet. Valami baljós közeleg.");
                    Console.WriteLine("Besötétül az ég, és egy tornádó jelenik meg mögötted.");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write("\nElkezdesz futni? (Igen/Nem) ");
                    tornado();
                }
            }

            if (valasz.Equals("Nem"))
            {
                Console.WriteLine("Megpróbálsz elmenekülni, de a medve észrevesz és hátbatámad.");
                newChance();
                maciLaci();
            }

            if (valasz.Equals("Help"))
            {
                help();
                maciLaci();
            }

            if (valasz.Equals("Statisztika"))
            {
                stats();
                maciLaci();
            }

            if (valasz.Equals("Feladom"))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Majd legközelebb!");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Nyomj egy gombot a kilépéshez...");
                Console.ReadKey();
                dead = true;
            }

            else
            {
                wrongAnswer();
                maciLaci();
            }
        }

        public void tornado()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            string valasz = Console.ReadLine();

            if (valasz.Equals("Igen"))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("A menekülés közben elesel, s halálos sebet kapsz.");
                newChance();
                tornado();
            }

            if (valasz.Equals("Nem"))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("A tornádó elragad magával, s egy ismeretlen helyen földet érsz.");
                Console.WriteLine("Körülnézel, s észreveszed, hogy egy atomrobbanást szenvedett városban vagy.");
                hungryness += 2;
                if (hungryness >= 10)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Mivel az éhségi szinted " + hungryness + ", ezért éhenhaltál.");
                    newChance();
                    idealizmus();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Éhséged " + hungryness + ". szintre növekedett!");
                    Console.WriteLine("Balra egy iskolát látsz.");
                    Console.WriteLine("Előre egy játszóteret veszel észre.");
                    Console.WriteLine("Jobbra pedig egy kórházat pillantasz meg. ");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write("Merre mész? (Balra/Előre/Jobbra)");
                    deadCity();
                }

            }

            if (valasz.Equals("Help"))
            {
                help();
                tornado();
            }

            if (valasz.Equals("Statisztika"))
            {
                stats();
                tornado();
            }

            if (valasz.Equals("Feladom"))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Majd legközelebb!");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Nyomj egy gombot a kilépéshez...");
                Console.ReadKey();
                dead = true;
            }

            else
            {
                wrongAnswer();
                tornado();
            }
        }

        public void deadCity()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            string valasz = Console.ReadLine();

            switch (valasz)
            {
                case "Jobbra":
                    {
                        Console.WriteLine("A kórház tíz emeletes.");
                        Console.Write("Melyik emeletre mész? (11. kilépés) ");
                        korhaz();
                        break;
                    }

                case "Balra":
                    {
                        Console.WriteLine("Az iskola 3 emeletes.");
                        Console.Write("Melyik emeletre mész? (4. kilépés) ");
                        school();
                        break;
                    }

                case "Előre":
                    {
                       
                        break;
                    }

                case "Statisztika":
                    {
                        stats();
                        deadCity();
                        break;
                    }
                case "Help":
                    {
                        help();
                        deadCity();
                        break;
                    }
                case "Feladom":
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Majd legközelebb!");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Nyomj egy gombot a kilépéshez...");
                        Console.ReadKey();
                        break;
                    }

                default:
                    {
                        wrongAnswer();
                        deadCity();
                        break;
                    }
            }
        }

        Boolean miniKnife = false;

        public void korhaz()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            byte emelet = 0;
            try
            {
                emelet = Convert.ToByte(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\nSzámot kértem, nem szöveget!");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("Válassz emeletet: ");
                tombhaz();
            }
            catch (OverflowException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\nAz emelet száma nem lehet nagyobb 255-nél, mivel ez a byte maximum értéke!");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("Válassz emeletet: ");
                tombhaz();
            }

            switch (emelet)
            {
                    case 1:
                    {
                        place = "Kórház - 1. emelet";
                        title(place);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Itt két szobát találsz.");
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("Hányadik szobába mész?");
                        Console.ForegroundColor = ConsoleColor.Green;

                        byte szoba = 0;
                        try
                        {
                            szoba = Convert.ToByte(Console.ReadLine());
                        }
                        catch (FormatException)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("\nSzámot kértem, nem szöveget!");
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.Write("Válassz emeletet: ");
                            korhaz();
                        }
                        catch (OverflowException)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("\nA szoba száma nem lehet nagyobb 255-nél, mivel ez a byte maximum értéke!");
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.Write("Válassz emeletet: ");
                            korhaz();
                        }

                        switch (szoba)
                        {
                            case 1:
                                {                                   
                                    break;
                                }

                            case 2:
                                {
                                    Console.WriteLine("Ez a szoba üres.");
                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                    Console.Write("\nMelyik emeletre mész tovább?");
                                    korhaz();
                                    break;
                                }

                            default:
                                {
                                    Console.WriteLine("Nincs ilyen szoba!");
                                    Console.Write("\nVálassz emeletet: ");
                                    korhaz();
                                    break;
                                }
                        }

                        break;
                    }

                    case 2:
                    {
                        place = "Kórház - 2. emelet";
                        title(place);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Itt három szobát találsz.");
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("Hányadik szobába mész?");
                        Console.ForegroundColor = ConsoleColor.Green;

                        byte szoba = 0;
                        try
                        {
                            szoba = Convert.ToByte(Console.ReadLine());
                        }
                        catch (FormatException)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("\nSzámot kértem, nem szöveget!");
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.Write("Válassz emeletet: ");
                            korhaz();
                        }
                        catch (OverflowException)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("\nA szoba száma nem lehet nagyobb 255-nél, mivel ez a byte maximum értéke!");
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.Write("Válassz emeletet: ");
                            korhaz();
                        }

                        switch (szoba)
                        {
                            case 1:
                                {
                                    break;
                                }

                            case 2:
                                {
                                    break;
                                }

                            case 3:
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine("Ez a szoba üres.");
                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                    Console.Write("\nMelyik emeletre mész tovább?");
                                    korhaz();
                                    break;
                                }

                            default:
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Nincs ilyen szoba!");
                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                    Console.Write("\nVálassz emeletet: ");
                                    korhaz();
                                    break;
                                }
                        }

                        break;
                    }

                    case 3:
                    {
                        place = "Kórház - 3. emelet";
                        title(place);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Itt egy szobát találsz");
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("Bemész a szobába? (Igen/Nem) ");
                        Console.ForegroundColor = ConsoleColor.Green;

                        string szoba = Console.ReadLine();

                        switch (szoba)
                        {
                            case "Igen":
                                {                                 
                                    break;
                                }

                            case "Nem":
                                {
                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                    Console.Write("\nVálassz emeletet: ");
                                    korhaz();
                                    break;
                                }

                            default:
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Nincs ilyen válasz!");
                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                    Console.Write("\nVálassz emeletet: ");
                                    korhaz();
                                    break;
                                }
                        }
                        break;
                    }

                    case 4:
                    {
                        place = "Kórház - 4. emelet";
                        byte szoba = 0;
                        title(place);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Itt három szobát találsz.");
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("Hányadik szobába mész?");
                        Console.ForegroundColor = ConsoleColor.Green;

                        try
                        {
                            szoba = Convert.ToByte(Console.ReadLine());
                        }
                        catch (FormatException)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("\nSzámot kértem, nem szöveget!");
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.Write("Válassz emeletet: ");
                            korhaz();
                        }
                        catch (OverflowException)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("\nA szoba száma nem lehet nagyobb 255-nél, mivel ez a byte maximum értéke!");
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.Write("Válassz emeletet: ");
                            korhaz();
                        }

                        switch (szoba)
                        {
                            case 1:
                                { 
                                    break;
                                }

                            case 2:
                                {                                    
                                    break;
                                }

                            case 3:
                                {
                                    break;
                                }

                            default:
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Nincs ilyen szoba!");
                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                    Console.Write("\nVálassz emeletet: ");
                                    korhaz();
                                    break;
                                }
                        }

                        break;
                    }

                    case 5:
                    {
                        place = "Kórház - 5. emelet";
                        title(place);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Itt három szobát találsz.");
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("Hányadik szobába mész?");
                        Console.ForegroundColor = ConsoleColor.Green;

                        byte szoba = 0;
                        try
                        {
                            szoba = Convert.ToByte(Console.ReadLine());
                        }
                        catch (FormatException)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("\nSzámot kértem, nem szöveget!");
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.Write("Válassz emeletet: ");
                            korhaz();
                        }
                        catch (OverflowException)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("\nA szoba száma nem lehet nagyobb 255-nél, mivel ez a byte maximum értéke!");
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.Write("Válassz emeletet: ");
                            korhaz();
                        }

                        switch (szoba)
                        {
                            case 1:
                                {
                                    break;
                                }

                            case 2:
                                {
                                    if (!miniKnife)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine("Itt találtál egy szikét. Sebzési értéke 5.");
                                        attack += 5;
                                        miniKnife = true;
                                        Console.WriteLine("Támadási értéked " + attack + ". szintre növekedett!");
                                        Console.ForegroundColor = ConsoleColor.Magenta;
                                        Console.Write("\nMelyik emeletre mész tovább?");
                                        korhaz();
                                    }
                                    else
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Már felvetted a szikét!");
                                    }
                                    break;
                                }

                            case 3:
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine("Ez a szoba üres.");
                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                    Console.Write("\nMelyik emeletre mész tovább?");
                                    korhaz();
                                    break;
                                }

                            default:
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Nincs ilyen szoba!");
                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                    Console.Write("\nVálassz emeletet: ");
                                    korhaz();
                                    break;
                                }
                        }

                        break;
                    }

                    case 6:
                    {
                        place = "Kórház - 6. emelet";
                        title(place);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Itt három szobát találsz.");
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("Hányadik szobába mész?");
                        Console.ForegroundColor = ConsoleColor.Green;

                        byte szoba = 0;
                        try
                        {
                            szoba = Convert.ToByte(Console.ReadLine());
                        }
                        catch (FormatException)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("\nSzámot kértem, nem szöveget!");
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.Write("Válassz emeletet: ");
                            korhaz();
                        }
                        catch (OverflowException)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("\nA szoba száma nem lehet nagyobb 255-nél, mivel ez a byte maximum értéke!");
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.Write("Válassz emeletet: ");
                            korhaz();
                        }

                        switch (szoba)
                        {
                            case 1:
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine("Ez a szoba üres.");
                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                    Console.Write("\nMelyik emeletre mész tovább?");
                                    korhaz();
                                    break;
                                }

                            case 2:
                                {
                                    break;
                                }

                            case 3:
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine("Ez a szoba üres.");
                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                    Console.Write("\nMelyik emeletre mész tovább?");
                                    korhaz();
                                    break;
                                }

                            default:
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Nincs ilyen szoba!");
                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                    Console.Write("\nVálassz emeletet: ");
                                    korhaz();
                                    break;
                                }
                        }

                        break;
                    }

                    case 7:
                    {
                        place = "Kórház - 7. emelet";
                        title(place);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Itt három szobát találsz.");
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("Hányadik szobába mész?");
                        Console.ForegroundColor = ConsoleColor.Green;

                        byte szoba = 0;
                        try
                        {
                            szoba = Convert.ToByte(Console.ReadLine());
                        }
                        catch (FormatException)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("\nSzámot kértem, nem szöveget!");
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.Write("Válassz emeletet: ");
                            korhaz();
                        }
                        catch (OverflowException)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("\nA szoba száma nem lehet nagyobb 255-nél, mivel ez a byte maximum értéke!");
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.Write("Válassz emeletet: ");
                            korhaz();
                        }

                        switch (szoba)
                        {
                            case 1:
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine("Ez a szoba üres.");
                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                    Console.Write("\nMelyik emeletre mész tovább?");
                                    korhaz();
                                    break;
                                }

                            case 2:
                                {
                                    break;
                                }

                            case 3:
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine("Ez a szoba üres.");
                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                    Console.Write("\nMelyik emeletre mész tovább?");
                                    korhaz();
                                    break;
                                }

                            default:
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Nincs ilyen szoba!");
                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                    Console.Write("\nVálassz emeletet: ");
                                    korhaz();
                                    break;
                                }
                        }

                        break;
                    }

                    case 8:
                    {
                        place = "Kórház - 8. emelet";
                        title(place);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Itt három szobát találsz.");
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("Hányadik szobába mész?");
                        Console.ForegroundColor = ConsoleColor.Green;

                        byte szoba = 0;
                        try
                        {
                            szoba = Convert.ToByte(Console.ReadLine());
                        }
                        catch (FormatException)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("\nSzámot kértem, nem szöveget!");
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.Write("Válassz emeletet: ");
                            korhaz();
                        }
                        catch (OverflowException)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("\nA szoba száma nem lehet nagyobb 255-nél, mivel ez a byte maximum értéke!");
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.Write("Válassz emeletet: ");
                            korhaz();
                        }

                        switch (szoba)
                        {
                            case 1:
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine("Ez a szoba üres.");
                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                    Console.Write("\nMelyik emeletre mész tovább?");
                                    korhaz();
                                    break;
                                }

                            case 2:
                                {
                                    break;
                                }

                            case 3:
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine("Ez a szoba üres.");
                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                    Console.Write("\nMelyik emeletre mész tovább?");
                                    korhaz();
                                    break;
                                }

                            default:
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Nincs ilyen szoba!");
                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                    Console.Write("\nVálassz emeletet: ");
                                    korhaz();
                                    break;
                                }
                        }

                        break;
                    }

                    case 9:
                    {
                        place = "Kórház - 9. emelet";
                        title(place);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Itt három szobát találsz.");
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("Hányadik szobába mész?");
                        Console.ForegroundColor = ConsoleColor.Green;

                        byte szoba = 0;
                        try
                        {
                            szoba = Convert.ToByte(Console.ReadLine());
                        }
                        catch (FormatException)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("\nSzámot kértem, nem szöveget!");
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.Write("Válassz emeletet: ");
                            korhaz();
                        }
                        catch (OverflowException)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("\nA szoba száma nem lehet nagyobb 255-nél, mivel ez a byte maximum értéke!");
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.Write("Válassz emeletet: ");
                            korhaz();
                        }

                        switch (szoba)
                        {
                            case 1:
                                {
                                    break;
                                }

                            case 2:
                                {
                                    break;
                                }

                            case 3:
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine("Ez a szoba üres.");
                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                    Console.Write("\nMelyik emeletre mész tovább?");
                                    korhaz();
                                    break;
                                }

                            default:
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Nincs ilyen szoba!");
                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                    Console.Write("\nVálassz emeletet: ");
                                    korhaz();
                                    break;
                                }
                        }

                        break;
                    }

                    case 10:
                    {
                        place = "Kórház - 10. emelet";
                        title(place);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Itt három szobát találsz.");
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("Hányadik szobába mész?");
                        Console.ForegroundColor = ConsoleColor.Green;

                        byte szoba = 0;
                        try
                        {
                            szoba = Convert.ToByte(Console.ReadLine());
                        }
                        catch (FormatException)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("\nSzámot kértem, nem szöveget!");
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.Write("Válassz emeletet: ");
                            korhaz();
                        }
                        catch (OverflowException)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("\nA szoba száma nem lehet nagyobb 255-nél, mivel ez a byte maximum értéke!");
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.Write("Válassz emeletet: ");
                            korhaz();
                        }

                        switch (szoba)
                        {
                            case 1:
                                {
                                    break;
                                }

                            case 2:
                                {
                                    break;
                                }

                            case 3:
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine("Ez a szoba üres.");
                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                    Console.Write("\nMelyik emeletre mész tovább?");
                                    korhaz();
                                    break;
                                }

                            default:
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Nincs ilyen szoba!");
                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                    Console.Write("\nVálassz emeletet: ");
                                    korhaz();
                                    break;
                        }
                    }

                    break;
                    }

                    case 11://kilépés a kórházból
                    {
                        if (!superGoat)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("Ismét a városban vagy, ám találkozol egy mutálódott kecskefejű emberrel.");
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.Write("Támadási értéke 70. Megtámadod? (Igen/Nem) ");
                            goatMan();
                        }
                        else
                        {
                            Console.WriteLine("Visszatértél a városba.");
                            Console.WriteLine("Balra egy iskolát látsz.");
                            Console.WriteLine("Előre egy játszóteret veszel észre.");
                            Console.WriteLine("Jobbra pedig egy kórházat pillantasz meg");
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.Write("Merre mész? (Balra/Előre/Jobbra) ");
                            deadCity();
                        }
                        break;
                    }

                    default:
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Nincs ilyen emelet!");
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("\nVálassz emeletet: ");
                        korhaz();
                        break;
                    }
            }
        }

        public void school()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            byte emelet = 0;
            try
            {
                emelet = Convert.ToByte(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\nSzámot kértem, nem szöveget!");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("Válassz emeletet: ");
                school();
            }
            catch (OverflowException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\nAz emelet száma nem lehet nagyobb 255-nél, mivel ez a byte maximum értéke!");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("Válassz emeletet: ");
                school();
            }

            switch (emelet)
            {
                case 1:
                    {
                        place = "Iskola - 1. emelet";
                        title(place);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Itt hét termet találsz.");
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("Hányadik terembe mész?");
                        Console.ForegroundColor = ConsoleColor.Green;

                        byte terem = 0;
                        try
                        {
                            terem = Convert.ToByte(Console.ReadLine());
                        }
                        catch (FormatException)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("\nSzámot kértem, nem szöveget!");
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.Write("Válassz emeletet: ");
                            school();
                        }
                        catch (OverflowException)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("\nA terem száma nem lehet nagyobb 255-nél, mivel ez a byte maximum értéke!");
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.Write("Válassz emeletet: ");
                            school();
                        }

                        switch (terem)
                        {
                            case 1:
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("Itt talász 10 gyufát.");
                                    match += 10;
                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                    Console.WriteLine("Gyufáid száma: " + match);
                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                    Console.Write("\nMelyik emeletre mész tovább?");
                                    school();
                                    break;
                                }

                            case 2:
                                {
                                    Console.WriteLine("Ez a terem üres.");
                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                    Console.Write("\nMelyik emeletre mész tovább?");
                                    school();
                                    break;
                                }

                            case 3:
                                {
                                    Console.WriteLine("Ez a terem üres.");
                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                    Console.Write("\nMelyik emeletre mész tovább?");
                                    school();
                                    break;
                                }

                            case 4:
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("Itt találsz 15 aranyat.");
                                    gold += 15;
                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                    Console.Write("\nMelyik emeletre mész tovább?");
                                    school();
                                    break;
                                }

                            case 5:
                                {
                                    Console.WriteLine("Ez a terem üres.");
                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                    Console.Write("\nMelyik emeletre mész tovább?");
                                    school();
                                    break;
                                }

                            case 6:
                                {
                                    Console.WriteLine("Ez a terem üres.");
                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                    Console.Write("\nMelyik emeletre mész tovább?");
                                    school();
                                    break;
                                }

                            case 7:
                                {
                                    Console.WriteLine("Ez a terem üres.");
                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                    Console.Write("\nMelyik emeletre mész tovább?");
                                    school();
                                    break;
                                }

                            default:
                                {
                                    Console.WriteLine("Nincs ilyen szoba!");
                                    Console.Write("\nVálassz emeletet: ");
                                    school();
                                    break;
                                }
                        }

                        break;
                    }

                case 2:
                    {
                        place = "Iskola - 2. emelet";
                        title(place);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Itt három termet találsz.");
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("Hányadik terembe mész? ");
                        Console.ForegroundColor = ConsoleColor.Green;

                        byte terem = 0;
                        try
                        {
                            terem = Convert.ToByte(Console.ReadLine());
                        }
                        catch (FormatException)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("\nSzámot kértem, nem szöveget!");
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.Write("Válassz emeletet: ");
                            school();
                        }
                        catch (OverflowException)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("\nA terem száma nem lehet nagyobb 255-nél, mivel ez a byte maximum értéke!");
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.Write("Válassz emeletet: ");
                            school();
                        }

                        switch (terem)
                        {
                            case 1:
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine("Ez a terem üres.");
                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                    Console.Write("Melyik emeletre mész tovább?");
                                    school();
                                    break;
                                }

                            case 2:
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("Itt találtál 4 zárfeltörőt!");
                                    lockpick += 4;
                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                    Console.Write("Melyik emeletre mész tovább? ");
                                    school();
                                    break;
                                }

                            case 3:
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine("Ez a terem üres.");
                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                    Console.Write("\nMelyik emeletre mész tovább? ");
                                    school();
                                    break;
                                }

                            default:
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Nincs ilyen terem!");
                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                    Console.Write("\nVálassz emeletet: ");
                                    school();
                                    break;
                                }
                        }

                        break;
                    }

                case 3:
                    {
                        place = "Iskola - 3. emelet";
                        title(place);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Itt négy termet találsz");
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("Hányadik terembe mész?" );
                        Console.ForegroundColor = ConsoleColor.Green;

                        byte terem = 0;
                        try
                        {
                            terem = Convert.ToByte(Console.ReadLine());
                        }
                        catch (FormatException)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("\nSzámot kértem, nem szöveget!");
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.Write("Válassz emeletet: ");
                            school();
                        }
                        catch (OverflowException)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("\nA terem száma nem lehet nagyobb 255-nél, mivel ez a byte maximum értéke!");
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.Write("Válassz emeletet: ");
                            school();
                        }
                        switch (terem)
                        {
                            case 1:
                                {                                  
                                    break;
                                }

                            case 2:
                                {
                                    break;
                                }

                            case 3:
                                {
                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                    Console.WriteLine("Ez a terem egy könyvtár.");
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine("Egy jehova szertartás szemtanúja leszel.");
                                    Console.WriteLine("\nVálasztási lehetőségeid:");
                                    Console.WriteLine(" - 1. Elmenekülsz");
                                    Console.WriteLine(" - 2. Csatlakozol közéjük");
                                    Console.WriteLine(" - 3. Megtámadod őket (Sebzési értékük: 200)");
                                    jehovak();
                                    break;
                                }

                            case 4:
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine("Ez a terem üres.");
                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                    Console.Write("\nMelyik emeletre mész tovább? ");
                                    school();
                                    break;
                                }

                        default:
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Nincs ilyen válasz!");
                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                    Console.Write("\nVálassz emeletet: ");
                                    school();
                                    break;
                                }
                        }
                        break;
                    }

                case 4://kijárat
                    {
                        if (!superGoat)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("Ismét a városban vagy, ám találkozol egy mutálódott kecskefejű emberrel.");
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.Write("Támadási értéke 70. Megtámadod? (Igen/Nem) ");
                            goatMan();
                        }
                        else
                        {
                            Console.WriteLine("Visszatértél a városba.");
                            Console.WriteLine("Balra egy iskolát látsz.");
                            Console.WriteLine("Előre egy játszóteret veszel észre.");
                            Console.WriteLine("Jobbra pedig egy kórházat pillantasz meg");
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.Write("Merre mész? (Balra/Előre/Jobbra) ");
                            deadCity();
                        }
                        break;
                    }

                default:
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Nincs ilyen emelet!");
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("\nVálassz emeletet: ");
                        school();
                        break;
                    }
            }
        }

        public void jehovak()
        {
            place = "Iskola - Könyvtár";
            title(place);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("Válasz: ");
            Console.ForegroundColor = ConsoleColor.Green;
            byte valasz = 0;
            try
            {
                valasz = Convert.ToByte(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\nSzámot kértem, nem szöveget!");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("Válasz: ");
                school();
            }
            catch (OverflowException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\nA válasz száma nem lehet nagyobb 255-nél, mivel ez a byte maximum értéke!");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("Válasz: ");
                school();
            }
            switch (valasz)
            {
                case 1:
                    {
                        break;
                    }

                case 2:
                    {
                        break;
                    }

                case 3:
                    {
                        break;
                    }

                default:
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Nincs ilyen válasz!");
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("\nVálasz: ");
                        jehovak();
                        break;
                    }
            }
        }

        public void goatMan()
        {
            place = "Az ajtó előtt";
            title(place);
            mission = "Hozz döntést!";
            Console.ForegroundColor = ConsoleColor.Green;
            string valasz = Console.ReadLine();

            switch (valasz)
            {
                case "Igen":
                    {
                        battle(attack, 70);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Sikeresen legyőzted a kecskefejű embert!");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Ismét a városban vagy.");
                        Console.WriteLine("Balra egy iskolát látsz.");
                        Console.WriteLine("Előre egy játszóteret veszel észre.");
                        Console.WriteLine("Jobbra pedig egy kórházat pillantasz meg");
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("Merre mész? (Balra/Előre/Jobbra) ");
                        deadCity();
                        break;
                    }

                case "Nem":
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Mivel nem támadod meg a kecskefejű embert, ezért veled tart az utadon.");
                        attack += 70;
                        superGoat = true;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Támadái értéked " + attack + ". szintre növekedett.");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Ismét a városban vagy.");
                        Console.WriteLine("Balra egy iskolát látsz.");
                        Console.WriteLine("Előre egy játszóteret veszel észre.");
                        Console.WriteLine("Jobbra pedig egy kórházat pillantasz meg");
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("Merre mész? (Balra/Előre/Jobbra) ");
                        deadCity();
                        break;
                    }

                case "Statisztika":
                    {
                        stats();
                        closedDoor();
                        break;
                    }
                case "Help":
                    {
                        help();
                        closedDoor();
                        break;
                    }
                case "Feladom":
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Majd legközelebb!");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Nyomj egy gombot a kilépéshez...");
                        Console.ReadKey();
                        break;
                    }

                default:
                    {
                        wrongAnswer();
                        closedDoor();
                        break;
                    }

            }

        }

        public void pilotData()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Név: Marancsics Tamás");
            Console.WriteLine("Születési ideje: 1979.03.23");
            Console.WriteLine("Neme: Férfi");
            Console.WriteLine("Beosztás: Főpilóta");
            Console.WriteLine("Kedvenc száma: 42");
            Console.WriteLine("Úticél: (olvashatatlan)");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void title(String place)
        {
            Console.Title = "hdani1337-AdventureGame - Helyszín: " + place;
        }

        public void battle(byte playerAttack, byte enemyAttack)
        {
            if (firecracker > 0 && match > 0)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("Szeretnél petárdát használni? (Igen/Nem) ");
                Console.ForegroundColor = ConsoleColor.Green;
                string valasz = Console.ReadLine();

                if (valasz.Equals("Igen"))
                {
                    firecrackerBattle(enemyAttack);
                    if (playerAttack >= enemyAttack)
                    {
                        dead = false;
                    }

                    if (playerAttack < enemyAttack)
                    {
                        dead = true;
                    }
                }

                if (valasz.Equals("Nem"))
                {
                    if (playerAttack >= enemyAttack)
                    {
                        dead = false;
                    }

                    if (playerAttack < enemyAttack)
                    {
                        dead = true;
                    }
                }

                if (valasz.Equals("Help"))
                {
                    help();
                    battle(playerAttack,enemyAttack);
                }

                if (valasz.Equals("Statisztika"))
                {
                    stats();
                    battle(playerAttack, enemyAttack);
                }

                if (valasz.Equals("Feladom"))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Majd legközelebb!");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Nyomj egy gombot a kilépéshez...");
                    Console.ReadKey();
                    dead = true;
                }

                else
                {
                    wrongAnswer();
                    battle(playerAttack, enemyAttack);
                }
            }
     
        }

        public void firecrackerBattle(byte enemyAttack)
        {
            byte temp;
            byte damage = 5;
            if (firecracker > 0 && match > 0)
            {
                if (firecracker > match && match > 0) temp = match;
                else if (firecracker < match && firecracker > 0) temp = firecracker;
                else temp = 0;

                Console.Write("Hány petárdát használsz? (Maximum: " + temp + ")");
                Console.ForegroundColor = ConsoleColor.Green;
                byte question = 0;

                try
                {
                    question = Convert.ToByte(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Számot kértem, nem betűt!");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write("Próbáld újra: ");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Túl nagy számot adtál meg!");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write("Próbáld újra: ");
                }

                if (question > temp)
                {
                    Console.WriteLine("Túl nagy értéket adtál meg!");
                    firecrackerBattle(enemyAttack);
                }

                for (byte i = 0; i < question; i++)
                {
                    enemyAttack -= damage;
                }

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Az ellenfél maradék támadási értéke: " + enemyAttack);
                Console.WriteLine("Támadási értéked: " + attack);
            }
        
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Sajnos nincs elég eszközöd a petárdák használatához!");
            }
        }

        public void help()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Ez egy szöveg alapú kalandjáték.");
            Console.WriteLine("A játékos válaszai befolyásolják a játék menetét, szóval dönts bölcsen!");
            Console.WriteLine("Csak a zárójelben megadott lehetőségek elfogadottak.");
            Console.WriteLine("\nSzínjelölések:");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("\n - Piros");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("     Figyelmeztetés, hibaüzenet, negatív események");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(" - Sárga");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("     Fő információ, választási lehetőségek");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(" - Zöld");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("      Játékos válaszai, pozitív események");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write(" - Magenta");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("   Kérdés");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(" - Cián");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("      Mellékadatok");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("\nVálasz a segítség előtti kérdésre: ");
            Console.ForegroundColor = ConsoleColor.Green;
        }

        public void stats()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("\nStatisztika:\n");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Játékos neve: " + playerName);
            if (dogName != "") {
                Console.WriteLine("Játékos kutyájának neve: " + dogName);
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Vagyon: " + gold + " arany");
            Console.ForegroundColor = ConsoleColor.Red;

            if (!samanPorkolt)
            {
                Console.WriteLine("Éhség: " + hungryness);
            }

            else
            {
                Console.WriteLine("Elfogyasztottad Németh Szilárd sámán pörköltjét, így nem halhatsz éhen.");
            }
            
            Console.WriteLine("Támadási erő: " + attack);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Helyszín: " + place);
            Console.WriteLine("Küldetés: " + mission);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\nRendelkezésre álló tárgyak:");

            if (match != 0)
            {
                Console.WriteLine(" - " + match + " darab gyufa");
            }

            if (torch)
            {
                Console.WriteLine(" - Fáklya");
            }
                if (!torch)
                {
                    Console.WriteLine(" - ??? (Ismeretlen tárgy)");
                }

            if (firecracker != 0)
            {
                Console.WriteLine(" - " + firecracker + " darab petárda");
            }
                if (firecracker == 0) {
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

            Console.ForegroundColor = ConsoleColor.Green;

            Console.Write("\nVálasz a Statisztika előtti kérdésre: ");

            Console.ForegroundColor = ConsoleColor.White;
        }

        public void wrongAnswer()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nHibás válasz. Kérlek, add meg újra a választ!");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("Válasz: ");
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