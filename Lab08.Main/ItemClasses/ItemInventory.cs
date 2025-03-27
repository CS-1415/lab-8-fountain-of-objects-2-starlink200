public class ItemInventory
{
    public (Weapon weapon, List<Potion> potions) Inventory;

    public ItemInventory()
    {
        Inventory.weapon = new NoWeapon();
        Inventory.potions = new List<Potion>();
    }
}