using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobManager : MonoBehaviour
{
    enum Etype { MOS,FLY,SPDR,G};
    public MobData MosPrefab;
    public MobData FlyPrefab;
    public MobData SpdrPrefab;
    public MobData GPrefab;

    private MobData[,] mobData;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateMobData(int x,int y)
    {
        mobData = new MobData[x,y];
        SetMobData();
    }

    void  SetMobData()
    {
        //モブの配置はここで設定・調整する
        SetMob(Etype.MOS, 1, 3);
        SetMob(Etype.MOS, 3, 1);
        SetMob(Etype.MOS, 1, 4);
        SetMob(Etype.MOS, 4, 1);
        SetMob(Etype.MOS, 5, 5);
        SetMob(Etype.MOS, 9, 5);
        SetMob(Etype.MOS, 2, 3);
        SetMob(Etype.MOS, 3, 2);
        SetMob(Etype.MOS, 3, 4);
        SetMob(Etype.MOS, 4, 3);
        SetMob(Etype.MOS, 6, 11);
        SetMob(Etype.MOS, 7, 10);
        SetMob(Etype.MOS, 8, 11);
        SetMob(Etype.MOS, 7, 12);
        SetMob(Etype.MOS, 10, 10);
        SetMob(Etype.MOS, 10, 11);
        SetMob(Etype.MOS, 11, 10);
        SetMob(Etype.MOS, 10, 12);
        SetMob(Etype.MOS, 12, 10);
        SetMob(Etype.MOS, 1,10);
        SetMob(Etype.MOS, 3,11);
        SetMob(Etype.MOS, 4,13);
        SetMob(Etype.MOS, 4,12);
        SetMob(Etype.MOS, 2,10);
        SetMob(Etype.FLY, 12,12);
        SetMob(Etype.FLY,  3, 3);
        SetMob(Etype.FLY, 10, 3);
        SetMob(Etype.FLY, 11, 3);
        SetMob(Etype.FLY, 12, 3);
        SetMob(Etype.FLY, 11, 4);
        SetMob(Etype.FLY, 11, 2);
        SetMob(Etype.FLY, 11,12);
        SetMob(Etype.FLY, 12,11);
        SetMob(Etype.FLY, 1, 2);
        SetMob(Etype.FLY, 2, 1);
        SetMob(Etype.FLY, 1,11);
        SetMob(Etype.FLY, 2,11);
        SetMob(Etype.FLY, 3,12);
        SetMob(Etype.FLY, 3,13);
        SetMob(Etype.SPDR,11,13);
        SetMob(Etype.SPDR,12,13);
        SetMob(Etype.SPDR,13,13);
        SetMob(Etype.SPDR,13,12);
        SetMob(Etype.SPDR,13,11);
        SetMob(Etype.SPDR,13, 2);
        SetMob(Etype.SPDR,13, 3);
        SetMob(Etype.SPDR,11, 1);
        SetMob(Etype.SPDR,12, 1);
        SetMob(Etype.SPDR, 1,12);
        SetMob(Etype.SPDR, 2,12);
        SetMob(Etype.SPDR, 2,13);
        SetMob(Etype.G, 13, 1);
        SetMob(Etype.G, 2, 2);
        SetMob(Etype.G, 11, 11);
        SetMob(Etype.G, 1, 13);
    }

    void  SetMob(Etype etype,int x,int y)
    {
        int type = 0;
        switch (etype)
        {
            case Etype.MOS: mobData[x, y] = (MobData)Instantiate(MosPrefab);
                type = 1;
                break;
            case Etype.FLY: mobData[x, y] = (MobData)Instantiate(FlyPrefab);
                type = 2;
                break;
            case Etype.SPDR: mobData[x, y] = (MobData)Instantiate(SpdrPrefab);
                type = 3;
                break;
            case Etype.G: mobData[x, y] = (MobData)Instantiate(GPrefab);
                type = 4;
                break;
            default: break;
        }
        mobData[x, y].SetMobData(type, x, y);
    }
    public MobData GetMob(int x,int y){
        MobData MD;
        if(mobData[x,y] == null){
            MD = null;
            return MD;
        }else{
            return MD = mobData[x,y];
        }
    }
    public void destroyMob(int x,int y)
    {
        mobData[x, y].enabled = false;
        Debug.Log("ですとろーい！！");
        Destroy(mobData[x, y].gameObject);
    }



}
