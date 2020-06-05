using System;


namespace StarkBank
{
    public partial class Boleto
    {
        /// <summary>
        /// Boleto.Discount object
        /// <br/>
        /// Used to define a discount in the boleto
        /// <br/>
        /// Attributes:
        /// <list>
        ///     <item>Date [string]: Date up to when the discount will be applied.ex: "2020-03-12"</item>
        ///     <item>Percentage [double]: discount percentage that will be applied.ex: 2.5</item>
        /// </list>
        /// </summary>
        public class Discount : Utils.SubResource
        {
            public DateTime Date { get; }
            public double Percentage { get; }

            /// <summary>
            /// Boleto.Discount object
            /// <br/>
            /// Used to define a discount in the boleto
            /// <br/>
            /// Attributes:
            /// <list>
            ///     <item>date [string]: Date up to when the discount will be applied.ex: "2020-03-12"</item>
            ///     <item>percentage [double]: discount percentage that will be applied.ex: 2.5</item>
            /// </list>
            /// </summary>
            public Discount(DateTime date, double percentage)
            {
                Date = date;
                Percentage = percentage;
            }
        }
    }
}
