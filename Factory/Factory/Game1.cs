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
using Factory.core;
using TomShane.Neoforce.Controls;

namespace Factory
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        //Neoforce Manager
        private Manager managerGUI;

        //botões
        Button btEncerrar;
        //
        Button btProx;//próxima estrutura
        Button btAnt;//estrutura anterior
        Button btInserir; //inserir estrutura

        Button btOrdenarAcima;
        Button btOrdenarAbaixo;

        GroupBox gbEstrutura;
        RadioButton rbArma;
        RadioButton rbMotor;
        RadioButton rbEstrutura;

        CheckBox cbFlipVertical;
        CheckBox cbFlipHorizontal;
        CheckBox cbAnimado;
        CheckBox cbXfixo;
        CheckBox cbYfixo;
        
        ShipComponent testComponent;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 1024;
            graphics.PreferredBackBufferHeight = 768;

            IsMouseVisible = true;
            managerGUI = new Manager(this, graphics); 
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            managerGUI.Initialize();

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            Texture2D tex = Content.Load<Texture2D>(@"structures/cockpit001");

            btEncerrar = new Button(managerGUI);
            btEncerrar.SetSize(100, 20);
            btEncerrar.SetPosition(600, 500);
            btEncerrar.Text = "Encerrar";
            managerGUI.Add(btEncerrar);

            gbEstrutura = new GroupBox(managerGUI);
            gbEstrutura.SetPosition(600, 10);
            gbEstrutura.SetSize(300, 500);
            gbEstrutura.Text = "Opções da Estrutura";
            managerGUI.Add(gbEstrutura);

            testComponent = new ShipComponent(this, tex);
            testComponent.Initialize();
            Components.Add(testComponent);

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || btEncerrar.Pushed)
                this.Exit();

            managerGUI.Update(gameTime);
            
            // TODO: Add your update logic here

            testComponent.Update(gameTime);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);


            managerGUI.BeginDraw(gameTime);
            managerGUI.Draw(gameTime);
            managerGUI.EndDraw();
            // TODO: Add your drawing code here
            testComponent.myDraw(gameTime, spriteBatch);

            base.Draw(gameTime);
        }
    }
}
