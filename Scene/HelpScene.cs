﻿/* HelpScene.cs
* Final project
* Revision History
* Zhiyuan Wu  , 2023.12.05: Created
* Zhiyuan Wu and Yijia Wang, 2023.12.10: Added code
* Zhiyuan Wu, 2023.12.10: Debugging complete
* Zhiyuan Wu, 2023.12.10: Comments added
*
*/
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolGame.Scene
{
    public class HelpScene : GameScene
    {
        private SpriteBatch sb;
        private Texture2D tex;


        public HelpScene(Game game) : base(game)
        {
            Game1 g = (Game1)game;
            sb = g._spriteBatch;
            tex = g.Content.Load<Texture2D>("Images/HelpScene");
        }

        public override void Draw(GameTime gameTime)
        {
            sb.Begin();
            sb.Draw(tex, Vector2.Zero, Color.White);
            sb.End();

            base.Draw(gameTime);
        }
    }
}
