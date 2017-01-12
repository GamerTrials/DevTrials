using System;

namespace GTClicker
{
	public class SellableGameAdapter: ISellableGame
	{
		IGameDevProject project;
		public SellableGameAdapter (IGameDevProject proj)
		{
			this.project = proj;
		}

		#region ISellableGame implementation

		public long GameSize {
			get {
				return this.project.FeaturesGenerated;
			}
		}

		#endregion
	}
}

