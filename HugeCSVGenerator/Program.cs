using System.Globalization;
using System.Text;

int lineCount;

if (args == null || args.FirstOrDefault() == null)
{
    Console.WriteLine("Please inform the maximum lines you want on your .csv files:");
    var input = Console.ReadLine();

    if (input == null)
    {
        return;
    }

    if(!int.TryParse(input, out lineCount))
    {
        Console.WriteLine("Failed to read from user input.");
        return;
    }
}
else
{
    if (!int.TryParse(args[0], out lineCount))
    {
        Console.WriteLine("Failed to read from user arguments.");
        return;
    }
}

string csvFile = $"{DateTime.Now.ToString("ddMMyyyyHHmmss")}.csv";
using StreamWriter outputFile = new StreamWriter(Path.Combine("./", csvFile), true);
outputFile.WriteLine("Guid,String,Int,Long,Float,Double,Decimal,Boolean,String Array,IntArray,FloatArray");

for (int i = 0; i < lineCount; i++)
{
    Guid newGuid = Guid.NewGuid();
    ArrayCreation newArrays = RandomArrays(false, 10);
    DataLineRecord newDataLineRecord = new DataLineRecord(
        newGuid,
        $"Kept you waiting for the generation of this .csv huh?",
        new Random().Next(),
        new Random().NextInt64(Int64.MaxValue),
        new Random().NextSingle() * Single.MaxValue,
        new Random().NextDouble() * Double.MaxValue,
        (decimal)new Random().NextDouble() * Decimal.MaxValue,
        new Random().Next() % 2 == 0 ? true : false,
        newArrays.StringArray,
        newArrays.IntArray,
        newArrays.FloatArray
        );
    outputFile.WriteLine(newDataLineRecord.ToCsv());
}

Console.WriteLine($"File {csvFile} generated.");
return;

static ArrayCreation RandomArrays(bool isRandomSize, int maxSize)
{
    HashSet<string> stringList = new HashSet<string>();
    HashSet<int> intList = new HashSet<int>();
    HashSet<float> floatList = new HashSet<float>();

    for (int i = 0; i < (isRandomSize ? new Random().Next(maxSize) : maxSize); i++ )
    {
        stringList.Add(i.ToString("B"));
        intList.Add(i);
        floatList.Add(i + new Random().NextSingle());
    }

    return new ArrayCreation(stringList.ToArray(), intList.ToArray(), floatList.ToArray());
}

public record ArrayCreation(
        string[] StringArray,
        int[] IntArray,
        float[] FloatArray
    );

public record DataLineRecord(Guid Guid, string String, int Int, long Long, float Float, double Double,
        decimal Decimal, bool Boolean, string[] StringArray, int[] IntArray, float[] FloatArray
    )
{
    public string ToCsv()
    {
        StringBuilder stringBuilder = new StringBuilder();
        string csvSeparator = CultureInfo.CurrentCulture.TextInfo.ListSeparator;

        stringBuilder.Append(Guid.ToString());
        stringBuilder.Append(csvSeparator);
        stringBuilder.Append(String);
        stringBuilder.Append(csvSeparator);
        stringBuilder.Append(Int);
        stringBuilder.Append(csvSeparator);
        stringBuilder.Append(Long);
        stringBuilder.Append(csvSeparator);
        stringBuilder.Append(Float);
        stringBuilder.Append(csvSeparator);
        stringBuilder.Append(Double);
        stringBuilder.Append(csvSeparator);
        stringBuilder.Append(Decimal);
        stringBuilder.Append(csvSeparator);
        stringBuilder.Append(Boolean);
        stringBuilder.Append(csvSeparator);
        stringBuilder.Append($"[{string.Join("; ", StringArray)}]");
        stringBuilder.Append(csvSeparator);
        stringBuilder.Append($"[{string.Join("; ", IntArray)}]");
        stringBuilder.Append(csvSeparator);
        stringBuilder.Append($"[{string.Join("; ", FloatArray)}]");

        return stringBuilder.ToString();
    }
};
