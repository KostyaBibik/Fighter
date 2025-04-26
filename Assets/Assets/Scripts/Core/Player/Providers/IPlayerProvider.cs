namespace Core
{
    public interface IPlayerProvider
    {
        public PlayerPresenter Player { get; }
        public void Set(PlayerPresenter presenter);
    }
}