namespace ConsoleApplication3.Entity
{
    public class Wolf : Animal
    {
        public Wolf(string alias) : base(alias)
        {
            FullHealthPoints = (int) HealthParameter.Wolf;
            _healthPoints = FullHealthPoints;
        }
    }
}