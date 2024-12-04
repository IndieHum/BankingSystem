using System.Text.RegularExpressions;

class Bank
{
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
    Console.WriteLine($"Welcome {username}");
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
