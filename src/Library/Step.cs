//-------------------------------------------------------------------------------
// <copyright file="Step.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//-------------------------------------------------------------------------------

namespace Full_GRASP_And_SOLID.Library
{
    public class Step
    {
        public Step(Product input, double quantity, Equipment equipment, int time)
        {
            this.Quantity = quantity;
            this.Input = input;
            this.Time = time;
            this.Equipment = equipment;
        }

        public Product Input { get; set; }

        public double Quantity { get; set; }

        public int Time { get; set; }

        private double timeInHours 
        //supusimos que la entrada del metodo era en segundos mientras que el costo del equipo es en horas,
        // por lo que añadimos una property que retorne el uso en horas para facilitar el cálculo
        {
            get
            {
                return ((double)(this.Time)/3600);
            }
        }

        public Equipment Equipment { get; set; }

        public double StepTotal
        //la sumatoria de insumos y equipamiento de cada paso se realiza dentro del step ya que 
        //cuenta con el tiempo de uso/cantidad y precio de cada producto/equipo
        { 
            get
            {
                return (this.Input.UnitCost * this.Quantity) + (this.Equipment.HourlyCost * this.timeInHours);
            }
        }
    }
}