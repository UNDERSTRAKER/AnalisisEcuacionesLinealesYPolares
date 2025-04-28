using System;
using System.Collections.Generic;

namespace Corte2POO
{
    /* 
     * Nombre 1:  LUIS FELIPE PADILLA ARENAS
     * Nombre 2:  DANIEL FELIPE CELIS
     * */
    class Polar : ClaseMadre
    {
        private double valA, valB;
        private double Xminimo, Xmaximo, paso;

        private List<double> simTetha = new();
        private List<double> pCortes = new();
        private List<double> Yvalores = new();

        // Ingresa los coeficientes para ecuación polar: r = a * sin(b * θ * π/180)
        public void Coeficientes(double valA, double valB)
        {
            this.valA = valA;
            this.valB = valB;
        }

        private double ValorR(double Theta)
        {
            double anguloConvert = valB * Theta;
            double radianes = anguloConvert * Math.PI / 180;
            double resultado = valA * Math.Sin(radianes);
            return resultado;
        }

        private double ValorX(double R, double Theta)
        {
            double radianes = Theta * Math.PI / 180;
            double x = R * Math.Cos(radianes);
            return x;
        }

        private double ValorY(double R, double Theta)
        {
            double radianes = Theta * Math.PI / 180;
            double y = R * Math.Sin(radianes);
            return y;
        }

        public override void Rango(double Minimo, double Maximo)
        {
            Xminimo = Minimo;
            Xmaximo = Maximo;
            RecalcularVal();
        }

        public override void setPaso(double Paso)
        {
            paso = Paso;
            RecalcularVal();
        }

        private void RecalcularVal()
        {
            simTetha.Clear();
            pCortes.Clear();
            Yvalores.Clear();

            for (double Theta = Xminimo; Theta <= Xmaximo; Theta += paso)
            {
                double r = ValorR(Theta);
                double y = ValorY(r, Theta);

                simTetha.Add(Theta);
                Yvalores.Add(y);
            }

            for (int i = 1; i < Yvalores.Count; i++)
            {
                if (Yvalores[i - 1] * Yvalores[i] < 0) // Cambio de signo → Punto de corte
                {
                    double corte = (simTetha[i - 1] + simTetha[i]) / 2.0;
                    pCortes.Add(corte);
                }
            }
        }

        public override int TotalPuntosCorte()
        {
            return pCortes.Count;
        }

        public override bool ExistePuntoCorte(int Punto)
        {
            return Punto > 0 && Punto <= pCortes.Count;
        }

        public override double ValorPuntoCorte(int Punto)
        {
            if (ExistePuntoCorte(Punto))
            {
                return pCortes[Punto - 1];
            }
            else
            {
                // Cambiado para uniformizar comportamiento con la clase Lineal
                return double.NaN;
            }
        }

        public override double MaximoValorY()
        {
            if (Yvalores.Count == 0) return 0;

            double max = Yvalores[0];
            foreach (double y in Yvalores)
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
            if (Yvalores.Count == 0) return 0;

            double min = Yvalores[0];
            foreach (double y in Yvalores)
            {
                if (y < min)
                {
                    min = y;
                }
            }
            return min;
        }

        public double MaximoValorX()
        {
            double maxX = double.MinValue;
            for (int i = 0; i < simTetha.Count; i++)
            {
                double theta = simTetha[i];   // Tomamos el ángulo real
                double r = ValorR(theta);     // Calculamos el radio r de forma correcta
                double x = ValorX(r, theta);  // Calculamos X correctamente
                if (x > maxX)
                {
                    maxX = x;
                }
            }
            return maxX;
        }

        public double MinimoValorX()
        {
            double minX = double.MaxValue;
            for (int i = 0; i < simTetha.Count; i++)
            {
                double theta = simTetha[i];   // Tomamos el ángulo real
                double r = ValorR(theta);     // Calculamos r correctamente
                double x = ValorX(r, theta);  // Calculamos X correctamente
                if (x < minX)
                {
                    minX = x;
                }
            }
            return minX;
        }
    }
}