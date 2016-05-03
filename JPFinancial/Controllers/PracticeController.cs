using System;
using System.Web.Mvc;

namespace JPFinancial.Web.Controllers
{
    public class PracticeController : Controller
    {
        // GET: Practice
        public ActionResult Income()
        {
            var corporateTaxRate = 0.30;


            //Sales Revenue
            var salesRevenue = RandomNumberBetween(2000000, 500000000);
            var salesDiscounts = salesRevenue * (RandomNumberBetween(0.00, 0.02));
            var salesReturns = salesRevenue * (RandomNumberBetween(0.015, 0.0825));
            var totalDiscounts = salesDiscounts + salesReturns;
            var netSalesRevenue = salesRevenue - totalDiscounts; //Sales Revenue - (Sales Discounts + Sales Returns)

            //Cost of Goods Sold
            var beginningInventory = salesRevenue * (RandomNumberBetween(0.05, 0.22));
            var purchases = beginningInventory * (RandomNumberBetween(4, 7.5));
            var purchaseDiscounts = purchases * (RandomNumberBetween(0.005, 0.015));
            var purchaseReturns = purchases * (RandomNumberBetween(0.001, 0.01));
            var purchaseAllowances = purchases * (RandomNumberBetween(0.005, 0.015));
            var netPurchases = purchases - (purchaseDiscounts + purchaseReturns + purchaseAllowances); //Purchases - (Purchase Discounts + Purchase Returns + Purchase Allowances)
            var shippingCharges = purchases * (RandomNumberBetween(0.005, 0.015));
            var totalPurchases = netPurchases + shippingCharges;
            var COGAFS = (netPurchases + shippingCharges) + beginningInventory; //cost of goods available for sale
            var endingInventory = beginningInventory * (RandomNumberBetween(0.60, 1.85));
            var COGS = COGAFS - endingInventory;
            var grossProfit = netSalesRevenue - COGS;

            //Operating Activities
            //--Selling Expenses
            var advertisingExpense = salesRevenue * (RandomNumberBetween(0.005, 0.02));
            var badDebtExpense = salesRevenue * (RandomNumberBetween(0.002, 0.005));
            var miscSellingExpenses = salesRevenue * (RandomNumberBetween(0.003, 0.007));
            var salesForceSalaries = salesRevenue * (RandomNumberBetween(0.005, 0.02));
            var sellingCommissionsExpense = salesRevenue * (RandomNumberBetween(0.020, 0.050));
            var shippingExpense = salesRevenue * (RandomNumberBetween(0.003, 0.006));
            var totalOperatingExpenses = advertisingExpense + badDebtExpense + miscSellingExpenses +
                                         salesForceSalaries + sellingCommissionsExpense + shippingExpense;

            //--Administrative Expenses
            var executiveSalariesExpense = salesRevenue * (RandomNumberBetween(0.025, 0.065));
            var depreciationAmortizationExpense = salesRevenue * (RandomNumberBetween(0.007, 0.025));
            var insuranceExpense = salesRevenue * (RandomNumberBetween(0.004, 0.009));
            var miscAdminExpense = salesRevenue * (RandomNumberBetween(0.001, 0.004));
            var officeSuppliesExpense = salesRevenue * (RandomNumberBetween(0.006, 0.01));
            var rentExpense = salesRevenue * (RandomNumberBetween(0.01, 0.025));
            var utilitiesExpense = salesRevenue * (RandomNumberBetween(0.008, 0.0175));
            var totalAdminExpenses = executiveSalariesExpense + depreciationAmortizationExpense +
                                    insuranceExpense + miscAdminExpense + officeSuppliesExpense +
                                    rentExpense + utilitiesExpense;
            var totalOperatingActivityExpenses = totalOperatingExpenses + totalAdminExpenses;
            var incomeFromOperations = grossProfit - (totalOperatingExpenses + totalAdminExpenses);


            //Other Gains and Losses
            var rentRevenue = salesRevenue * (RandomNumberBetween(0.000, 0.004));
            var interestExpense = salesRevenue * (RandomNumberBetween(0.002, 0.008));
            var totalGainsLosses = rentRevenue - interestExpense;
            var incomeFromContOpsBeforeTaxes = (rentRevenue + (interestExpense * -1)) + incomeFromOperations;
            var incomeTaxExpense = incomeFromContOpsBeforeTaxes * corporateTaxRate;
            var netIncome = incomeFromContOpsBeforeTaxes - incomeTaxExpense;


            //Income Statement Ratios

            var shares = RandomNumberBetween(1000000, 100000000);
            var sharesOutstanding = Math.Truncate(shares);
            var stockPrice = RandomNumberBetween(12.00, 125.00);
            var stockDividend = RandomNumberBetween(0.00, 0.80);

            var EPS = netIncome / sharesOutstanding;
            var grossProfitMargin = grossProfit / netSalesRevenue;
            var operatingProfit = grossProfit - totalOperatingExpenses;
            var operatingProfitMargin = operatingProfit / netSalesRevenue;
            var effTaxRate = (incomeFromContOpsBeforeTaxes / incomeTaxExpense) / 10; // is income from cont. ops. before taxes the same as EBIT??
            var netProfitmargin = netIncome / netSalesRevenue;
            var priceToEarnings = stockPrice / EPS;
            var timesIntEarned = netIncome / interestExpense;
            var dividendYield = stockDividend / stockPrice;

            ViewBag.salesRevenue = salesRevenue.ToString("C");
            ViewBag.salesDiscounts = salesDiscounts.ToString("C");
            ViewBag.salesReturns = salesReturns.ToString("C");
            ViewBag.totalDiscounts = totalDiscounts.ToString("C");
            ViewBag.netSalesRevenue = netSalesRevenue.ToString("C");
            ViewBag.beginningInventory = beginningInventory.ToString("C");
            ViewBag.purchases = purchases.ToString("C");
            ViewBag.purchaseDiscounts = purchaseDiscounts.ToString("C");
            ViewBag.purchaseReturns = purchaseReturns.ToString("C");
            ViewBag.purchaseAllowances = purchaseAllowances.ToString("C");
            ViewBag.netPurchases = netPurchases.ToString("C");
            ViewBag.shippingCharges = shippingCharges.ToString("C");
            ViewBag.totalPurchases = totalPurchases.ToString("C");
            ViewBag.COGAFS = COGAFS.ToString("C");
            ViewBag.endingInventory = endingInventory.ToString("C");
            ViewBag.COGS = COGS.ToString("C");
            ViewBag.grossProfit = grossProfit.ToString("C");
            ViewBag.advertisingExpense = advertisingExpense.ToString("C");
            ViewBag.badDebtExpense = badDebtExpense.ToString("C");
            ViewBag.miscSellingExpenses = miscSellingExpenses.ToString("C");
            ViewBag.salesForceSalaries = salesForceSalaries.ToString("C");
            ViewBag.sellingCommissionsExpense = sellingCommissionsExpense.ToString("C");
            ViewBag.shippingExpense = shippingExpense.ToString("C");
            ViewBag.totalOperatingExpenses = totalOperatingExpenses.ToString("C");
            ViewBag.executiveSalariesExpense = executiveSalariesExpense.ToString("C");
            ViewBag.depreciationAmortizationExpense = depreciationAmortizationExpense.ToString("C");
            ViewBag.insuranceExpense = insuranceExpense.ToString("C");
            ViewBag.miscAdminExpense = miscAdminExpense.ToString("C");
            ViewBag.officeSuppliesExpense = officeSuppliesExpense.ToString("C");
            ViewBag.rentExpense = rentExpense.ToString("C");
            ViewBag.utilitiesExpense = utilitiesExpense.ToString("C");
            ViewBag.totalAdminExpenses = totalAdminExpenses.ToString("C");
            ViewBag.totalOperatingActivityExpenses = totalOperatingActivityExpenses.ToString("C");
            ViewBag.incomeFromOperations = incomeFromOperations.ToString("C");
            ViewBag.rentRevenue = rentRevenue.ToString("C");
            ViewBag.interestExpense = interestExpense.ToString("C");
            ViewBag.totalGainsLosses = totalGainsLosses.ToString("C");
            ViewBag.incomeFromContOpsBeforeTaxes = incomeFromContOpsBeforeTaxes.ToString("C");
            ViewBag.incomeTaxExpense = incomeTaxExpense.ToString("C");
            ViewBag.netIncome = netIncome.ToString("C");
            ViewBag.sharesOutstanding = sharesOutstanding.ToString("N");
            ViewBag.stockPrice = stockPrice.ToString("C");
            ViewBag.stockDividend = stockDividend.ToString("C");
            ViewBag.EPS = EPS.ToString("N");
            ViewBag.grossProfitMargin = grossProfitMargin.ToString("N");
            ViewBag.operatingProfit = operatingProfit.ToString("C");
            ViewBag.operatingProfitMargin = operatingProfitMargin.ToString("N");
            ViewBag.effectiveTaxRate = effTaxRate.ToString("N");
            ViewBag.netProfitmargin = netProfitmargin.ToString("N");
            ViewBag.priceToEarnings = priceToEarnings.ToString("N");
            ViewBag.timesInterestEarned = timesIntEarned.ToString("N");
            ViewBag.dividendYield = dividendYield.ToString("N");

            return View();
        }

