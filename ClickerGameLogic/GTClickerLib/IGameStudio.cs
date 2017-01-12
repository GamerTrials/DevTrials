using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GTClicker {
	
    public interface IGameStudio {

        IGameStudio AddDevToFreePool();

        IGameStudio Click(int index);

        IGameStudio TimeLapse(long deltaTime);

        IGameStudio Remove(int index);

		IGameStudio AddDevtoProject (int index);

		IGameDevProject GetGame (int index);

		long FreeDevPool { get;}
    }

}
