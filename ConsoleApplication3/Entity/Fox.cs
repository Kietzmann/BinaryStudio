namespace ConsoleApplication3.Entity
{
    public class Fox : Animal
    {
        public Fox(string alias) : base(alias)
        {
            FullHealthPoints = (int) HealthParameter.Fox;
            _healthPoints = FullHealthPoints;
        }
    }
}