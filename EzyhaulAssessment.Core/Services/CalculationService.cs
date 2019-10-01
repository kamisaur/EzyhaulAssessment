using System;
using System.Collections.Generic;
using System.Text;

namespace EzyhaulAssessment.Core.Services
{
	public class CalculationService : ICalculationService
	{
		public double TipAmount(double subTotal, int generosity)
		{
			return subTotal * ((double)generosity) / 100.0;
		}
	}
}
