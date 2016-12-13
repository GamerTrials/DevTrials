using System;

namespace GTClicker
{
	class MainClass
	{
		
		public static void Main (string[] args)
		{

			var game = new GameDevProject ();
			CLI cli = new CLI (game);

			for (;;) {
				var now = DateTime.UtcNow;
				var algo = Console.ReadLine ();
				var then = DateTime.UtcNow;
				var delta = then - now;

				var output = cli.Input (algo, (long)delta.TotalMilliseconds);


				Console.WriteLine (output);
		

			}
		}


	}
}
