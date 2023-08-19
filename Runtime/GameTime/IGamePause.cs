namespace Dre0Dru.GameTime
{
    public interface IGamePause
    {
        public delegate void PauseStatusChange(bool isPaused);
        
        event PauseStatusChange PauseStatusChanged;
        
        bool IsPaused { get; }

        void Pause();

        void Unpause();
    }
}
