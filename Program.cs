
using System;
using System.Linq;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarTest();
            //ColorTest();
            //BrandTest();
            //RentalTest();
            //UserAndCustomerTest();

            
            
        }

        private static void UserAndCustomerTest()
        {
            //UserManager userManager = new UserManager(new EfUserDal());
            //User user = new User { UserName = "Narily", UserLastName = "Scanf", UserEmail = "narilyscanf@outlook.com", UserPassword = "narilyscanf" };
            ////userManager.Add(user);

            //CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            //customerManager.Add(new Customer { UserID = (userManager.Get(user).Data.UserID), CompanyName = "Chance" });

        }

        private static void RentalTest()
        {
            /*
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var result = rentalManager.GetRentalDetails();
            foreach (var results in result.Message)
            {
                Console.WriteLine(result.Message);
            }
            */

            //rentalManager.Add(new Rental { CarID = 12, CustomerID = 4, RentDate = new DateTime(2021, 02, 12), ReturnDate = new DateTime(2021, 02, 13) });

            //Console.WriteLine();
            //foreach (var results in result.Data)
            //{
            //    Console.WriteLine("{0}|{1}|{2}|{3}|{4}|{5}",
            //        results.RentalID, results.CarName, results.CustomerName, results.CustomerLastName, results.CompanyName, results.RentDate, results.ReturnDate);
            //}

        }

        private static void BrandTest()
        {
         
        }

        private static void ColorTest()
        {
            
            Console.WriteLine();
        }

        private static void CarTest()
        {
           

        }
    }
}
