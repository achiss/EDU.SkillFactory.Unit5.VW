 
// Refactoring from: https://github.com/achiss/Unut5_result.git 

 
namespace Unit5.refactoring         // Подчёркивается, почему?
{ 
    class Program
    {
        // Объявление кортежа
        static (string Name, string Surname, int Age, bool isPet, int petCount, string[] petList,
            int colorCount, string[] colorList) userData;
        
        // Метод "Main" (точка входа)
        static void Main(string[] args)
        {
           GetUserData(out userData.Name, out userData.Surname, out userData.Age);
           GetPetUserData(ref userData.isPet, ref userData.petCount, ref userData.petList);
           GetColorUserData(ref userData.colorCount, ref userData.colorList);
           
           ShowUserData(in userData);
           
           Console.ReadKey(); 
        } 
 
        // Общие методы (методы "получение" данных, проверки) 
        // Получение данных из консоли (проверка: null, пустая строка, строка состоящая из символов разделителей) 
        static string GetDataFromConsole()
        {
            var error = "The data cannot be null.";
            
            string receivedData = Console.ReadLine(); 
            if (string.IsNullOrWhiteSpace(receivedData))
            { 
                ShowMistakeMessage(error); 
                return GetDataFromConsole(); 
            } 
            
            return receivedData; 
        } 
 
        // Проверка полученных данных из консоли (проверка: на цифры и специальные символы) 
        static string CharactersToChecked()
        {
            var error = "Еhe data cannot contain numbers and special characters.";
            
            string characterString = GetDataFromConsole(); 
            bool containSpecialChars = characterString.Any(char.IsLetterOrDigit);
            bool containNumbers = characterString.Any(char.IsDigit);
            
           if ((containSpecialChars == false) || (containNumbers == true))      // Почему IDE не подсвечивает true? 
            { 
                ShowMistakeMessage(error); 
                return CharactersToChecked(); 
            } 
 
            return characterString; 
        } 
 
        //  Проверка полученных данных из консоли (проверка: введено число) 
        static int NumberIdentification()
        {
            var error = "The entered data can be only a number.";
            
            string receivedData = GetDataFromConsole(); 
            int receivedNumber; 
             
           if (int.TryParse(receivedData, out receivedNumber)) 
            { 
                return receivedNumber; 
            } 
            else 
            { 
                ShowMistakeMessage(error); 
                NumberIdentification(); 
            } 
 
            return receivedNumber; 
        } 
 
        // Проверка полученных данных из консоли (проверка: введённое число больше 0) 
        static int CheckNumber(int receivedNumber)
        {
            var error = "The entered value must be greater than 0.";
            
            if (receivedNumber < 0) 
            { 
                ShowMistakeMessage(error); 
                return NumberIdentification(); 
            } 
            else
            { 
                if (receivedNumber == 0) 
                { 
                    ShowMistakeMessage(error); 
                    return NumberIdentification(); 
                } 
                else
                { 
                    return receivedNumber; 
                } 
            } 
        }
        
        // Метод выводит сообщение об ошибке если введены не корректные значения
       static void ShowMistakeMessage(string error) 
        { 
            Console.WriteLine("\t [Info] The value you are entering is incorrect!"); 
            Console.Write("\t [Error] {0} Please, re-enter this data: ", error); 
        }
       
       // Метод получения данных и их сохранение в часть кортежа (личные данные пользователя)
       static void GetUserData(out string userName, out string userSurname, out int userAge)
        { 
            Console.Write("\n"); 
             
            Console.Write("\t Input your name (only letters): "); 
            userName = CharactersToChecked(); 
             
            Console.Write("\t Input your surname (only letters): "); 
            userSurname = CharactersToChecked(); 
             
            Console.Write("\t Input your full agе (only numbers): "); 
            userAge = CheckNumber(NumberIdentification());
        }
       
