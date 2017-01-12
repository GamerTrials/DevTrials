using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GTClicker {
	public class GameStudio : IGameStudio {
        IGameDevProject theProject { get; set; }
		Func<IGameDevProject> projectFactory;

        public long NextDevCost { get; private set; }
        public long MoneyPerSecond { get {return  theProject.FeaturesGeneratedPerSec; } }

		public long FreeDevPool {
			get;
			private set;
		}

		public GameStudio(Func<IGameDevProject> projectFactory) {
            this.theProject = projectFactory();
			this.projectFactory = projectFactory;
            this.NextDevCost = 30;

        }

        public GameStudio(Func<IGameDevProject> projectFactory, long currency) {
            this.theProject = projectFactory();
			this.projectFactory = projectFactory;
            this.NextDevCost = 30;
        }

        public IGameStudio AddDevToFreePool() {
        
			FreeDevPool++;
           
         
            return this;
        }

		public IGameStudio Click(int index) {
            this.theProject = this.theProject.DevelopFeature();
            return this;
        }

		public IGameStudio TimeLapse(long deltaTime) {
            this.theProject = this.theProject.TimeLapse(deltaTime);
            return this;
        }

		public IGameStudio Remove(int index) {
			FreeDevPool = this.theProject.FeaturesGeneratedPerSec;
			this.theProject = this.projectFactory ();
            return this;
        }
    	
		public IGameStudio AddDevtoProject(int index){

			if (FreeDevPool > 0) 
			{
				IDeveloper dev = new Developer ();
				this.theProject = this.theProject.Associate (dev);
				FreeDevPool--;
			}

			return this;
		}

		public IGameDevProject GetGame (int index)
		{
			return this.theProject;
		}
	}

}
