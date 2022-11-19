﻿using System.ComponentModel.Design;
using System.Net;
using Billing_API.Classes;
using Billing_API.Filters;
using Billing_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Billing_API.Controllers;

// https://github.com/oganzins/Task-Billing-API
[ApiController]
[Route("[controller]")]
public class OrderController : ControllerBase
{
    private readonly ILogger _logger;
    private readonly IPaymentGatewayService _gatewayService;

    public OrderController(ILogger<OrderController> logger, IPaymentGatewayService gatewayService)
    {
        _logger = logger;
        _gatewayService = gatewayService;
    }

    /// <exception cref="ArgumentOutOfRangeException"></exception>
    /// <remarks>
    ///  sends the order to an appropriate payment gateway. If the order is processed successfully
    /// by the payment gateway, the billing service creates a receipt and returns it in response.
    /// </remarks>
    /// <response code="200">OK. Indicates that the order is processed.</response>
    /// <response code="500">Error. Indicates processing error.</response>
    /// <returns>All products.</returns>
    [HttpPost]
    [ServiceFilter(typeof(ExampleActionFilter))]
    public IActionResult Place([FromBody] Order order)
    {
        var paymentGateway = _gatewayService.GetPaymentGateway(order.GatewayCode);

        return Ok( paymentGateway.DoPlaceOrder(order));
    }
}
