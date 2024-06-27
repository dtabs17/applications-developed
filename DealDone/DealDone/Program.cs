using DealDone;
using System.Globalization;

int option;
List<Ad> adList = new List<Ad>();
do
{
    Console.WriteLine("Welcome to the DealDone Application! Please enter the option you would like to implement: ");
    Console.WriteLine("1. Set up data.");
    Console.WriteLine("2. Display data.");
    Console.WriteLine("3. Search by Ad Id.");
    Console.WriteLine("4. Delete Ad.");
    Console.WriteLine("5. Renew.");
    Console.WriteLine("6. Display publication.");
    Console.WriteLine("7. Archive.");
    Console.WriteLine("8. Exit.");
    option = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine();
    switch (option)
    {
        case 1:
            SetUpData(adList);
            break;
        case 2:
            DisplayData(adList);
            break;
        case 3:
            Search(adList);
            break;
        case 4:
            Delete(adList);
            break;
        case 5:
            Renew(adList);
            break;
        case 6:
            DisplayPublication(adList);
            break;
        case 7:
            Archive(adList);
            break;
        case 8:
            break;
        default:
            Console.WriteLine("Invalid Option! Please enter a value between 1 and 8.");
            break;
    }
}
while (option != 8);
Console.WriteLine("Thank you for using the DealDone Application! Goodbye!");


static void SetUpData(List<Ad> adList)
{
    Corporate C1 = new Corporate("Ad1", "Corporate Ad 1", "aaa@gmail.com", "pig.jpg");
    Corporate C2 = new Corporate("Ad2", "Corporate Ad 2", "bbb@gmail.com", "goat.jpg");
    adList.Add(C1);
    adList.Add(C2);
    Standard S1 = new Standard("Ad3", "Standard Ad 1", "ccc@gmail.com", "cat.jpg");
    Standard S2 = new Standard("Ad4", "Standard Ad 2", "ddd@gmail.com", "dog.jpg");
    adList.Add(S1);
    adList.Add(S2);
    FreeAd F1 = new FreeAd("Ad5", "Free Ad 1", "eee@gmail.com");
    FreeAd F2 = new FreeAd("Ad6", "Free Ad 2", "fff@gmail.com");
    adList.Add(F1);
    adList.Add(F2);
    Console.WriteLine("Your data has been set up!\n");
}

static void DisplayData(List<Ad> adList)
{
    foreach (Ad ad in adList)
    {
        ad.PrintAdDetails();
        Console.WriteLine();
    }
}

static void Search(List<Ad> adList)
{
    Console.WriteLine("Please enter the ID you would like to find: ");
    string ID = Console.ReadLine();
    Console.WriteLine();
    Ad foundAd = FindAd(adList, ID);
    if (foundAd != null)
    {
        foundAd.PrintAdDetails();
    }
    else
    {
        Console.WriteLine($"Ad with ID '{ID}' not found.");
    }
    Console.WriteLine();
}

static Ad FindAd(List<Ad> adList, string ID)
{
    Ad foundAd = adList.FirstOrDefault(ad => ad.AdID == ID);
    return foundAd;
}

static void Delete(List<Ad> adList)
{
    Console.WriteLine("Enter the Ad ID of the ad you would like to delete:");
    string AdID = Console.ReadLine();
    Console.WriteLine();
    Ad foundAd = FindAd(adList, AdID);

    if (foundAd != null)
    {
        adList.Remove(foundAd);
        Console.WriteLine($"Ad with ID '{AdID}' has been deleted.");
    }
    else
    {
        Console.WriteLine($"Ad with ID '{AdID}' not found.");
    }
}

static void Renew(List<Ad> adList)
{
    Console.WriteLine("Enter the Ad ID of the ad you would like to renew:");
    string AdID = Console.ReadLine();
    Console.WriteLine();
    Ad foundAd = FindAd(adList, AdID);

    if (foundAd != null)
    {
        
        if (foundAd.Renew() == false)
        {
            Console.WriteLine($"Error! Could not renew {foundAd.AdID}\n");
        }
        
    }
    else
    {
        Console.WriteLine($"Ad with ID '{AdID}' not found.");
    }
}

static void DisplayPublication(List<Ad> adList)
{
    Console.WriteLine("Enter a date (dd/MM/yyyy): ");
    string dateString = Console.ReadLine();
    Console.WriteLine();
    CultureInfo irishCulture = new CultureInfo("en-IE");
    DateOnly date = DateOnly.Parse(dateString, irishCulture);

    foreach (Ad ad in adList)
    {
        if (date >= ad.Start_Date && date <= ad.Archive_Date)
        {
            ad.PrintAdDetails();
        }
        Console.WriteLine();
    }
}

static void Archive(List<Ad> adList)
{
    DateOnly currentDate = DateOnly.FromDateTime(DateTime.Now);

    foreach (Ad ad in adList)
    {
        if (currentDate >= ad.Archive_Date)
        {
            ad.Archive();
           Console.WriteLine(); 
        }
    }
}




