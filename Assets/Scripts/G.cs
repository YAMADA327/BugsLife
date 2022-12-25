using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G : MobData
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public  void SetMobData(int x, int y)
    {
        Enable = true;
        MobName = "G";
        MobHp = 50;
        MobExp = 25;
        MobAtk = 25;
        MobDef = 0;
        MobX = x;
        MobY = y;
        Vector3 p = transform.position;
        p.x = MobX * mobPx + mobPx_half + disp_px;
        p.y = MobY * mobPx + mobPx_half + disp_py;
        p.z = -1;
        transform.position = p;
    }
}
