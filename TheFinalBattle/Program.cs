using TheFinalBattle.Players;

Game game = new Game();
game.InitialiseGame();

public class Game
{
    public void InitialiseGame()
    {
        Renderer.WriteLine("What is your name?");
        var playerName = Console.ReadLine();

        while (true)
        {
            var computerPlayer = new Computer();
            var humanPlayer = new Human();

            var hero = new TheTrueProgrammer(playerName, new Punch());
            var heroes = new Party(new List<Character>() { hero }, humanPlayer);

            var battleSeries = new BattleSeries();
            List<Battle> battles = new List<Battle>()
            {
                battleSeries.CreateFirstBattle(heroes, computerPlayer),
                battleSeries.CreateSecondBattle(heroes, computerPlayer),
                battleSeries.CreateThirdBattle(heroes, computerPlayer),
            };

            foreach (var battle in battles)
            {
                var winningParty = battle.RunBattle();

                if (winningParty != heroes)
                    Renderer.WriteLine(
                        "The monsters have won and the Uncoded One is now free to reign terror across all of Consolas");

                if (battles[^1] != battle)
                    Console.WriteLine("The heroes win and move on to the next battle");
            }

            Renderer.WriteLine("The heroes have prevailed, Consolas is saved.");
        }
    }
}


public class BattleSeries()
{
    public Battle CreateFirstBattle(Party heroes, IPlayer player)
    {
        var skeleton = new Skeleton(new BoneCrunch());
        var monsters = new Party(new List<Character>() { skeleton }, player);

        return new Battle(heroes, monsters);
    }

    public Battle CreateSecondBattle(Party heroes, IPlayer player)
    {
        var skeleton = new Skeleton(new BoneCrunch());
        var skeletonTwo = new Skeleton(new BoneCrunch());
        var monsters = new Party(new List<Character>() { skeleton, skeletonTwo }, player);

        return new Battle(heroes, monsters);
    }

    public Battle CreateThirdBattle(Party heroes, IPlayer player)
    {
        var uncodedOne = new UncodedOne(new Unravel());
        var monsters = new Party(new List<Character>() { uncodedOne }, player);

        return new Battle(heroes, monsters);
    }
}