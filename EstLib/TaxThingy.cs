namespace EstLib;

public static class Taxes
{
    public static List<TaxThingy> Thingies = new()
    {
        new()
        {
            Year = 2022,
            Grundfreibetrag = 10347,
            GrundfreibetragEhe = 20694,

            TarifZone2Bis = 14926,
            TarifZone2Multiplier = 1088.67m,
            TarifZone2Const2 = 1400,

            TarifZone3Bis = 58596,
            TarifZone3Multiplier = 206.43m,
            TarifZone3Const2 = 2397,
            TarifZone3ToAdd = 869.32m,

            TarifZone4Bis = 277825,
            TarifZone4Satz = 0.42m,
            TarifZone4Abzug = 9336.45m,
            
            TarifZone5Ab = 277826,
            TarifZone5Satz = 0.45m,
            TarifZone5Abzug = 17671.2m,
        }
    };
}

public class TaxThingy
{
    public int Year { get; set; }

    public decimal Grundfreibetrag { get; set; }
    public decimal GrundfreibetragEhe { get; set; }

    public decimal TarifZone2Bis { get; set; }
    public decimal TarifZone2Multiplier { get; set; }
    public decimal TarifZone2Const2 { get; set; }

    public decimal TarifZone3Bis { get; set; }
    public decimal TarifZone3Multiplier { get; set; }
    public decimal TarifZone3Const2 { get; set; }
    public decimal TarifZone3ToAdd { get; set; }

    public decimal TarifZone4Bis { get; set; }
    public decimal TarifZone4Satz { get; set; }
    public decimal TarifZone4Abzug { get; set; }

    public decimal TarifZone5Ab { get; set; }
    public decimal TarifZone5Satz { get; set; }
    public decimal TarifZone5Abzug { get; set; }
}