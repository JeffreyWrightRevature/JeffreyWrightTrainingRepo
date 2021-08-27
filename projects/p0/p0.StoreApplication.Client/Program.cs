﻿using System;
using System.Collections.Generic;
using p0.StoreApplication.Domain.Abstracts;
using p0.StoreApplication.Domain.Models;
using p0.StoreApplication.Storage.Repositories;
using p0.StoreApplication.Client.Singletons;

namespace p0.StoreApplication.Client
{
  /// <summary>
  /// Defines the Program class
  /// </summary>
  class Program
  {
    private static readonly StoreSingleton _storeSingleton = StoreSingleton.Instance;
    private static readonly CustomerSingleton _customerSingleton = CustomerSingleton.Instance;
    /// <summary>
    /// Defines the main outfit
    /// </summary>
    /// <param name="args"></param>
    static void Main(string[] args)
    {
      var p = new Program();
      Console.WriteLine("Welcome to The Store!");
      p.DisplayMenu();
    }
    /// <summary>
    /// 
    /// </summary>
    private void DisplayMenu()
    {
      Console.WriteLine("1: View customers");
      Console.WriteLine("3: View store locations");
      Console.WriteLine("4: Select store");
      //Console.WriteLine("3: View products to purchase");
      //Console.WriteLine("4: View past purchases");
      Console.WriteLine("7: Log Out");
      Console.Write("Select an option: ");
      var option = int.Parse(Console.ReadLine());
      switch (option)
      {
        case 1:
          var customers = new List<Customer>
          {
            new Customer() { Name = "Elizabeth Medford" },
            new Customer() { Name = "Nicole Medford" },
            new Customer() { Name = "Henry Medford" }
          };
          Output<Customer>(_customerSingleton.Customers);
          break;
        case 2:
          Console.WriteLine(SelectCustomer() + "\n");
          break;
        case 3:
          var stores = new List<Store>()
          {
            new FurnitureStore(){ Name = "IKEA", State = "IN", City = "Fishers"},
            new TechStore(){ Name = "Best Buy", State = "TX", City = "San Antonio" },
            new MultimediaStore(){ Name = "Jeffrey's Home Entertainment", State = "AZ", City = "Mesa" },
            new TechStore(){ Name = "Smartphones and Gizmos", State = "CA", City = "Long Beach"},
            new MultimediaStore(){ Name = "Smithsonian Museum Media Collection", State = "DC", City = "Washington"},
            new FurnitureStore(){ Name = "Cool Funiture", State = "UT", City = "Orem"}
          };
          Output<Store>(_storeSingleton.Stores);
          break;
        case 4:
          Console.WriteLine(SelectStore() + "\n");
          break;
        case 7:
          break;
      }
      if (option != 5)
        DisplayMenu();
    }

    private static void Output<T>(List<T> data) where T : class
    {
      var i = 1;

      foreach (var item in data)
      {
        Console.WriteLine(i + ": " + item);
        i++;
      }
      Console.WriteLine("");
    }

    private Customer SelectCustomer()
    {
      //Access the stores from the store repository
      var customers = (_customerSingleton.Customers);

      //Prompt to select a store
      Console.Write("Select a Customer: ");

      //Return the store of the user input
      return (customers[int.Parse(Console.ReadLine()) - 1]);
    }

    private Store SelectStore()
    {
      //Access the stores from the store repository
      var stores = (_storeSingleton.Stores);

      //Prompt to select a store
      Console.Write("Select a Store: ");

      //Return the store of the user input
      return (stores[int.Parse(Console.ReadLine()) - 1]);
    }
  }
}
