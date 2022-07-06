using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Stripe.Checkout;
using Stripe;

namespace PozoristeProjekat.Controllers
{
    public class StripeController : ControllerBase
    {
        [HttpPost]
        [Route("api/stripe")]
        public ActionResult CreateCheckoutSession(int ukupnaCenaRezervacija, string rezervacijaID, string emailunos)
        {
            //var optionsSearch = new CustomerSearchOptions
            //{
            //    Query = "email:'bs@test.com'",
            //};
            //var serviceSearch = new CustomerService();
            
            //StripeSearchResult<Stripe.Customer> rezultat = serviceSearch.Search(optionsSearch);
            //Console.WriteLine(rezultat);
            //string customerstari = rezultat.FirstOrDefault().Id;
            //Console.WriteLine(customerstari);


//            #region
//            var optionsUpdate = new CustomerUpdateOptions
//            {
//                Description = rezervacijaID,
//            };
//            var serviceUpdate = new CustomerService();
//            serviceUpdate.Update(customerstari, optionsUpdate);
//#endregion
            var options = new CustomerCreateOptions
            {
                Description = rezervacijaID,
            };
            var service2 = new CustomerService();
            Customer customer = service2.Create(options);
            string CustomerID = customer.Id;
            string price = null;
            if (ukupnaCenaRezervacija == 300)
            {
                price = "price_1LA8KyADqdpBkuR80xQEeSQY";
            }
            if (ukupnaCenaRezervacija == 400)
            {
                price = "price_1LAIdiADqdpBkuR86oqTN1w8";
            }
            else if (ukupnaCenaRezervacija == 100)
            {
                price = "price_1LABVZADqdpBkuR8dMarEzlB";
            }
            else if (ukupnaCenaRezervacija == 500)
            {
                price = "price_1LACFMADqdpBkuR8dLUSL9zR";
            }
            else if (ukupnaCenaRezervacija == 600)
            {
                price = "price_1LA8KyADqdpBkuR8Ry3w11uh";
            }
            else if (ukupnaCenaRezervacija == 900)
            {
                price = "price_1LA8KyADqdpBkuR8z3njN9AO";
            }
            else if (ukupnaCenaRezervacija == 1200)
            {
                price = "price_1LA8KyADqdpBkuR8iWGcB71O";
            }
            else if (ukupnaCenaRezervacija == 1500)
            {
                price = "price_1LAB3kADqdpBkuR8ZSKhwtZc";
            }
            var domain = "http://localhost:3000/";
            var options1 = new SessionCreateOptions()
            {
                LineItems = new List<SessionLineItemOptions>()
                {
                    new SessionLineItemOptions()
                    {
                        Price = price,
                        Quantity = 1
                    }
                },
                PaymentMethodTypes = new List<string>()
                {
                    "card"
                },
                Mode = "payment",
                SuccessUrl = domain + "success",
                CancelUrl = domain + "cancel",
                ClientReferenceId = rezervacijaID,
                Customer = CustomerID,
            };

            var service = new SessionService();
            Session session = service.Create(options1);

            Response.Headers.Add("Location", session.Url);
            return new StatusCodeResult(303);

    }
    }
}
