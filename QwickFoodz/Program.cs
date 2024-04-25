using System;
namespace QwickFoodz;
public class Program
{
    public static void Main(string[] args)
    {

        //creating folder
        FileHandling.Create();

        //read files
        FileHandling.ReadFromCSV();

        //default data
        // Operations.DefaultData();

        //calling main menu
        Operations.MainMenu();

        //writing Files
        FileHandling.WriteTOCSV();
    }
}