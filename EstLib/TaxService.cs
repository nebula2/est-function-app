namespace EstLib;

public class TaxService : ITaxService
{
    public decimal GetTax(int year, bool isSingle, decimal taxableIncome)
    {
        var taxThingy = Taxes.Thingies.Single(x => x.Year == year);

        decimal tarifzone2 = 0, tarifzone3 = 0, tarifzone4 = 0, tarifzone5 = 0;

        if (!isSingle)
        {
            taxableIncome /= 2;
        }

        // tarifzone 1 ist grundfreibetrag. da muss nix berechnet werden

        // tarifzone 2
        if (taxableIncome > taxThingy.Grundfreibetrag &&  taxableIncome <= taxThingy.TarifZone2Bis)
        {
            var y = (taxableIncome - taxThingy.Grundfreibetrag) / 10000;
            tarifzone2 = Math.Floor(((taxThingy.TarifZone2Multiplier * y) + taxThingy.TarifZone2Const2) * y);
        }

        // tarifzone 3
        if (taxableIncome > taxThingy.TarifZone2Bis && taxableIncome <= taxThingy.TarifZone3Bis)
        {
            var z = (taxableIncome - taxThingy.TarifZone2Bis) / 10000;
            tarifzone3 = Math.Floor((taxThingy.TarifZone3Multiplier * z + taxThingy.TarifZone3Const2) * z + taxThingy.TarifZone3ToAdd);
        }

        // tarifzone 4
        if (taxableIncome > taxThingy.TarifZone3Bis && taxableIncome <= taxThingy.TarifZone4Bis)
        {
            tarifzone4 = Math.Floor((taxThingy.TarifZone4Satz * taxableIncome) - taxThingy.TarifZone4Abzug);
        }

        // tarifzone 5
        if (taxableIncome > taxThingy.TarifZone4Bis)
        {
            tarifzone5 = Math.Floor((taxThingy.TarifZone5Satz * taxableIncome) - taxThingy.TarifZone5Abzug);
        }


        return (tarifzone2 + tarifzone3 + tarifzone4 + tarifzone5) * (isSingle ? 1 : 2);
    }
}
