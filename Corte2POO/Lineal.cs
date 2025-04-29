namespace Corte2POO
{
    /* 
     * Nombre 1:  LUIS FELIPE PADILLA ARENAS
     * Nombre 2:  DANIEL FELIPE CELIS
     * */

        internal class Lineal : ClaseMadre
        {
            private double[] coeficientes = new double[7]; // Almacena los coeficientes A-G
            private double minimo, maximo, paso;
            private (double X, double Y)[] puntos; // Array para almacenar los puntos calculados

            public void Coeficientes(double valA, double valB, double valC, double valD, double valE, double valF, double valG)
            {
                coeficientes[0] = valA;
                coeficientes[1] = valB;
                coeficientes[2] = valC;
                coeficientes[3] = valD;
                coeficientes[4] = valE;
                coeficientes[5] = valF;
                coeficientes[6] = valG;
            }

            private double CalcularY(double x)
            {
                return coeficientes[0] * Math.Pow(x, 6) +
                       coeficientes[1] * Math.Pow(x, 5) +
                       coeficientes[2] * Math.Pow(x, 4) +
                       coeficientes[3] * Math.Pow(x, 3) +
                       coeficientes[4] * Math.Pow(x, 2) +
                       coeficientes[5] * x +
                       coeficientes[6];
            }

            public override void Rango(double Minimo, double Maximo)
            {
                minimo = Minimo;
                maximo = Maximo;
            }

            public override void setPaso(double Paso)
            {
                paso = Paso;
            }

            public void GenerarPuntos()
            {
                int cantidadPuntos = (int)((maximo - minimo) / paso) + 1;
                puntos = new (double X, double Y)[cantidadPuntos];

                for (int i = 0; i < cantidadPuntos; i++)
                {
                    double x = minimo + i * paso;
                    puntos[i] = (x, CalcularY(x));
                }
            }

            public override int TotalPuntosCorte()
            {
                GenerarPuntos();
                return puntos.Zip(puntos.Skip(1), (p1, p2) => p1.Y * p2.Y < 0).Count(cambio => cambio);
            }

            public override bool ExistePuntoCorte(int Punto)
            {
                GenerarPuntos();
                int contador = 0;

                for (int i = 1; i < puntos.Length; i++)
                {
                    if (puntos[i - 1].Y * puntos[i].Y < 0)
                    {
                        contador++;
                        if (contador == Punto)
                            return true;
                    }
                }
                return false;
            }

            public override double ValorPuntoCorte(int Punto)
            {
                GenerarPuntos();
                int contador = 0;

                for (int i = 1; i < puntos.Length; i++)
                {
                    if (puntos[i - 1].Y * puntos[i].Y < 0)
                    {
                        contador++;
                        if (contador == Punto)
                            return (puntos[i - 1].X + puntos[i].X) / 2.0;
                    }
                }
                return double.NaN;
            }

            public override double MaximoValorY()
            {
                GenerarPuntos();
                return puntos.Max(p => p.Y);
            }

            public override double MinimoValorY()
            {
                GenerarPuntos();
                return puntos.Min(p => p.Y);
            }

            public int CasosCalcularArea(double Xini, double Xfin)
            {
                int numPuntos = 10000;
                double pasoInterno = (Xfin - Xini) / numPuntos;
                bool hayPositivos = false, hayNegativos = false;

                for (double x = Xini; x <= Xfin; x += pasoInterno)
                {
                    double y = CalcularY(x);
                    if (y > 0) hayPositivos = true;
                    if (y < 0) hayNegativos = true;

                    if (hayPositivos && hayNegativos)
                        return 0;
                }

                return hayPositivos ? 1 : -1;
            }
        }
    }
