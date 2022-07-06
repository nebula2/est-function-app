using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstLib;

public interface ITaxService
{
    decimal GetTax(int year, bool isSingle, decimal taxableIncome);
}