        // Метод получения данных и их сохранение в часть кортежа (данные о питомцах)
        static void GetPetUserData(out bool userIsPet)
        {
            Console.Write("\t Do yo have any pet(s) (only letters, Yes(y) or No(n): ");
            userIsPet = HavePet();
        }
        
        // Метод возвращает булевское значение в переменную userIsPet, есть ли у пользователя питомцы
        static void HavePet(bool userIsPet)
        {
            
        }
        
        
        
        
       
       
       
       
       
       static void PetUserData(ref bool userIsPet, ref int userPetCount, ref string[] userPetList)
       {
           Console.Write("\t Do yo have any pet(s) (only letters, Yes(y) or No(n): ");
           userIsPet = CheckDataIsPetAnswer();
           
           if (userIsPet == true)
           {
               Console.Write("\t Input, how many pet's do you have (only numbers)?");
               userPetCount = CheckNumber(NumberIdentification());
               
               AddDataToTheUserPetList(in userPetCount, ref userPetList);
           }
           else
           {
               ShowMessage();
               NotCorrectDataToUserPetCount(ref userPetCount);
               AddDataToTheUserPetList(in userPetCount, ref userPetList);
           }
       }
       
       static bool CheckDataIsPetAnswer()
       {
           string receivedData = CharactersToChecked();
           if ((receivedData.ToLower() == "yes") || (receivedData.ToLower() == "y"))
           {
               return true;
           }
           else
           {
               if ((receivedData.ToLower() == "no") || (receivedData.ToLower() == "n"))
               {
                   return false;
               }
               else
               {
                   ShowMessage();
                   return CheckDataIsPetAnswer();
               }
           }
       }

       static void NotCorrectDataToUserPetCount(ref int userPetCount)
       {
           userPetCount = CheckNumber(NumberIdentification());
           while (userPetCount <= 0)
           {
               ShowMessage();
               userPetCount = CheckNumber(NumberIdentification());
           }
       }

       static void AddDataToTheUserPetList(in int userPetCount, ref string[] userPetList)
       {
           userPetList = new string[userPetCount];
           for (int i = 1; i < userPetCount; i++)
           {
               Console.Write("\t Input you {0} pet name: ", Convert.ToString(i));
               userPetList[0] = CharactersToChecked();
           }
       }
       
       
       
       

       // Возвращает часть кортежа: количество любимых цветов и их наименование
       static void GetColorUserData(ref int userColorCount, ref string[] userColorList)
       {
           Console.Write("\t How many colors do you like (only numbers)? ");
           userColorCount = NumberIdentification();
           
           userColorList = new string[userColorCount];
           for (int i = 1; i < userColorCount; i++)
           {
               Console.Write("\t Input you {0} favorite colors (only letters): ", Convert.ToString(i));
               userColorList[0] = CharactersToChecked();
           }
       }
       
       // Метод отображает введённую информацию 
       static void ShowUserData(in (string Name, string Surname, int Age, bool isPet, int petCount, string[] petList,
           int colorCount, string[] colorList) userData)
       {
           Console.WriteLine($"\n\t Hello {userData.Surname} {userData.Name}, yor are {userData.Age} full years old.");
           
           if (userData.isPet == true)
           {
               Console.WriteLine("\t Yor have a {0} pet.", Convert.ToString(userData.petCount));
               for (int i = 0; i < userData.petCount; i++)
               {
                   Console.WriteLine($"\t {userData.petList[i]}");
               }
           }
           else
           {
               Console.WriteLine("\t You don't have any pet's.");
           }

           if (userData.colorCount == 0)
           {
               Console.WriteLine("\t You don't have favorite color.");
           }
           else
           {
               if (userData.colorCount == 1)
               {
                   Console.WriteLine("\t You favorite color is: {0}", userData.colorList[0]);
               }
               else
               {
                   Console.WriteLine("\t You favorite colors are: ");
                   for (int i = 1; i < userData.colorCount; i++)
                   {
                       Console.WriteLine($"\t\t - {userData.colorList[i]}");
                   }
               }
           }
       } 
    } 
} 