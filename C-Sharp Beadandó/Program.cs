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
        public static byte firecracker = 0;
        public static byte attack = 10;
        public static byte hungryness = 0;
        public static Boolean dead = false;
        public static Boolean pickaxe = false;
        public static Boolean torch = false;
        public static Boolean map = false;
        public static Random random = new Random();
        public static string playerName;
        public static string dogName = "";
        public static string place;
        public static string mission;

        //Robi takarodj innen mert eltöröm a kezed :D

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
                title(place);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Olyan furcsán érzed magad. Kinyitod a szemed, s egy szigeten találod magad furcsa öltözetben.\nKörülnézel, " +
                    "s támadt pár gondolatod.\n");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Balra melletted vannak ágak és zsinegek. Készíthetsz belőle fáklyát.");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Előtted van egy sötét barlang.");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Jobbra pedig pár madár keres valami eledelt a homokban.");

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\nMerre mész tovább? (Balra/Előre/Jobbra)");
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
            Console.ForegroundColor = ConsoleColor.White;
            if (valasz.Equals("Balra")) {
                place = "Fáklyakészítő hely";
                mission = "Kezdd el az utad!";
                title(place);
                torch = true;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nSikeresen elkészítetted a fáklyát!");
                Console.ForegroundColor = ConsoleColor.White;
                hungryness++;
                Console.WriteLine("\nA munka miatt az éhséged " + hungryness + "-re nőtt. Vigyázz, ha az éhséged eléri a 10-es szintet, éhenhalsz!\n");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Balra nem tudsz menni, mert arra a tenger van.");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Jobbra a barlang található.");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Előre pedig magas sziklák vannak.");

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\nMerre tovább? (Balra/Előre/Jobbra)");
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
            Console.ForegroundColor = ConsoleColor.White;
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
                title(place);
                Console.WriteLine("\nBeértél a barlangba és meggyújtod a fákját. Azonnal kettéoszlik a barlang.\n");

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Balról kutyaugatást hallasz.");
                Console.WriteLine("Jobbról gyenge fény pislákol.");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\nMerre mész? (Balra/Jobbra)");
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
                title(place);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("\nErőt veszel magadon, és elindulsz az ugatás felé." +
                    "\nMeglepő, egy farkaskutya az, akinek beszorult a lába egy kő alá. Segítesz neki? ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("(");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Igen");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("/");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Nem");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(")\n");
                farkas();
            }

            if (valasz.Equals("Jobbra"))
            {
                place = "Az erdő";
                title(place);
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
                Console.WriteLine("\nA támadási értéked " + attack + "-ra nőtt, ám az éhséged is " + hungryness + "-es szintre emelkedett!\n" +
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
            title(place);
            Console.WriteLine("A fény egyre erősödik, s egy erdőbe érkezel.\n");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Balra találsz egy almafát.");
            Console.WriteLine("Előre egy domb van.");
            Console.WriteLine("Jobbra pedig pár erősebb botot és köveket találsz.\n");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Furdal a kíváncsiság, hogy mi lehet a domb mögött, így csak EGYSZER választhatsz.\n" +
                "Dönts okosan! " +
                "Merre mész? (Balra/Előre/Jobbra)");
            erdo();
        }

        public void erdo() {
            string valasz = Console.ReadLine();
            place = "A puma árnyékában";
            mission = "A puma legyőzése";
            title(place);
            if (valasz.Equals("Balra"))
            {
                Console.WriteLine("Eszel az almából, aminek tápértéke 2. Ezután elindulsz a dombhoz.");
                Console.WriteLine("A dombon túl egy pumát pillantasz meg. Támadási értéke 30. megtámadod? (Igen/Nem)");
                hungryness -= 2;
                puma();
            }

            if (valasz.Equals("Jobbra"))
            {
                Console.WriteLine("A botokból és kövekből lándzsát készítesz, így támadási értéked 15-tel növekszik! Ezután elindulsz a dombhoz.");
                Console.WriteLine("A dombon túl egy pumát pillantasz meg. Támadási értéke 30. megtámadod? (Igen/Nem)");
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
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Gratulálok, legyőzted a pumát!");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\nA puma megölése után tovább indulsz.\n" +
                        "Körülbelül fél óra séta után találsz egy holttestet.\n" +
                        "Az öltözetéből ítélve egy bányász volt.\n");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("Kirabolod? (Igen/Nem)");
                    Console.ForegroundColor = ConsoleColor.White;
                    place = "A bányász nyughelye";
                    mission = "Hozd meg a helyes döntést!";
                    Console.Title = "hdani1337-AdventureGame - " + place;
                    holttest();
                }
            }

            if (valasz.Equals("Nem"))
            {
                Console.WriteLine("Nem támadod meg a pumát, úgyhogy visszamész az erdőbe.");
                place = "Újra az erdőben";
                title(place);
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
            title(place);
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
                    "Először a helikopterben kezdesz el kutatni. Észreveszel egy ládát, egy kesztyűtartót és egy bőröndöt.\nMelyiket nyitod ki? (Láda/Kesztyűtartó/Bőrönd)");
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
            title(place);
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
                Console.WriteLine("Majd legközelebb!");
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

        public void borond() {
            string valasz = Console.ReadLine();

            if (!valasz.Equals("0323")) {
                Console.WriteLine("Nem nyílik ki a bőrönd. Próbáld újra");
            }

            if (valasz.Equals("0323")) {
                Console.WriteLine("Kinyitottad a bőröndöt.");
                Console.WriteLine("Találsz benne egy kulcsot és némi élelmiszert.");
                Console.ForegroundColor = ConsoleColor.Green;
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
                Console.WriteLine("Majd legközelebb!");
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

        public void lada() {
            Console.WriteLine("A ládában találsz 7 petárdát. Sebzési értékük 5.");
            firecracker = 7;
            hungryness += 3;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Ettől a sok kalandtól az éhséged " + hungryness + ". szintre nőtt. Lassan kéne enni valamit.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Szeretnél ételt keresni?");
            Console.Write("(");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Igen");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("/");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Nem");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(")");

            ladaKajaDontes();
        }

        public void ladaKajaDontes() {
            string valasz = Console.ReadLine();

            if (valasz.Equals("Igen"))
            {
                Console.WriteLine("Két irányba indulhatsz el ételt keresni.");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Balra találsz egy üres táborhelyet.");
                Console.WriteLine("Jobbra pedig egy gyümölcsöst veszel észre.");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Merre mész? (Balra/Jobbra)");
                Console.ForegroundColor = ConsoleColor.White;
                kajaKereses();
            }

            if (valasz.Equals("Nem"))
            {
                Console.WriteLine("Útközben találkozol egy medvével.");
                Console.WriteLine("Támadási értéke 40.");
                Console.WriteLine("Megtámadod?");
                Console.Write("(");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Igen");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("/");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Nem");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(")");
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
                Console.WriteLine("Majd legközelebb!");
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

        public void kajaKereses() {
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
                    //to be continued...
                }
            }

            if (valasz.Equals("Jobbra"))
            {
                Console.WriteLine("A gyümölcsösben elfogyasztasz pár körtét és epret.");
                hungryness -= 2;
                Console.WriteLine("Az éhséged " + hungryness + ". szintre csökkent.");
                Console.WriteLine("A friss gyümölcstől hirtelen egy kis energiára kaptál.");
                Console.WriteLine("Játszol egy kicsit " + dogName + "val?");
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
                Console.WriteLine("Majd legközelebb!");
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

        public void gameWithDog() {
            string valasz = Console.ReadLine();

            if (valasz.Equals("Igen"))
            {
                Console.WriteLine(dogName + " nagyon örült a játéknak.");
                Console.WriteLine("Támadási ereje 5-tel növekedett.");
                attack += 5;
                Console.WriteLine("Tovább folytatjátok az utatokat.");
                Console.WriteLine("Egy hídhoz érkeztek.");
                Console.WriteLine("Pár tartógerendája már repedt vagy eltörött. Régóta nem tartja karban senki.");
                Console.WriteLine("Átmentek rajta? (Igen/Nem)");
                hid();
                //to be continued...

            }

            if (valasz.Equals("Nem"))
            {
                Console.WriteLine("Tovább folytatjátok az utatokat.");
                Console.WriteLine("Egy hídhoz érkeztek.");
                Console.WriteLine("Pár tartógerendája már repedt vagy eltörött. Régóta nem tartja karban senki.");
                Console.WriteLine("Átmentek rajta? (Igen/Nem)");
                hid();
                //to be continued...

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
                Console.WriteLine("Majd legközelebb!");
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

        public void hid() {
            string valasz = Console.ReadLine();

            if (valasz.Equals("Igen"))
            {
                byte luck = (byte)random.Next(1, 10);

                if (luck <= 5)
                {
                    Console.WriteLine("Sikeresen átkeltél a hídon.");
                    //to be continued...
                }

                else
                {
                    Console.WriteLine("Sajnos leestél a hídról.");
                    Console.WriteLine("Vége a játéknak.");
                    Console.WriteLine("Nyomj egy gombot a kilépéshez...");
                    Console.ReadKey();
                    dead = true;
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
                Console.WriteLine("Majd legközelebb!");
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

        public void maciLaci() {
            string valasz = Console.ReadLine();

            if (valasz.Equals("Igen"))
            {
                battle(attack,40);

                if (!dead) {
                    Console.WriteLine(dogName + " ismét valami szagot fog, úgyhogy elindulsz utána.");
                    Console.WriteLine("Pár keselyű teteméhez vezet. Valami baljós közeleg.");
                    Console.WriteLine("Besötétül az ég, és egy tornádó jelenik meg mögötted.");
                    Console.WriteLine("Elkezdesz futni? (Igen/Nem)");
                    tornado();
                }
            }

            if (valasz.Equals("Nem"))
            {
                Console.WriteLine("Megpróbálsz elmenekülni, de a medve észrevesz és hátbatámad.");
                Console.WriteLine("Meghaltál, vége a játéknak.");
                Console.ReadKey();
                dead = true;
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
                Console.WriteLine("Majd legközelebb!");
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

        public void tornado() {
            string valasz = Console.ReadLine();

            if (valasz.Equals("Igen"))
            {
                Console.WriteLine("A menekülés közben elesel, s halálos sebet kapsz.");
                Console.WriteLine("Vége a játéknak!");
                Console.WriteLine("Nyomj egy gombot a kilépéshez!");
                Console.ReadKey();
                dead = true;
            }

            if (valasz.Equals("Nem"))
            {
                Console.WriteLine("A tornádó elragad magával, s egy ismeretlen helyen földet érsz.");
                //to be continued...
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
                Console.WriteLine("Majd legközelebb!");
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

        public void pilotData() {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Név: Marancsics Tamás");
            Console.WriteLine("Születési ideje: 1979.03.23");
            Console.WriteLine("Neme: Férfi");
            Console.WriteLine("Beosztás: Főpilóta");
            Console.WriteLine("Kedvenc száma: 42");
            Console.WriteLine("Úticél: (olvashatatlan)");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void title(String place) {
            Console.Title = "hdani1337-AdventureGame - Helyszín: " + place;
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
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nEz egy szöveg alapú kalandjáték. Csak a zárojelben megadott válaszleghetőségek elfogadottak.\n" +
                "A játékban bármikor használhatod a ,,Statisztika'' parancsot, ami leírja a pontos információidat.\n" +
                "A játékot bármikor befejezheted a ,,Feladom'' szóval.\n" +
                "Sok sikert a játékhoz!");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void stats() {
            Console.ForegroundColor = ConsoleColor.Gray;
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
