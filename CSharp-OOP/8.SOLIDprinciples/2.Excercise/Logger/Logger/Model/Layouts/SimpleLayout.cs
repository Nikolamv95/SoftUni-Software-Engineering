using SolidLogger.Model.Contracts;

namespace SolidLogger.Model.Layouts
{
    public class SimpleLayout : ILayout
    {
        public string Format => "{0} - {1} - {2}";
    }
}
