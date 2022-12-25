using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public enum EndRank {S,A,B,C,D};
    public static EndRank ERank;

    public Text GUI_turn;
    public Text GUI_Lv;
    public Text GUI_Hp;
    public Text GUI_MaxHp;
    public Text GUI_Atk;
    public Text GUI_Def;
    public Text GUI_Wepon;
    public Text GUI_Armor;
    public Text GUI_X;
    public Text GUI_Y;
    public Text GUI_Log1;
    public Text GUI_Log2;
    public Text GUI_Log3;
    public Text GUI_NextLv;
    public double next_x;
    public double next_y;

    public int turn = 0;
    public TileData tilePrefab;
    private const int t_wall = 0;
    private const int t_tile = 1;
    private const int field_w = 15;
    private const int field_h = 15;
    public  TileData[,] field_data;

    public CharaData CPrefab;
    public GameObject NPCPrefab;

    private GameObject NPC;
    private int npcX = 7;
    private int npcY = 8;
    private int NpcCnt = 0;
    private int enCnt = 0;


    private CharaData chara;
    public MobManager MManager;
    public EventSystem EV;
    public double movecnt = 0;

    // Start is called before the first frame update
    void Start()
    {
        CreateField();
        SetChara();
        SetMob();
    }

    // Update is called once per frame
    void Update()
    {
        EV.CheckEvent(NpcCnt,chara);
        if (EV.PM == EventSystem.PlayMode.PLAY_SEQ)
        {
            int x = 0;
            int y = 1;
            // 左に移動
            if (EV.AM == EventSystem.ActMode.STAY_SEQ)
            {
                if (Input.GetKeyDown("a"))
                {
                    EV.AM = EventSystem.ActMode.LEFTMOVE_SEQ;
                    CheckMove(x, -1);
                }
                // 右に移動
                if (Input.GetKeyDown("d"))
                {
                    EV.AM = EventSystem.ActMode.RIGHTMOVE_SEQ;
                    CheckMove(x, 1);
                }
                // 前に移動
                if (Input.GetKeyDown("w"))
                {
                    EV.AM = EventSystem.ActMode.UPMOVE_SEQ;
                    CheckMove(y, 1);
                }
                // 後ろに移動
                if (Input.GetKeyDown("s"))
                {
                    EV.AM = EventSystem.ActMode.DOWNMOVE_SEQ;
                    CheckMove(y, -1);
                }
                if (Input.GetKeyDown("e"))
                {
#if UNITY_EDITOR
                    UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_STANDALONE
                UnityEngine.Application.Quit();
#endif
                }
            }
            else
            {
                switch (EV.AM)
                {
                    case EventSystem.ActMode.UPMOVE_SEQ:
                        CheckMove(y, 1);
                        break;
                    case EventSystem.ActMode.LEFTMOVE_SEQ:
                        CheckMove(x, -1);
                        break;
                    case EventSystem.ActMode.RIGHTMOVE_SEQ:
                        CheckMove(x, 1);
                        break;
                    case EventSystem.ActMode.DOWNMOVE_SEQ:
                        CheckMove(y, -1);
                        break;

                }
            }
        }
            SetGUI();
    }

    void CheckMove(int type,int move){
        Debug.Log(EV.AM);
        int nx = 0;
        int ny = 0;
        if(type == 0){
            nx = chara.CharaX + move;
            ny = chara.CharaY;
        }else{
            nx = chara.CharaX;
            ny = chara.CharaY + move;
        }
        MobData MD = MManager.GetMob(nx,ny);
        if(MD == null){
            int moveCheak = TileCheck(nx, ny);
            if (0 < moveCheak)
            {
                if (nx == npcX && ny == npcY)
                {
                    NPCEvent();
                    EV.setSTAY();
                }
                else
                {
                   // Debug.Log(movecnt == 1);/
                    if ((int)movecnt == 1)
                    {
                        //Debug.Log("true:" + movecnt);
                        chara.CharaX = nx;
                        chara.CharaY = ny;
                        chara.CharaMove();
                        movecnt = 0;
                        EV.setSTAY();
                    }
                    else
                    {
                        movecnt = movecnt + 0.2;
                        //Debug.Log("else:"+ movecnt);
                        double movex = 0;
                        double movey = 0;
                        switch (EV.AM)
                        {
                            case EventSystem.ActMode.UPMOVE_SEQ:
                                movey = 32 * movecnt * move;
                                chara.CharaMove((int)movex,(int)movey);
                                break;
                            case EventSystem.ActMode.LEFTMOVE_SEQ:
                                movex = 32 * movecnt * move;
                                chara.CharaMove((int)movex, (int)movey);
                                break;
                            case EventSystem.ActMode.RIGHTMOVE_SEQ:
                                movex = 32 * movecnt * move;
                                chara.CharaMove((int)movex, (int)movey);
                                break;
                            case EventSystem.ActMode.DOWNMOVE_SEQ:
                                movey = 32 * movecnt * move;
                                chara.CharaMove((int)movex, (int)movey);
                                break;
                                
                        }
                    }
                }
            }
        }else
        {
            Battle(MD, nx, ny);
            EV.setSTAY();
        }
        if (EV.AM == EventSystem.ActMode.STAY_SEQ) {
            TurnCount();
        }
    }

    void NPCEvent()
    {
        Debug.Log("ミクに話しかけるよ");
        NpcCnt++;
        Debug.Log(NpcCnt);
        EV.CheckEvent(NpcCnt, chara);
    }

    void Battle(MobData MD,int x,int y){
        int damage = chara.GetAttack() - MD.MobDef;
        if (damage < 0) damage = 0;
        MD.MobHp = MD.MobHp - damage;
        string str = MD.MobName + "に攻撃！" + damage.ToString() + "のダメージ！！";
        SetLog(str);
        
        if(MD.MobHp < 0)
        {
            int exp = MD.MobExp;
            str = MD.MobName + "を倒した！" + exp.ToString() + "の経験値を手に入れた！";
            SetLog(str);
            MManager.destroyMob(x, y);
            CheckEnd();
            if (chara.GetExp(exp))
            {
                str = "レベルが上がった！！";
                SetLog(str);
            }
        }
        else
        {
            damage = MD.MobAtk - chara.GetDef();
            if (damage < 0) damage = 0;
            str = MD.MobName + "の攻撃！" + damage.ToString() + "のダメージを受けた！！";
            SetLog(str);
            
            if (chara.GetDamage(damage))
            {
                GameOver();
            }
        }
    }

    void SetLog(string log)
    {
        GUI_Log3.text = GUI_Log2.text;
        GUI_Log2.text = GUI_Log1.text;
        GUI_Log1.text = log;
        
    }
    int TileCheck(int nx, int ny){
        int checkT = field_data[nx,ny].GetTile();
        return checkT;
    }

    void TurnCount(){
        turn++;
    }

    void CreateField()
    {
         
        field_data = new TileData[field_w, field_h];
        for (int w = 0;w < field_w; w++)
        {
            for(int h = 0;h < field_h; h++)
            {
                int type = 0;
                if (0 < w && w < field_w - 1)
                {
                    if (0 < h && h < field_h -1)
                    {
                        type = t_tile;
                    }
                    else
                    {
                        type = t_wall;
                    }
                }
                else
                {
                    type = t_wall;
                }

                field_data[w, h] = Instantiate(tilePrefab);
                field_data[w, h].SetTileData(w, h, type);
            }
        }
        
    }

    void SetChara()
    {
       chara = Instantiate(CPrefab);
        NPC = Instantiate(NPCPrefab);
        Vector3 p = NPC.transform.position;
        p.x = npcX * 32 + 16 + 320;
        p.y = npcY * 32 - 25;
        p.z = -2;
        Debug.Log(p.x);
        NPC.transform.position = p;

        //chara.CharaInit();
    }

    void SetMob()
    {
        MManager.CreateMobData(field_w, field_h);
    }
    void SetGUI()
    {
        GUI_turn.text = turn.ToString();
        GUI_Lv.text = chara.CharaLv.ToString();
        GUI_Hp.text = chara.CharaHp.ToString();
        GUI_MaxHp.text = chara.CharaMaxHp.ToString();
        int atk = chara.CharaAtk + chara.CharaWepon;
        GUI_Atk.text = atk.ToString();
        int def = chara.CharaDef + chara.CharaArmor;
        GUI_Def.text = def.ToString(); 
        GUI_Wepon.text = chara.WeponName.ToString();
        GUI_Armor.text = chara.ArmorName.ToString();
        GUI_X.text = chara.CharaX.ToString();
        GUI_Y.text = chara.CharaY.ToString();
        int NLv;
        NLv = chara.GetNLv();
        GUI_NextLv.text = NLv.ToString();

    }
    //実装なう
    void CheckEnd()
    {
        enCnt++;
        if (enCnt == 55)
        {
            GameClear(turn);
        }
    }

    void GameClear(int turnCnt)
    {
        if(turnCnt <= 180)
        {
            ERank = EndRank.S;
        }else
        if (turnCnt <= 220)
        {
            ERank = EndRank.A;
        }
        else
        if (turnCnt <= 250)
        {
            ERank = EndRank.B;
        }
        else
        {
            ERank = EndRank.C;
        }
        SceneManager.LoadScene("EndingScene");

    }
    void GameOver()
    {
        EV.GORTN();
    }
}
