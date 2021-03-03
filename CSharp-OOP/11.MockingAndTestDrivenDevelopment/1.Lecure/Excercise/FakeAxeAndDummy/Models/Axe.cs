using System;

// Axe durability drop with 5 
public class Axe : IWeapon
{
    //Constants
    private const int dropWeponPoints = 5;

    //Fields
    private int attackPoints;
    private int durabilityPoints;

    //Constructor
    public Axe(int attack, int durability)
    {
        this.attackPoints = attack;
        this.durabilityPoints = durability;
    }

    //Properties
    public int AttackPoints
    {
        get { return this.attackPoints; }
    }
    public int DurabilityPoints
    {
        get { return this.durabilityPoints; }
    }

    //Methods
    public void Attack(ITarget target)
    {
        if (this.durabilityPoints <= 0)
        {
            throw new InvalidOperationException("Axe is broken.");
        }

        target.TakeAttack(this.attackPoints);

        this.durabilityPoints -= dropWeponPoints;
    }
}
