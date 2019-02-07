using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Beadandó
{
    class Program
    {
        public static byte gold = 10;
        public static int progress = 0;
        public static Boolean dead = false;
        public static string playerName;
        

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
                progress = 1;
                Console.WriteLine("Remek, kezdjünk is bele!\n");
                Console.WriteLine("2009 januárjában járunk. Az egész város alszik még. Reggel ötkor megcsörren az ébresztőórád, indulnod kell dolgozni. \n" +
                    "Egy kicsit morcosan készülődsz, hiszen alig látsz ki a fejedből a fáradtság miatt. \nPár óra alvás még jól jött volna, nem igaz? \n" +
                    "A válasz egyértelmű, de már kár ezzel foglalkozni, lassan elkellene indulni a vasútállomásra. \n" +
                    "Kiérsz az állomásra, és alig tudsz mozdulni, annyira sok ember van. Mindenki ugyanúgy alszik még, mint ahogyan te magad is. \n" +
                    "Ez teljesen érthető, mivel éppen még csak most zajlottak le az ünnepek, mindenki otthon pihenne még a családjával. \n" +
                    "Nem lehet mit tenni ellene, vissza kell rázódni a megszokott kerékvágásba.\nMiközben ezen elmélkedsz, elkezd szállingózni a hó\n" +
                    "Ennek láttán picit elnosztalgiázol, felidézed a gyerekkorodat. Milyen jó is volt a karácsony gyerekként!\n" +
                    "De gondolataid hamar elszállnak, ugyanis megérkezik a vonat.\nTe vagy az utolsó, előtted már mindenki felszállt, mégis találsz egy szabad fülkét.\n" +
                    "Gyorsan helyet foglalsz, és el is indul a vonat. Két megállóval odébb felszáll egy bőrkabátos alak, aki veled szembe ül le.\n" +
                    "Gyanúsan néz rád, minthogyha ismerne valahonnan. Kellemetlenül érzed magad, de lasan megérkezel a munkahelyedre.\n" +
                    "Fel is pattansz, de mielőtt leszállnál, a férfi egy cetlit nyom a kezedbe, és közli,\nhogyha bárkinek beszélsz erről, akkor nagy bajba kerülhetsz.\n" +
                    "Egy telefonszám áll rajta. Amint beérsz a munkahelyedre, abban a pillanatban felhívod a számot. Előfizető nem kapcsolható, de fura érzés fog el.\n" +
                    "Nagyon lassan telik az idő aznap, de mégis végzel a munkával.\nAz utad természetesen ismét a vasút felé tartana, de ekkor kapsz egy SMS-t egy ismeretlen számról: \n,," + playerName +
                    ", te vagy a kiválasztott!''" +
                    "\nValahonnan mégis ismerős a telefonszám. Hiszen ez az, amit reggel az ismeretlen férfi a kezedbe nyomott, szóval megint felhívod!\n" +
                    "Ismét. Ezen a számon előfizető nem kapcsolható. Már hagynád is az egészet a francba, mire még egy SMS-t kapsz:\n" +
                    ",,Ne próbálkozz annyit, majd mindennek eljön az ideje!''\nPróbálsz lenyugodni, de egyszerűen nem megy. Beáll a vonat, felszállsz és hazamész.\n" +
                    "Ezúttal semmi szokatlan. Leagalábbis csak azt hiszed...\n" +
                    "Belépsz az ajtódon, levetkőzöl, eszel egy kicsit a tegnapi rántotthúsból. Ezután megkeresed a reggeli újságot. Pár perc keresés után megtalálod a szekrényben.\n" +
                    "Nagyon szokatlan. Sose rakod a szekrénybe az újságot, de nem is törődsz vele.\nKiveszed, alatta egy cetli, amin egy GPS-koordináta van.\n" +
                    "Éppen hogy csak megnézed, kapsz egy telefonhívást. Édesapád az. Azt mondja, hogy a húgod minden nyom nélkül eltűnt.\n" +
                    "Rákeresel erre a helyre. Körülbelül 100 kilométerre van tőled, egy barlangot jelöl. A gyanúval élve el is indulsz oda. Itt kezdődik a kalandunk!");
                barlang();
            }

            else if (valasz.Equals("Nem"))
            {
                Console.WriteLine("Ezek szerint még nem vagy elég érett erre a feladatra. Majd legközelebb!");
                Console.WriteLine("Nyomj egy gombot a kilépéshez!");
                Console.ReadKey();
            }

            else
            {
                wrongAnswer();
            }
        }

        public void barlang() {
            progress = 2;
            Console.WriteLine("Megérkezel erre a furcsa helyre. Indulnál is felfedezni a barlang rejtelmeit, azonban két ismeretlen alak állja az utad.\n" +
                "Fegyverrel kényszerítenek, hogy vetkőzz le teljesen és minden tárgyadat dobd el magadtól. A félelem miatt ezt meg is teszed.\n" +
                "Ezután adnak neked egy rongyos szövetruhát, egy kopott kabátot, 10 aranyat és egy fáklyát. Sok sikert kívánnak neked.\n" +
                "A sokk és az adrenalin hatására indulsz is a barlangba. Néhány méter séta után máris egy útvesztőbe botlasz.\n" +
                "Eldöntheted, hogy balra, vagy jobbra folytatod az utat. (Ne a politikára gondolj most)\n" +
                "Balról medvék morajlását hallod, jobbról pedig gyenge fény pislákol.\n" +
                "Merre szeretnél menni? (Balra/Jobbra)");
            string valasz = Console.ReadLine();

            if (valasz.Equals("Balra")) {
            }

            if (valasz.Equals("Jobbra")) {
            }

        }

        public void wrongAnswer() {
            Console.WriteLine("\nHibás válasz. Kérlek, add meg újra a választ!");
            progress = 0;
            introduction();
        }

        static void Main(string[] args)
        {
            Console.Title = "hdani1337-AdventureGame";
            new Program();
            if (dead) {
                Console.WriteLine("Meghaltál, vége a játéknak!");
                Console.ReadKey();
            }
        }
    }
}
