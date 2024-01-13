enum Powers{
 enl,
 frozen,
 fasten;
 
 public static Powers getRandom() {return values()[(int) (Math.random() * values().length)];}
}

public class PowerUps{
  PImage sb;
  float lg =20;
  float alt = 20;
  float x;
  float y;
  float ySpeed=1;
  Powers pwr;
  float time;
  PowerUps(float ct){
    this.pwr = Powers.getRandom();
    //this.pwr = Powers.slim;
    x = random(0,width- lg);
    y = 0;
    time = ct;
  }
  
  
  void drawPwr(){
    update();
    
    color c=0;
    stroke(0);
    switch(pwr){
      case enl:
        sb= loadImage("enl.jpg"); 
        //c = color(100,200,100);
        break;
      case frozen:
        sb= loadImage("snowflake.jpg"); 
        //c = color(100, 200, 217);
        break;
      case fasten:
        sb= loadImage("bolt.jpg"); 
        //c = color(213, 159, 21);
        break;
     
    }
    fill(c);
    sb.resize((int)lg,(int)alt);
    image(sb,x,y);
  }
  
  
  void update(){
    y += ySpeed;
  }
  
  Powers getPWR(){
     return pwr;
  }
   
}
