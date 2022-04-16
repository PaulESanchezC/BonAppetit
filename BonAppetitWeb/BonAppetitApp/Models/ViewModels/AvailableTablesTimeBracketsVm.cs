using Models.TableReservationBracketsModels;

namespace Models.ViewModels;

public class AvailableTablesTimeBracketsVm
{
    public int ForHowMany { get; set; }
    public int ForHowManyTemp { get; set; }
    public DateTime DateOfRequest { get; set; }
    public string DateOfRequestString { get; set; }
    public List<TableReservationBracket> Brackets { get; set; } = new();
    public List<double> AvailableBrackets { get; set; } = new();
    public List<int> SeatsAvailable { get; set; } = new();
}