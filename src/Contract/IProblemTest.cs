namespace Contract
{
    public interface IProblemTest : IDependency
    {
        bool Execute();
        string Description { get; }
        string Title { get; }
        string Answer { get; }
        string FileName { get; }
    }
}
