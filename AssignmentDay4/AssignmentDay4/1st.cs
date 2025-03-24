using System;
using System.Xml.Linq;

class loggedINUsers
{
    public static int totalusers = 0;
    public string username;

    public loggedINUsers(string name)
    {
        username = name;
        totalusers++;
    }

    public void showUser()
    {
        Console.WriteLine($"User loggin in : {username}");
    }

    public static void showTotalUsers()
    {
        Console.WriteLine($"Total number of users loggin is :{totalusers}");
    }
}

class Program()
{
    static void Main()
    {
        loggedINUsers user1 = new loggedINUsers("Rho");
        user1.showUser();
        loggedINUsers user2 = new loggedINUsers("Alpha");
        user2.showUser();
        loggedINUsers user3 = new loggedINUsers("Gamma");
        user3.showUser();

        loggedINUsers.showTotalUsers();

    }
}