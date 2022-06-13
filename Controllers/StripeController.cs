using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Stripe.Checkout;

namespace PozoristeProjekat.Controllers
{
    public class StripeController : ControllerBase
    {
        [HttpPost]
        [Route("api/stripe")]
        public ActionResult CreateCheckoutSession(int ukupnaCenaRezervacija)
        {
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
            Console.Write(ukupnaCenaRezervacija);
            var options = new SessionCreateOptions()
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
                CancelUrl = domain + "cancel"
            };

            var service = new SessionService();
            Session session = service.Create(options);

            Response.Headers.Add("Location", session.Url);
            return new StatusCodeResult(303);

    }
    }
}
