﻿namespace TestPryaniky.Application.Products.Commands.CreateProduct;

public record CreateProductCommand(string Name, string Description, decimal Price) : ICommand<CreateProductResult>;
public record CreateProductResult(Guid Id);