using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        ComputerStore computerStore = new ComputerStore();
        computerStore.LoadFromFile("datori.txt");

        bool isRunning = true;

        while (isRunning)
        {
            Console.WriteLine("Izvēlieties darbību:");
            Console.WriteLine("1. Pievienot jaunu datoru");
            Console.WriteLine("2. Parādīt visus datorus");
            Console.WriteLine("3. Atrast datoru pēc nosaukuma");
            Console.WriteLine("4. Dzēst datoru pēc nosaukuma");
            Console.WriteLine("5. Pievienot pircēju");
            Console.WriteLine("6. Parādīt visus pircējus");
            Console.WriteLine("7. Pievienot pārdevēju");
            Console.WriteLine("8. Parādīt visus pārdevējus");
            Console.WriteLine("9. Nopirkt datoru");
            Console.WriteLine("10. Iziet");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    // Pievienot jaunu datoru
                    Console.WriteLine("Ievadiet datora nosaukumu:");
                    string name = Console.ReadLine();

                    Console.WriteLine("Ievadiet datora cenu:");
                    decimal price = decimal.Parse(Console.ReadLine());

                    Console.WriteLine("Ievadiet datora ražotāju:");
                    string manufacturer = Console.ReadLine();

                    Console.WriteLine("Ievadiet datora RAM:");
                    int ram = int.Parse(Console.ReadLine());

                    Console.WriteLine("Ievadiet datora procesoru:");
                    string processor = Console.ReadLine();

                    Console.WriteLine("Ievadiet datora GPU:");
                    string gpu = Console.ReadLine();

                    Console.WriteLine("Ievadiet datora atmiņu:");
                    int memory = int.Parse(Console.ReadLine());

                    Computer computer = new Computer(name, price, manufacturer, ram, processor, gpu, memory);
                    computerStore.AddComputer(computer);

                    Console.WriteLine("Dators ir veiksmīgi pievienots!");
                    break;

                case "2":
                    // Parādīt visus datorus
                    Console.WriteLine("Visi datori:");
                    computerStore.ShowComputers();
                    break;

                case "3":
                    // Atrast datoru pēc nosaukuma
                    Console.WriteLine("Ievadiet datora nosaukumu:");
                    string searchName = Console.ReadLine();

                    Computer foundComputer = computerStore.FindComputerByName(searchName);
                    if (foundComputer != null)
                    {
                        Console.WriteLine($"Dators ar nosaukumu '{foundComputer.Name}' ir atrasts:");
                        Console.WriteLine($"Cena: {foundComputer.Price}, Ražotājs: {foundComputer.Manufacturer}, RAM: {foundComputer.RAM}GB, Procesors: {foundComputer.Processor}, GPU: {foundComputer.GPU}, Atmiņa: {foundComputer.Memory}GB");
                    }
                    else
                    {
                        Console.WriteLine("Dators ar norādīto nosaukumu netika atrasts!");
                    }
                    break;

                case "4":
                    // Dzēst datoru pēc nosaukuma
                    Console.WriteLine("Ievadiet datora nosaukumu, kuru vēlaties dzēst:");
                    string deleteName = Console.ReadLine();

                    bool isDeleted = computerStore.DeleteComputer(deleteName);
                    if (isDeleted)
                    {
                        Console.WriteLine($"Dators ar nosaukumu '{deleteName}' ir veiksmīgi dzēsts!");
                    }
                    else
                    {
                        Console.WriteLine("Dators ar norādīto nosaukumu netika atrasts!");
                    }
                    break;

                case "5":
                    // Pievienot pircēju
                    Console.WriteLine("Ievadiet pircēja vārdu:");
                    string buyerName = Console.ReadLine();

                    Console.WriteLine("Ievadiet pircēja uzvārdu:");
                    string buyerSurname = Console.ReadLine();

                    Console.WriteLine("Ievadiet pircēja e-pastu:");
                    string buyerEmail = Console.ReadLine();

                    Buyer buyer = new Buyer(buyerName, buyerSurname, buyerEmail);
                    computerStore.AddBuyer(buyer);

                    Console.WriteLine("Pircējs ir veiksmīgi pievienots!");
                    break;

                case "6":
                    // Parādīt visus pircējus
                    Console.WriteLine("Visi pircēji:");
                    computerStore.ShowBuyers();
                    break;

                case "7":
                    // Pievienot pārdevēju
                    Console.WriteLine("Ievadiet pārdevēja vārdu:");
                    string sellerName = Console.ReadLine();

                    Console.WriteLine("Ievadiet pārdevēja uzvārdu:");
                    string sellerSurname = Console.ReadLine();

                    Console.WriteLine("Ievadiet pārdevēja tālruņa numuru:");
                    string sellerPhone = Console.ReadLine();

                    Seller seller = new Seller(sellerName, sellerSurname, sellerPhone);
                    computerStore.AddSeller(seller);

                    Console.WriteLine("Pārdevējs ir veiksmīgi pievienots!");
                    break;

                case "8":
                    // Parādīt visus pārdevējus
                    Console.WriteLine("Visi pārdevēji:");
                    computerStore.ShowSellers();
                    break;

                case "9":
                    // Nopirkt datoru
                    Console.WriteLine("Ievadiet datora nosaukumu, kuru vēlaties nopirkt:");
                    string buyComputerName = Console.ReadLine();

                    Computer buyComputer = computerStore.FindComputerByName(buyComputerName);
                    if (buyComputer != null)
                    {
                        Console.WriteLine($"Dators ar nosaukumu '{buyComputer.Name}' ir atrasts:");
                        Console.WriteLine($"Cena: {buyComputer.Price}");

                        Console.WriteLine("Vai vēlaties apstiprināt pirkumu? (y/n)");
                        string confirmChoice = Console.ReadLine();

                        if (confirmChoice.ToLower() == "y")
                        {
                            Console.WriteLine("Ievadiet savu vārdu:");
                            string buyerFirstName = Console.ReadLine();

                            Console.WriteLine("Ievadiet savu uzvārdu:");
                            string buyerLastName = Console.ReadLine();

                            Console.WriteLine("Ievadiet savu tālruņa numuru:");
                            string buyerPhone = Console.ReadLine();

                            Console.WriteLine("Ievadiet savu e-pastu:");
                            string buyerEmailInput = Console.ReadLine();

                            Console.WriteLine("Rēķins tiks nosūtīts uz šo e-pasta adresi. Vai tas ir pareizi? (y/n)");
                            string emailConfirmChoice = Console.ReadLine();

                            if (emailConfirmChoice.ToLower() == "y")
                            {
                                // Nosūtīt rēķinu uz norādīto e-pasta adresi
                                string invoiceEmail = buyerEmailInput;
                                Console.WriteLine($"Rēķins ir veiksmīgi nosūtīts uz e-pasta adresi {invoiceEmail}!");
                            }
                            else
                            {
                                Console.WriteLine("Ievades atceltas. Pirkums netika apstiprināts!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Pirkums netika apstiprināts!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Dators ar norādīto nosaukumu netika atrasts!");
                    }
                    break;

                case "10":
                    // Iziet
                    isRunning = false;
                    break;

                default:
                    Console.WriteLine("Nepareiza darbības izvēle!");
                    break;
            }

            Console.WriteLine();
        }

        computerStore.SaveToFile("datori.txt");
    }
}

