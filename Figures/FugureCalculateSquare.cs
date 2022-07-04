using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures
{
    public static class FugureCalculateSquare
    {
        public static double CalculateSquareAtCompileTime<T>(this T figure) where T : Figure => figure.CalculateSquare();
    }
}
