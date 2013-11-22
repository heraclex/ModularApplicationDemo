namespace NerverLand.Framework.CarModule
{
    using NerverLand.Framework.Contract.Provider;

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
