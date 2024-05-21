﻿
using Basket.API.Basket.GetBasket;
using Basket.API.Basket.Storebasket;

namespace Basket.API.Basket.DeleteBasket;
//public record DeleteBasketRequest(string UserName);
public record DeleteBasketResponse(bool  IsSuccess);

public class DeleteBasketEndpoints : ICarterModule
{
    public  void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/basket/{userName}", async (string userName, ISender sender) =>
        {
            var result = await sender.Send(new DeleteBasketCommand(userName));
            var response = result.Adapt<DeleteBasketResponse>();
            return Results.Ok(response);
        })
        .WithName("DeleteBasket")
        .Produces<GetBasketResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary(" Delete Basket")
        .WithDescription("Delete Basket");
    }
}
