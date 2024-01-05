/* Score.cs
* Final project
* Revision History
* Zhiyuan Wu  , 2023.12.08: Created
* Zhiyuan Wu , 2023.12.08: Added code
* Zhiyuan Wu, 2023.12.10: Debugging complete
* Zhiyuan Wu, 2023.12.10: Comments added
*
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolGame.Model
{
    /// <summary>
    /// Represents a player's score in the game.
    /// </summary>
    public class Score
	{
        /// <summary>
        /// Gets or sets the name of the player.
        /// </summary>
        public string PlayerName {  get; set; }

        /// <summary>
        /// Gets or sets the value of the score.
        /// </summary>
        public int Value { get; set; }

        /// <summary>
        /// Gets or sets the number of enemies destroyed by the player.
        /// </summary>
        public int NumberDestroyedEnemy { get; set; }

        /// <summary>
        /// Gets or sets the survival time of the player in the game.
        /// </summary>
        public float survivalTime { get; set; }

    }
}
