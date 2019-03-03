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
        public static byte lockpick = 0;
        public static byte hungryness = 0;
        public static byte match = 0;
        public static Boolean dead = false;
        public static Boolean pickaxe = false;
        public static Boolean torch = false;
        public static Boolean map = false;
        public static Boolean samanPorkolt = false;
        public static Boolean quest = false;
        public static Random random = new Random();
        public static string playerName;
        public static string dogName = "";
        public static string place;
        public static string mission;

        //Robi takarodj innen mert eltöröm a kezed :D

        public Program()
        {
            if (!dead) {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Hogy hívnak?");
                playerName = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("\nÜdv " + playerName + "! Készen állsz egy kalandra? (Igen/Nem) ");
                introduction();
            }    
        }

        public void introduction() {
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
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Balra melletted vannak ágak, zsinegek és egy gyufa. Készíthetsz belőle fáklyát.");
                Console.WriteLine("Előtted van egy sötét barlang.");
                Console.WriteLine("Jobbra pedig pár madár keres valami eledelt a homokban.");

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("\nMerre mész tovább? (Balra/Előre/Jobbra) ");
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
            Console.ForegroundColor = ConsoleColor.Green;
            string valasz = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            if (valasz.Equals("Balra")) {
                place = "Fáklyakészítő hely";
                mission = "Kezdd el az utad!";
                title(place);
                torch = true;
                match += 1;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nSikeresen elkészítetted a fáklyát!");
                Console.ForegroundColor = ConsoleColor.White;
                hungryness++;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nA munka miatt az éhséged " + hungryness + "-re nőtt. Vigyázz, ha az éhséged eléri a 10-es szintet, éhenhalsz!\n");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Balra nem tudsz menni, mert arra a tenger van.");
                Console.WriteLine("Jobbra a barlang található.");
                Console.WriteLine("Előre pedig magas sziklák vannak.");

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("\nMerre tovább? (Balra/Előre/Jobbra) ");
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
            Console.ForegroundColor = ConsoleColor.Green;
            string valasz = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            mission = "Kezdd el az utad!";
            if (valasz.Equals("Balra"))
            {
                Console.WriteLine("Mégis bemész a vízbe, ám olyan mély, hogy azonnal lesüllyedsz az aljára és megfulladsz.");
                Console.WriteLine("Nyomj egy gombot a kilépéshez...");
                Console.ReadKey();
                dead = true;
            }

            if (valasz.Equals("Jobbra"))
            {
                place = "A barlang";
                mission = "Döntsd el, hogy merre szeretnél továbbmenni!";
                title(place);
                Console.WriteLine("\nBeértél a barlangba és meggyújtod a fákját. Azonnal kettéoszlik a barlang.\n");
                match -= 1;
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Balról kutyaugatást hallasz.");
                Console.WriteLine("Jobbról gyenge fény pislákol.");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("\nMerre mész? (Balra/Jobbra)");
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
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("\nSegítesz neki? (Igen/Nem) "); 
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
            Console.ForegroundColor = ConsoleColor.Green;
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
            Console.ForegroundColor = ConsoleColor.Green;
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
            Console.ForegroundColor = ConsoleColor.DarkYellow;
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
            Console.ForegroundColor = ConsoleColor.Green;
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
            Console.ForegroundColor = ConsoleColor.Green;
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
                    Console.Write("\nKirabolod? (Igen/Nem) ");
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
            Console.ForegroundColor = ConsoleColor.Green;
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
                "Ez a térkép néhány szigetet ábrázol, az egyik sziget úticélnak van megjelölve. Elteszed, hátha jól jön.");
            Console.Write("\nTöröd a fejed egy próbán, beindítod a helikoptert? (Igen/Nem) ");
            map = true;
            place = "A helikopter történetének nyomában";
            mission = "Döntsd el, hogy megéri-e engedni a kíváncsiságnak!";
            title(place);
            Console.ForegroundColor = ConsoleColor.Green;
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
            place = "A bőrönd";
            mission = "Fejtsd meg a kódot!";
            title(place);
            Console.ForegroundColor = ConsoleColor.Green;
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
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("A ládában találsz 7 petárdát. Sebzési értékük 5.");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Használatukhoz gyufa szükséges!");
            firecracker = 7;
            hungryness += 3;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Ettől a sok kalandtól az éhséged " + hungryness + ". szintre nőtt. Lassan kéne enni valamit.");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("\nSzeretnél ételt keresni? (Igen/Nem) ");
            ladaKajaDontes();
        }

        public void ladaKajaDontes() {
            Console.ForegroundColor = ConsoleColor.Green;
            string valasz = Console.ReadLine();

            if (valasz.Equals("Igen"))
            {
                Console.WriteLine("Két irányba indulhatsz el ételt keresni.");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
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
            place = "A híd";
            title(place);
            mission = "Kelj át a hídon, sok szerencsét!";
            Console.ForegroundColor = ConsoleColor.Green;
            string valasz = Console.ReadLine();

            if (valasz.Equals("Igen"))
            {
                byte luck = (byte)random.Next(1, 10);

                if (luck <= 5)
                {
                    Console.WriteLine("Sikeresen átkeltél a hídon.");
                    Console.WriteLine("Ismét elindulhatsz több irányba.");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Balra egy kihalt tömbházat találsz.");
                    Console.WriteLine("Előre egy kisboltot veszel észre.");
                    Console.WriteLine("Jobbra pedig egy bunkerrel találkozol.");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write("\nMerre mész? (Balra/Előre/Jobbra) ");
                    afterBridge();
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

        public void afterBridge() {
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
                Console.WriteLine("Beléptél a bunkerbe.");
                //balra legyenek valami kommunista propagandák
                //jobbra legyen egy újabb folyosó
                //előre pedig legyen egy bezárt ajtó
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
                Console.WriteLine("Majd legközelebb!");
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

        public void tombhazText() {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Emeletek:");
            Console.WriteLine(" 1. emelet");
            Console.WriteLine(" 2. emelet");
            Console.WriteLine(" 3. emelet");
            Console.WriteLine(" 4. emelet");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("\nEmelet: ");
            tombhazText();
        }

        public void tombhaz() {
            Console.ForegroundColor = ConsoleColor.Green;
            byte emelet = Convert.ToByte(Console.ReadLine());

            switch (emelet)
            {
                case 1:
                    {
                        place = "Tömbház - 1. emelet";
                        title(place);
                        Console.WriteLine("Itt két szobát találsz.");
                        Console.Write("Hányadik szobába mész?");
                        byte szoba = Convert.ToByte(Console.ReadLine());

                        switch (szoba)
                        {
                            case 1:
                                {
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
                        Console.WriteLine("Itt három szobát találsz.");
                        Console.Write("Hányadik szobába mész?");

                        byte szoba = Convert.ToByte(Console.ReadLine());

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
                                    Console.WriteLine("Nincs ilyen szoba!");
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
                        Console.WriteLine("Itt egy szobát találsz");
                        Console.Write("Bemész a szobába? (Igen/Nem) ");

                        string szoba = Console.ReadLine();

                        switch (szoba)
                        {
                            case "Igen":
                                {
                                    break;
                                }

                            case "Nem":
                                {
                                    Console.Write("\nVálassz emeletet: ");
                                    tombhaz();
                                    break;
                                }

                            default:
                                {
                                    Console.WriteLine("Nincs ilyen válasz!");
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
                        title(place);
                        Console.WriteLine("Itt három szobát találsz.");
                        Console.Write("Hányadik szobába mész?");

                        byte szoba = Convert.ToByte(Console.ReadLine());

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
                                    Console.WriteLine("Nincs ilyen szoba!");
                                    Console.Write("\nVálassz emeletet: ");
                                    tombhaz();
                                    break;
                                }
                        }

                        break;
                    }

                default:
                    {
                        Console.WriteLine("Nincs ilyen emelet!");
                        Console.Write("\nVálassz emeletet: ");
                        tombhaz();
                        break;
                    }
            }
        }

        public void torpeQuest() {
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

                default:
                    {
                        wrongAnswer();
                        torpeQuest();
                        break;
                    }
            }
        }

        public void shopText() {
            place = "Gizi néni kisboltja";
            mission = "Vegyél meg mindent amíg tart a Black Friday!";
            title(place);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Válassz kategóriát!");
            Console.WriteLine(" 1. Fegyverek");
            Console.WriteLine(" 2. Ételek");
            Console.WriteLine(" 3. Kiegészítők");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("\nKategória: ");
            shop();
        }

        public void shop() {
            byte kategoria = Convert.ToByte(Console.ReadLine());

            switch (kategoria)
            {
                case 1:
                    {
                        Console.WriteLine("Kategória: Fegyverek");
                        Console.WriteLine(" 1. Petárda (Sebzés: 5) (Ár: 1 arany) (Darab: 3)");
                        Console.WriteLine(" 2. Balta (Sebzés: 40) (Ár: 8 arany) (Darab: 1)");

                        byte fegyver = Convert.ToByte(Console.ReadLine());

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

                        byte kaja = Convert.ToByte(Console.ReadLine());

                        switch (kaja)
                        {
                            case 1:
                                {
                                    if (gold >= 1)
                                    {
                                        hungryness -= 1;
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

                        byte egyebek = Convert.ToByte(Console.ReadLine());

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

        public void shopContinue() {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("\nSzeretnéd folytatni a vásárlást? (Igen/Nem) ");
            Console.ForegroundColor = ConsoleColor.Green;
            string valasz = Console.ReadLine();

            if (valasz.Equals("Igen")) {
                Console.Write("\nKategória: ");
                shop();
            }

            if (valasz.Equals("Nem"))
            {
            }

            else {
                wrongAnswer();
            }
        }

        public void maciLaci() {
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
            Console.ForegroundColor = ConsoleColor.Green;
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

        public void wrongAnswer() {
            Console.ForegroundColor = ConsoleColor.Cyan;
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
