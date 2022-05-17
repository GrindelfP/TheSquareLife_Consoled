using TheSquareLife_Consoled.Visualization;

namespace TheSquareLife_Consoled;

internal class God
{
    Board Board;
    Population Population;
    BoardVisualizer Visualizer;

    private void Begin()
    {
        Board.Update(Population.EntityPositions());
        Visualizer.Visualize();
        Move();
    }

    private void Move() // Not completed yet! Or it is done?
    {
        Population.Entities().ForEach(entity =>
        {
            var positionsForMove = MovementCalculator.PosibleMoveCoorsinates(entity, Board);
            var nextPosition = entity.Move(positionsForMove);
        });
        Board.Update(Population.EntityPositions());
        Visualizer.Visualize();
    }

    public God()
    {
        Board = new Board(new BoardSize(40, 40));
        Population = Population.GeneratePopulation(25, 9, Board.BoardSize);
        Visualizer = new Visualization.ConsoleBoardVisualizer();
        Begin();
    }
}