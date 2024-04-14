﻿using Catalog.API.Models;

namespace Catalog.API.Products.CreateProduct
{
    
        public record CreateProductCommand(
        string Name,
        List<string> Category,
        string Description,
        string ImageFile,
        decimal Price) : ICommand<CreateProductResult>;
        public record CreateProductResult(Guid id);
        internal class CreateProductCommandHandler(IDocumentSession session) : ICommandHandler<CreateProductCommand, CreateProductResult>
        {

            public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
            {
                //create Product entity from command object
                var product = new Product
                {
                    Name = command.Name,
                    Category = command.Category,
                    Description = command.Description,
                    ImageFile = command.ImageFile,
                    Price = command.Price,
                };

                //save db
                session.Store(product);
                await session.SaveChangesAsync(cancellationToken);

                //return  CreateProductResult
                return new CreateProductResult(product.Id);
            }
        }
    }
