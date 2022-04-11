using Models.TableModels;

namespace Models.TableReservationBracketsModels;

public class TableReservationBracket
{
    public Table Table { get; set; }
    public List<TableTimeBracket> TablesTimeBrackets { get; set; } = new();
}