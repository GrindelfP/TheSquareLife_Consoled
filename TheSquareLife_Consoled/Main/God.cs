using System.Diagnostics.CodeAnalysis;
using TheSquareLife_Consoled.Visualization;

namespace TheSquareLife_Consoled;

internal class God : IUserInputGetter<int>
{
    private readonly Board _board;
    private readonly Population _population;
    private readonly IVisualizer _visualizer;
    private readonly int _numberOfCycles;
    private static readonly God GodWhoIs = new();

    public static God I_Am() => GodWhoIs;
    public int GetUserNumberOf(string type)
    {
        var numberOfIterations = 0;
        var flag = true;
        while (flag)
        {
            Console.Write($"How many {type} should take place -> ");
            try
            {
                numberOfIterations = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("You are supposed to use integers!");
            }
            switch (type)
            {
                case nameof(Kuvahaku) when numberOfIterations < 10:
                    Console.WriteLine($"There must be at least 10 {type}");
                    break;
                case nameof(Kuvahaku) when numberOfIterations > 30:
                    Console.WriteLine($"There must be not more than 30 {type}");
                    break;
                case nameof(Kuvat) when numberOfIterations < 8:
                    Console.WriteLine($"There must be at least 8 {type}");
                    break;
                case nameof(Kuvat) when numberOfIterations > 25:
                    Console.WriteLine($"There must be not more than 25 {type}");
                    break;
                case "cycles" when numberOfIterations < 2:
                    Console.WriteLine($"There must be at least 2 {type}");
                    break;
                case "cycles" when numberOfIterations > 40:
                    Console.WriteLine($"There must be not more than 40 {type}");
                    break;
                default:
                    flag = false;
                    break;
            }
            
        }
        
        return numberOfIterations;
    }

    [SuppressMessage("ReSharper.DPA", "DPA0002: Excessive memory allocations in SOH", MessageId = "type: System.String")]
    private void StartEvolution()
    {
        for (var cycleNumber = 0; cycleNumber < _numberOfCycles; cycleNumber++)
        {
            EvolutionCycle(cycleNumber);
            if (cycleNumber == _numberOfCycles - 1) FinalizeEvolution();
        }
    }
    
    private void EvolutionCycle(int evolutionCycleNumber) 
    {
        // 1. command entities to move        
        _population.AliveEntities().ForEach(entity =>
        {
            entity.Move();
        });
        UpdateBoard(evolutionCycleNumber);
        
        // 2. check results of the movement
        // 2.1 swallowing
        var populationSizeProbe = _population.Size();
        _population.AliveEntities().ForEach(ProcessSwallowing);
        if (_population.Size() != populationSizeProbe)
        {
            UpdateBoard(evolutionCycleNumber, "someone doesn't survive!");
            Console.WriteLine(_population);
        }
        
        // 2.2 procreation
        // _population.AliveEntities().ForEach(ProcessProcreation); TODO: implement procreation
    }

    /*
    private void ProcessProcreation(Entity entity)
    {
        // Guardian: we do not check procreation if the entity is not alive (this value can be changed after we built the list of alive entities)
        if (!entity.IsAlive) return;
    }
    */

    private void ProcessSwallowing(Entity entity)
    {
        // Guardian: we do not check swallowing if the entity is not alive (this value can be changed after we built the list of alive entities)
        if (!entity.IsAlive) return;

        var overlappingAliens = new List<Entity>();
        _population.AliveEntities().ForEach(it =>
        {
            if (entity.OverlapWithAlien(it)) overlappingAliens.Add(it);
        });
        var commonCoordinates = entity.CommonCoordinates(overlappingAliens);

        switch (entity)
        {
            case Uutiset:
                if (commonCoordinates.Count >= 5) entity.IsAlive = false;
                else overlappingAliens.ForEach(overlappingEntity =>
                {
                    switch (overlappingEntity)
                    {
                        case Kuvahaku:
                            overlappingEntity.IsAlive = false;
                            break;
                        case Kuvat:
                            // Uutiset overlaps with Kuvat, and they occupy 2 or more common coordinates
                            if (entity.CommonCoordinates(overlappingEntity).Count >= 2)
                                overlappingEntity.IsAlive = false;
                            break;
                    }
                });
                break;
            case Kuvat:
                if (commonCoordinates.Count >= 2) entity.IsAlive = false;
                // if kuvat survived then kuvahakus (in fact the one overlapping kuvahaku) are swallowed.
                // But we should filter out Uutiset (if it survived)
                else
                {
                    var overlappingAliensWithoutUutiset = overlappingAliens.FindAll(it => it is not Uutiset);
                    overlappingAliensWithoutUutiset.ForEach(it =>
                    {
                        it.IsAlive = false;
                    });
                }
                break;
            case Kuvahaku:
                /*NOP: if Kuvahaku is still alive then there is nothing to check here: Kuvahaku is a real survivor!*/
                break;
        }
    }
    
    private void UpdateBoard(int evolutionCycleNumber, string? extraMessage = null)
    {
        _board.Update(_population.AliveEntitiesPositions());
        _visualizer.Visualize(evolutionCycleNumber, extraMessage);
    }
    private void FinalizeEvolution()
    {
        _visualizer.Finalize(_population.GetNumberOfAliveEntities(), _board);
    }

    protected internal God()
    {
        _numberOfCycles = GetUserNumberOf("cycles");
        _board = new Board(new BoardSize(40, 40));
        _population = Population.GeneratePopulation(GetUserNumberOf(nameof(Kuvahaku)), GetUserNumberOf(nameof(Kuvat)), _board);
        _visualizer = new ConsoleBoardVisualizer(_board);
        UpdateBoard(-1);
        StartEvolution();
    }
}