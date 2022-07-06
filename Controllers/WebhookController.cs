using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PozoristeProjekat.DTOs.Confirmations;
using PozoristeProjekat.DTOs.Updates;
using PozoristeProjekat.Models;
using PozoristeProjekat.Models.ModelConfirmations;
using PozoristeProjekat.Repositories;
using Stripe;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PozoristeProjekat.Controllers
{
    
   [Route("webhook")]
    public class WebhookController : Controller


    {
        private readonly IRezervacijaRepository rezervacijaRepository;
        private readonly IMapper mapper;
        // This is your Stripe CLI webhook secret for testing your endpoint locally.
        const string endpointSecret = "whsec_06ad6cf45c273f8f1d613009a27b7468d5caf26030d4d2ec7d88a173d8252d9e";

        public WebhookController(IRezervacijaRepository rezervacijaRepository, IMapper mapper)
        {
            this.rezervacijaRepository = rezervacijaRepository;
            this.mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> Index()
        {
            var json = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync();
            try
            {
                var stripeEvent = EventUtility.ConstructEvent(json,
                    Request.Headers["Stripe-Signature"], endpointSecret);

                // Handle the event

                if (stripeEvent.Type == Events.PaymentIntentSucceeded)
                {
                    var paymentIntent = stripeEvent.Data.Object as PaymentIntent;
                    var service = new CustomerService();
                    var customer = service.Get(paymentIntent.CustomerId);
                    Guid id = new Guid(customer.Description);
                    rezervacijaRepository.UpdateRezervacija(id);
                    rezervacijaRepository.SaveChanges();


                    // Then define and call a method to handle the successful payment intent.
            //        handlePaymentIntentSucceeded(paymentIntent);
                }
                else if (stripeEvent.Type == Events.CheckoutSessionCompleted)
                {
                    Console.Write("Gotovo je");
                }
                // ... handle other event types
                else
                {
                    Console.WriteLine("Unhandled event type: {0}", stripeEvent.Type);
                }

                return Ok();
            }
            catch (StripeException e)
            {
                return BadRequest();
            }

        }
        //public ActionResult<RezervacijaConfirmationDTO> UpdateRezervacija(Guid rezervacijaID)
        //{
        //    try
        //    {
        //        if (rezervacijaRepository.GetRezervacijaById(rezervacijaID) == null)
        //        {
        //            return NotFound();
        //        }
        //        Rezervacija rezervacija2 = mapper.Map<Rezervacija>(GetRezervacija(rezervacijaID));
        //        RezervacijaConfirmation confirmation = rezervacijaRepository.UpdateRezervacija(rezervacija2.RezervacijaID);
        //        rezervacijaRepository.SaveChanges();
        //        return Ok(mapper.Map<RezervacijaConfirmation>(confirmation));
        //    }
        //    catch
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, "Update error");
        //    }
        //}

    }
}
