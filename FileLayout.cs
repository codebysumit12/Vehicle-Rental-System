public class FileLayout
{
    public string Header()
    {
        return "ID     | Name         | Type        | Rate/hr     | City        | Status";
    }

    public string Row(string id, string name, string type, string rate, string city, string status)
    {
        return $"{id,-6} | {name,-12} | {type,-10} | {rate,-10} | {city,-10} | {status}";
    }
}