class Computer
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Manufacturer { get; set; }
    public int RAM { get; set; }
    public string Processor { get; set; }
    public string GPU { get; set; }
    public int Memory { get; set; }

    public Computer(string name, decimal price, string manufacturer, int ram, string processor, string gpu, int memory)
    {
        Name = name;
        Price = price;
        Manufacturer = manufacturer;
        RAM = ram;
        Processor = processor;
        GPU = gpu;
        Memory = memory;
    }
}

class Buyer
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }

    public Buyer(string firstName, string lastName, string email)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
    }
}

class Seller
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }

    public Seller(string firstName, string lastName, string phone)
    {
        FirstName = firstName;
        LastName = lastName;
        Phone = phone;
    }
}

class ComputerStore
{
    private List<Computer> computers;
    private List<Buyer> buyers;
    private List<Seller> sellers;

    public ComputerStore()
    {
        computers = new List<Computer>();
        buyers = new List<Buyer>();
        sellers = new List<Seller>();
    }

    public void LoadFromFile(string fileName)
    {
        if (File.Exists(fileName))
        {
            string[] computerLines = File.ReadAllLines(fileName);
            foreach (string line in computerLines)
            {
                string[] computerData = line.Split(';');
                if (computerData.Length == 7)
                {
                    string name = computerData[0];
                    decimal price = decimal.Parse(computerData[1]);
                    string manufacturer = computerData[2];
                    int ram = int.Parse(computerData[3]);
                    string processor = computerData[4];
                    string gpu = computerData[5];
                    int memory = int.Parse(computerData[6]);

                    Computer computer = new Computer(name, price, manufacturer, ram, processor, gpu, memory);
                    computers.Add(computer);
                }
            }
        }
    }

    public void SaveToFile(string fileName)
    {
        using (StreamWriter writer = new StreamWriter(fileName))
        {
            foreach (Computer computer in computers)
            {
                string line = $"{computer.Name};{computer.Price};{computer.Manufacturer};{computer.RAM};{computer.Processor};{computer.GPU};{computer.Memory}";
                writer.WriteLine(line);
            }
        }
    }

    public void AddComputer(Computer computer)
    {
        computers.Add(computer);
    }

    public void ShowComputers()
    {
        foreach (Computer computer in computers)
        {
            Console.WriteLine($"Nosaukums: {computer.Name}, Cena: {computer.Price}, Ražotājs: {computer.Manufacturer}, RAM: {computer.RAM}GB, Procesors: {computer.Processor}, GPU: {computer.GPU}, Atmiņa: {computer.Memory}GB");
        }
    }

    public Computer FindComputerByName(string name)
    {
        return computers.Find(computer => computer.Name == name);
    }

    public bool DeleteComputer(string name)
    {
        Computer computer = FindComputerByName(name);
        if (computer != null)
        {
            computers.Remove(computer);
            return true;
        }
        return false;
    }

    public void AddBuyer(Buyer buyer)
    {
        buyers.Add(buyer);
    }

    public void ShowBuyers()
    {
        foreach (Buyer buyer in buyers)
        {
            Console.WriteLine($"Vārds: {buyer.FirstName}, Uzvārds: {buyer.LastName}, E-pasts: {buyer.Email}");
        }
    }

    public void AddSeller(Seller seller)
    {
        sellers.Add(seller);
    }

    public void ShowSellers()
    {
        foreach (Seller seller in sellers)
        {
            Console.WriteLine($"Vārds: {seller.FirstName}, Uzvārds: {seller.LastName}, Telefons: {seller.Phone}");
        }
    }
}

