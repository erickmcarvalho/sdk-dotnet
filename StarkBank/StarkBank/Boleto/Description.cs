namespace StarkBank
{
    public partial class Boleto
    {
        /// <summary>
        /// Boleto.Description object
        /// <br/>
        /// Used to define a description in the boleto
        /// <br/>
        /// Attributes:
        /// <list>
        ///     <item>Text [string]: text describing a part of the boleto value. ex: "Taxes"</item>
        ///     <item>Amount [integer]: amount to which the text refers to.ex: 120 (=R$1,20)</item>
        /// </list>
        /// </summary>
        public class Description : Utils.SubResource
        {
            public string Text { get; }
            public int? Amount { get; }

            /// <summary>
            /// Boleto.Description object
            /// <br/>
            /// Used to define a description in the boleto
            /// <br/>
            /// Attributes:
            /// <list>
            ///     <item>text [string]: text describing a part of the boleto value. ex: "Taxes"</item>
            ///     <item>amount [integer]: amount to which the text refers to.ex: 120 (=R$1,20)</item>
            /// </list>
            /// </summary>
            public Description(string text, int amount)
            {
                Text = text;
                Amount = amount;
            }

            /// <summary>
            /// Boleto.Description object
            /// <br/>
            /// Used to define a description in the boleto
            /// <br/>
            /// Attributes:
            /// <list>
            ///     <item>text [string]: text describing a part of the boleto value. ex: "Taxes"</item>
            /// </list>
            /// </summary>
            public Description(string text)
            {
                Text = text;
                Amount = null;
            }
        }
    }
}
