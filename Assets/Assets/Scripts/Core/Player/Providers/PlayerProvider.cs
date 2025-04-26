namespace Core
{
    public class PlayerProvider: IPlayerProvider
    {
        public PlayerPresenter Player { get; private set; }

        public void Set(PlayerPresenter presenter)
        {
            Player = presenter;
        }
    }
}