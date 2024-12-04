using System.Text.RegularExpressions;

class Bank
{
  static Random ranNum = new Random();
  static long accountBalance = ranNum.Next(1200, 21000);

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
    Console.WriteLine($"your account balance: {accountBalance:C}\n");
    Console.WriteLine("What you want to do?\n1) Deposit Money\n2) Withdraw Money\n3) Exit");

    bool isDone = false;

    while (!isDone)
    {
      Arrow();
      string userInput = Console.ReadLine();

      if (int.TryParse(userInput, out int input) && input >= 1 && input <= 3)
      {
        switch (input)
        {
          case 1:
            break;
          case 2:
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
