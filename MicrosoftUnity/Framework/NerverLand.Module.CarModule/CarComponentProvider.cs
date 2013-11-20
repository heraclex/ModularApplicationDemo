namespace NerverLand.Module.CarModule
{
    using NerverLand.Module.Contract.Provider;

    public abstract class CarComponentProvider : ICarComponentProvider
    {
        protected string ComponentName;

        public virtual void BuildComponent(string name)
        {
        }

        public virtual string GetComponentName()
        {
            return "CarComponentProvider";
        }
    }
}
