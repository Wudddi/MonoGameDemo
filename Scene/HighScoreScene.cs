/* HighScoreScene.cs
* Final project
* Revision History
* Zhiyuan Wu, 2023.12.09: Created
* Zhiyuan Wu, 2023.12.09: Added code
* Zhiyuan Wu, 2023.12.10: Debugging complete
* Zhiyuan Wu, 2023.12.10: Comments added
*
*/
using CoolGame.Controls;
using CoolGame.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct2D1;
using System;
using System.Linq;

namespace CoolGame.Scene
{
    /// <summary>
    /// Represents the high score scene in the game, displaying the top scores across various categories.
    /// </summary>
    public class HighScoreScene: GameScene
	{
		private GraphicsDeviceManager graphics;
		private SpriteFont _font;
		private ScoreManager _scoreManager;
		private Microsoft.Xna.Framework.Graphics.SpriteBatch sb;
		private Game1 g;
        private const float StartPositionX = 80f;
        private const float StartPositionY = 100f;
        /// <summary>
        /// Initializes a new instance of the HighScoreScene class.
        /// </summary>
        /// <param name="game">The game object this scene is associated with.</param>
        public HighScoreScene(Game game) : base(game)
		{

			g = (Game1)game;
			this.sb = g._spriteBatch;
			this.graphics = g._graphics;
			_scoreManager = ScoreManager.Load();
			_font = g.Content.Load<SpriteFont>("Fonts/Font");
		}
        /// <summary>
        /// Updates the high score scene. It is called once per frame.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
		{   
			base.Update(gameTime);
            _scoreManager = ScoreManager.Load();
        }
        /// <summary>
        /// Draws the high score scene, including the top scores in various categories.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values, used for frame-based animation.</param>
        public override void Draw(GameTime gameTime)
		{
			sb.Begin();

            sb.Draw(g.startScene.StartMenutex, Vector2.Zero, Color.White);

            var topScoresByValue = _scoreManager.Highscores;
            var topScoresByEnemy = _scoreManager.GetTopFiveByNumberDestroyedEnemy();
            var topScoresByTime = _scoreManager.GetTopFiveBySurvivalTime();

            string levelText = "Top Rankings";
            Vector2 levelTextSize = _font.MeasureString(levelText);
            Vector2 levelTextPosition = new Vector2(
                (GraphicsDevice.Viewport.Width - levelTextSize.X) / 2,
                10
            );
            sb.DrawString(_font, levelText, levelTextPosition, Color.Black);

            // Screen dimensions
            int screenWidth = 800;

            // Define the leaderboard titles
            string topScoresTitle = "Top Scores:";
            string topEnemiesTitle = "Top Enemies Destroyed:";
            string topTimesTitle = "Top Survival Times:";

            // Measure the text size of each leaderboard title
            var sizeTopScoresTitle = _font.MeasureString(topScoresTitle);
            var sizeTopEnemiesTitle = _font.MeasureString(topEnemiesTitle);
            var sizeTopTimesTitle = _font.MeasureString(topTimesTitle);

            // Calculate positions for each leaderboard title
            Vector2 positionTopScoresTitle = new Vector2(screenWidth / 6 - sizeTopScoresTitle.X / 2, StartPositionY);
            Vector2 positionTopEnemiesTitle = new Vector2(screenWidth / 2 - sizeTopEnemiesTitle.X / 2, StartPositionY);
            Vector2 positionTopTimesTitle = new Vector2(5 * screenWidth / 6 - sizeTopTimesTitle.X / 2, StartPositionY);

            // Draw leaderboard titles
            sb.DrawString(_font, topScoresTitle, positionTopScoresTitle, Color.Black);
            sb.DrawString(_font, topEnemiesTitle, positionTopEnemiesTitle, Color.Black);
            sb.DrawString(_font, topTimesTitle, positionTopTimesTitle, Color.Black);

            // Calculate positions for each leaderboard based on title positions
            Vector2 positionTopScores = new Vector2(positionTopScoresTitle.X, positionTopScoresTitle.Y + sizeTopScoresTitle.Y);
            Vector2 positionTopEnemies = new Vector2(positionTopEnemiesTitle.X + sizeTopEnemiesTitle.X / 2-33, positionTopEnemiesTitle.Y + sizeTopEnemiesTitle.Y);
            Vector2 positionTopTimes = new Vector2(positionTopTimesTitle.X, positionTopTimesTitle.Y + sizeTopTimesTitle.Y);

            // Draw the leaderboards
            sb.DrawString(_font, string.Join("\n", topScoresByValue.Select(c => c.PlayerName + " : " + c.Value)), positionTopScores, Color.Red);
            sb.DrawString(_font, string.Join("\n", topScoresByEnemy.Select(c => c.PlayerName + " : " + c.NumberDestroyedEnemy)), positionTopEnemies, Color.Red);
            sb.DrawString(_font, string.Join("\n", topScoresByTime.Select(c => c.PlayerName + " : " + c.survivalTime.ToString("0.00") + " sec")), positionTopTimes, Color.Red);



            sb.End();
			base.Draw(gameTime);
		}
	}
}
