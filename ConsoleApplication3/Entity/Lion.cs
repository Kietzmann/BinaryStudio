namespace ConsoleApplication3.Entity
{
    public class Lion : Animal
    {
        public Lion(string alias) : base(alias)
        {
            FullHealthPoints = (int) HealthParameter.Lion;
            _healthPoints = FullHealthPoints;
        }
    }
}