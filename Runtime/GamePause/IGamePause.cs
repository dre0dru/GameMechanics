namespace Dre0Dru.GamePause
{
    /// <summary>
    /// TODO сервис для паузы, можно как по эвентам работать, так и через поллинг
    /// TODO в стракте просто будет ссылка на сервис и там будем чекать проверти IsPaused
    /// TODO может message pipe под это приспособить?
    /// </summary>
    public interface IGamePause
    {
        public delegate void OnPauseStatusChange(bool isPaused);
        
        event OnPauseStatusChange PauseStatusChange;
        
        bool IsPaused { get; }

        void Pause();

        void Unpause();
    }
}
