namespace Soccer
{
    public enum PlayerFunction
    {
        Goalkeeper = 'G',
        Defender = 'D',
        Midfielder = 'M',
        Forward = 'F'
    }

    public class Player
    {
        public Player(string name, string firstName, int shirtNumber, PlayerFunction function)
        {
            Name = name;
            FirstName = firstName;
            ShirtNumber = shirtNumber;
            Function = function;
        }

        public string Name { get; }
        public string FirstName { get; }
        public int ShirtNumber { get; }
        public PlayerFunction Function { get; }
    }
}