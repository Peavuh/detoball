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
  //  TileMap ruudut = TileMap.FromLevelAsset("kentta1");
    private int kenttaNro = 1;
    
        
        
        
    
    public override void Begin()
    {
        Seuraavakenttä();
        Keyboard.Listen(Key.J, ButtonState.Pressed, boom, "explode, but left");
        Gravity = new Vector(0.0, -981.0);
        Keyboard.Listen(Key.L, ButtonState.Pressed, kaboom, "explode, but right");
        Keyboard.Listen(Key.D, ButtonState.Down, right, null);
        Keyboard.Listen(Key.A, ButtonState.Down, left, null);
        Keyboard.Listen(Key.Escape, ButtonState.Pressed, ConfirmExit, "end game");
        Keyboard.Listen(Key.K, ButtonState.Pressed, kablooey, "explodes, but up");
        
        
        
    }
    
    
    void LuoKentta(string kentta)
    {
        TileMap ruudut = TileMap.FromLevelAsset(kentta);
        
        
        Level.Background.Color = Color.Black;
        ruudut.SetTileMethod('P',the_ballmaker );
        ruudut.SetTileMethod('X',LuoSeina, Color.Gray);
        ruudut.Execute();
        Camera.ZoomToLevel();
    }

    void Seuraavakenttä()
    {
        ClearAll();

        if (kenttaNro == 1) LuoKentta("kentta1.txt");
        else if (kenttaNro == 2) LuoKentta("kentta2");
        else if (kenttaNro == 3) LuoKentta("kentta3");
        else if (kenttaNro > 3) Exit();
        
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


    private void LuoSeina(Vector paikka, double leveys, double korkeus, Color vari)
    {
        PhysicsObject seina = new PhysicsObject(leveys-1, korkeus-2);
        seina.Position = paikka;
        seina.Color = vari;
        seina.Tag = "rakenne";
        seina.IgnoresExplosions=true;
        Add(seina);
        seina.IgnoresGravity = true;
        seina.MakeStatic();
        seina.Restitution = 1.0;
    }

    void the_ballmaker(Vector paikka, double leveys, double korkeus)
    {
        ball = new PhysicsObject(25.0, 25.0);
        ball.Shape = Shape.Circle;
        ball.Position = paikka;
        ball.Restitution = 0.5;
        
        Add(ball);
        
        
    }

 //      XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX   
 //      X                                 X  
 //      X                                 X 
 //      X                                 X  
 //      X                                 X  
 //      X                                 X 
 //      X                                 X  
 //      X                                 X   
 //      X                                 X   
 //      X                                 X  
 //      X                                 X  
 //      X                                 X  
 //      X                                 X  
 //      X                                 X  
 //      X                                 X  
 //      X                                 X  
 //      X                                 X  
 //      XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX  




















































}