namespace Corte2POO
{
    /* 
     * Nombre 1:  LUIS FELIPE PADILLA ARENAS
     * Nombre 2:  DANIEL FELIPE CELIS
     * */

    internal class Program
    {
        static void Main()
        {
            Random Azar = new();

            Console.WriteLine("Nombre 1: LUIS FELIPE PADILLA  Código: 2316668");
            Console.WriteLine("Nombre 2: DANIEL FELIPE CELIS  Código: [INSERTAR CÓDIGO REAL]");

            // PRIMERA PRUEBA - LINEAL
            Console.WriteLine("================ ECUACIÓN A: LINEAL - PRUEBA 1 ================");
            Lineal objPolinomio1 = new();

            double Xminimo1 = -7;
            double Xmaximo1 = 7;
            objPolinomio1.Coeficientes(0.1, 0.6, -0.9, -6, 0, 4, 1);
            objPolinomio1.Rango(Xminimo1, Xmaximo1);
            objPolinomio1.setPaso(0.1);
            objPolinomio1.GenerarPuntos();


            Console.WriteLine("Polinomio Grado 6");
            Console.WriteLine("Total de puntos de corte: " + objPolinomio1.TotalPuntosCorte());
            Console.WriteLine("Máximo valor de Y: " + objPolinomio1.MaximoValorY());
            Console.WriteLine("Mínimo valor de Y: " + objPolinomio1.MinimoValorY());

            //Imprime los puntos de corte
            Console.WriteLine("Puntos de corte:");
            int Punto = 1;
            while (objPolinomio1.ExistePuntoCorte(Punto))
            {
                Console.WriteLine("X = " + objPolinomio1.ValorPuntoCorte(Punto));
                Punto++;
            }

            Console.WriteLine("Cálculo de áreas (no hay corte en el rango dado)");
            for (int Cont = 1; Cont <= 5; Cont++)
            {
                double Xizq, Xder;
                do
                {
                    Xizq = (Xmaximo1 - Xminimo1) * Azar.NextDouble() + Xminimo1;
                    Xder = (Xmaximo1 - Xminimo1) * Azar.NextDouble() + Xminimo1;
                } while (Xder < Xizq);
                int PuedeCalcular = objPolinomio1.CasosCalcularArea(Xizq, Xder);

                Console.Write("La curva entre: " + Xizq + " y " + Xder + ": ");
                switch (PuedeCalcular)
                {
                    case 1: Console.WriteLine("Está por encima del eje X"); break;
                    case -1: Console.WriteLine("Está por debajo del eje X"); break;
                    case 0: Console.WriteLine("Tiene uno o más cortes"); break;
                }
            }

            // SEGUNDA PRUEBA - LINEAL
            Console.WriteLine("\r\n================ ECUACIÓN A: LINEAL - PRUEBA 2 ================");
            Lineal objPolinomio2 = new();

            double Xminimo2 = -5;
            double Xmaximo2 = 5;
            // Diferentes coeficientes para la segunda prueba
            objPolinomio2.Coeficientes(0, 0, 1, -2, -5, 6, 0);
            objPolinomio2.Rango(Xminimo2, Xmaximo2);
            objPolinomio2.setPaso(0.05);
            objPolinomio2.GenerarPuntos();

            Console.WriteLine("Polinomio Grado 4 (los coeficientes A y B son cero)");
            Console.WriteLine("Total de puntos de corte: " + objPolinomio2.TotalPuntosCorte());
            Console.WriteLine("Máximo valor de Y: " + objPolinomio2.MaximoValorY());
            Console.WriteLine("Mínimo valor de Y: " + objPolinomio2.MinimoValorY());

            //Imprime los puntos de corte
            Console.WriteLine("Puntos de corte:");
            Punto = 1;
            while (objPolinomio2.ExistePuntoCorte(Punto))
            {
                Console.WriteLine("X = " + objPolinomio2.ValorPuntoCorte(Punto));
                Punto++;
            }

            Console.WriteLine("Cálculo de áreas (no hay corte en el rango dado)");
            for (int Cont = 1; Cont <= 5; Cont++)
            {
                double Xizq, Xder;
                do
                {
                    Xizq = (Xmaximo2 - Xminimo2) * Azar.NextDouble() + Xminimo2;
                    Xder = (Xmaximo2 - Xminimo2) * Azar.NextDouble() + Xminimo2;
                } while (Xder < Xizq);
                int PuedeCalcular = objPolinomio2.CasosCalcularArea(Xizq, Xder);

                Console.Write("La curva entre: " + Xizq + " y " + Xder + ": ");
                switch (PuedeCalcular)
                {
                    case 1: Console.WriteLine("Está por encima del eje X"); break;
                    case -1: Console.WriteLine("Está por debajo del eje X"); break;
                    case 0: Console.WriteLine("Tiene uno o más cortes"); break;
                }
            }

            // PRIMERA PRUEBA - POLAR
            Console.WriteLine("\r\n================ ECUACIÓN B: POLAR - PRUEBA 1 ================");
            Polar objPolar1 = new();

            double ThetaMinimo1 = 20;
            double ThetaMaximo1 = 246;
            objPolar1.Coeficientes(3, 1.4);

            objPolar1.Rango(ThetaMinimo1, ThetaMaximo1);
            objPolar1.setPaso(1);
            objPolar1.GenerarPuntos();

            Console.WriteLine("Ecuación polar: r = 3 * sin(1.4 * θ * π/180)");
            Console.WriteLine("Total de puntos de corte: " + objPolar1.TotalPuntosCorte());
            Console.WriteLine("Máximo valor de X: " + objPolar1.MaximoValorX());
            Console.WriteLine("Mínimo valor de X: " + objPolar1.MinimoValorX());
            Console.WriteLine("Máximo valor de Y: " + objPolar1.MaximoValorY());
            Console.WriteLine("Mínimo valor de Y: " + objPolar1.MinimoValorY());

            //Imprime los puntos de corte
            Console.WriteLine("Puntos de corte:");
            Punto = 1;
            while (objPolar1.ExistePuntoCorte(Punto))
            {
                Console.WriteLine("X = " + objPolar1.ValorPuntoCorte(Punto));
                Punto++;
            }

            // SEGUNDA PRUEBA - POLAR
            Console.WriteLine("\r\n================ ECUACIÓN B: POLAR - PRUEBA 2 ================");
            Polar objPolar2 = new();

            double ThetaMinimo2 = 0;
            double ThetaMaximo2 = 360;
            objPolar2.Coeficientes(2, 2);

            objPolar2.Rango(ThetaMinimo2, ThetaMaximo2);
            objPolar2.setPaso(0.5);
            objPolar2.GenerarPuntos();

            Console.WriteLine("Ecuación polar: r = 2 * sin(2 * θ * π/180)");
            Console.WriteLine("Total de puntos de corte: " + objPolar2.TotalPuntosCorte());
            Console.WriteLine("Máximo valor de X: " + objPolar2.MaximoValorX());
            Console.WriteLine("Mínimo valor de X: " + objPolar2.MinimoValorX());
            Console.WriteLine("Máximo valor de Y: " + objPolar2.MaximoValorY());
            Console.WriteLine("Mínimo valor de Y: " + objPolar2.MinimoValorY());

            //Imprime los puntos de corte
            Console.WriteLine("Puntos de corte:");
            Punto = 1;
            while (objPolar2.ExistePuntoCorte(Punto))
            {
                Console.WriteLine("X = " + objPolar2.ValorPuntoCorte(Punto));
                Punto++;
            }
        }
    }
}