public interface IPlayer
{
    void Unlock(Door target);
    void OpenInventory();
    void PickUp(Item item);
    void Move();
}