using health_calc_pack_dotnet.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace helath_calc_pack_dotnet.Strategy.Base
{
    public  abstract class MacroNutrientBase
    {
        public double GENDER_MUlTIPLIER;
        public MacroNutrientBase(BiologicalGenderEnum sexo)
        {
            GENDER_MUlTIPLIER = (sexo == BiologicalGenderEnum.female) ? 0.8 : 1;
        }
    }
}
