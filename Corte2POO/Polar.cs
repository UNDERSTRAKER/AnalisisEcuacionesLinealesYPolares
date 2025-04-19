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


        //Ingresa los coeficientes para ecuación polar
        // r= a*seno(b*θ*π/180)
        public void Coeficientes(double valA, double valB) {
            this.valA = valA;
            this.valB = valB;
        }

        private double ValorR(double Theta) {

            double anguloConvert = valB * Theta;
            double radianes = anguloConvert * Math.PI / 180;
            double resultado = valA * Math.Sin(radianes);

            return resultado;
        }

        private double ValorX(double R, double Theta) {
            
            double radianes = Theta * Math.PI / 180;
            double x = R * Math.Cos(radianes);

            return x;
        }

        private double ValorY(double R, double Theta) {

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
                if (Yvalores[i - 1] * Yvalores[i] < 0) // cambio de signo
                {
                    double corte = (simTetha[i - 1] + simTetha[i]) / 2.0;
                    pCortes.Add(corte);
                }
            }
        }

        public override int TotalPCorte()
        {
            return pCortes.Count;
        }


        //Retorna el máximo valor de X en el rango dado
        public double MaximoValorX() {
            //Su código va aquí
            return 0;
        }

        //Retorna el mínimo valor de X en el rango dado
        public double MinimoValorX() {
            //Su código va aquí
            return 0;
        }
    }
}
