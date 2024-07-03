namespace si730ebu202217239.inventory.Domain.Model.ValueObjects;

public class Description
{
    public string StatusDescription { get;  }

    public Description()
    {
        StatusDescription = string.Empty;
    }

    public Description(String statusDescription)
    {
        if (statusDescription.Equals("OPERATIONAL") || statusDescription.Equals("UNOPERATIONAL"))
        {
            StatusDescription = statusDescription;
        }
        else
        {
            throw new ArgumentException("Invalid status description");
        }
    }

}