# Alpong

## A small C# Godot Project

A first look at making a game with Godot and C#.

This game is a pong/bricks breaker - like but where you can add more than one player (up to 4 players). Balls appear sometimes and with your paddle you have to kick them away from your side. If a ball hit your side, you loose a life. There is no ending or scoring. You can play as long as you are alive. Also, IA are just random moves along their sides.

## Configuration

Follow Godot official documentation to use C# in Godot and import the project inside Godot.

## Adding IA or Human players

To add IA or Player (or to change your side), you must go directly to the code in the file located at "./src/Scripts/Main.cs". You'll find a function called "NewGame()".

```csharp
private void NewGame()
    {
        this.AddPlayer(Constants.Side.BOTTOM, new Human());
        // this.AddPlayer(Constants.Side.TOP, new Computer());
        this.AddBall();
        this.StartBallSpawner();
        GetNode<AudioStreamPlayer>("Music").Play();
    }
```

For example, uncomment the line to add an IA at the top. You can also change your side or adding a new player but if you do so, the new player can not be at the opposite side of your. The bottom player, as the top player, use left and right arrows to move and no implementation has been made so far to modify this.

With 2 humans players and 1 IA player :

```csharp
private void NewGame()
    {
        // will use left and right arrows
        this.AddPlayer(Constants.Side.BOTTOM, new Human());
        // will use top and bottom arrows
        this.AddPlayer(Constants.Side.LEFT, new Human());

        this.AddPlayer(Constants.Side.RIGHT, new Computer());

        this.AddBall();
        this.StartBallSpawner();
        GetNode<AudioStreamPlayer>("Music").Play();
    }
```

Another valid configuration for 2 players :

```csharp
private void NewGame()
    {
        // will use left and right arrows
        this.AddPlayer(Constants.Side.TOP, new Human());
        // will use top and bottom arrows
        this.AddPlayer(Constants.Side.RIGHT, new Human());

        this.AddPlayer(Constants.Side.BOTTOM, new Computer());

        this.AddBall();
        this.StartBallSpawner();
        GetNode<AudioStreamPlayer>("Music").Play();
    }
```

## Art

All the (beautiful) graphics assets and sounds have been made by me. You can reuse it freely. Keep in mind that I'm a programmer first :P

## License

This program is under GNU GPL v3 which generally means that you can use it freely for wathever you want (including commercial use) as long as your implementation is also under this license and the source code must be open-source.