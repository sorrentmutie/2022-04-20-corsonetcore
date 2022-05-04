namespace BlazorHttpApi.Models;

public class ChartData
{
    public List<string> Labels { get; set; } = new List<string>();
    public List<ChartValues> Series { get; set; } = new List<ChartValues>();
}

public class ChartValues
{
    public List<double> Values { get; set; } = new List<double>();
}
