using System;
using System.Collections.Generic;

namespace DealDone
{
    public abstract class Ad
    {
        public string AdID { get; init; }
        public string Description { get; init; }
        public string Email { get; init; }
        public DateOnly Start_Date { get; init; }
        public DateOnly Archive_Date { get; set; }
        public Status AdStatus { get; set; }

        public enum Status
        {
            LIVE,
            ARCHIVED
        }

        public Ad(string adID, string description, string email)
        {
            AdID = adID;
            Description = description;
            Email = email;
            AdStatus = Status.LIVE;
            Start_Date = DateOnly.FromDateTime(DateTime.Now);
        }

        public abstract bool Renew();

        public void Archive()
        {
            AdStatus = Status.ARCHIVED;
            Archive_Date = DateOnly.FromDateTime(DateTime.Now);
        }

        public virtual void PrintAdDetails()
        {
            Console.WriteLine($"AdID: {AdID}");
            Console.WriteLine($"Description: {Description}");
            Console.WriteLine($"Email: {Email}");
            Console.WriteLine($"Start Date: {Start_Date}");
            Console.WriteLine($"Archive Date: {Archive_Date}");
            Console.WriteLine($"Ad Status: {AdStatus}");
        }

        public bool IsLiveOn(DateOnly date)
        {
            if (AdStatus == Status.LIVE && date >= Start_Date && date <= Archive_Date)
                return true;
            else
                return false;
        }
    }

    public class FreeAd : Ad
    {
        public FreeAd(string adID, string description, string email) : base(adID, description, email)
        {
            Archive_Date = Start_Date.AddDays(7);
        }

        public override bool Renew()
        {
            Console.WriteLine("Free Ads cannot be renewed.");
            return false;
        }

        public new void PrintAdDetails()
        {
            Console.WriteLine($"AdID: {AdID}");
            Console.WriteLine($"Description: {Description}");
            Console.WriteLine($"Email: {Email}");
            Console.WriteLine($"Start Date: {Start_Date}");
            Console.WriteLine($"Archive Date: {Archive_Date}");
            Console.WriteLine($"Ad Status: {AdStatus}");
        }
    }

    public abstract class PaidAd : Ad
    {
        public string ImageMain { get; set; }
        public bool IsRenewed { get; set; }
        public int RenewalPeriod { get; set; }

        public PaidAd(string adID, string description, string email, string imageMain) : base(adID, description, email)
        {
            ImageMain = imageMain;
        }

        public override bool Renew()
        {
            if (IsRenewed == true || AdStatus != Status.LIVE)
            {
                return false;
            }
            else
            {
                Archive_Date = Archive_Date.AddDays(RenewalPeriod);
                IsRenewed = true;
                return true;
            }
        }
    }

    public class Standard : PaidAd
    {
        public Standard(string adID, string description, string email, string imageMain) : base(adID, description, email, imageMain)
        {
            RenewalPeriod = 7; // Standard ads are renewed for 7 days
            Archive_Date = Start_Date.AddDays(14);
        }

        public new void PrintAdDetails()
        {
            Console.WriteLine($"AdID: {AdID}");
            Console.WriteLine($"Description: {Description}");
            Console.WriteLine($"Email: {Email}");
            Console.WriteLine($"Start Date: {Start_Date}");
            Console.WriteLine($"Archive Date: {Archive_Date}");
            Console.WriteLine($"Ad Status: {AdStatus}");
        }
    }

    public class Corporate : PaidAd
    {
        public int ImagesLimit { get; set; }
        public List<string> AdditionalImages { get; init; }

        public Corporate(string adID, string description, string email, string imageMain) : base(adID, description, email, imageMain)
        {
            RenewalPeriod = 14; // Corporate ads are renewed for 14 days
            AdditionalImages = new List<string>();
            Archive_Date = Start_Date.AddDays(20);
        }
    }
}

