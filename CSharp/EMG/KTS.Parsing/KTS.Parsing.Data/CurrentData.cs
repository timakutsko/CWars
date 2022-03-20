
namespace KTS.Parsing.Data
{
    ///<summary>
    /// Коллекция данных по позиции из запроса
    ///</summary>
    public sealed class CurrentData
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Difference { get; set; }
        public string Value { get; set; }
        public string Time { get; set; }
    }
}
