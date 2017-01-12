namespace GTClicker {
    public interface IMarketPlace {
		IMarketPlace Sell (ISellableGame sellable);
		bool BuyDev ();
		long TotalMoney{ get;}
		long NextDevCost{ get;}

    }
}