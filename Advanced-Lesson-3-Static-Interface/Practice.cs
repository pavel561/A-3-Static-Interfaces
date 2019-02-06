using System;
using System.Drawing;

namespace Advanced_Lesson_3_Static_Interface
{
    public partial class Practice
    {
        /// <summary>
        /// AL3-P1/3. Создать класс UniqueItem c числовым полем Id. 
        /// Каждый раз, когда создается новый экземпляр данного класса, 
        /// его идентификатор должен увеличиваться на 1 относительно последнего созданного. 
        /// Приложение должно поддерживать возможность начать идентификаторы с любого числа. 
        /// </summary>
        public static void AL3_P1_3()
        {
			UniqueItem Item = new UniqueItem();
			UniqueItem Item2 = new UniqueItem();
			UniqueItem Item3 = new UniqueItem();
		}
		public class UniqueItem
		{
			//private static int? instanceCounter;
			public static int? Id;
			public UniqueItem(int id)
			{
				Id = id;
				//instanceCounter
			}
			public UniqueItem()
			{
				if(Id == null)
				{
					Id = 0;
				}
				else
				{
					Id++;
				}
			}
		}
        /// <summary>
        /// AL3-P2/3. Отредактировать консольное приложение Printer. 
        /// Заменить базовый абстрактный класс на интерфейс.
        /// </summary>
        public static void AL3_P2_3()
        {
			Console.WriteLine(" Choose print type: ");
			Console.WriteLine("1 - Console");
			Console.WriteLine("2 - File");
			Console.WriteLine("3 - Image");
			Console.Write(">> ");
			var type = Console.ReadLine();
			IPrinter printer = null;

			switch (type)
			{
				case "1":
					{
						printer = new ConsolePrinter(ConsoleColor.DarkBlue);
						//printer.Print();
						//Console.WriteLine("You have chosen printing into console");
						break;
					}
				case "2":
					{
						printer = new FilePrinter("PrintingText");
						//printer.Print();
						//Console.WriteLine("You have chosen printing into file");
						break;
					}
				case "3":
					{
						printer = new BitmapPrinter("testImage");
						//printer.Print(Console);
						//Console.WriteLine("You have chosen printing into image");
						break;
					}

			}
			Console.WriteLine("Write text");
			for (int i = 0; i < 1; i++)
			{
				Console.Write(">> ");
				printer.Print(Console.ReadLine());
				//printer.Print();
			}
		}
		public interface IPrinter
		{
			void Print(string str);
		}
		public class ConsolePrinter : IPrinter
		{
			public void Print(string str)
			{
				Console.ForegroundColor = _color;
				Console.WriteLine(str);
				Console.ResetColor();
			}
			public ConsolePrinter(ConsoleColor color)
			{
				_color = color;
			}
			private ConsoleColor _color;
		}
		public class FilePrinter : IPrinter
		{
			public void Print(string str)
			{
				//Console.ForegroundColor = _color;
				System.IO.File.AppendAllText($@"D:\{_fileName}.txt", str);
				Console.WriteLine(str);
				Console.ResetColor();
			}
			public FilePrinter(string fileName)
			{
				_fileName = fileName;
			}
			private string _fileName;
		}
		public class ImagePrinter : IPrinter
		{
			public void Print(string str)
			{
				Console.ForegroundColor = _color;
				Console.WriteLine(str);
				Console.ResetColor();
			}
			public ImagePrinter(string text, ConsoleColor color)
			{
				_color = color;
			}
			private ConsoleColor _color;
		}

		public class BitmapPrinter : IPrinter
		{
			public string FileName { get; }
			public void Print(string str)
			{
				Bitmap bitmap = new Bitmap(500, 300);
				Font drawFont = new Font("Arial", 16);
				SolidBrush drawBrush = new SolidBrush(Color.Black);
				float x = 10.0F;
				float y = 10.0F;
				StringFormat drawFormat = new StringFormat();
				drawFormat.FormatFlags = StringFormatFlags.DisplayFormatControl;
				Graphics graphics = Graphics.FromImage(bitmap);
				graphics.DrawString(str, drawFont, drawBrush, x, y, drawFormat);
				bitmap.Save($@"D:\{FileName}.png");
			}
			public BitmapPrinter(string fileName)
			{
				FileName = fileName;
			}
		}
		/// <summary>
		/// AL3-P3/3. Создайте обобщенный метод GuessType<T>(T item), 
		/// который будет принимать переменную обобщенного типа и выводить на консоль, 
		/// что это за тип был передан.
		/// </summary>
		public static void AL3_P3_3()
		{
			int tempInteger = 100500;
			string textString = "stringString";
			float tempFloat = 1.789F;
			DateTime dateTime = DateTime.Now;
			Car car = new Car();

			GuessType(tempInteger);
			GuessType(textString);
			GuessType(tempFloat);
			GuessType(dateTime);
			GuessType(car);
		}		
		public static void GuessType<T>(T item)
		{
			if(item is String)
			{
				string str = item.ToString();
				Console.WriteLine($"Вы ввели строку, длиной {str.Length} символа(-ов)");
			}
			else if(item is Int32)
			{
				Console.WriteLine($"Вы передали положительное целое число ");
			}
			else if(item is float)
			{
				Console.WriteLine($"Вы передали вещественное число с 5 значащими цифрами ");
			}
			else if(item is DateTime)
			{
				Console.WriteLine($"Вы передали время ");
			}
			else
			{
				Console.WriteLine("Понятия не имею, что вы мне передали =(");
			}
		}

    }    
}
