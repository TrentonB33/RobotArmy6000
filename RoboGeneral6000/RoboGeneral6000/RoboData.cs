using System;
using System.Collections.Generic;
using System.Diagnostics;



public class Unit
{
    public int owner { get; set; }
    public int x { get; set; }
    public int y { get; set; }
    public int maxhp { get; set; }
    public int hp { get; set; }
    public int @enum { get; set; }

    public Unit(string option)
    {
        if(String.Equals(option, "nil"))
        {
            owner = 0;
            x = 0;
            y = 0;
            maxhp = 0;
            hp = 0;
            @enum = -1212;
        }
    }

    public string PrintData()
    {
        string result = "";

        result += "    OWNER" + owner.ToString() + "\n";
        result += "    X" + x.ToString() + "\n";
        result += "    Y" + y.ToString() + "\n";
        result += "    MAXHP" + maxhp.ToString() + "\n";
        result += "    HP" + hp.ToString() + "\n";
        result += "    ENUM" + @enum.ToString() + "\n";

        return result;
    }
}

public class MainCore
{
    public int owner { get; set; }
    public int x { get; set; }
    public int y { get; set; }
    public int maxhp { get; set; }
    public int hp { get; set; }
    public int @enum { get; set; }

    public string PrintData()
    {
        string result = "";

        result += "    OWNER " + owner.ToString() + "\n";
        result += "    X " + x.ToString() + "\n";
        result += "    Y " + y.ToString() + "\n";
        result += "    MAXHP " + maxhp.ToString() + "\n";
        result += "    HP " + hp.ToString() + "\n";
        result += "    ENUM " + @enum.ToString() + "\n";

        return result;
    }
}

public class Player
{
    public int owner { get; set; }
    public int income { get; set; }
    public int bits { get; set; }
    public int horizonMin { get; set; }
    public int horizonMax { get; set; }
    public int territoryMin { get; set; }
    public int territoryMax { get; set; }
    public List<Unit> towers { get; set; }
    public List<Unit> troops { get; set; }
    public MainCore mainCore { get; set; }

    public string PrintData()
    {
        string result;

        result = "  OWNER: " + owner.ToString() + "\n";
        result += "  INCOME: " + income.ToString() + "\n";
        result += "  BITS: " + bits.ToString() + "\n";
        result += "  HORIZON_MIN: " + horizonMin.ToString() + "\n";
        result += "  HORIZON_MAX: " + horizonMax.ToString() + "\n";
        result += "  TERRITORY_MIN: " + territoryMin.ToString() + "\n";
        result += "  TERRITORY_MAX: " + territoryMax.ToString() + "\n";

        result += "\n  TOWERS:\n";
        for(int itr = 0; itr<towers.Count; itr++)
        {
            result += towers[itr].PrintData() + "\n"; ;
        }

        result += "\n  UNITS:\n";
        for (int troop = 0; troop<troops.Count; troop++)
        {
            result += troops[troop].PrintData() + "\n";
        }


        result += "  MAINCORE: \n" + mainCore.PrintData() + "\n";

        return result;
    }
}

public class RoboData
{
    public int w { get; set; }
    public int h { get; set; }
    public Player p1 { get; set; }
    public Player p2 { get; set; }

    public string PrintData()
    {
        string result;
        result = "WIDTH: " + w.ToString() + "\nHEIGHT: " + h.ToString() + "\n";
        result += "P1: \n" + p1.PrintData();
        result += "P2: \n" + p2.PrintData();
        return result;
    }
}