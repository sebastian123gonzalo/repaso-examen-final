using si730ebu202217239.inventory.Domain.Model.Aggregates;
using si730ebu202217239.Inventory.Domain.Model.Commands;
using si730ebu202217239.inventory.Domain.Repositories;
using si730ebu202217239.inventory.Domain.Services;
using si730ebu202217239.Shared.Domain.Repositories;

namespace si730ebu202217239.inventory.Application.Internal.CommandServices;

public class ProductCommandService(IProductRepository productRepository, IUnitOfWork unitOfWork) : IProductCommandService
{
     public async Task<Product?> Handle(CreateProductCommand command)
     {
         var existingProduct = await productRepository.FindBySerialNumberAsync(command.SerialNumber);
         if (existingProduct is not null) throw new Exception("Product with the same number already exists");
         var product = new Product(command);
         try
         {
             await productRepository.AddAsync(product);
             await unitOfWork.CompleteAsync();
             return product;
         }
         catch (Exception e)
         {
             Console.WriteLine(e);
             throw new Exception("An error ocurred while creating product");
         }
     }

     public async Task<Product?> Handle(UpdateProductStatusBySerialNumberCommand command)
     {
         var product = await productRepository.FindBySerialNumberAsync(command.SerialNumber);
         if (product is null) throw new Exception("Product not found");
         product.UpdateStatus(command);

         try
         {
             productRepository.Update(product);
             await unitOfWork.CompleteAsync();
             return product;
         }
         catch (Exception e)
         {
             Console.WriteLine(e);
             throw new Exception(e.Message);
         }
     }
}