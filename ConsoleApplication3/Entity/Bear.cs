namespace ConsoleApplication3.Entity
{
    public class Bear : Animal
    {
        public Bear(string alias) : base(alias)
        {
            FullHealthPoints = (int) HealthParameter.Bear;
            _healthPoints = FullHealthPoints;
        }
    }
}