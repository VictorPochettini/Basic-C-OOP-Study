using System;
using System.IO;
using System.Collections.Generic;

class Globals
{
    public static Random random = new Random();
}

class Character
{
    protected float _hp;
    public float HP
    {
        get { return _hp; }
        set { _hp = value > 0 ? value : 1; }
    }
    protected float _attack;
    public float Attack 
    {
        get { return _attack; } 
        set { _attack = value > 0? value : 1; }
    }
    protected string _name;
    public string Name
    {
        get { return _name; } 
        set { _name = value ?? throw new ArgumentException("Error: No name was informed"); }
    }

    public Character(float HP, float Attack, string Name)
    {
        this.HP = HP;
        this.Attack = Attack;
        this.Name = Name;
    }

    public void TakeDamage(int Damage)
    {
        HP -= Damage;
    }

    public virtual void Die()
    {
        Console.WriteLine("The creature died");
    }

    public float CounterAttack(float attack1)
    {
        int ca = Globals.random.Next(1, 11);
        if(ca < 4)
        {
            Console.WriteLine("Counterattacked!");
            return Attack;
        }
        else
        {
            Console.WriteLine("Counterattack failed!");
            HP -= attack1;
            return 0;
        }
    }

    public bool Dodge()
    {
        int d = Globals.random.Next(1, 11);
        return d < 5;
    }
}

class Player : Character
{
    public Player(float HP, float Attack, string Name) : base(HP, Attack, Name) { }

    public override void Die()
    {
        Console.WriteLine("You died, stupid bitch");
    }

    public void Setting()
    {
       do
        {
            int total = 30;
            Console.WriteLine("You have 30 points to share to your HP and Attack");
            Console.WriteLine("How much HP do you want?");
            HP = float.Parse(Console.ReadLine());
            if (HP > 30 || HP < 0)
            {
                throw new ArgumentException("Error: Not enough points\n");
                continue;
            }
            Attack = total - HP;
            Console.WriteLine("HP: " + HP + "\nAttack: " + Attack);
            break;
        } while (true);
    }

    public void Attacks(Enemy enemy)
    {
        Console.WriteLine("You attack!");
        switch(enemy.Name)
        {
            case "Red Skeleton":
            RedSkeleton(enemy)
            break;
        }
    }

    public void RedSkeleton(Enemy enemy)
    {
        if(HP <= 20 && enemy.HP > Attack)
        {
            Console.WriteLine("Red Skeleton: If my counterattack succeeds, you die! MUAHAHAHA");
            HP -= enemy.CounterAttack(Attack);

            Console.WriteLine("Red Skeleton counterattacked!");
        }
        else
        {
            Console.WriteLine("Red Skeleton: I better not risk this time...");
            enemy.HP -= Attack;
            Console.WriteLine("Red Skeleton received " + Attack + "damage");
        }
    }

    public void FatZombie(Enemy enemy)
    {
        if(enemy.HP >= 15 && enemy.HP > Attack)
        {
            Console.WriteLine("Errr... You're cooked, and I want to eat...");
            HP -= enemy.CounterAttack(Attack);
        }
        else if(enemy.HP < 15 && enemy.HP > 10 && HP <= 10)
        {
            Console.WriteLine("Fat Zombie: Gurrr... I want a McBrain...");
            HP -= enemy.CounterAttack(Attack);
        }
        else if(enemy.HP < 15 && enemy.HP > 10 && (Attack * 1.5) < enemy.HP)
        {
            Console.WriteLine("Fat Zombie: Wharrr... Give me ozempic...");
            if(Dodge())
            {
                Console.WriteLine("Fat Zombie: Darrr... Fat people can also dodge...");
                continue;
            }
            else
            {
                enemy.HP -= (float)(Attack * 1.5);
                ("Fat Zombie received" + Attack * 1.5 + "damage");
            }
        }
        else if(enemy.HP < 10)
        {
            Console.WriteLine("Fat Zombie: Gerrr... Stop being fatfobic!");
            enemy.HP -= (float)(Attack);
            ("Fat Zombie received" + Attack + "damage");
        }
    }

