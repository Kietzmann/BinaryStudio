namespace ConsoleApplication3.Entity

{
    public class Elephant : Animal
    {
        public Elephant(string alias) : base(alias)
        {
            FullHealthPoints = (int) HealthParameter.Elephant;
            _healthPoints = FullHealthPoints;
        }
    }
}