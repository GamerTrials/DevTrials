using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTClicker {

    public class CLI {
        private IGameDevProject game;
        private long total;

        public CLI(IGameDevProject game) {
            this.game = game;
        }

        public string Input(string input, long deltaTime) {
       
            this.game = this.game.TimeLapse(deltaTime);
            if (input.Contains("m"))
                this.game = this.game.Associate(new Developer());
            else
                this.game = this.game.DevelopFeature();

            total += this.game.FeaturesGenerated;
            this.game = this.game.HarvestFeatures();
            return string.Format("Trial Pieces: {0}\nTrial Pieces por segundo: {1}",
                total,this.game.FeaturesGeneratedPerSec);
        }
    }

}
