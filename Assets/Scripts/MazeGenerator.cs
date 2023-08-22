using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using UnityEngine;

public class MazeGeneratorCell
{
    public int X;
    public int Y;

    public bool WallLeft = true;
    public bool WallBottom = true;

    public bool Visited = false;
    public int DistanceFromStart;
}

    public class MazeGenerator
{
    static public int Width = 13;
    static public int Height = 13;
    public MazeGeneratorCell[,] GenerateMaze() 
    {
        MazeGeneratorCell[,] maze = new MazeGeneratorCell[Width, Height];

        for (int x = 0; x < maze.GetLength(0); x++)
        {
            for (int y = 0; y < maze.GetLength(1); y++)
            {
                maze[x, y] = new MazeGeneratorCell { X = x, Y = y };
            }
        }

        //Вместо 0 поставил 1
        for (int x = 1; x < maze.GetLength(0); x++)
        {
            maze[x, Height - 1].WallLeft = false;
        }
        for (int y = 1; y < maze.GetLength(1); y++)
        {
            maze[Width - 1, y].WallBottom = false;
        }


        //Вообще не было
        for (int x = 0; x < maze.GetLength(0); x++)
        {
            maze[x, 0] = new MazeGeneratorCell { X = x, Y = 0 };
            maze[x, 0].WallLeft = false;
            maze[x, 0].WallBottom = false;
        }
        for (int y = 0; y < maze.GetLength(1); y++)
        {
            maze[0, y] = new MazeGeneratorCell { X = 0, Y = y };
            maze[0, y].WallLeft = false;
            maze[0, y].WallBottom = false;
        }


        RemoveWallsWithBacktracker(maze);

        PlaceMazeExit(maze);

        return maze;
    }

    private void RemoveWallsWithBacktracker(MazeGeneratorCell[,] maze)
    {
        //Вместо 0 поставил 1 (конкретно на нижней строчке)
        MazeGeneratorCell current = maze[1, 1];
        current.Visited = true;
        Stack<MazeGeneratorCell> stack = new Stack<MazeGeneratorCell>();

        current.DistanceFromStart = 0;
        do
        {
            List<MazeGeneratorCell> unvisitedNeighbours = new List<MazeGeneratorCell>();

            int x = current.X;
            int y = current.Y;

            //Вместо 0 поставил 1
            if (x > 1 && !maze[x - 1, y].Visited) unvisitedNeighbours.Add(maze[x - 1, y]);
            if (y > 1 && !maze[x, y - 1].Visited) unvisitedNeighbours.Add(maze[x, y - 1]);
            if (x < Width - 2 && !maze[x + 1, y].Visited) unvisitedNeighbours.Add(maze[x + 1, y]);
            if (y < Height - 2 && !maze[x, y + 1].Visited) unvisitedNeighbours.Add(maze[x, y + 1]);

            if (unvisitedNeighbours.Count > 0)
            {
                MazeGeneratorCell chosen = unvisitedNeighbours[UnityEngine.Random.Range(0, unvisitedNeighbours.Count)];
                RemoveWall(current, chosen);

                chosen.Visited = true;
                stack.Push(chosen);
                current = chosen;
                chosen.DistanceFromStart = stack.Count;
            }
            else
            {
                current = stack.Pop();
            }

        } while (stack.Count > 0);
    }

    private void RemoveWall(MazeGeneratorCell a, MazeGeneratorCell b)
    {
        if (a.X == b.X)
        {
            if (a.Y > b.Y) a.WallBottom = false;
            else b.WallBottom = false;
        }
        else
        {
            if (a.X > b.X) a.WallLeft = false;
            else b.WallLeft = false;
        }
    }

    private void PlaceMazeExit(MazeGeneratorCell[,] maze)
    {
        //Вместо 0 поставил 1
        MazeGeneratorCell furthest = maze[1, 1];

        for (int x = 1; x < maze.GetLength(0); x++)
        {
            if (maze[x, Height - 2].DistanceFromStart > furthest.DistanceFromStart) furthest = maze[x, Height - 2];
            if (maze[x, 1].DistanceFromStart > furthest.DistanceFromStart) furthest = maze[x, 1];

        }

        for (int y = 1; y < maze.GetLength(1); y++)
        {
            if (maze[Width - 2, y].DistanceFromStart > furthest.DistanceFromStart) furthest = maze[Width - 2, y];
            if (maze[1, y].DistanceFromStart > furthest.DistanceFromStart) furthest = maze[1, y];
        }

        if (furthest.X == 1) furthest.WallLeft = false;
        else if (furthest.Y == 1) furthest.WallBottom = false;
        else if (furthest.X == Width - 2) maze[furthest.X + 1, furthest.Y].WallLeft = false;
        else if (furthest.Y == Height - 2) maze[furthest.X, furthest.Y + 1].WallBottom = false;

        EnemyVar.furthestX = furthest.X;
        EnemyVar.furthestY = furthest.Y;

        GameObject Exit = Resources.Load<GameObject>("Exit");

        if (furthest.X == 1) GameObject.Instantiate(Exit, new Vector3(5, 5, furthest.Y * 10 + 5), Quaternion.identity);
        if (furthest.X == Width - 2) GameObject.Instantiate(Exit, new Vector3((Width - 2) * 10 + 15, 5, furthest.Y * 10 + 5), Quaternion.identity);
        if (furthest.Y == 1) GameObject.Instantiate(Exit, new Vector3(furthest.X * 10 + 5, 5, 5), Quaternion.identity);
        if (furthest.Y == Height - 2) GameObject.Instantiate(Exit, new Vector3(furthest.X * 10 + 5, 5, (Height - 2) * 10 + 15), Quaternion.identity);
    }


}