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
            private double coefA, coefB;
            private double thetaMin, thetaMax, incremento;

            private List<(double Theta, double R, double X, double Y)> puntos = new(); // Almacena todos los puntos calculados
            private List<double> puntosDeCorte = new(); // Almacena los puntos de corte

            // Configura los coeficientes para la ecuación polar: r = a * sin(b * θ * π/180)
            public void Coeficientes(double a, double b)
            {
                coefA = a;
                coefB = b;
            }

            private double CalcularR(double theta)
            {
                return coefA * Math.Sin(coefB * theta * Math.PI / 180);
            }

            private (double X, double Y) CalcularCoordenadas(double r, double theta)
            {
                double radianes = theta * Math.PI / 180;
                double x = r * Math.Cos(radianes);
                double y = r * Math.Sin(radianes);
                return (x, y);
            }

            public override void Rango(double minimo, double maximo)
            {
                thetaMin = minimo;
                thetaMax = maximo;
            }

            public override void setPaso(double paso)
            {
                incremento = paso;
            }

            // Genera todos los puntos y calcula los puntos de corte
            public void GenerarPuntos()
            {
                puntos.Clear();
                puntosDeCorte.Clear();

                for (double theta = thetaMin; theta <= thetaMax; theta += incremento)
                {
                    double r = CalcularR(theta);
                    var (x, y) = CalcularCoordenadas(r, theta);
                    puntos.Add((theta, r, x, y));
                }

                // Detectar puntos de corte (cambio de signo en Y)
                for (int i = 1; i < puntos.Count; i++)
                {
                    if (puntos[i - 1].Y * puntos[i].Y < 0) // Cambio de signo
                    {
                        double corte = (puntos[i - 1].Theta + puntos[i].Theta) / 2.0;
                        puntosDeCorte.Add(corte);
                    }
                }
            }

            public override int TotalPuntosCorte()
            {
                return puntosDeCorte.Count;
            }

            public override bool ExistePuntoCorte(int punto)
            {
                return punto > 0 && punto <= puntosDeCorte.Count;
            }

            public override double ValorPuntoCorte(int punto)
            {
                if (ExistePuntoCorte(punto))
                {
                    return puntosDeCorte[punto - 1];
                }
                return double.NaN;
            }

            public override double MaximoValorY()
            {
                if (puntos.Count == 0) return 0;
                double maxY = double.MinValue;
                foreach (var punto in puntos)
                {
                    if (punto.Y > maxY)
                    {
                        maxY = punto.Y;
                    }
                }
                return maxY;
            }

            public override double MinimoValorY()
            {
                if (puntos.Count == 0) return 0;
                double minY = double.MaxValue;
                foreach (var punto in puntos)
                {
                    if (punto.Y < minY)
                    {
                        minY = punto.Y;
                    }
                }
                return minY;
            }

            public double MaximoValorX()
            {
                if (puntos.Count == 0) return 0;
                double maxX = double.MinValue;
                foreach (var punto in puntos)
                {
                    if (punto.X > maxX)
                    {
                        maxX = punto.X;
                    }
                }
                return maxX;
            }

            public double MinimoValorX()
            {
                if (puntos.Count == 0) return 0;
                double minX = double.MaxValue;
                foreach (var punto in puntos)
                {
                    if (punto.X < minX)
                    {
                        minX = punto.X;
                    }
                }
                return minX;
            }
        }
    }

