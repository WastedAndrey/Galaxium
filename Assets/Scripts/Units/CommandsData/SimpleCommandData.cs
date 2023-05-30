
namespace Assets.Scripts.Units.CommandsData
{
    public class SimpleCommandData<T>
    {
        public T InitialValue { get; private set; }
        public T FinalValue;

        public SimpleCommandData(T initialValue)
        {
            InitialValue = initialValue;
            FinalValue = initialValue;
        }
    }
}