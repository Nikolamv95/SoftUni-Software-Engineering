using SolidLogger.Model.Contracts;
using SolidLogger.Model.Enumerations;

namespace SolidLogger.Model
{
    public interface IAppender
    {
        ILayout Layout { get; }
        Level Level { get; }

        void Append(IError error);

    }
}
