using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GTClicker {
	public class MarketPlace : IMarketPlace {

		public long NextDevCost { get; private set; }

		public MarketPlace()
		{
			NextDevCost = 30; 
		}

		public IMarketPlace Sell(ISellableGame sellable)
		{
			this.TotalMoney += sellable.GameSize;
		
			return this;
		}

		public bool BuyDev()
		{
			if (TotalMoney >= NextDevCost) 
			{
				TotalMoney -= NextDevCost;
				NextDevCost = (long)(NextDevCost * 1.11);
				return true;
			}

			return false;
		}

		public long TotalMoney {
			get;
			private set;
		}
    }
}
