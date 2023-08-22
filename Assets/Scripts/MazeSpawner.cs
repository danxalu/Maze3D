using UnityEngine;
using UnityEngine.UIElements;

public class MazeSpawner : MonoBehaviour
{
    public Cell CellPrefab;
    public GameObject Crystal;
    static public Vector3 CellSize = new Vector3(10, 0, 10);
    private void Start()
    {
        MazeGenerator generator = new MazeGenerator();
        MazeGeneratorCell[,] maze = generator.GenerateMaze();
        byte r = (byte)Random.Range(10, 255);
        int random = Random.Range(1, 4);
        Color color1() {
            byte g1 = (byte)Random.Range(10, 255);
            if (random == 1) { return new Color32(r, g1, g1, 255); }
            else if (random == 2) { return new Color32(g1, r, g1, 255); }
            else { return new Color32(g1, g1, r, 255); }
        }
        Color color2()
        {
            byte g1 = (byte)Random.Range(10, 255);
            byte g2 = (byte)Random.Range(10, 255);
            if (random == 1) { return new Color32(r, g1, g2, 255); }
            else if (random == 2) { return new Color32(g1, r, g2, 255); }
            else { return new Color32(g1, g1, r, 255); }
        }
        Color color3()
        {
            byte g1 = (byte)Random.Range(10, 255);
            if (random == 1) { return new Color32(r, g1, g1, 255); }
            else if (random == 2) { return new Color32(g1, r, g1, 255); }
            else { return new Color32(g1, g1, r, 255); }
        }
        Color color4()
        {
            byte g1 = (byte)Random.Range(10, 255);
            byte g2 = (byte)Random.Range(10, 255);
            if (random == 1) { return new Color32(r, g1, g2, 255); }
            else if (random == 2) { return new Color32(g1, r, g2, 255); }
            else { return new Color32(g1, g1, r, 255); }
        }

        Color color5()
        {
            byte g1 = (byte)Random.Range(10, 255);
            byte g2 = (byte)Random.Range(10, 255);
            if (random == 1) {
                Color.RGBToHSV(new Color32(r, g1, g2, 255), out float H, out float S, out float V);
                return Color.HSVToRGB(H, 0.25f, 0.99f);
            }
            else if (random == 2) {
                Color.RGBToHSV(new Color32(g1, r, g2, 255), out float H, out float S, out float V);
                return Color.HSVToRGB(H, 0.25f, 0.99f);
            }
            else { 
                Color.RGBToHSV(new Color32(g1, g1, r, 255), out float H, out float S, out float V);
                return Color.HSVToRGB(H, 0.25f, 0.99f);
            }
        }

        void CrystalSpawner(float x, float y)
        {
            int ran = Random.Range(1, 6);
            if (ran == 1) Instantiate(Crystal, new Vector3(x, 3, y), Quaternion.identity);
        }

        GameObject Camera = GameObject.FindGameObjectWithTag("MainCamera");
        Camera.GetComponent<Camera>().backgroundColor = color5();

        for (int x = 0; x < maze.GetLength(0); x++)
        {
            for (int y = 0; y < maze.GetLength(1); y++)
            {
                Cell c = Instantiate(CellPrefab, new Vector3(x * CellSize.x, y * CellSize.y, y * CellSize.z), Quaternion.identity);

                c.WallLeft.SetActive(maze[x, y].WallLeft);
                c.WallLeft.GetComponent<Renderer>().material.color = color1();
                c.WallLeft.GetComponent<Renderer>().material.SetColor("_EmissionColor", color2());
                c.WallBottom.SetActive(maze[x, y].WallBottom);
                c.WallBottom.GetComponent<Renderer>().material.color = color1();
                c.WallBottom.GetComponent<Renderer>().material.SetColor("_EmissionColor", color2());
                c.Floor.GetComponent<Renderer>().material.color = color3();
                c.Floor.GetComponent<Renderer>().material.SetColor("_EmissionColor", color4());

                if(x > 0 && x < maze.GetLength(0) - 1 && y > 0 && y < maze.GetLength(1) - 1 && !(x == 1 && y == 1)) CrystalSpawner(x * CellSize.x + CellSize.z / 2, y * CellSize.z + CellSize.z/2);
            }
        }

    }
}