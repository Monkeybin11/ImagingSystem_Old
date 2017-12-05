namespace ChipProcessingLib
{
    public interface IConfig
    {
        int AreaDwLimt { get; set; }
        int AreaUpLimt { get; set; }
        double BLX { get; set; }
        double BLY { get; set; }
        double BRX { get; set; }
        double BRY { get; set; }
        int ChipHNum { get; set; }
        int ChipHSize { get; set; }
        int ChipWNum { get; set; }
        int ChipWSize { get; set; }
        int ThrsDwLimt { get; set; }
        int ThrsUpLimt { get; set; }
        double TLX { get; set; }
        double TLY { get; set; }
        double TRX { get; set; }
        double TRY { get; set; }
    }
}