using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileData : MonoBehaviour
{
    private const int tile_px = 32;
    private const int tile_px_half = 16; //タイルPixel幅の半分
    private const int disp_px = 320; //画面表示位置調整ゲタ
    private const int disp_py = 0; //画面表示位置調整ゲタ

    public int tile_x = 0;
    public int tile_y = 0;
    public int tile_type = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SetTileData(int x, int y, int type)
    {
        tile_x = x;
        tile_y = y;
        tile_type = type;

        Vector3 p = transform.position;
        p.x = tile_x * tile_px + tile_px_half + disp_px;
        p.y = tile_y * tile_px + tile_px_half + disp_py;
        transform.position = p;

    }
    public int GetTile(){
        return tile_type;
    }
}
