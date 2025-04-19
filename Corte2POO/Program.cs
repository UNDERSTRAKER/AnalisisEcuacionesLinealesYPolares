namespace Corte2POO {
    /* 
     * Nombre 1:  LUIS FELIPE PADILLA ARENAS
     * Nombre 2:  DANIEL FELIPE CELIS
    * */

    internal class Program {
        static void Main() {
            Random Azar = new();

            Console.WriteLine("Nombre 1: XXXXX -- YYaaaqYYYYdd - VVVBjjj@@@KKKKK - bnTTYYUI  Código: 99988888888888888888");
            Console.WriteLine("Nombre 2: EWRQE -- DFSMNJERJKHC - ÑÑLÑNKJHGTFFFGG - HHFUJKGG  Código: 24546545465432465757");

            //Usando su clase
            Console.WriteLine("================ ECUACIÓN A: LINEAL ================");
            Lineal objPolinomio = new();

            double Xminimo = -7;
            double Xmaximo = 7;
            objPolinomio.Coeficientes(0.1, 0.6, -0.9, -6, 0, 4, 1);
            objPolinomio.Rango(Xminimo, Xmaximo);
            objPolinomio.setPaso(0.1);

            Console.WriteLine("Polinomio Grado 6");
            Console.WriteLine("Total de puntos de corte: " + objPolinomio.TotalPuntosCorte());
            Console.WriteLine("Máximo valor de Y: " + objPolinomio.MaximoValorY());
            Console.WriteLine("Mínimo valor de Y: " + objPolinomio.MinimoValorY());

            //Imprime los puntos de corte
            Console.WriteLine("Puntos de corte:");
            int Punto = 1;
            while (objPolinomio.ExistePuntoCorte(Punto)) {
                Console.WriteLine("X = " + objPolinomio.ValorPuntoCorte(Punto));
                Punto++;
            }

            /*
             * La integral de una función Y = F(X) sobre un intervalo (a, b) calcula el área neta entre la curva y el eje X.
             * Esto significa que las áreas por encima del eje X son positivas y las áreas por debajo del eje X son negativas.
             * Para calcular el área total en un rango [a,b] debería:
             * a. Saber si hay uno o más puntos de corte
             * b. La curva en ese rango está por encima del eje X
             * c. La curva en ese rango está por debajo del eje X
             * Son tres posibilidades, luego el método PosibleCalcularArea debe retornar:
             * 1 La curva en ese rango está por encima del eje X
             * -1 La curva en ese rango está por debajo del eje X
             * 0  La curva en ese rango tiene uno o más cortes
             * */
            Console.WriteLine("Cálculo de áreas (no hay corte en el rango dado)");
            for (int Cont=1; Cont <=10; Cont++){
                double Xizq, Xder;
                do {
                    Xizq = (Xmaximo - Xminimo) * Azar.NextDouble() + Xminimo;
                    Xder = (Xmaximo - Xminimo) * Azar.NextDouble() + Xminimo;
                } while (Xder < Xizq);
                int PuedeCalcular = objPolinomio.CasosCalcularArea(Xizq, Xder);

                Console.Write("La curva entre: " + Xizq + " y " + Xder + ": ");
                switch (PuedeCalcular) {
                    case 1: Console.WriteLine("Está por encima del eje X"); break;
                    case -1: Console.WriteLine("Está por debajo del eje X"); break;
                    case 0: Console.WriteLine("Tiene uno o más cortes"); break;
                }
            }

            //Usando su clase
            Console.WriteLine("\r\n\r\n================ ECUACIÓN B: POLAR ================");
            Polar objPolar = new();

            double ThetaMinimo = 20;
            double ThetaMaximo = 246;
            objPolar.Coeficientes(3, 1.4);

            objPolar.Rango(ThetaMinimo, ThetaMaximo);
            objPolar.setPaso(1);

            Console.WriteLine("Ecuación polar");
            Console.WriteLine("Total de puntos de corte: " + objPolar.TotalPuntosCorte());
            Console.WriteLine("Máximo valor de X: " + objPolar.MaximoValorX());
            Console.WriteLine("Mínimo valor de X: " + objPolar.MinimoValorX());
            Console.WriteLine("Máximo valor de Y: " + objPolar.MaximoValorY());
            Console.WriteLine("Mínimo valor de Y: " + objPolar.MinimoValorY());

            //Imprime los puntos de corte
            Console.WriteLine("Puntos de corte:");
            Punto = 1;
            while (objPolar.ExistePuntoCorte(Punto)) {
                Console.WriteLine("X = " + objPolar.ValorPuntoCorte(Punto));
                Punto++;
            }
        }
    }
}
