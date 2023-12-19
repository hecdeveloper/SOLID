using System.Xml.Linq;

namespace SOLID.Example
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SaleWithTaxes sale = new LocalSale(100, "Hector", 0.16m);
            sale.CalculateTaxes();
            sale.Generate();

            AbstractSale sale2 = new ForeignSale(200, "Pepe");
            sale2.Generate();
        }

        public abstract class AbstractSale //T
        {
            protected decimal amount;
            protected string? customer;
            //protected decimal taxes;

            public abstract void Generate();
            //public abstract void CalculateTaxes(); 
        }

        public abstract class SaleWithTaxes : AbstractSale
        {
            protected decimal taxes;
            public abstract void CalculateTaxes();
        }

        public class LocalSale : SaleWithTaxes{

        public LocalSale(decimal amount, string customer, decimal taxes)
        {
            this.amount = amount;
            this.customer = customer;
            this.taxes = taxes;
        }

            public override void Generate()
            {
                Console.WriteLine("procesing sale");
            }
            public override void CalculateTaxes()
            {
                Console.WriteLine("calculating taxes");
            }
        }

        public class SaleInvoice : SaleWithTaxes
        {
            public SaleInvoice(decimal amount, string customer, decimal taxes)
            {
                this.amount = amount;
                this.customer = customer;
                this.taxes = taxes;
            }
            public override void Generate()
            {
                Console.WriteLine("procesing sale");
            }
            public override void CalculateTaxes()
            {
                Console.WriteLine("calculating taxes");
            }
        }


        public class ForeignSale : AbstractSale
        { 

        public ForeignSale(decimal amount, string customer)
        {
            this.amount = amount; 
            this.customer = customer;
        }

            public override void Generate()
            {
                    Console.WriteLine("procesing sale");
            }
        }
    }


}



