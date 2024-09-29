// RAPPORTSYSTEM 80 - Systemkrav och funktioner
// 1. REGISTRERING AV UTRYCKNINGAR
// Möjlighet att detaljerat registrera varje enskild utryckning med parametrar som TYP 
//(t.ex. stöld, bråk, trafikbrott), PLATS, TIDPUNKT och vilka POLISER som deltog. 2. RAPPORTER
// När en utryckning är över måste en rapport skrivas för utryckningen. 
//Rapporten skall innehålla RAPPORTNUMMER, DATUM, POLISSTATION som hanterar ärendet samt BESKRIVNING.
// 3. PERSONAL
// Om möjligt, funktion för att registrera personal med NAMN och TJÄNSTENUMMER. 4. INFORMATIONSSAMMANSTÄLLNING
// Snabb och enkel åtkomst till listor och detaljerad information om utryckningar, rapporter och personal via klara och koncisa kommandon.


class Program
{
    static void Main(string[] args) // Main-metoden bör endast hantera övergripande styrning, 
    //som att skapa objekt och anropa metoder. Du har gjort rätt genom att skapa objektet Reports, 
    //men logiken för att lägga till brott bör ligga i sina egna klasser/metoder.
    {   
        Crimes crimes = new Crimes(); // skapa objekt crimes
        Reports report1 = new Reports(); // skapa objecte report1
        Reports report2 = new Reports();

        report1.AddCrime("Stöld", "Kiruna", "29/09");
        report1.AddDetails("Natali", 12, "Mindre klädstöld");
        crimes.list.Add(report1);
        
        report2.AddCrime("Bråk", "Göteborg", "20/09");
        report2.AddDetails("Lukas", 11, "Bråk på avenyen");
        crimes.list.Add(report2);
                
        crimes.StartMenu();

    }

    public class Crimes 
    // Crimes-klassen kan representera en samling brottsrapporter (en lista över Reports). 
    // Den kan hantera saker som att lägga till, visa och söka brott i listan.
    {
        public List<Reports> list = new(); // this list will hold objects of the Reports class.
        
        //Reports report = new(); // Utan denna kommer vi INTE åt grejer i Reports!

        public Crimes() // Det du lägger här i måste fyllas i varje gång du skapar ett objekt! 
        {   
            list =  new List <Reports>(); // Initalisera lista
            // I detta fall skapas en ny lista varje gång du skapar ett nytt objekt av klassen Crimes, 
            // och listan är nu redo att användas. 
            // Du kan nu lägga till objekt i listan med till exempel list.Add().

            
        }
        public void StartMenu()
        {
            while (true)
            {
                Console.WriteLine("1. Registrera ny utryckning"); //Addcrime
                Console.WriteLine("2. Fyll i rapport"); //AddDetails
                Console.WriteLine("3. Registera personal"); // AddNewPolice
                Console.WriteLine("4. Informationssammanställning"); // PrintReport & se en lista över personal med id-nummer
                Console.Write("Gör ett val: ");
                int choice = int.Parse(Console.ReadLine());
            
                switch (choice)
                {   
                    case 1: // crime,place,date
                        for (int i = 0; i < list.Count; i++)
                        {
                        Reports report = new();
                        Console.WriteLine("Fyll i brott: ort: datum: ");
                        string c = Console.ReadLine();
                        //Console.Write("Fyll i ort: ");
                        string p = Console.ReadLine();
                        //Console.Write("Fyll i datum: ");
                        string d = Console.ReadLine();
                        report.AddCrime(c,p,d);
                        list.Add(report);
                        PrintReport();
                        }
                    break; 
                    
                    case 2: // name,id,descrpition
                    // Välj rapport att fylla i: 
                    for (int i = 0; i < list.Count; i++)
                        {
                        Reports report = new();
                        Console.WriteLine("Fyll i polis: ID-nummer: Beskrivning");
                        string nam = Console.ReadLine();
                        int id = Convert.ToInt32(Console.ReadLine());
                        string des = Console.ReadLine();  
                        report.AddDetails(nam, id, des);
                        list.Add(report);
                        PrintReport();

                        }

                    break; 
                    case 3: // Registrering av personal 

                    break; 
                    
                    case 4: 
                    PrintReport();
                    break; 
                }
            }
        }

        public void PrintReport()
        {
            for (int i = 0; i < list.Count; i++)
            {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("__________________________");
            Console.WriteLine("Rapportnummer: " + list[i].GenerateReportNumber());
            Console.WriteLine($"Station: {list[i].StationNumber}");
            Console.WriteLine("Typ av brott: " + list[i].Crime);
            Console.WriteLine("Plats:" + list[i].Place +", Datum: "+list[i].Date);
            Console.WriteLine("Polis: " + list[i].Name+ ", Id-nummer: "+list[i].IdNr);
            Console.WriteLine("Beskrivning: "+list[i].Description);
            Console.WriteLine("__________________________");
            Console.ResetColor();
            }
            
        }


    }
    public class Reports
    // Reports-klassen ska representera //en enskild rapport med all information som krävs 
    //(som brott, plats, datum, etc.).
    {

        public int StationNumber{get;set;}
        public int ReportNumber{get; set;} // rndNr
        public string Crime{get; set;}
        public string Place{get; set;}
        public string Date{get; set;}
        public string Name{get; set;}
        public int IdNr{get; set;}
        public string Description{get; set;} 
        
        public Reports ()
        { // standardkonstruktor utan parametrar, kan användas till att initisalera defaultvärden! 
        //Ska kanske också ta bort null? 
            StationNumber = 641;  
            Crime = "Inget brott angivet";
            Place = "Ingen stad angiven";
            Date = "00/00"; 
            Name = "Ingen polis angiven";
            IdNr = 00;
            Description = "Ingen beskrivning angiven";
            ReportNumber = 0000;

        }
        public void AddCrime(string crime, string place, string date)
        {
            this.Crime = crime;
            this.Place = place;
            this.Date = date; 

        }
        public void AddDetails(string name, int idNr, string description)
        {
            this.Name = name;
            this.IdNr = idNr;
            this.Description = description;

        }
        public int GenerateReportNumber()
        {
        Random random = new Random();
        return random.Next(999,6000);
       
        }


    }

}