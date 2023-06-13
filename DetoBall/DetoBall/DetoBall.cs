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
    private static readonly String[] lines =
    {
        "        X  X  X         "};
        
        
        
        
    
    public override void Begin()
    {
        Keyboard.Listen(Key.J, ButtonState.Pressed, boom, "explode, but left");
        Gravity = new Vector(0.0, -981.0);
        Keyboard.Listen(Key.L, ButtonState.Pressed, kaboom, "explode, but right");
        LuoKentta();
        Keyboard.Listen(Key.D, ButtonState.Down, right, null);
        Keyboard.Listen(Key.A, ButtonState.Down, left, null);
        Keyboard.Listen(Key.Escape, ButtonState.Pressed, ConfirmExit, "end game");
        Keyboard.Listen(Key.K, ButtonState.Pressed, kablooey, "explodes, but up");
    }
    
    
    void LuoKentta()
    {
        ball = new PhysicsObject(25.0, 25.0);
        ball.Shape = Shape.Circle;
        ball.X = -200.0;
        ball.Y = -50;
        ball.Restitution = 0.5;
        
        Add(ball);
        
        Level.CreateBorders(1.0, false);
        Level.Background.Color = Color.Black;

        Camera.ZoomToLevel();
    }





    void kaboom()
    {
        ball.LinearDamping = 0;
        Explosion rajahdys = new Explosion(50);
        rajahdys.Position = ball.Position;
        Add(rajahdys);
        Timer.SingleShot(1.5, friction);
        rajahdys.Speed = 500.0;
        rajahdys.Force = 15.0;
        ball.IgnoresExplosions = true;
        ball.Hit(new Vector(750, 675));





    }

    void right()
    {
        ball.Push(new Vector(1000, 0));
        
        
        
        
    }

    void left()
    {
        ball.Push(new Vector(-1000, 0));
        
        
        
        
    }

    void boom()
    {
        ball.LinearDamping = 0;
        Explosion rajahdys = new Explosion(50);
        rajahdys.Position = ball.Position;
        Add(rajahdys);
        Timer.SingleShot(1.5, friction);
        rajahdys.Speed = 500.0;
        rajahdys.Force = 15.0;
        ball.IgnoresExplosions = true;
        ball.Hit(new Vector(-750, 675));
        
        
        
        
    }


    void kablooey()
    {
        ball.LinearDamping = 0;
        Explosion rajahdys = new Explosion(50);
        rajahdys.Position = ball.Position;
        Add(rajahdys);
        Timer.SingleShot(0.25, friction);
        rajahdys.Speed = 500.0;
        rajahdys.Force = 15.0;
        ball.IgnoresExplosions = true;
        ball.Hit(new Vector(0, 1000));
        
        
        
    }
    
    void friction()
    {
        ball.LinearDamping = 3.0;

    }






























































}