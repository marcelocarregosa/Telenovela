using System;

namespace Telenovelas
{
  class Program
  {
    static TelenovelasRepository repository = new TelenovelasRepository();
    static void Main(string[] args)
    {
      string userOption = GetUserOption();

      while (userOption.ToUpper() != "X")
      {
        switch (userOption)
        {
          case "1":
            ListTelenovelas();
            break;
          case "2":
            InsertTelenovela();
            break;
          case "3":
            UpdateTelenovela();
            break;
          case "4":
            DeleteTelenovela();
            break;
          case "5":
            ViewTelenovela();
            break;
          case "C":
            Console.Clear();
            break;
          default:
            throw new ArgumentOutOfRangeException();
        }
        userOption = GetUserOption();
      }
      Console.WriteLine("Thanks for using our services!");
      Console.ReadLine();
    }

    private static void ListTelenovelas()
    {
      Console.WriteLine("List Telenovelas");
      var list = repository.List();

      if (list.Count == 0)
      {
        Console.WriteLine("No telenovela registered.");
        return;
      }

      foreach (var telenovela in list)
      {
        var deleted = telenovela.isDeleted();
        Console.WriteLine("#ID {0}: - {1}", telenovela.returnId(), telenovela.returnTitle(), (deleted ? "*Deleted" : ""));
      }
    }

    private static void InsertTelenovela()
    {
      Console.WriteLine("Insert New Telenovela");

      foreach (int i in Enum.GetValues(typeof(Country)))
      {
        Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Country), i));
      }

      Console.Write("Enter the country from the options above: ");
      int countryInput = int.Parse(Console.ReadLine());

      Console.Write("Enter the telenovela title: ");
      string titleInput = Console.ReadLine();

      Console.Write("Enter the year of the beginning of the telenovela: ");
      int yearInput = int.Parse(Console.ReadLine());

      Console.Write("Enter the description of the telenovela: ");
      string descriptionInput = Console.ReadLine();

      Telenovela newTelenovela = new Telenovela(id: repository.NextId(),
                                                country: (Country)countryInput,
                                                title: titleInput,
                                                description: descriptionInput,
                                                year: yearInput);
      repository.Insert(newTelenovela);
    }

    private static void UpdateTelenovela()
    {
      Console.Write("Enter the telenovela Id: ");
      int telenovelaIndex = int.Parse(Console.ReadLine());

      foreach (int i in Enum.GetValues(typeof(Country)))
      {
        Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Country), i));
      }

      Console.Write("Enter the country from the options above: ");
      int countryInput = int.Parse(Console.ReadLine());

      Console.Write("Enter the telenovela title: ");
      string titleInput = Console.ReadLine();

      Console.Write("Enter the year of the beginning of the telenovela: ");
      int yearInput = int.Parse(Console.ReadLine());

      Console.Write("Enter the description of the telenovela: ");
      string descriptionInput = Console.ReadLine();

      Telenovela updateTelenovela = new Telenovela(id: repository.NextId(),
                                                country: (Country)countryInput,
                                                title: titleInput,
                                                description: descriptionInput,
                                                year: yearInput);
      repository.Update(telenovelaIndex, updateTelenovela);
    }

    private static void DeleteTelenovela()
    {
      Console.Write("Digite o id da telenovela: ");
      int telenovelaIndex = int.Parse(Console.ReadLine());

      repository.Delete(telenovelaIndex);
    }

    private static void ViewTelenovela()
    {
      Console.Write("Digite o id da telenovela: ");
      int telenovelaIndex = int.Parse(Console.ReadLine());

      var telenovela = repository.returnById(telenovelaIndex);

      Console.WriteLine(telenovela);
    }

    private static string GetUserOption()
    {
      Console.WriteLine();
      Console.WriteLine("TELENOVELAS");
      Console.WriteLine("Enter the desired option:");

      Console.WriteLine("1_ List telenovelas");
      Console.WriteLine("2_ Insert new telenovela");
      Console.WriteLine("3_ Update telenovela");
      Console.WriteLine("4_ Delete telenovela");
      Console.WriteLine("5_ View telenovela");
      Console.WriteLine("C_ Clear screen");
      Console.WriteLine("X_ Exit");

      string userOption = Console.ReadLine().ToUpper();
      Console.WriteLine();
      return userOption;
    }
  }
}
