using System.Text.RegularExpressions;

class Bank
{
  static Random ranNum = new Random();
  static long accountBalance = ranNum.Next(1200, 21000);
  static string SerialCard = CardSerial();

  static string CardSerial()
  {
    string SerieOne = $"{ranNum.Next(1111, 9999)}";
    string SerieTwo = $"{ranNum.Next(1111, 9999)}";
    string SerieThree = $"{ranNum.Next(1111, 9999)}";
    string SerieFour = $"{ranNum.Next(1111, 9999)}";

    return $"{SerieOne} - {SerieTwo} - {SerieThree} - {SerieFour}";
  }

  static string NameGenerate()
  {
    string[] Names = { "Fatemeh", "Ali", "Hasan", "Hosein", "Sajad", "Bagher", "Sadegh" };
    string[] LastNames = { "Zamani", "Askari", "Naghavi", "Javadi", "Razavi", "Kazemi", "Mohammadi" };

    return $"{Names[ranNum.Next(0, 7)]} {LastNames[ranNum.Next(0, 4)]}";
  }

  static void PayamMohtaramane() => Console.WriteLine("Adam bash doost aziz");

  static void Main(string[] args)
  {
    Console.Clear();
    Console.WriteLine("*** Welcome To Our Bank ***\n");
    Console.WriteLine("You have not Account here! Please SignIn.");

    bool isLogIn = false;
    //Auth procces
    while (!isLogIn)
    {
      //asking for username
      Console.WriteLine("Enter Username: ");
      Arrow();
      string userName = Console.ReadLine().Trim();

      //check for validation of username
      if (StringValidCheck(userName))
      {
        //asking for password
        Console.WriteLine("Enter Password: ");
        Console.WriteLine("#Hint: Password must be between 8 to 16 charchter, include alphabet, numbers and signs.");
        Arrow();
        string passWord = Console.ReadLine();

        if (PassValidCheck(passWord))
        {
          Console.WriteLine("Please enter your password again.");
          Arrow();
          string passWordAgain = Console.ReadLine();

          if (passWordAgain.Equals(passWord))
          {
            Console.WriteLine("Account created successfully!");
            Console.WriteLine("loading...");
            System.Threading.Thread.Sleep(2000);
            isLogIn = true;
            Menu(userName, passWord);
          }
          else Console.WriteLine("Password does not match!");
        }
        else Console.WriteLine("Password is wrong, please read hint!");
      }
      else Console.WriteLine("Username is wrong!");
    }
  }

  static void Menu(string username, string password)
  {
    Console.Clear();
    Console.WriteLine($"Welcome {username}\n");
    Console.WriteLine($"your account balance: {accountBalance:C}");

    bool isDone = false;

    while (!isDone)
    {
      Console.WriteLine("\nWhat you want to do?\n1) Deposit Money\n2) Withdraw Money\n3) Exit");
      Arrow();
      string userInput = Console.ReadLine();

      if (int.TryParse(userInput, out int input) && input >= 1 && input <= 3)
      {
        switch (input)
        {
          case 1:
            DepositMoney();
            break;
          case 2:
            WithdrawMoney();
            break;
          case 3:
            isDone = true;
            Console.WriteLine("bye bye, we will stole your money");
            break;
        }
      }
      else Console.WriteLine("Adam bash doost aziz");
    }
  }

  static void WithdrawMoney()
  {
    Console.WriteLine("Write SERIAL CARD you want send money:");
    Arrow();
    string ClientSerial = Console.ReadLine();

    if (SerialCardCheck(ClientSerial))
    {
      Console.WriteLine($"The serial card you enter is for {NameGenerate()}.");
      Console.WriteLine("If its true, enter money you want to send\nIf not, enter anything else.");

      Arrow();
      string ClientMoney = Console.ReadLine();

      // have an error, not fixed yet!
      if (int.TryParse(ClientMoney, out int ClientMoneyInt) &&
          ClientMoneyInt >= 0 && ClientMoneyInt <= accountBalance)
      {
        accountBalance -= ClientMoneyInt;
        Console.WriteLine("Money withdraw successfully!");
        Console.WriteLine($"your account balance: {accountBalance:C}\n");
      }
      else return;
    }
    else Console.WriteLine("Serial Card is wrong!");
  }

  static bool SerialCardCheck(string text)
  {
    string numCheck = @"^\d{16}$";
    if (StringValidCheck(text) && Regex.IsMatch(text, numCheck)) return true;
    return false;
  }

  static void DepositMoney()
  {
    long Deposit = ranNum.Next(1, 666);
    Console.WriteLine($"This is your SERIAL CARD, send it to whom you want money from there.\n{SerialCard}");
    System.Threading.Thread.Sleep(1500);
    Console.WriteLine("Proccesing...");
    System.Threading.Thread.Sleep(3000);
    Console.WriteLine($"{Deposit:C} | This amount of money is sent by {NameGenerate()}");

    accountBalance += Deposit;

    Console.WriteLine($"\nyour account balance: {accountBalance:C}");
  }

  static void Arrow() => Console.Write("=> ");

  static bool StringValidCheck(string text)
  {
    if (string.IsNullOrWhiteSpace(text) || string.IsNullOrEmpty(text)) return false;
    return true;
  }

  static bool PassValidCheck(string text)
  {
    string filter = @"^(?=.*[a-zA-Z])(?=.*\d)(?=.*[\W]).{8,16}$";
    if (StringValidCheck(text) && Regex.IsMatch(text, filter)) return true;
    return false;
  }
}
