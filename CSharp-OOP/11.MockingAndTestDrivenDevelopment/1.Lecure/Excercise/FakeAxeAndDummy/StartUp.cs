public class StartUp
{
    static void Main(string[] args)
    {
        IWeapon wepon = new Axe(10, 10);
        ITarget target = new Dummy(10, 10);
        Hero hero = new Hero("Marin", wepon);

        
        hero.Attack(target);
    }
}
