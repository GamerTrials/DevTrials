using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GTClicker {
	public class GameDevCompany : IGameDevCompany {
		
		IMarketPlace MarketPlace { get;  set; }
        IGameStudio GameStudio { get; set; }

        public GameDevCompany(IMarketPlace market, IGameStudio studio) {
            this.MarketPlace = market;
            this.GameStudio = studio;
        }


		#region IGameDevCompany implementation

		public long NextDevCost {
			get {
				return MarketPlace.NextDevCost;
			}
		}

		public void HireDev ()
		{
			if (MarketPlace.BuyDev ())
			{
				this.GameStudio.AddDevToFreePool ();
			}
		}

		public void TimeLapse (long deltaTime)
		{
			GameStudio = GameStudio.TimeLapse (deltaTime);
		}

		public void HelpDevGame (int index)
		{
			GameStudio = GameStudio.Click (index);
		}

		public void SellGame (int index)
		{
			var game = GameStudio.GetGame (0);
			MarketPlace.Sell (new SellableGameAdapter (game));
			GameStudio.Remove (0);
		}

		public void AssociateADev (int index)
		{
			GameStudio = GameStudio.AddDevtoProject (index);
		}

        public IGameDevProject GetProject(int index) {
            return GameStudio.GetGame(0);
        }

        public long Money {
			get {
				return MarketPlace.TotalMoney;
			}
		}

		public long FreeDevs {
			get {
				return GameStudio.FreeDevPool;
			}
		}
		#endregion
    }
}
