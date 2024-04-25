using System;
namespace HybridInheritance2;
public class Program
{
    public static void Main(string[] args)
    {
        SavingAccount savingAccoun1 = new SavingAccount("rio","male",new DateTime(2000,8,9),"8832994","9367477433","VID20002","3288432849","PSGDFN3884","savings",90,"HDF","IFSC8384","Anna nagar");
        SavingAccount savingAccount2 = new SavingAccount("ramesh","male",new DateTime(1989,12,19),"8342334","9343247433","VID24842","35334849","PSGBH4556","savings",290,"jdid","IFSC8344","koyembedu");


        Console.WriteLine($"Balance : {savingAccoun1.Deposit(20)}");
        Console.WriteLine($"Balance : {savingAccount2.Withdraw(30)}");
        Console.WriteLine($"Balance : {savingAccoun1.BalanceCheck()}");
        
        
        
    }
}