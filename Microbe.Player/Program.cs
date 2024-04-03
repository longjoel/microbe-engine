using Microsoft.Xna.Framework;

public class MicrobeGame : Game { 

    public MicrobeGame() {
        // Set up the game window
        var graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
    }

    protected override void Initialize() {
        base.Initialize();
    }

    protected override void LoadContent() {
    }

    protected override void UnloadContent() {
    }

    protected override void Update(GameTime gameTime) {
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime) {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        base.Draw(gameTime);
    }

}

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        using (var game = new MicrobeGame()) {
            game.Run();
        }
    }
}