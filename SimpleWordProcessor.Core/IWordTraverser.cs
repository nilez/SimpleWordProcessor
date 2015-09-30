namespace SimpleWordProcessor.Core
{
    public interface IWordTraverser
    {
        void AcceptProcessor(IWordProcessor processor);
    }
}
