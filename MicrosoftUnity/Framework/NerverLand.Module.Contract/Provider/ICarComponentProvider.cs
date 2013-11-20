namespace NerverLand.Module.Contract.Provider
{
    public interface ICarComponentProvider
    {
        void BuildComponent(string name);

        string GetComponentName();
    }
}
