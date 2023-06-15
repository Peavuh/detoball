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
        bal_move();
        Seuraavakentta();
        
        
        
        
    }
    
    
    void LuoKentta(string kentta)
    {
        TileMap ruudut = TileMap.FromLevelAsset(kentta);
        
        
        Level.Background.Color = Color.Black;
        ruudut.SetTileMethod('P',the_ballmaker);
        ruudut.SetTileMethod('X',LuoSeina, Color.Gray);
        ruudut.SetTileMethod('M',Stylish_Finish, Color.Cyan);
        ruudut.SetTileMethod('Y', death_doritos, Color.Cyan);
        ruudut.Execute(42, 42);
        Camera.ZoomToLevel();
    }

    void Seuraavakentta()
    {
        ClearAll();
        bal_move();
        if (kenttaNro == 1) LuoKentta("kentta1.txt");
        else if (kenttaNro == 2) LuoKentta("kentta2.txt");
        else if (kenttaNro == 3) LuoKentta("kentta3");
        else if (kenttaNro == 4) LuoKentta("kentta4");
        else if (kenttaNro == 5) LuoKentta("kentta5");
        else if (kenttaNro > 5) Exit();
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
        ball.Hit(new Vector(0, 800));
        
        
        
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
        ball.Tag = "bal";
        Add(ball);
        
        
    }

    void Stylish_Finish(Vector paikka, double leveys, double korkeus, Color vari)
    {
        PhysicsObject finish = new PhysicsObject(30.0, 30.0);
        finish.Shape = Shape.Rectangle;
        finish.IgnoresExplosions = true;
        finish.IgnoresGravity = true;
        finish.Restitution = 0;
        finish.Position = paikka;
        finish.Color=Color.Cyan;
        finish.MakeStatic();
        AddCollisionHandler(finish, "bal", TormasiMaaliin);
        
        Add(finish);
        
    }

    void death_doritos(Vector paikka, double leveys, double korkeus, Color vari)
    {
        PhysicsObject spike = new PhysicsObject(30.0, 30.0);
        spike.Shape = Shape.Triangle;
        spike.IgnoresExplosions = true;
        spike.IgnoresGravity = true;
        spike.Restitution = 0;
        spike.Position = paikka;
        spike.Color = Color.Red;
        spike.MakeStatic();
        AddCollisionHandler(spike, "bal", death);
        Add(spike);
    }
    void TormasiMaaliin(PhysicsObject ball, PhysicsObject finish)
    {
        //Kasvatetaan kenttänumeroa yhdellä ja siirrytään seuraavaan kenttään:
        kenttaNro++;
        Seuraavakentta();
    }
    void death(PhysicsObject ball, PhysicsObject spike)
    {
        //Sama kenttä ladataan alusta jos kenttänumeroa ei kasvateta:
        Seuraavakentta();
        
    }

    void bal_move()
    {
        Keyboard.Listen(Key.J, ButtonState.Pressed, boom, "explode, but left");
        Gravity = new Vector(0.0, -981.0);
        Keyboard.Listen(Key.L, ButtonState.Pressed, kaboom, "explode, but right");
        Keyboard.Listen(Key.D, ButtonState.Down, right, null);
        Keyboard.Listen(Key.A, ButtonState.Down, left, null);
        Keyboard.Listen(Key.Escape, ButtonState.Pressed, ConfirmExit, "end game");
        Keyboard.Listen(Key.K, ButtonState.Pressed, kablooey, "explodes, but up");
        
        
        
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