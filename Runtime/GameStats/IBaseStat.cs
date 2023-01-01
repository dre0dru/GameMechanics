namespace Dre0Dru.GameStats
{
    //TODO предоставить реалзиации базовых интерфейсов
    //TODO юзеры будут выбриать комбинации интерфейсов и использовать готовые реализации
    //делегировать им имплементацию
    public interface IBaseStat<TValue>
    {
        TValue GetBaseValue();
        void SetBaseValue(TValue value);
    }
}