        public ActionResult Answer(string answer, string divId, string correctAnswer)
        {
            var modifiedAnswer = answer;

            if (answer == "")
            {
                answer = "0";
            }
            else if (answer[0] == '.')
            {
                modifiedAnswer = answer.Insert(0, "0");
            }
            else
            {
                modifiedAnswer = answer;
            }

            var result = CheckAnswer(modifiedAnswer, divId, correctAnswer);

            return PartialView("_PracticeAnswer", result);
        }

        public object CheckAnswer(string modifiedAnswer, string divId, string correctAnswer)
        {

            if (divId == "eps")
            {
                ViewBag.divID = "eps";

                if (modifiedAnswer == correctAnswer)
                {
                    ViewBag.answer = "That is correct!";
                }
                else
                {
                    ViewBag.answer = "Try again";
                }

            }
            else if (divId == "grossProfitMargin")
            {
                ViewBag.divID = "grossProfitMargin";

                if (modifiedAnswer == correctAnswer)
                {
                    ViewBag.answer = "That is correct!";
                }
                else
                {
                    ViewBag.answer = "Try again";
                }
            }
            else if (divId == "operatingProfitMargin")
            {
                ViewBag.divID = "operatingProfitMargin";

                if (modifiedAnswer == correctAnswer)
                {
                    ViewBag.answer = "That is correct!";
                }
                else
                {
                    ViewBag.answer = "Try again";
                }
            }
            else if (divId == "effectiveTaxRate")
            {
                ViewBag.divID = "effectiveTaxRate";

                if (modifiedAnswer == correctAnswer)
                {
                    ViewBag.answer = "That is correct!";
                }
                else
                {
                    ViewBag.answer = "Try again";
                }
            }
            else if (divId == "netProfitMargin")
            {
                ViewBag.divID = "netProfitMargin";

                if (modifiedAnswer == correctAnswer)
                {
                    ViewBag.answer = "That is correct!";
                }
                else
                {
                    ViewBag.answer = "Try again";
                }
            }
            else if (divId == "priceToEarnings")
            {
                ViewBag.divID = "priceToEarnings";

                if (modifiedAnswer == correctAnswer)
                {
                    ViewBag.answer = "That is correct!";
                }
                else
                {
                    ViewBag.answer = "Try again";
                }
            }
            else if (divId == "timesInterestEarned")
            {
                ViewBag.divID = "timesInterestEarned";

                if (modifiedAnswer == correctAnswer)
                {
                    ViewBag.answer = "That is correct!";
                }
                else
                {
                    ViewBag.answer = "Try again";
                }
            }
            else if (divId == "dividendYield")
            {
                ViewBag.divID = "dividendYield";

                if (modifiedAnswer == correctAnswer)
                {
                    ViewBag.answer = "That is correct!";
                }
                else
                {
                    ViewBag.answer = "Try again";
                }
            }

            return ViewBag;
        }


        private static readonly Random random = new Random();

        private static double RandomNumberBetween(double minValue, double maxValue)
        {
            var next = random.NextDouble();

            return minValue + (next * (maxValue - minValue));
        }

    }
}