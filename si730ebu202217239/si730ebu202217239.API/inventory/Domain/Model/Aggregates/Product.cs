using System.ComponentModel.DataAnnotations.Schema;
using EntityFrameworkCore.CreatedUpdatedDate.Contracts;
using si730ebu202217239.Inventory.Domain.Model.Commands;
using si730ebu202217239.inventory.Domain.Model.ValueObjects;

namespace si730ebu202217239.inventory.Domain.Model.Aggregates;

public partial class Product 
{
    public int Id { get;  }
    public string Brand { get; private set; }
    public string Model { get; private set; }
    public string SerialNumber { get; private set; }
    public Description StatusDescription { get; private set; }
    public int Status { get; private set; }
    
    public Product()
    {
        //Initializing the properties
        Brand = string.Empty;
        Model = string.Empty;
        SerialNumber = string.Empty;
        StatusDescription = new Description("OPERATIONAL");
        Status = 1;    
    }

    public Product(CreateProductCommand command)
    {
        Brand = command.Brand;
        Model = command.Model;
        SerialNumber = command.SerialNumber;
        StatusDescription = new Description(command.StatusDescription);
        Status = StatusDescription.StatusDescription switch
        {
            "OPERATIONAL" => 1,
            "UNOPERATIONAL" => 2,
        };
    }

    public void UpdateStatus(UpdateProductStatusBySerialNumberCommand command)
    {
        // Activity Result: 0 = UNOPERATIONAL, 1 = OPERATIONAL, Status: 1 = OPERATIONAL, 2 = UNOPERATIONAL
        if(command.Status == 0)
        {
            StatusDescription = new Description("UNOPERATIONAL");
            Status = 2;
        }
        else if(command.Status == 1)
        {
            StatusDescription = new Description("OPERATIONAL");
            Status = 1;
        }
        
    }
    
 
    
}