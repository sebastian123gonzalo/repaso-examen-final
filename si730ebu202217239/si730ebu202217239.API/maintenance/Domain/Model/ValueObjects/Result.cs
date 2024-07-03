namespace si730ebu202217239.maintenance.Domain.Model.ValueObjects;

public class Result
{
    public Result()
    {
        ActivityResult = 0;
    }

    public Result(int activityResult)
    {
        if (activityResult is < 0 or > 1)
        {
            throw new ArgumentException("Activity result must be 0 or 1");
        }
        ActivityResult = activityResult;
    }
    public int ActivityResult { get; }

     
}