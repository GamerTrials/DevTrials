using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTClicker {

    public class CLI {
        private IGame game;
        private long total;

        public CLI(IGame game) {
            this.game = game;
        }

        public string Input(string input, long deltaTime) {
       
            this.game = this.game.TimeLapse(deltaTime);
            if (input.Contains("m"))
                this.game = this.game.Associate(new Monkey());
            else
                this.game = this.game.MakeReport();

            total += this.game.TrialPiecesGenerated;
            this.game = this.game.HarvestTrialPieces();
            return string.Format("Trial Pieces: {0}\nTrial Pieces por segundo: {1}",
                total,this.game.TrialPiecesPerSec);
        }
    }

}
