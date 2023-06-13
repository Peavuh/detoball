using System;
using System.Collections.Generic;
using Jypeli;
using Jypeli.Assets;
using Jypeli.Controls;
using Jypeli.Widgets;

namespace DetoBall;

public class DetoBall : PhysicsGame
{
    private PhysicsObject ball;
    public override void Begin()
    {
        //make the ball explode yes yes
        LuoKentta();

        
        Keyboard.Listen(Key.Escape, ButtonState.Pressed, ConfirmExit, "end game");
    }
    
    
    void LuoKentta()
    {
        ball = new PhysicsObject(40.0, 40.0);
        ball.Shape = Shape.Circle;
        ball.X = -200.0;
        ball.Y = -50;
        ball.Restitution = 1.0;
        Add(ball);

        Level.CreateBorders(1.0, false);
        Level.Background.Color = Color.Black;

        Camera.ZoomToLevel();
    }
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
}