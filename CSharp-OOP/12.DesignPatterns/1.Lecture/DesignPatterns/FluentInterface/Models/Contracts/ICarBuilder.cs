namespace FluentInterface.Models.Contracts
{
    public interface ICarBuilder
    {
        ICarBuilder BuildTyres(Car car);
        ICarBuilder BuildEngine(Car car);
        ICarBuilder BuildTransmission(Car car);
    }
}
