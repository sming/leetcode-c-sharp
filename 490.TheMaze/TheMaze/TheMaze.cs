using System;
using System.Collections.Generic;

/**
 * https://leetcode.com/articles/the-maze/
 *
 * There is a ball in a maze with empty spaces and walls. The ball can go through empty spaces by rolling up, down,
 * left or right, but it won't stop rolling until hitting a wall. When the ball stops, it could choose the next direction.

* Given the ball's start position, the destination and the maze, determine whether the ball could stop at the
* destination.
* 
* The maze is represented by a binary 2D array.
* 1 means the wall and
* 0 means the empty space.
*
* You may assume that the borders of the maze are all walls. The start and * destination coordinates are represented *by row and column indexes*.
* 
* Input 1: a maze represented by a 2D array
*
* col 0
* ^
* 0 0 1 0 0 ← row 0
* 0 0 0 0 0
* 0 0 0 1 0
* 1 1 0 1 1
* 0 0 0 0 0
*                                                   r  c
* Input 2: start coordinate (rowStart, colStart) = (0, 4)
* Input 3: destination coordinate (rowDest, colDest) = (4, 4)
* 
* Output: true
* 
* Explanation: One possible way is : left -> down -> left -> down -> right -> down -> right.
* 
* 
* Input 1: a maze represented by a 2D array
* 
* 0 0 1 0 0
* 0 0 0 0 0
* 0 0 0 1 0
* 1 1 0 1 1
* 0 0 0 0 0
* 
* Input 2: start coordinate (rowStart, colStart) = (0, 4)
* Input 3: destination coordinate (rowDest, colDest) = (3, 2)
* 
* Output: false
* 
* Explanation: There is no way for the ball to stop at the destination.
*
* -----------------------------
* 
* Note:

* - There is only one ball and one destination in the maze.
* - Both the ball and the destination exist on an empty space, and they will not be at the same position initially.
* - The given maze does not contain border (like the red rectangle in the example pictures), but you could assume
* the border of the maze are all walls.
* - The maze contains at least 2 empty spaces, and both the width and height of the maze won't exceed 100.
* 
* -----------------------------
* PSK NOTES
* - indices assume surrounding walls, which are not given. synthesize those?
* - row index starts from the top
* - col index start from left
*
* So, how do we know if we've arrived at the dest? could just plug it in
* as a property.
*/
namespace TheMaze
{
    public class Coords
    {
        public Coords(int rowIdx, int colIdx, VisitState visitState = VisitState.UNVISITED)
        {
            RowIdx = rowIdx;
            ColIdx = colIdx;
            VisitState = visitState;
        }

        public Coords GetNextCoord(DIRECTION dir)
        {
            return dir switch
            {
                DIRECTION.UP => new Coords(RowIdx - 1, ColIdx),
                DIRECTION.RIGHT => new Coords(RowIdx, ColIdx + 1),
                DIRECTION.DOWN => new Coords(RowIdx + 1, ColIdx),
                DIRECTION.LEFT => new Coords(RowIdx, ColIdx - 1),
                _ => throw new ApplicationException("Bollocks"),
            };
        }


        public override bool Equals(object obj)
        {
            var other = (Coords)obj;
            return other.RowIdx == RowIdx && other.ColIdx == ColIdx;
        }

        public override int GetHashCode()
        {
            return 32 * RowIdx * ColIdx;
        }

        public int RowIdx { get; }
        public int ColIdx { get; }
        public VisitState VisitState { get; set; }
    }

    public enum DIRECTION
    {
        UP,
        RIGHT,
        DOWN,
        LEFT
    }

    public enum VisitState
    {
        UNVISITED,
        BEING_VISITED,
        WAS_VISITED
    }

    public enum CoordType
    {
        SPACE,
        WALL
    }

    public class TheMaze
    {
        internal Coords Destination { get; private set; }
        public int[][] Maze { get; private set; }
        public HashSet<Coords> VisitedCoords { get; private set; }
        public bool DestinationFound { get; set; }

        public TheMaze()
        {
            VisitedCoords = new HashSet<Coords>();
        }

        public bool HasPath(int[][] maze, int[] start, int[] destination)
        {
            // TODO check for nulls, empty, out of bounds etc.

            // Assuming that start and destination are within the bounds
            // of the maze.
            Destination = new Coords(destination[0], destination[1]);
            Maze = maze;
            ExploreMazeDfs(new Coords(start[0], start[1]), DIRECTION.UP);
            return DestinationFound;
        }

        private bool WasVisited(Coords loc)
        {
            if (VisitedCoords.TryGetValue(loc, out Coords foundCoords))
            {
                if (foundCoords.VisitState == VisitState.WAS_VISITED)
                    return true;
            }

            loc.VisitState = VisitState.WAS_VISITED;
            VisitedCoords.Add(loc);

            return false;
        }
        /// <summary>
        /// We start off by checking if we've arrived or have already
        /// found the destination.
        ///
        /// Otherwise, go in the same direction and go as far as we
        /// can either 'til we hit a wall or the end of the array or
        /// have found the destination.
        ///
        /// If the destination is still not found, we pick a new direction
        /// and repeate the above.
        ///
        /// If we've tried every direction permutation at every stopping
        /// point without encountering the destination, it therefore is unreachable.
        private void ExploreMazeDfs(Coords loc, DIRECTION dir)
        {
            if (WasVisited(loc))
                return;

            if (DestinationFound)
                return;

            // This is when the previous cell wasn't the destination
            if (IsWall(loc))
                return;

            // If the next coord is a wall and we've arrived - bingo!
            if (IsWall(loc.GetNextCoord(dir)))
            {
                if (loc == Destination)
                {
                    DestinationFound = true;
                    return;
                }
            }
            else
            {
                // Try to keep on going the same direction until we stop
                var nextCoord = loc.GetNextCoord(dir);
                ExploreMazeDfs(nextCoord, dir);
            }

            if (DestinationFound)
                return;

            // OK so if we hit here, we've gone as far as we can in `dir`'s
            // direction and haven't found the destination. Hence we try
            // the other three directions.
            var dirs = (DIRECTION[])Enum.GetValues(typeof(DIRECTION));
            foreach (var nextDir in dirs)
            {
                if (nextDir == dir)
                    continue;

                Coords nextCoord = loc.GetNextCoord(nextDir);
                ExploreMazeDfs(nextCoord, nextDir);
            }
        }


        private bool IsWall(Coords loc)
        {
            if (loc.RowIdx >= Maze.Length - 1 || loc.ColIdx >= Maze[0].Length - 1)
                return true;

            return Maze[loc.RowIdx][loc.ColIdx] == (int)CoordType.WALL;
        }
    }
}
