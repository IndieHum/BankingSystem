using System.Text.RegularExpressions;

class Bank
{
  static string userName;
  static string passWord;

  static void Main(string[] args)
  {
    Console.Clear();
    Console.WriteLine("*** Welcome To Our Bank ***\n");
    Console.WriteLine("You have not Account here! Please SignIn.");

    bool isLogIn = false;
    while (!isLogIn)
    {
      Console.WriteLine("Enter Username: ");
      Arrow();
      userName = Console.ReadLine().Trim();

      if (StringValidCheck(userName))
      {
        Console.WriteLine("Enter Password: ");
        Console.WriteLine("#Hint: Password must be between 8 to 16 charchter, include alphabet, numbers and signs.");
        Arrow();
        passWord = Console.ReadLine();

        if (PassValidCheck(passWord))
        {
          Console.WriteLine("Please enter your password again.");
          Arrow();
          string passWordAgain = Console.ReadLine();

          if (passWordAgain.Equals(passWord))
          {
            Console.WriteLine("Account created successfully!");
            isLogIn = true;
          }
          else Console.WriteLine("Password does not match!");
        }
        else Console.WriteLine("Password is wrong, please read hint!");
      }
      else Console.WriteLine("Username is wrong!");
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
    string pattern = @"^(?=.*[a-zA-Z])(?=.*[\W]).{8,16}$";
    if (StringValidCheck(text) || Regex.IsMatch(text, pattern)) return true;
    return false;
  }
}
