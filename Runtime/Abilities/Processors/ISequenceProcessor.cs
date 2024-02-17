namespace Abilities
{
    //resembles behaviour tree selector/sequence tasks
    public interface ISequenceProcessor
    {
        SequenceStatus Process(float dt);
    }
}
