using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobData : MonoBehaviour
{
    public const int mobPx = 32;
    public const int mobPx_half = 16;
    public const int disp_px = 320;
    public const int disp_py = -40;
    private bool enable;
    public bool Enable { get; set; } = false;
    private string mobName;
    public string MobName { get; set; }
    private int mobHp;
    public int MobHp { get; set; }
    private int mobExp;
    public int MobExp { get; set; }

    private int mobAtk;
    public int MobAtk { get; set; }

    private int mobDef;
    public int MobDef { get; set; }
    private int mobX;
    public int MobX { get; set; }
    private int mobY;
    public int MobY { get; set; }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SetMobData(int type,int x, int y)
    {
        Enable = true;
        switch (type)
        {
            case 1:
                MobName = "モスキート";
                MobHp = 5;
                MobExp = 3;
                MobAtk = 5;
                MobDef = 0;
                MobX = x;
                MobY = y;
                break;
            case 2:
                MobName = "ハエさん";
                MobHp = 10;
                MobExp = 5;
                MobAtk = 8;
                MobDef = 0;
                MobX = x;
                MobY = y;
                break;
            case 3:
                MobName = "クモさん";
                MobHp = 25;
                MobExp = 10;
                MobAtk = 15;
                MobDef = 0;
                MobX = x;
                MobY = y;
                break;
            case 4:
                MobName = "G";
                MobHp = 50;
                MobExp = 25;
                MobAtk = 25;
                MobDef = 0;
                MobX = x;
                MobY = y;
                break;
            default: break;

        }
        Vector3 p = transform.position;
        p.x = MobX * mobPx + mobPx_half + disp_px;
        p.y = MobY * mobPx + mobPx_half + disp_py;
        p.z = -1;
        transform.position = p;


    }

}
