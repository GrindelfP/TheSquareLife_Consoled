using TheSquareLife_Consoled.Entities;
using TheSquareLife_Consoled.Visualization;

namespace TheSquareLife_Consoled.MainUtility;

internal class God
{
    private readonly Board _board;
    private readonly Population _population;
    private readonly BoardVisualizer _visualizer;

    private void StartEvolution()
    {
        var iteration = 10;
        while (iteration > 0)
        {
            EvolutionCycle(iteration - iteration + 1);
            iteration--;
        }
    }

    private void EvolutionCycle(int evolutionCycleNumber) // Not completed yet! Or it is done?
    {
        // 1. command entities to move        
        _population.Entities().ForEach(entity =>
        {
            if (entity.IsAlive)
            {
                var positionsForMove = MovementCalculator.PossibleMoveCoordinates(entity, _board);
                entity.Move(positionsForMove);
            }
        });
        UpdateBoard(evolutionCycleNumber);
        // 2. check results of the movement (overlapping that give birth or result in entity's death)
        var overlappingEntities = OverlappingEntities();
        overlappingEntities.ForEach(it =>
        {
            Console.WriteLine($""); //TODO: What is written here?
        });
        
        _board.Update(_population.EntityPositions());
        _visualizer.Visualize(evolutionCycleNumber);
    }

    private List<Entity> OverlappingEntities()
    {
        throw new NotImplementedException();
    }
    private void UpdateBoard(int evolutionCycleNumber)
    {
        _board.Update(_population.EntityPositions());
        _visualizer.Visualize(evolutionCycleNumber);
    }
    
    public God()
    {
        _board = new Board(new BoardSize(40, 40));
        _population = _population!.GeneratePopulation(25, 9, _board.BoardSize);
        _visualizer = new ConsoleBoardVisualizer();
        UpdateBoard(-1);
        StartEvolution();
    }
}