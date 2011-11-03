using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace Factory.core
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class SpriteComponent : Microsoft.Xna.Framework.DrawableGameComponent
    {
        public Texture2D textura;
        public List<Rectangle> Frames;
        public Int16 quadroAtual = 0;
        public Game game;

        public SpriteComponent(Game game, Texture2D textura)
            : base(game)
        {
            this.game = game;
            this.textura = textura;
            Frames = new List<Rectangle>();
            for(int i = 0; i<4;i++){
                Rectangle frame = new Rectangle((textura.Width / 4) * i, 0, (textura.Width / 4), textura.Height);
                Frames.Add(frame);
            }
            // TODO: Construct any child components here
        }

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {
            // TODO: Add your initialization code here

            base.Initialize();
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            // TODO: Add your update code here
            //Frames[quadroAtual];


            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}
