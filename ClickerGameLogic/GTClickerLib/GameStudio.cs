using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GTClicker {
    public class GameStudio {
        IGameDevProject theProject;

        public long Money { get; private set; }
        public long NextDevCost { get; private set; }
        public long MoneyPerSecond { get {return  theProject.FeaturesGeneratedPerSec; } }

        public GameStudio(Func<IGameDevProject> projectFactory) {
            this.theProject = projectFactory();
            this.Money = 30;
            this.NextDevCost = 30;
        }

        public GameStudio AddDev(int index) {
            if(Money >= NextDevCost) 
            {
                this.theProject = this.theProject.Associate(new Developer());
                Money -= NextDevCost;
                NextDevCost = (long)(NextDevCost * 1.11);
            }
            
            return this;
        }

        public GameStudio Click(int index) {
            this.theProject = this.theProject.DevelopFeature();
            return this;
        }

        public GameStudio TimeLapse(long deltaTime) {
            this.theProject = this.theProject.TimeLapse(deltaTime);
            this.Money += this.theProject.FeaturesGenerated;
            this.theProject = this.theProject.HarvestFeatures();
            return this;
        }
    }
}
