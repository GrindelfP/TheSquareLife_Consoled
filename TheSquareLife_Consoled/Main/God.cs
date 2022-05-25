using TheSquareLife_Consoled.Visualization;

namespace TheSquareLife_Consoled;

internal class God
{
    private readonly Board _board;
    private readonly Population _population;
    private readonly IVisualizer _visualizer;
    private readonly int _numberOfCycles;

    private static int NumberOfCycles()
    {
        Console.Write("How many cycles should take place -> ");
        var numberOfCycles = 0;
        var flag = true;
        while (flag)
        {
            try
            {
                numberOfCycles = Convert.ToInt32(Console.ReadLine());
                flag = false;
            }
            catch
            {
                Console.WriteLine("You are supposed to use integers!");
            }
        }
        return numberOfCycles;
    }

    private void StartEvolution()
    {
        var iteration = _numberOfCycles;
        while (iteration > 0)
        {
            EvolutionCycle(iteration - iteration + 1);
            iteration--;
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
                            // Uutiset overlaps with Kuvat, and they occupy 2 or more common coordinates
                            break;
                        case Kuvat:
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
                    var overlappingAliensWithoutUutiset = new List<Entity>(); 
                    overlappingAliens.ForEach(it =>
                    {
                        if (it is not Uutiset) overlappingAliensWithoutUutiset.Add(it);
                    }); 
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
    
    protected internal God()
    {
        _numberOfCycles = NumberOfCycles();
        _board = new Board(new BoardSize(40, 40));
        _population = Population.GeneratePopulation(25, 20, _board);
        _visualizer = new ConsoleBoardVisualizer(_board);
        UpdateBoard(-1);
        StartEvolution();
    }
}