using static TheSquareLife_Consoled.EntitySize;

namespace TheSquareLife_Consoled;

internal class Population
    {
        readonly Uutiset Uutiset;
        readonly List<Kuvahaku> Kuvahakus;
        readonly List<Kuvat> Kuvatus;
        private List<Coordinate> Coordinates = new();

        public List<Entity> Entities()
        {
            var entities = new List<Entity> { Uutiset };
            entities.AddRange(Kuvahakus);
            entities.AddRange(Kuvatus);

            return entities;
        }

        public List<EntityPosition> EntityPositions()
        {
            var positions = new List<EntityPosition> { new EntityPosition(Uutiset.Position, Uutiset.Color) };
            Kuvahakus.ForEach(it =>
            {
                positions.Add(new EntityPosition(it.Position, it.Color));
            });
            Kuvatus.ForEach(it =>
            {
                positions.Add(new EntityPosition(it.Position, it.Color));
            });

            return positions;
        }

        public Population GeneratePopulation(int numberOfKuvahakus, int numberOfuvatus, BoardSize sizeOfBoard)
        {
            var minSize = KuvahakuSize + KuvatSize + UutisetSize + 2;
            if (BoardSize.NumberOfRows < minSize) 
            { 
                throw new Exception($"Board height must be greater than {minSize}"); 
            }
            if (BoardSize.NumberOfColumns < minSize) 
            { 
                throw new Exception($"Board length must be greater than {minSize}"); 
            }
            var numberOfEntities = 1 + numberOfKuvahakus + numberOfuvatus; // This and following is not used! Why? Check!
            var numberOfFreeAreas = (BoardSize.NumberOfRows * BoardSize.NumberOfColumns) / (MinEntityAreaSize * MinEntityAreaSize);
            var areas = new List<Coordinate>();
            for (var rowIndex = 1; rowIndex < BoardSize.NumberOfRows; rowIndex += MinEntityAreaSize)
            {
                for (var positionInRow = 1; positionInRow < BoardSize.NumberOfColumns; positionInRow += MinEntityAreaSize)
                {
                    areas.Add(new Coordinate(positionInRow, rowIndex));
                }
            }
            var uutiset = InitUutiset(areas);
            var kuvahakus = InitKuvahakus(numberOfKuvahakus, areas);
            var kuvatus = InitKuvatus(numberOfuvatus, areas);

            return new Population(uutiset, kuvahakus, kuvatus);
        }

        private static List<Kuvahaku> InitKuvahakus(int numberOfKuvahakus, List<Coordinate> areas)
        {
            var random = new Random();
            var kuvahakus = new List<Kuvahaku>();
            while (numberOfKuvahakus > 0)
            {
                var coordinate = areas[random.Next(0, areas.Count)];
                areas.Remove(coordinate);
                var availibleCoordinates = new HashSet<Coordinate>
                {
                    new Coordinate(coordinate.X + random.Next(1, 4), coordinate.Y + random.Next(1, 4))
                };
                var availablePositions = new Position(availibleCoordinates);
                kuvahakus.Add(new Kuvahaku(availablePositions));
                numberOfKuvahakus--;
            }

            return kuvahakus;
        }
        private static List<Kuvat> InitKuvatus(int numberOfKuvatus, List<Coordinate> areas)
        {
            var random = new Random();
            var kuvatus = new List<Kuvat>();
            while (numberOfKuvatus > 0)
            {
                var coordinate = areas[random.Next(0, areas.Count)];
                areas.Remove(coordinate);
                var shiftedCorner = new Coordinate(random.Next(0, 2), random.Next(0, 2));
                var availibleCoordinates = new HashSet<Coordinate>
                {
                    new Coordinate(shiftedCorner.X + 1, shiftedCorner.Y + 1),
                    new Coordinate(shiftedCorner.X + 1, shiftedCorner.Y + 2),
                    new Coordinate(shiftedCorner.X + 2, shiftedCorner.Y + 1),
                    new Coordinate(shiftedCorner.X + 2, shiftedCorner.Y + 2)
                };
                var availiblePositions = new Position(availibleCoordinates);
                kuvatus.Add(new Kuvat(availiblePositions));
                numberOfKuvatus--;
            }

            return kuvatus;
        }
        private static Uutiset InitUutiset(List<Coordinate> areas)
        {
            var uutisetIndex = new Random().Next(0, areas.Count);
            var uutisetUpperLeftCoordinate = areas[uutisetIndex];
            areas.Remove(uutisetUpperLeftCoordinate);
            var availableCoordinates = new HashSet<Coordinate>
            {
                    new Coordinate(uutisetUpperLeftCoordinate.X + 1, uutisetUpperLeftCoordinate.Y + 1),
                    new Coordinate(uutisetUpperLeftCoordinate.X + 1, uutisetUpperLeftCoordinate.Y + 2),
                    new Coordinate(uutisetUpperLeftCoordinate.X + 1, uutisetUpperLeftCoordinate.Y + 3),
                    new Coordinate(uutisetUpperLeftCoordinate.X + 2, uutisetUpperLeftCoordinate.Y + 1),
                    new Coordinate(uutisetUpperLeftCoordinate.X + 2, uutisetUpperLeftCoordinate.Y + 2),
                    new Coordinate(uutisetUpperLeftCoordinate.X + 2, uutisetUpperLeftCoordinate.Y + 3),
                    new Coordinate(uutisetUpperLeftCoordinate.X + 3, uutisetUpperLeftCoordinate.Y + 1),
                    new Coordinate(uutisetUpperLeftCoordinate.X + 3, uutisetUpperLeftCoordinate.Y + 2),
                    new Coordinate(uutisetUpperLeftCoordinate.X + 3, uutisetUpperLeftCoordinate.Y + 3),
            };
            var availablePositions = new Position(availableCoordinates);

            return new Uutiset(availablePositions);
        }

        public Population(Uutiset uutiset, List<Kuvahaku> kuvahakus, List<Kuvat> kuvatus)
        {
            Uutiset = uutiset;
            Kuvahakus = kuvahakus;
            Kuvatus = kuvatus;
            Coordinates.AddRange(Uutiset.Position.Coordinates);
            Kuvahakus.ForEach(it =>
            {
               Coordinates.AddRange(it.Position.Coordinates);
            });
            Kuvatus.ForEach(it =>
            {
                Coordinates.AddRange(it.Position.Coordinates);
            });
            var setOfCoordinates = new HashSet<Coordinate>(Coordinates);
            if (Coordinates.Count != setOfCoordinates.Count)
            {
                throw new Exception("There are entities with overlapping positions.");
            }
        }
    }