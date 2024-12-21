using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektNr1_Kuźnicki_61961
{
    internal static class EkstremumSzeregu
    {//deklaracje dwoch metod: MinSx oraz MaxSx
        public static float MinSx(float[,] JKTWS)
        {
            float AktualneMin;
            //
            AktualneMin = JKTWS[0, 1];
            //
            for (int i = 0; i < JKTWS.GetLength(0); i++)
                if (AktualneMin > JKTWS[i, 1])
                    // został znaleziony element mniejszy od AktualneMin i ten będzie nową wartością AktualneMin
                    AktualneMin = JKTWS[i, 1];
            // zwrotne przekazanie wartości minimalnej szeregu potęgowego
            return AktualneMin;
        }
        public static float MaxSx(float[,] JKTWS)
        {
            float AktualneMax;
            // ustalenie stanu początkowego
            AktualneMax = JKTWS[0, 1];
            // analiza TWS i szukanie wartości maksymalnej S(X)
            for (int i = 0; i < JKTWS.GetLength(0); i++)
                if (AktualneMax < JKTWS[i, 1])
                    AktualneMax = JKTWS[i, 1];
            // zwrotne przekazanie wartości maksymalnej szeregu
            return AktualneMax;
        }
    }
}