    public void Corrupted Soldier(Enemy enemy)
    {
        if(enemy.HP>10 && Attack < (enemy.HP*(3/4)))
        {
            Console.WriteLine("Corrupted Soldier: Why are you doing this?");
            HP -= enemy.CounterAttack(Attack);
        }
        else if(HP>5 && HP<10 && Attack < (enemy.HP*2))
        {
            Console.WriteLine("Corrupted Soldier: Please, don't do this. I have family. You don't even know me");
            if(Dodge())
            {
                Console.WriteLine("Corrupted Soldier: I don't understand why you are doing this. Please, stop! I don't want to fight");
                continue;
            }
            else
            {
                enemy.HP -= (float)(Attack * 1.5);
                ("Corrupted Soldier received" + Attack * 1.5 + "damage");
            }
        }
        else if(HP<5)
        {
            Console.WriteLine("Little Daughter: Dad? Dad! Why are you so injured? Why are they doing this to you!?");
            if(Dodge())
            {
                Console.WriteLine("Corrupted Soldier: I don't know! But don't worry! I'll beat them and we'll go to that waterfall you always wanted to see!");
                continue;
            }
            else
            {
                enemy.HP -= (float)(Attack * 1.5);
                ("Corrupted Soldier received" + Attack * 1.5 + "damage");
            }
        }
    }
}

class Enemy : Character
{
    public Enemy(float HP, float Attack, string Name) : base(HP, Attack, Name) { }

    public void Attacks(Player player)
    {
        Console.WriteLine(Name + " attacks!");
        Console.WriteLine("What will you do");
        Console.WriteLine("\n(1) Counter Attack [30% Chance]\n(2) Dodge [40% Chance][150% of normal damage if fails]\n (3) Nothing\n");

        int option = int.Parse(Console.ReadLine());
        switch(option)
        {
            case 1:
                HP -= player.CounterAttack(Attack);
                break;

            case 2:    
                if(Dodge())
                {
                    Console.WriteLine("You dodged!");
                    break;
                }
                else
                {
                    Console.WriteLine("Dodge failed!");
                    Console.WriteLine("You received " + 1.5 * Attack + " damage!");
                    player.HP -= (float)(1.5 * Attack);
                    break;
                }

            case 3:
                player.HP -= Attack;
                Console.WriteLine("You received " + Attack + " damage!");
                break;

            default:
                throw new ArgumentException("Error: Option doesn't exist\n");
                break;
        }
    }
}

class Program
{
    static void Main()
    {   
        int input;
        do
        {
            Console.WriteLine("Welcome to THE Fighting Game");
            Console.WriteLine("\n(1)Play\n(2)Leave\n");

            input = int.Parse(Console.ReadLine());

            switch(input)
            {
                case 1:
                    StartGame();
                    break;

                case 2:
                    break;
            }
        } while( input != 2 );
    }

    static void StartGame()
    {
        Player player = new Player(0, 0, null);
        player.Setting();

        Console.Write("\n\nYour opponent will be: ");

        int opponent = Globals.random.Next(1, 4);

        Enemy enemy = null;
        switch(opponent)
        {
            case 1:
                enemy = new Enemy(10, 20, "Red Skeleton");
                break;

            case 2:
                enemy = new Enemy(27, 7, "Fat Zombie");
                break;

            case 3:
                enemy = new Enemy(15, 15, "Corrupted Soldier");
                break;

            default:
                throw new ArgumentException("Error: Random function didn't work");
        }

        Console.WriteLine(enemy.Name);
        Console.WriteLine("\nYou're fighting!");
        
        int beginner = Globals.random.Next(1,3);
        switch(beginner)
        {
            case 1:
                Console.WriteLine("You begin!");
                while(player.HP > 0 && enemy.HP > 0)
                {
                    enemy.Attacks(player);
                    Display(player, enemy);
                }
                break;

            case 2:
                Console.WriteLine(enemy.Name + " begins!\n");
                while(player.HP > 0 && enemy.HP > 0)
                {
                    enemy.Attacks(player);
                    Display(player, enemy);
                }
                break;
        }            
    } 

    public static void Display(Player player, Enemy enemy)
    {
        Console.WriteLine("HP: " + player.HP);
        Console.WriteLine("Attack: " + player.Attack);
        Console.WriteLine("E. HP:" + enemy.HP);
        Console.WriteLine("E. Attack: " + enemy.Attack + "\n");
    }        
}