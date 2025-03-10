using System;

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
        set { _name = value ?? throw new ArgumentException("Error: No name was informed\n") }
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
        Console.WriteLine("The creature died")
    }
}


class Player : Character
{
    public Player(int HP, int Attack, string Name) : base(HP, Attack, string Name) { }

    public override void Die()
    {
        Console.WriteLine("You died, stupid bitch\n");
    }
}

class Enemy : Character
{
    public Enemy(int HP, int Attack, string Name) : base(HP, Attack, string Name) { }
}

class Program
{
    static void Main()
    {

    }

    
}