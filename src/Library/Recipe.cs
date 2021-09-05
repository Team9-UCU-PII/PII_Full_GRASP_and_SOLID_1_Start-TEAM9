//-------------------------------------------------------------------------
// <copyright file="Recipe.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//-------------------------------------------------------------------------

using System;
using System.Collections;

namespace Full_GRASP_And_SOLID.Library
{
    public class Recipe
    {
        private ArrayList steps = new ArrayList();

        public Product FinalProduct { get; set; }

        public void AddStep(Step step)
        {
            this.steps.Add(step);
        }

        public void RemoveStep(Step step)
        {
            this.steps.Remove(step);
        }

        public void PrintRecipe()
        {
            Console.WriteLine($"Receta de {this.FinalProduct.Description}:");
            foreach (Step step in this.steps)
            {
                Console.WriteLine($"{step.Quantity} de '{step.Input.Description}' " +
                    $"usando '{step.Equipment.Description}' durante {step.Time} segundos");
            }
        }

        public double GetProductionCost()
        /* Utilizamos el patrón EXPERT que determina que una responsabilidad debe asignarse a la clase experta en la información
        necesaria para cumplirla. Recipe al colaborar con Step accede a la información de todos los pasos de la receta, por lo 
        que puede conocer todos los precios de cada uno de los pasos (que step le otorga a traves de StepTotal)*/
        {
            double result = 0;

            foreach (Step step in this.steps)
            {
                result += step.StepTotal;
            }

            return result;
        }
    }
}


