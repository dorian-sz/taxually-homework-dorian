namespace Taxually.TechnicalTest.Helpers.Interfaces.ModelPropertyChecker
{
    public interface IModelPropertyChecker<T>
    {
        bool AnyPropertiesDefault(T model);
    }
}
