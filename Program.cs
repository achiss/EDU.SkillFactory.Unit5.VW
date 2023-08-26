 
// Refactoring from: https://github.com/achiss/Unut5_result.git 

 
namespace Unit5.refactoring                                                                                             // Подчёркивается, почему?
{ 
    class Program
    {
        private static (string Name, string Surname, int Age, bool isPet, int petCount, string[] petList,
            int colorCount, string[] colorList) userData;
        
        static void Main(string[] args)
        {
           GetUserDataFromConsole(out userData.Name, out userData.Surname, out userData.Age);                           // Пример: out
           PetUserData(ref userData.isPet, ref userData.petCount, ref userData.petList);                                // Пример: ref
           ColorUserData(ref userData.colorCount, ref userData.colorList);                                              //
           
           ShowUserData(in (string Name, string Surname, int Age, bool isPet, int petCount, string[] petList,
               int colorCount, string[] colorList) userData);
           
           Console.ReadKey(); 
        } 
 
        // Получение данных из консоли (проверка: null, пустая строка, строка состоящая из символов разделителей) 
        static string GetDataFromConsole() 
        { 
            string receivedData = Console.ReadLine(); 
            if (string.IsNullOrWhiteSpace(receivedData))                                                                //
            { 
                ShowMessage(); 
                return GetDataFromConsole(); 
            } 
 
            return receivedData; 
        } 
 
        // Проверка полученных данных из консоли (проверка: на цифры и специальные символы) 
        static string CharacterIdentification() 
        { 
            string characterString = GetDataFromConsole(); 
            bool containSpecialChars = characterString.Any(char.IsLetterOrDigit);                                       // Необходимость текущих строк? 
            bool containNumbers = characterString.Any(char.IsDigit);                                                    //  
            
           if ((containSpecialChars == false) && (containNumbers == true))                                              // Почему IDE не подсвечивает true? 
            { 
                ShowMessage(); 
                return CharacterIdentification(); 
            } 
 
            return characterString; 
        } 
 
        //  Проверка полученных данных из консоли (проверка: введено число) 
        static int NumberIdentification() 
        { 
            string receivedData = GetDataFromConsole(); 
            int receivedNumber; 
             
           if (int.TryParse(receivedData, out receivedNumber)) 
            { 
                return receivedNumber; 
            } 
            else 
            { 
                ShowMessage(); 
                NumberIdentification(); 
            } 
 
            return receivedNumber; 
        } 
 
        // Проверка полученных данных из консоли (проверка: введённое число больше 0) 
        static int CheckNumber(int receivedNumber) 
        { 
            if (receivedNumber < 0) 
            { 
                ShowMessage(); 
                return NumberIdentification(); 
            } 
            else                                                                                                        // не выделяет IDE
            { 
                if (receivedNumber == 0) 
                { 
                    ShowMessage(); 
                    return NumberIdentification(); 
                } 
                else                                                                                                    // не выделяет IDE
                { 
                    return receivedNumber; 
                } 
            } 
        }
        
        // Метод выводит сообщение об ошибке если введены не корректные значения
       static void ShowMessage() 
        { 
            Console.WriteLine("\t The data is not correct."); 
            Console.Write("\t Please, enter the data again: "); 
        }

       static void GetUserDataFromConsole(out string userName, out string userSurname, out int userAge)
        { 
            Console.Write("\n"); 
             
            Console.Write("\t Input your name (only letters): "); 
            userName = CharacterIdentification(); 
             
            Console.Write("\t Input your surname (only letters): "); 
            userSurname = CharacterIdentification(); 
             
            Console.Write("\t Input your full agе (only numbers): "); 
            userAge = CheckNumber(NumberIdentification());
        }
       
       static void PetUserData(ref bool userIsPet, ref int userPetCount, ref string[] userPetList)
       {
           Console.Write("\t Do yo have any pets (only letters, yes(y) or no(n): "); 
           
           
       }
       
       static void ColorUserData(ref (int ColorCount, string[] ColorList) UserData)
       {
           
       }
         
       static void ShowUserData(in (string Name, string Surname, int Age, bool isPet, int PetCount, string[] PetList, 
           int
           ColorCount, string[] ColorList) UserData) 
       {
       } 
    } 
} 