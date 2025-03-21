using System;
using System.IO;
using System.Collections.Generic;

class Globals
{
    public static Random random = new Random();
}

class Character
{
    protected int _hp;
    public int HP
    {
        get { return _hp; }
        set { _hp = value > 0 ? value : 1; } // Ensure HP is always at least 1
    }
    protected int _attack;
    public int Attack 
    {
        get { return _attack; } 
        set { _attack = value > 0? value : 1; }
    }
    protected string _name;
    public string Name
    {
        get { return _name; } 
        set { _name = value ?? throw new ArgumentException("Error: No name was informed\n"); }
    }

    public Character(int HP, int Attack, string Name)
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

    public int CounterAttack(int attack1)
    {
        int ca = Globals.random.Next(1, 11);
        if(ca < 4)
        {
            Console.WriteLine("You counterattacked!\n")
            return Attack;
        }
        else
        {
            Console.WriteLine("You failed counterattacking!\n")
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
    public Player(int HP, int Attack, string Name) : base(HP, Attack, Name) { }

    public override void Die()
    {
        Console.WriteLine("You died, stupid bitch\n");
    }

    public void Setting()
    {
       do
        {
            int total = 30;
            Console.WriteLine("You have 30 points to share to your HP and Attack\n");
            Console.WriteLine("How much HP do you want?\n");
            HP = int.Parse(Console.ReadLine());
            if (HP > 30 || HP < 0)
            {
                Console.WriteLine("Error: Not enough points\n");
                continue;
            }
            Attack = total - HP;
            Console.WriteLine("HP: " + HP + "\nAttack: " + Attack);
            break;
        } while (true);
    }

    public void Attacks(Enemy enemy)
    {
        Console.WriteLine("You attack!\n");
        
    }
}

class Enemy : Character
{
    public Enemy(int HP, int Attack, string Name) : base(HP, Attack, Name) { }

    public void Attacks(Player player)
    {
                Console.WriteLine(Name + " attacks!\n");
                Console.WriteLine("What will you do\n");
                Console.WriteLine("\n(1) Counter Attack [30% Chance]\n(2) Dodge [40% Chance]\n (3) Nothing\n\n");

                int option = int.Parse(Console.ReadLine());
                switch(option)
                {
                    case 1:
                    HP -= player.CounterAttack(Attack);
                    break;

                    case 2:    
                    if(Dodge())
                    {
                        Console.WriteLine("You dodged!\n");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Dodge failed!\n";)
                        Console.WriteLine("You received " + Attack + " damage!\n");
                        player.HP -= Attack;
                        break;
                    }

                    case 3:
                    player.HP -= Attack;
                    Console.WriteLine("You received " + Attack + " damage!\n");
                    break;

                    default:
                    Console.WriteLine("Error: Option doesn't exist\n");
                    break;
                }
    }
}

class Program
{
    static void Main()
    {   do
        {
            Console.WriteLine("Welcome to THE Fighting Game");
            Console.WriteLine("\n(1)Play\n(2)Leave\n");

            int input = int.Parse(Console.ReadLine());

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
        player.Setting(player.HP, player.Attack);

        Console.WriteLine("\n\nYour oponent will be: ");

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
            break;
        }

        Console.WriteLine("\nYou're fighting!\n");
        
        int beginner = Globals.random.Next(1,3);
        switch(beginner)
        {
                case 1:
                Console.WriteLine("You begin!\n");
                while(player.HP > 0 && enemy.HP > 0)
                {
                    enemy.Attacks(player);
                    Display(player, enemy);
                }
                break;

                case 2:
                Console.WriteLine(enemy.Name + " begins!\n\n");
                while(player.HP > 0 && enemy.HP > 0)
                {
                    enemy.Attacks(player);
                    Display(player, enemy);
                }
                break;
        }            
    } 

    public void Display(Player player, Enemy enemy)
    {
        Console.WriteLine("HP: " + player.HP + "\n");
        Console.WriteLine("Attack: " + player.HP + "\n");
        Console.WriteLine("E. HP:" + enemy.HP + "\n");
        Console.WriteLine("E. Attack: " + enemy.HP + "\n\n");
    }        
}

//Ainda tenho que implementar o ataque do player, onde os monstros tem as mesmas opções; um displayer de HP e ataque no começo do turno;