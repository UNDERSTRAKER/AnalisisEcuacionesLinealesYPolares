
using System;
using System.Collections.Generic;

namespace Corte2POO
{
    /* 
     * Nombre 1:  LUIS FELIPE PADILLA ARENAS
     * Nombre 2:  DANIEL FELIPE CELIS
     * */
    internal class Lineal : ClaseMadre
    {
        private double valA, valB, valC, valD, valE, valF, valG;

        private double minimo, maximo, paso;

        private List<double> valoresX = new();
        private List<double> valoresY = new();
        private List<double> puntosDeCorte = new();

        public void Coeficientes(double valA, double valB, double valC, double valD, double valE, double valF, double valG)
        {
            this.valA = valA;
            this.valB = valB;
            this.valC = valC;
            this.valD = valD;
            this.valE = valE;
            this.valF = valF;
            this.valG = valG;
        }

        private double ValorY(double ValorX)
        {
            double y = valA * Math.Pow(ValorX, 6)
                     + valB * Math.Pow(ValorX, 5)
                     + valC * Math.Pow(ValorX, 4)
                     + valD * Math.Pow(ValorX, 3)
                     + valE * Math.Pow(ValorX, 2)
                     + valF * ValorX
                     + valG;
            return y;
        }

        public override void Rango(double Minimo, double Maximo)
        {
            minimo = Minimo;
            maximo = Maximo;
            RecalcularValores();
        }

        public override void setPaso(double Paso)
        {
            paso = Paso;
            RecalcularValores();
        }

        private void RecalcularValores()
        {
            valoresX.Clear();
            valoresY.Clear();
            puntosDeCorte.Clear();

            // Generar los valores de X e Y
            for (double x = minimo; x <= maximo; x += paso)
            {
                double y = ValorY(x);
                valoresX.Add(x);
                valoresY.Add(y);
            }

            // Detectar cambios de signo en Y para encontrar puntos de corte
            for (int i = 1; i < valoresY.Count; i++)
            {
                double yAnterior = valoresY[i - 1];
                double yActual = valoresY[i];

                if (yAnterior * yActual < 0) // Cambio de signo detectado
                {
                    double corte = (valoresX[i - 1] + valoresX[i]) / 2.0;
                    puntosDeCorte.Add(corte);
                }
            }
        }

        public override int TotalPuntosCorte()
        {
            return puntosDeCorte.Count;
        }

        public override bool ExistePuntoCorte(int Punto)
        {
            // Verifica que el punto de corte exista
            return Punto >= 1 && Punto <= puntosDeCorte.Count;
        }

        public override double ValorPuntoCorte(int Punto)
        {
            if (ExistePuntoCorte(Punto))
            {
                return puntosDeCorte[Punto - 1];
            }
            else
            {
                return double.NaN; // Si no existe, devuelve NaN
            }
        }

        public override double MaximoValorY()
        {
            if (valoresY.Count == 0) return 0;

            double max = valoresY[0];
            foreach (double y in valoresY)
            {
                if (y > max)
                {
                    max = y;
                }
            }
            return max;
        }

        public override double MinimoValorY()
        {
            if (valoresY.Count == 0) return 0;

            double min = valoresY[0];
            foreach (double y in valoresY)
            {
                if (y < min)
                {
                    min = y;
                }
            }
            return min;
        }

        public int CasosCalcularArea(double Xini, double Xfin)
        {
            double PasoInterno = (Xfin - Xini) / 100.0;
            bool hayPositivos = false;
            bool hayNegativos = false;

            for (double x = Xini; x <= Xfin; x += PasoInterno)
            {
                double y = ValorY(x);
                if (y > 0)
                {
                    hayPositivos = true;
                }
                if (y < 0)
                {
                    hayNegativos = true;
                }
            }

            if (hayPositivos && hayNegativos)
            {
                return 0; // Hay cortes
            }
            else if (hayPositivos)
            {
                return 1; // Está arriba del eje X
            }
            else if (hayNegativos)
            {
                return -1; // Está abajo del eje X
            }
            else
            {
                return 0;
            }
        }
    }
}
