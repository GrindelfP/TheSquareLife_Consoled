using static TheSquareLife_Consoled.EntitySize;

namespace TheSquareLife_Consoled;

internal class Population
    {
        private readonly Uutiset _uutiset;
        private readonly List<Kuvahaku> _kuvahakus;
        private readonly List<Kuvat> _kuvatus;
        private readonly List<Coordinate> _coordinates = new();

        internal List<Entity> AliveEntities()
        {
            var entities = new List<Entity> { _uutiset };
            entities.AddRange(_kuvahakus);
            entities.AddRange(_kuvatus);
            var aliveEntities = new List<Entity>();
            entities.ForEach(it =>
            {
                if (it.IsAlive) aliveEntities.Add(it);
            });
            return aliveEntities;
        }

        internal List<EntityPosition> AliveEntitiesPositions()
        {
            var positions = new List<EntityPosition>();
            if (_uutiset.IsAlive) positions.Add(new EntityPosition(_uutiset.Position, _uutiset.Color));
            _kuvatus.ForEach(kuvat =>
            {
                if (kuvat.IsAlive) positions.Add(new EntityPosition(kuvat.Position, kuvat.Color));
            });
            _kuvahakus.ForEach(kuvahaku =>
            {
                if (kuvahaku.IsAlive) positions.Add(new EntityPosition(kuvahaku.Position, kuvahaku.Color));
            });
            
            return positions;
        }

        internal int Size() => AliveEntities().Count;

        internal List<EntityPosition> EntityPositions()
        {
            var positions = new List<EntityPosition> { new EntityPosition(_uutiset.Position, _uutiset.Color) };
            _kuvahakus.ForEach(it =>
            {
                positions.Add(new EntityPosition(it.Position, it.Color));
            });
            _kuvatus.ForEach(it =>
            {
                positions.Add(new EntityPosition(it.Position, it.Color));
            });

            return positions;
        }

        internal static Population GeneratePopulation(int numberOfKuvahakus, int numberOfKuvatus, Board board)
        {
            var minSize = KuvahakuSize + KuvatSize + UutisetSize + 2;
            if (board.BoardSize.NumberOfRows < minSize) 
            { 
                throw new Exception($"Board height must be greater than {minSize}"); 
            }
            if (board.BoardSize.NumberOfColumns < minSize) 
            { 
                throw new Exception($"Board length must be greater than {minSize}"); 
            }
            var areas = new List<Coordinate>();
            for (var rowIndex = 1; rowIndex < board.BoardSize.NumberOfRows; rowIndex += MinEntityAreaSize)
            {
                for (var positionInRow = 1; positionInRow < board.BoardSize.NumberOfColumns; positionInRow += MinEntityAreaSize)
                {
                    areas.Add(new Coordinate(positionInRow, rowIndex));
                }
            }
            var uutiset = InitUutiset(areas, board);
            var kuvahakus = InitKuvahakus(numberOfKuvahakus, areas, board);
            var kuvatus = InitKuvatus(numberOfKuvatus, areas, board);

            return new Population(uutiset, kuvahakus, kuvatus);
        }

        private static List<Kuvahaku> InitKuvahakus(int numberOfKuvahakus, List<Coordinate> areas, Board board)
        {
            var random = new Random();
            var kuvahakus = new List<Kuvahaku>();
            while (numberOfKuvahakus > 0)
            {
                var coordinate = areas[random.Next(0, areas.Count)];
                areas.Remove(coordinate);
                var availableCoordinates = new HashSet<Coordinate>
                {
                    new(coordinate.X + random.Next(1, 4), coordinate.Y + random.Next(1, 4))
                };
                var availablePositions = new Position(availableCoordinates, board);
                kuvahakus.Add(new Kuvahaku(availablePositions));
                numberOfKuvahakus--;
            }

            return kuvahakus;
        }
        private static List<Kuvat> InitKuvatus(int numberOfKuvatus, List<Coordinate> areas, Board board)
        {
            var random = new Random();
            var kuvatus = new List<Kuvat>();
            while (numberOfKuvatus > 0)
            {
                var coordinate = areas[random.Next(0, areas.Count)];
                areas.Remove(coordinate);
                var shiftedCorner = new Coordinate(random.Next(0, 2), random.Next(0, 2));
                var availableCoordinates = new HashSet<Coordinate>
                {
                    new(shiftedCorner.X + 1, shiftedCorner.Y + 1),
                    new(shiftedCorner.X + 1, shiftedCorner.Y + 2),
                    new(shiftedCorner.X + 2, shiftedCorner.Y + 1),
                    new(shiftedCorner.X + 2, shiftedCorner.Y + 2)
                };
                var availablePositions = new Position(availableCoordinates, board);
                kuvatus.Add(new Kuvat(availablePositions));
                numberOfKuvatus--;
            }

            return kuvatus;
        }
        private static Uutiset InitUutiset(List<Coordinate> areas, Board board)
        {
            var uutisetIndex = new Random().Next(0, areas.Count);
            var uutisetUpperLeftCoordinate = areas[uutisetIndex];
            areas.Remove(uutisetUpperLeftCoordinate);
            var availableCoordinates = new HashSet<Coordinate>
            {
                    new(uutisetUpperLeftCoordinate.X + 1, uutisetUpperLeftCoordinate.Y + 1),
                    new(uutisetUpperLeftCoordinate.X + 1, uutisetUpperLeftCoordinate.Y + 2),
                    new(uutisetUpperLeftCoordinate.X + 1, uutisetUpperLeftCoordinate.Y + 3),
                    new(uutisetUpperLeftCoordinate.X + 2, uutisetUpperLeftCoordinate.Y + 1),
                    new(uutisetUpperLeftCoordinate.X + 2, uutisetUpperLeftCoordinate.Y + 2),
                    new(uutisetUpperLeftCoordinate.X + 2, uutisetUpperLeftCoordinate.Y + 3),
                    new(uutisetUpperLeftCoordinate.X + 3, uutisetUpperLeftCoordinate.Y + 1),
                    new(uutisetUpperLeftCoordinate.X + 3, uutisetUpperLeftCoordinate.Y + 2),
                    new(uutisetUpperLeftCoordinate.X + 3, uutisetUpperLeftCoordinate.Y + 3),
            };
            var availablePositions = new Position(availableCoordinates, board);

            return new Uutiset(availablePositions);
        }

        private Population(Uutiset uutiset, List<Kuvahaku> kuvahakus, List<Kuvat> kuvatus)
        {
            _uutiset = uutiset;
            _kuvahakus = kuvahakus;
            _kuvatus = kuvatus;
            _coordinates.AddRange(_uutiset.Position.Coordinates);
            _kuvahakus.ForEach(it =>
            {
               _coordinates.AddRange(it.Position.Coordinates);
            });
            _kuvatus.ForEach(it =>
            {
                _coordinates.AddRange(it.Position.Coordinates);
            });
            var setOfCoordinates = new HashSet<Coordinate>(_coordinates);
            if (_coordinates.Count != setOfCoordinates.Count)
            {
                throw new Exception("There are entities with overlapping positions.");
            }
        }
    }