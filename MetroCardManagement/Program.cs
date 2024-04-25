using System;
namespace MetroCardManagement;
public class Program
{
    public static void Main(string[] args)
    {
        //create folders and files
        FileHandling.Create();

        //read data from csv files
        //FileHandling.ReadFromCSV();

        //adding default data
        //Operations.DefaultData();

        //calling Main menu
        Operations.MainMenu();

        //write files to csv
        //FileHandling.WriteToCSV();

    }
}