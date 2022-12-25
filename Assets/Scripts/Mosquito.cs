using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mosquito : MobData
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public  void SetMobData(int x ,int y)
    {
        Enable = true;
        MobName = "モスキート";
        MobHp = 5;
        MobExp = 3;
        MobAtk = 5;
        MobDef = 0;
        MobX = x;
        MobY = y;
        Vector3 p = transform.position;
        p.x = MobX * mobPx + mobPx_half;
        p.y = MobY * mobPx + mobPx_half + disp_px;
        p.z = -1;
        transform.position = p;
    }
}
