namespace ConsoleApplication3.Entity
{
    public class Tiger : Animal
    {
        public Tiger(string alias) : base(alias)
        {
            FullHealthPoints = (int) HealthParameter.Tiger;
            _healthPoints = FullHealthPoints;
        }
    }
}