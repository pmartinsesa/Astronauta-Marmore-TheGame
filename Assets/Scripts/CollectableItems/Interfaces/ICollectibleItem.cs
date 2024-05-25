namespace Assets.Scripts
{
    public interface ICollectibleItem
    {
        void OnCollect();

        void SelfDestroy();
    }
}
