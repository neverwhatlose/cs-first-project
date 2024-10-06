// Селчук Эмин Абдулкеримович БПИ249 Проект: основная задача
namespace ConsoleApp1;
/// <summary>
/// Главный класс программы, в котором решается задача
/// </summary>
    public static class Program
    {
        /// <summary>
        /// Основной метод программы и ее точка входа
        /// </summary>
        public static void Main()
        {
            //Указание директории хранения input.txt и output.txt
            string path = Directory.GetCurrentDirectory().Substring(0, Directory.GetCurrentDirectory().LastIndexOf("ConsoleApp1"));
            //Переменная, используемая для хранения информации о нажатой кнопки
            ConsoleKeyInfo key;

            do
            {
                //Для более приятного отображения информации в консоль выводится пустая строка
                Console.WriteLine();

                try
                {
                    string[] file = File.ReadAllLines(path + "input.txt");

                    //Поскольку известно, что существует 2 строки, создается 2 массива
                    int[] firstArray = LineToArray(file[0]);
                    int[] secondArray = LineToArray(file[1]);

                    //Перевод результата (ответа) к строке для дальнейшего использования
                    string result = CountComposition(firstArray, secondArray).ToString();
                    WriteResult(path, result);
                    Console.WriteLine("Result has been succesfully written to output.txt");

                }
                //Обработчик на случай, если input.txt отсутствует в path
                catch (FileNotFoundException)
                {
                    Console.WriteLine("input.txt is missing!");
                }
                //см. документацию класса
                catch (WrongInputValueException ex)
                {
                    Console.WriteLine(ex.GetMessage());
                }
                //см. документацию класса
                catch (DifferentLengthException ex)
                {
                    Console.WriteLine(ex.GetMessage());
                }
                //Обработчик переполнения результирующей суммы
                catch (OverflowException)
                {
                    Console.WriteLine("Numeric value of result is too large, change input.txt");
                }

                Console.WriteLine("\nPress Q to end the program or any other button to repeat");
                key = Console.ReadKey();
                //Программа будет работать до тех пор, пока пользователь не нажмет Q (q)
            } while (key.Key != ConsoleKey.Q);
        }

        /**
         * <summary>
         * Приводит переданную строку к массиву типа int,
         * исключая неверно введенные данные
         * </summary>
         * <param name="line">
         * Строка для приведения
         * </param>
         * <returns>
         * Массив int[], содержащий отфильтрованный набор данных
         * </returns>
         * <exception cref="WrongInputValueException">
         * Введенное число вызывает переполнение типа или является некорректным
         * </exception>
         */
        private static int[] LineToArray(string line)
        {
            //Переменная для промежуточного хранения отфильтрованной строки
            string checkedLine = "";
            //Переменная для хранения числовых значений превышающих максимальный размер int
            string wrongElements = "";
            
            //Поочередная проверка введенных данных
            foreach (string element in line.Split(" "))
            {
                if (int.TryParse(element, out int result))
                {
                    checkedLine += result + " ";
                }
                
                //Блок используется для определения того, чтобы понять
                // числовое значение превышает максимально допустимое int-ом или
                // это просто некорректно введенное значение (не число)
                else
                {
                    //Пропускаем пустые элементы
                    if (element.Length == 0) continue;
                    
                    //Основой идеи проверки является ПРЕДПОЛОЖЕНИЕ, что пользователь
                    // ввел слишком большое число. Полная проверка элемента 
                    // нецелесообразна ввиду того, что это займет много ресурсов 
                    // (напомню, проверяется КАЖДЫЙ элемент введеных данных
                    char[] correctChars = { '-', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
                    char[] elementChars = element.ToCharArray();
                    if (correctChars.Contains(elementChars[0]))
                    {
                        wrongElements += $"{element} ";
                    }
                }
            }
            
            //Проверка на то, что существуют неверные числовые значения
            if (wrongElements.Length != 0)
                throw new WrongInputValueException($"Provided element(s): {wrongElements}are incorrect! Numeric value of the entered data is too large or it is not a number!");
            
            string[] array = checkedLine.TrimEnd().Split(" ");
            //Возвращаемый массив
            int[] returnArray = new int[array.Length];

            for (int i = 0; i < returnArray.Length; i++)
            {
                //Используется Parse, поскольку мы точно знаем, что остались
                // корректные числа
                returnArray[i] = int.Parse(array[i]);
            }

            return returnArray;
        }
        
        /// <summary>
        /// Записывает полученный результат работы программы в output.txt
        /// </summary>
        /// <param name="path">
        /// Директория для хранения output.txt
        /// </param>
        /// <param name="result">
        /// Полученный результат, записываемый в output.txt
        /// </param>
        private static void WriteResult(string path, string result)
        {
            File.WriteAllText(path + "output.txt", result);
        }
        
        /// <summary>
        /// Обрабатывает полученные массивы, считая скалярное произведение
        /// </summary>
        /// <param name="firstArr">
        /// Любая строка
        /// </param>
        /// <param name="secondArr">
        /// Любая строка
        /// </param>
        /// <returns>
        /// Скалярное произведение двух строк (массивов)
        /// </returns>
        /// <exception cref="DifferentLengthException">
        /// Длина двух строк (массивов) отличается
        /// </exception>
        private static int CountComposition(int[] firstArr, int[] secondArr)
        {
            int sum = 0;
            if (firstArr.Length != secondArr.Length)
                throw new DifferentLengthException("Provided arrays have different length");
            
            for (int i = 0; i < firstArr.Length; i++)
            {   
                //Проверка на то, что результат не вызывает переполнения sum
                sum = checked(sum + firstArr[i] * secondArr[i]);
            }

            return sum;
        }
        
        /// <summary>
        /// Внутренний (локальный) класс-исключение, означающий разную длину введенных строк (массивов)
        /// </summary>
        /// <param name="message">
        /// Сообщение исключения
        /// </param>
        private class DifferentLengthException(string message) : Exception
        {
            //Геттер на сообщение исключения
            public string GetMessage()
            {
                return message;
            }
        }
        
        /// <summary>
        /// Внутренний (локальный) класс-исключение, означающий неверно введенное число
        /// </summary>
        /// <param name="message">
        /// Сообщение исключения
        /// </param>
        private class WrongInputValueException(string message) : Exception
        {
            //Геттер на сообщение исключения
            public string GetMessage()
            {
                return message;
            }
        }
    }
