public interface IDamageable { 
 void TakeDamage (int amount);
 bool IsDestroyed{get;}
 }



public class Character : IDamageable
{
    public string Name{get; set;}
    public int Health{get; set;}
    public int Level{get; set;}
    public int BaseAttack{get; set;}
    public int Armor{get; set;}
    public Character(string name, int health, int level, int baseAttack, int armor){
        Name = name;
        Health = health;
        Level = level;
        BaseAttack = baseAttack;
        Armor = armor;
        }
        public  void TakeDamage(int amount){
            Health -= amount;
            Console.WriteLine($"персонажу нанесли {amount}  урона ");
        }
        public bool IsDestroyed => Health <= 0;


    }
public class Chest : IDamageable
{
    public int Health{get; set;}
    public  void TakeDamage(int amount){
            Health -= amount;
            Console.WriteLine($"скрині нанесли {amount}  урона ");
        }
    public bool IsDestroyed => Health <= 0;

}

public class Barricade : IDamageable
{
    public int Health{get; set;}
    public  void TakeDamage(int amount){
            Health -= amount;
            Console.WriteLine($"барикаді нанесли {amount}  урона ");
        }
     public bool IsDestroyed => Health <= 0;
   
}


public class Weapon
{
    public string Title;
    public int Damage;
    public int Durability;

}    
public class SpellSystem
{
    
    public static void CastMeteorite(List<IDamageable> targets, int spellDamage)
    {
        Console.WriteLine($"\n--- Закляття Meteorite наносить {spellDamage} шкоди усім цілям у зоні! ---");
        
        foreach (var target in targets)
        {
            target.TakeDamage(spellDamage);
            
            if (target.IsDestroyed)
            {
                Console.WriteLine("--> Ціль знищено!");
            } 
        }
    }
}

class Program
{
    static void Main()
    {
        List<IDamageable> targetsInArea = new List<IDamageable>
        {
            new Character("Орк-Воїн", health: 100, level: 5, baseAttack: 15, armor: 10),
            new Barricade{Health = 50},
            new Character("Гоблін", health: 30, level: 2, baseAttack: 5, armor: 0)
        };

        
        SpellSystem.CastMeteorite(targetsInArea, spellDamage: 40);
    }
}
