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

        result += "    OWNER" + owner.ToString() + "\n";
        result += "    X" + x.ToString() + "\n";
        result += "    Y" + y.ToString() + "\n";
        result += "    MAXHP" + maxhp.ToString() + "\n";
        result += "    HP" + hp.ToString() + "\n";
        result += "    ENUM" + @enum.ToString() + "\n";

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
    public List<string> towers { get; set; }
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

        for(int itr = 0; itr<towers.Count; itr++)
        {
            result += "  " + towers[itr] + "\n";
        }

        for(int troop = 0; troop<troops.Count; troop++)
        {
            result += "  " + troops[troop].PrintData() + "\n";
        }


        result += "  MAINCORE: " + mainCore.PrintData() + "\n";

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
        result = "WIDTH: " + w.ToString() + "\n HEIGHT: " + h.ToString() + "\n";
        result += "P1: \n" + p1.PrintData();
        result += "P2: \n" + p2.PrintData();
        return result;
    }
}


/*public class Troop
{
    public int owner { get; set; }
    public int x { get; set; }
    public int y { get; set; }
    public int maxhp { get; set; }
    public int hp { get; set; }
    public int @enum { get; set; }
}

public class MainCore
{
    public int owner { get; set; }
    public int x { get; set; }
    public int y { get; set; }
    public int maxhp { get; set; }
    public int hp { get; set; }
    public int @enum { get; set; }
}

public class P1
{
    public int owner { get; set; }
    public int income { get; set; }
    public int bits { get; set; }
    public int horizonMin { get; set; }
    public int horizonMax { get; set; }
    public int territoryMin { get; set; }
    public int territoryMax { get; set; }
    public List<string> towers { get; set; }
    public List<Troop> troops { get; set; }
    public MainCore mainCore { get; set; }
}

public class MainCore2
{
    public int owner { get; set; }
    public int x { get; set; }
    public int y { get; set; }
    public int maxhp { get; set; }
    public int hp { get; set; }
    public int @enum { get; set; }
}

public class P2
{
    public int owner { get; set; }
    public int income { get; set; }
    public int bits { get; set; }
    public int horizonMin { get; set; }
    public int horizonMax { get; set; }
    public int territoryMin { get; set; }
    public int territoryMax { get; set; }
    public List<string> towers { get; set; }
    public List<object> troops { get; set; }
    public MainCore2 mainCore { get; set; }
}

public class RoboData
{
    public int w { get; set; }
    public int h { get; set; }
    public P1 p1 { get; set; }
    public P2 p2 { get; set; }
}
*/