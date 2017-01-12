using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GTClicker {
    interface IGameDevCompany {

		void HireDev ();

		void TimeLapse (long deltaTime);

		long Money { get;}

		long FreeDevs{ get;}

		long NextDevCost{ get;}

		void HelpDevGame(int index);

		void SellGame (int index);

		void AssociateADev(int index);

        IGameDevProject GetProject(int index);


    }


}
